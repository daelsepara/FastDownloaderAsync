using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FastDownloaderAsync
{
    //SEE: https://dejanstojanovic.net/aspnet/2018/march/download-file-in-chunks-in-parallel-in-c/

    public class DownloadResult
    {
        public long Size { get; set; }
        public string FilePath { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public int ParallelDownloads { get; set; }
    }

    public class Range
    {
        public long Start { get; set; }
        public long End { get; set; }
    }
    
    public class FastDownloaderAsync
    {
        public async Task<DownloadResult> DownloadChunks(string fileUrl, string destinationFilePath, int numberOfParallelDownloads = 0, bool validateSSL = false)
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.MaxServicePointIdleTime = 1000;

            if (!validateSSL)
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            }

            var uri = new Uri(fileUrl);

            var result = new DownloadResult() { FilePath = destinationFilePath };

            // Handle number of parallel downloads  
            if (numberOfParallelDownloads <= 0)
            {
                numberOfParallelDownloads = Environment.ProcessorCount;
            }

            #region Get file size  
            
            var webRequest = HttpWebRequest.Create(fileUrl);
            
            webRequest.Method = "HEAD";
            
            var responseLength = 0L;
            
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                responseLength = long.Parse(webResponse.Headers.Get("Content-Length"));
                
                result.Size = responseLength;
            }
            
            #endregion

            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Append))
            {
                var tempFilesDictionary = new ConcurrentDictionary<long, string>();

                #region Calculate ranges

                var readRanges = new List<Range>();

                for (var chunk = 0; chunk < numberOfParallelDownloads - 1; chunk++)
                {
                    var range = new Range()
                    {
                        Start = chunk * (responseLength / numberOfParallelDownloads),
                        End = ((chunk + 1) * (responseLength / numberOfParallelDownloads)) - 1
                    };
                    
                    readRanges.Add(range);
                }

                readRanges.Add(new Range()
                {
                    Start = readRanges.Any() ? readRanges.Last().End + 1 : 0,
                    End = responseLength - 1
                });

                #endregion

                var startTime = DateTime.Now;

                #region Parallel download  

                var index = 0;

                var tasks = new ConcurrentBag<Task>();

                Parallel.ForEach(readRanges, new ParallelOptions() { MaxDegreeOfParallelism = numberOfParallelDownloads }, readRange =>
                {
                    tasks.Add(DownloadStream(fileUrl, readRange, tempFilesDictionary));

                    index++;
                });

                // Download all chunks asynchronously
                await Task.WhenAll(tasks);

                result.ParallelDownloads = index;

                #endregion

                #region Merge to single file  
                
                foreach (var tempFile in tempFilesDictionary.OrderBy(b => b.Key))
                {
                    var tempFileBytes = File.ReadAllBytes(tempFile.Value);
                    
                    destinationStream.Write(tempFileBytes, 0, tempFileBytes.Length);
                    
                    if (File.Exists(tempFile.Value))
                        File.Delete(tempFile.Value);
                }
                
                #endregion

                result.TimeTaken = DateTime.Now.Subtract(startTime);

                return result;
            }
        }

        private async Task DownloadStream(string fileUrl, Range readRange, ConcurrentDictionary<long, string> tempFilesDictionary)
        {
            var httpWebRequest = HttpWebRequest.Create(fileUrl) as HttpWebRequest;
            
            httpWebRequest.Method = "GET";
            httpWebRequest.AddRange(readRange.Start, readRange.End);

            var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

            var tempFilePath = Path.GetTempFileName();

            using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                tempFilesDictionary.TryAdd(readRange.Start, tempFilePath);

                await httpWebResponse.GetResponseStream().CopyToAsync(fileStream);
            }
        }
    }
}
