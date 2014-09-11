namespace eDoc_Operations
{
    partial class frmFileFolderSelection
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
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSelectedFileFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd2eDoc = new System.Windows.Forms.Button();
            this.lstbSelectedFiles = new System.Windows.Forms.ListBox();
            this.bwAdd2eDoc = new System.ComponentModel.BackgroundWorker();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plainBackgroundPainter1 = new ProgressODoom.PlainBackgroundPainter();
            this.plainBorderPainter1 = new ProgressODoom.PlainBorderPainter();
            this.plainProgressPainter2 = new ProgressODoom.PlainProgressPainter();
            this.plainProgressPainter1 = new ProgressODoom.PlainProgressPainter();
            this.plainBackgroundPainter2 = new ProgressODoom.PlainBackgroundPainter();
            this.dualProgressBar2 = new ProgressODoom.DualProgressBar();
            this.SuspendLayout();
            // 
            // txtSelectedFileFolder
            // 
            this.txtSelectedFileFolder.Location = new System.Drawing.Point(22, 41);
            this.txtSelectedFileFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtSelectedFileFolder.Name = "txtSelectedFileFolder";
            this.txtSelectedFileFolder.Size = new System.Drawing.Size(638, 23);
            this.txtSelectedFileFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Επιλεγμένος Φάκελος:";
            // 
            // btnAdd2eDoc
            // 
            this.btnAdd2eDoc.Location = new System.Drawing.Point(260, 380);
            this.btnAdd2eDoc.Name = "btnAdd2eDoc";
            this.btnAdd2eDoc.Size = new System.Drawing.Size(159, 23);
            this.btnAdd2eDoc.TabIndex = 2;
            this.btnAdd2eDoc.Text = "Προσθήκη στο eDoc";
            this.btnAdd2eDoc.UseVisualStyleBackColor = true;
            this.btnAdd2eDoc.Click += new System.EventHandler(this.btnAdd2eDoc_Click);
            // 
            // lstbSelectedFiles
            // 
            this.lstbSelectedFiles.FormattingEnabled = true;
            this.lstbSelectedFiles.ItemHeight = 16;
            this.lstbSelectedFiles.Location = new System.Drawing.Point(22, 69);
            this.lstbSelectedFiles.Name = "lstbSelectedFiles";
            this.lstbSelectedFiles.Size = new System.Drawing.Size(638, 308);
            this.lstbSelectedFiles.TabIndex = 3;
            // 
            // bwAdd2eDoc
            // 
            this.bwAdd2eDoc.WorkerReportsProgress = true;
            this.bwAdd2eDoc.WorkerSupportsCancellation = true;
            this.bwAdd2eDoc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwAdd2eDoc_DoWork);
            this.bwAdd2eDoc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwAdd2eDoc_ProgressChanged);
            this.bwAdd2eDoc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwAdd2eDoc_RunWorkerCompleted);
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblCurrentFile.ForeColor = System.Drawing.Color.Maroon;
            this.lblCurrentFile.Location = new System.Drawing.Point(11, 404);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(658, 113);
            this.lblCurrentFile.TabIndex = 5;
            this.lblCurrentFile.Text = "lblCurrentFile";
            this.lblCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // plainBackgroundPainter1
            // 
            this.plainBackgroundPainter1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.plainBackgroundPainter1.GlossPainter = null;
            // 
            // plainBorderPainter1
            // 
            this.plainBorderPainter1.Color = System.Drawing.Color.DarkGray;
            this.plainBorderPainter1.RoundedCorners = true;
            this.plainBorderPainter1.Style = ProgressODoom.PlainBorderPainter.PlainBorderStyle.Flat;
            // 
            // plainProgressPainter2
            // 
            this.plainProgressPainter2.Color = System.Drawing.Color.SteelBlue;
            this.plainProgressPainter2.GlossPainter = null;
            this.plainProgressPainter2.LeadingEdge = System.Drawing.Color.Transparent;
            this.plainProgressPainter2.ProgressBorderPainter = null;
            // 
            // plainProgressPainter1
            // 
            this.plainProgressPainter1.Color = System.Drawing.Color.LightSkyBlue;
            this.plainProgressPainter1.GlossPainter = null;
            this.plainProgressPainter1.LeadingEdge = System.Drawing.Color.Transparent;
            this.plainProgressPainter1.ProgressBorderPainter = this.plainBorderPainter1;
            // 
            // plainBackgroundPainter2
            // 
            this.plainBackgroundPainter2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.plainBackgroundPainter2.GlossPainter = null;
            // 
            // dualProgressBar2
            // 
            this.dualProgressBar2.BackColor = System.Drawing.SystemColors.Control;
            this.dualProgressBar2.BackgroundPainter = this.plainBackgroundPainter1;
            this.dualProgressBar2.BorderPainter = this.plainBorderPainter1;
            this.dualProgressBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dualProgressBar2.Location = new System.Drawing.Point(0, 520);
            this.dualProgressBar2.MarqueePercentage = 25;
            this.dualProgressBar2.MarqueeSpeed = 10;
            this.dualProgressBar2.MarqueeStep = 2;
            this.dualProgressBar2.MasterMaximum = 100;
            this.dualProgressBar2.MasterPainter = this.plainProgressPainter2;
            this.dualProgressBar2.MasterProgressPadding = 0;
            this.dualProgressBar2.MasterValue = 0;
            this.dualProgressBar2.Maximum = 100;
            this.dualProgressBar2.Minimum = 0;
            this.dualProgressBar2.Name = "dualProgressBar2";
            this.dualProgressBar2.PaintMasterFirst = true;
            this.dualProgressBar2.ProgressPadding = 2;
            this.dualProgressBar2.ProgressPainter = this.plainProgressPainter1;
            this.dualProgressBar2.ProgressType = ProgressODoom.ProgressType.MarqueeBounce;
            this.dualProgressBar2.ShowPercentage = false;
            this.dualProgressBar2.Size = new System.Drawing.Size(682, 18);
            this.dualProgressBar2.TabIndex = 0;
            this.dualProgressBar2.Value = 0;
            // 
            // frmFileFolderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(682, 538);
            this.Controls.Add(this.dualProgressBar2);
            this.Controls.Add(this.lblCurrentFile);
            this.Controls.Add(this.lstbSelectedFiles);
            this.Controls.Add(this.btnAdd2eDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSelectedFileFolder);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileFolderSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFileFolderSelection";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSelectedFileFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd2eDoc;
        private System.Windows.Forms.ListBox lstbSelectedFiles;
        private System.ComponentModel.BackgroundWorker bwAdd2eDoc;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Timer timer1;
        private ProgressODoom.PlainBackgroundPainter plainBackgroundPainter1;
        private ProgressODoom.PlainBorderPainter plainBorderPainter1;
        private ProgressODoom.PlainProgressPainter plainProgressPainter1;
        private ProgressODoom.PlainProgressPainter plainProgressPainter2;
        private ProgressODoom.PlainBackgroundPainter plainBackgroundPainter2;
        private ProgressODoom.DualProgressBar dualProgressBar2;
    }
}