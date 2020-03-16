using System;
using System.Reflection;
using System.Windows.Forms;

namespace DownloaderTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly().GetName();
                var version = assembly.Version.ToString();
                var mutexString = string.Concat(assembly.Name.Trim(), " v", version).Trim();

                var hMutex = new System.Threading.Mutex(true, mutexString, out bool owned);

                if (owned)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new DownloadForm());
                }
                else
                {
                    MessageBox.Show("Application is already running!");

                    return;
                }

                GC.KeepAlive(hMutex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return;
        }
    }
}
