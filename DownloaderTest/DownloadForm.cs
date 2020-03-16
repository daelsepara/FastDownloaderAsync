using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DownloaderTest
{
    public partial class DownloadForm : Form
    {
        FolderBrowserDialog folderBrowserDialog;
        bool InsideControls = false;
        bool SelectMode = true;
        string DownloadFolder = string.Empty;

        public DownloadForm()
        {
            InitializeComponent();

            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Downloads");

            DestinationPath.ReadOnly = true;
            DestinationPath.Text = folderBrowserDialog.SelectedPath;

            DownloadFolder = DestinationPath.Text;

            if (!Directory.Exists(DownloadFolder))
                Directory.CreateDirectory(DownloadFolder);
        }

        private void SetControlsStatus(bool status)
        {
            FileListBox.Enabled = status;
            SelectButton.Enabled = status;
            RemoveButton.Enabled = status;
            ClearButton.Enabled = status;
            DownloadButton.Enabled = status;
            FileURL.Enabled = status;
            DestinationPath.Enabled = status;
            BrowseButton.Enabled = status;
            AddURLButton.Enabled = status;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                DestinationPath.Text = folderBrowserDialog.SelectedPath.Trim();
                DownloadFolder = DestinationPath.Text;
            }
        }

        private void AddURLButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileURL.Text))
            {
                bool result = Uri.TryCreate(FileURL.Text, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (result && !FileListBox.Items.Contains(FileURL.Text))
                    FileListBox.Items.Add(FileURL.Text);
            }
        }

        private void ApplySelectMode()
        {
            if (FileListBox.Items.Count > 0)
            {
                for (var index = 0; index < FileListBox.Items.Count; index++)
                {
                    FileListBox.SetItemChecked(index, SelectMode);
                }

                SelectMode = !SelectMode;
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            ApplySelectMode();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (FileListBox.Items.Count > 0)
            {
                var newList = new List<string>();

                for (var index = 0; index < FileListBox.Items.Count; index++)
                {
                    if (!FileListBox.GetItemChecked(index))
                        newList.Add(FileListBox.Items[index].ToString());
                }

                FileListBox.Items.Clear();

                foreach(var item in newList)
                {
                    FileListBox.Items.Add(item);
                }

                if (FileListBox.Items.Count > 0)
                {
                    SelectMode = !SelectMode;
                }
                else
                {
                    SelectMode = true;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            FileListBox.Items.Clear();
            
            SelectMode = true;
        }

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            if (!InsideControls)
            {
                InsideControls = true;
                SetControlsStatus(false);

                if (FileListBox.CheckedItems.Count > 0)
                {
                    var downloadList = new List<string>();

                    for (var index = 0; index < FileListBox.CheckedItems.Count; index++)
                    {
                        downloadList.Add(FileListBox.CheckedItems[index].ToString());
                    }

                    if (Directory.Exists(DownloadFolder))
                    {
                        var downloader = new FastDownloaderAsync.FastDownloaderAsync();

                        await downloader.DownloadFiles(downloadList, DownloadFolder, 4, 4, false);
                    }
                }

                SetControlsStatus(true);
                InsideControls = false;
            }
        }
    }
}
