using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;

namespace eDoc_Operations
{
    public partial class frmFileFolderSelection : Form
    {
        [System.Runtime.InteropServices.DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hwnd, string appname, string idlist);

        protected System.Collections.Specialized.StringCollection m_Logger = new System.Collections.Specialized.StringCollection();
        protected System.Collections.Specialized.StringCollection m_LoggerErr = new System.Collections.Specialized.StringCollection();

        private delegate void VoidDelegate(int state, String strFileName);

        public frmFileFolderSelection()
        {
            InitializeComponent();
            this.PrepareControls4Start();

            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // the code here will be executed if the user presses Open in
                // the dialog.
                txtSelectedFileFolder.Text = folderBrowserDialog1.SelectedPath;

                String foldername = this.folderBrowserDialog1.SelectedPath;
                foreach (String f in Directory.GetFiles(foldername))
                    this.lstbSelectedFiles.Items.Add(f);    
            }
        }

        private void btnAdd2eDoc_Click(object sender, EventArgs e)
        {
            //dualProgressBar1.MarqueeStart();
            dualProgressBar2.MarqueeStart();
            timer1.Enabled = true;

            this.btnAdd2eDoc.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            this.bwAdd2eDoc.RunWorkerAsync();
            Cursor.Current = Cursors.Default;

            //System.IO.DirectoryInfo diSelPath = new DirectoryInfo(txtSelectedFileFolder.Text);

            //WalkDirectoryTreeRecursive(diSelPath);

            //foreach (String strLogMsg in m_LoggerErr)
            //{
            //    MessageBox.Show(strLogMsg);
            //}
        }

        private void WalkDirectoryTreeRecursive(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[]      files   = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                m_LoggerErr.Add(e.Message);
                MessageBox.Show("UnauthorizedAccessException Error occurred: \n" + e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("DirectoryNotFoundException Error occurred: \n" + e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    Console.WriteLine(fi.FullName);
                    m_Logger.Add(fi.FullName);

                    try
                    {
                        this.SetLabelState(1, fi.FullName);
                        System.Threading.Thread.Sleep(100);
                        FileOperations.UploadFile(fi.FullName);

                        //ThreadStart threadStart = new ThreadStart(MyWorkerThreadMethod);
                        //Thread threadObj = new Thread(threadStart);

                        //Thread threadObj = new Thread(new ThreadStart(MyWorkerThreadMethod));

                        ////System.Diagnostics.Process.Start(@"C:\\Develop\\Samples\\FILESTREAM\\1489_MSSQLTip_SQL2008_FILESTREAM_SampleCode\\BLOB\\bin\\Release\\BLOB.exe", "put " + fi.FullName);
                        //System.Diagnostics.ProcessStartInfo pInfo = new System.Diagnostics.ProcessStartInfo("C:\\Develop\\Samples\\FILESTREAM\\1489_MSSQLTip_SQL2008_FILESTREAM_SampleCode\\BLOB\\bin\\Release\\BLOB.exe", "put '" + fi.FullName + "'");
                        //pInfo.RedirectStandardOutput = false;
                        //pInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        //pInfo.UseShellExecute = true;

                        //System.Diagnostics.Process listFiles;
                        //listFiles = System.Diagnostics.Process.Start(pInfo);
                        //listFiles.WaitForExit(2000);
                        ////if (listFiles.HasExited)
                        ////{
                        ////    String processResults = processOutput.ReadToEnd();
                        ////}
                    }
                    catch (Exception objException)
                    {
                        // Log the exception
                        MessageBox.Show(objException.Message);
                    }
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTreeRecursive(dirInfo);
                }
            }
        }

        private void MyWorkerThreadMethod(String strFullName)
        {   // This is the Thread
            FileOperations.UploadFile(strFullName);
        }

        private void bwAdd2eDoc_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending)
            {
                // cancel was initiated -> leave loop
                e.Cancel = true;
            }
            //this.SetLabelState(i);
            //worker.ReportProgress(i);
            System.Threading.Thread.Sleep(100);

            System.IO.DirectoryInfo diSelPath = new DirectoryInfo(txtSelectedFileFolder.Text);

            WalkDirectoryTreeRecursive(diSelPath);

            foreach (String strLogMsg in m_LoggerErr)
            {
                MessageBox.Show(strLogMsg);
            }

            e.Result = "READY";

            //for (int i = 0; i < 100; i++)
            //{
            //    if (worker.CancellationPending)
            //    {
            //        // cancel was initiated -> leave loop
            //        e.Cancel = true;
            //        break;
            //    }
            //    this.SetLabelState(i);
            //    worker.ReportProgress(i);
            //    System.Threading.Thread.Sleep(100);
            //}
            //e.Result = "READY";
        }

        private void bwAdd2eDoc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void bwAdd2eDoc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.PrepareControls4Start();
            timer1.Enabled = false;
            this.dualProgressBar2.Value = 0;
            this.dualProgressBar2.MasterValue = 0;
            this.dualProgressBar2.MarqueeStop();
            if (e.Cancelled)
                this.lblCurrentFile.Text = "State: ABORT";
            else
                this.lblCurrentFile.Text = "State: " + e.Result.ToString();
        }

        private void SetLabelState(int state, String strFileName)
        {
            this.btnAdd2eDoc.Enabled = false;
            if (this.lblCurrentFile.InvokeRequired)
                this.lblCurrentFile.Invoke(new VoidDelegate(this.SetLabelState), state, strFileName);
            else
                this.lblCurrentFile.Text = "Adding file " + strFileName + ".....";
        }

        private void PrepareControls4Start()
        {
            this.btnAdd2eDoc.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r2 = new Random(DateTime.Now.Millisecond);
            int newval2 = dualProgressBar2.MasterValue + r2.Next(0, 10);
            if (newval2 > dualProgressBar2.MasterMaximum)
            {
                dualProgressBar2.MasterValue = 0;
            }
            else
            {
                dualProgressBar2.MasterValue = newval2;
            }
        }
    }
}
