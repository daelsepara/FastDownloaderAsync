namespace DownloaderTest
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileListBox = new System.Windows.Forms.CheckedListBox();
            this.DownloadListLabel = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.FileURL = new System.Windows.Forms.TextBox();
            this.AddURLButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.DestinationPath = new System.Windows.Forms.TextBox();
            this.DestinationPathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileListBox
            // 
            this.FileListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.Location = new System.Drawing.Point(20, 50);
            this.FileListBox.MaximumSize = new System.Drawing.Size(745, 380);
            this.FileListBox.MinimumSize = new System.Drawing.Size(745, 200);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(745, 379);
            this.FileListBox.TabIndex = 0;
            // 
            // DownloadListLabel
            // 
            this.DownloadListLabel.AutoSize = true;
            this.DownloadListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadListLabel.Location = new System.Drawing.Point(20, 30);
            this.DownloadListLabel.Name = "DownloadListLabel";
            this.DownloadListLabel.Size = new System.Drawing.Size(105, 16);
            this.DownloadListLabel.TabIndex = 1;
            this.DownloadListLabel.Text = "Download List";
            // 
            // SelectButton
            // 
            this.SelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectButton.Location = new System.Drawing.Point(20, 435);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(180, 25);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Select/Deselect All";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(210, 435);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(180, 25);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove Selected";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(400, 435);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(180, 25);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear List";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(590, 435);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(180, 25);
            this.DownloadButton.TabIndex = 5;
            this.DownloadButton.Text = "Download Selected";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // FileURL
            // 
            this.FileURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileURL.Location = new System.Drawing.Point(20, 472);
            this.FileURL.Name = "FileURL";
            this.FileURL.Size = new System.Drawing.Size(560, 22);
            this.FileURL.TabIndex = 6;
            // 
            // AddURLButton
            // 
            this.AddURLButton.Location = new System.Drawing.Point(590, 470);
            this.AddURLButton.Name = "AddURLButton";
            this.AddURLButton.Size = new System.Drawing.Size(180, 25);
            this.AddURLButton.TabIndex = 7;
            this.AddURLButton.Text = "Add URL";
            this.AddURLButton.UseVisualStyleBackColor = true;
            this.AddURLButton.Click += new System.EventHandler(this.AddURLButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(590, 525);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(180, 25);
            this.BrowseButton.TabIndex = 8;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DestinationPath
            // 
            this.DestinationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationPath.Location = new System.Drawing.Point(20, 527);
            this.DestinationPath.Name = "DestinationPath";
            this.DestinationPath.Size = new System.Drawing.Size(560, 22);
            this.DestinationPath.TabIndex = 9;
            // 
            // DestinationPathLabel
            // 
            this.DestinationPathLabel.AutoSize = true;
            this.DestinationPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationPathLabel.Location = new System.Drawing.Point(20, 510);
            this.DestinationPathLabel.Name = "DestinationPathLabel";
            this.DestinationPathLabel.Size = new System.Drawing.Size(86, 16);
            this.DestinationPathLabel.TabIndex = 10;
            this.DestinationPathLabel.Text = "Destination";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DestinationPathLabel);
            this.Controls.Add(this.DestinationPath);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.AddURLButton);
            this.Controls.Add(this.FileURL);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.DownloadListLabel);
            this.Controls.Add(this.FileListBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FastDownloaderAsync Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox FileListBox;
        private System.Windows.Forms.Label DownloadListLabel;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.TextBox FileURL;
        private System.Windows.Forms.Button AddURLButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox DestinationPath;
        private System.Windows.Forms.Label DestinationPathLabel;
    }
}

