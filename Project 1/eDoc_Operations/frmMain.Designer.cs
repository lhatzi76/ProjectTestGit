namespace eDoc_Operations
{
    partial class frmMain
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
            this.btnAddFilesFolders = new System.Windows.Forms.Button();
            this.grpbxOperation = new System.Windows.Forms.GroupBox();
            this.btnFileMetaData = new System.Windows.Forms.Button();
            this.grpbxOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddFilesFolders
            // 
            this.btnAddFilesFolders.BackColor = System.Drawing.SystemColors.Info;
            this.btnAddFilesFolders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddFilesFolders.FlatAppearance.BorderSize = 2;
            this.btnAddFilesFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnAddFilesFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnAddFilesFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFilesFolders.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAddFilesFolders.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddFilesFolders.Location = new System.Drawing.Point(54, 41);
            this.btnAddFilesFolders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddFilesFolders.Name = "btnAddFilesFolders";
            this.btnAddFilesFolders.Size = new System.Drawing.Size(235, 44);
            this.btnAddFilesFolders.TabIndex = 1;
            this.btnAddFilesFolders.Text = "Προσθήκη Αρχείων/Φακέλων";
            this.btnAddFilesFolders.UseVisualStyleBackColor = false;
            this.btnAddFilesFolders.Click += new System.EventHandler(this.btnAddFilesFolders_Click);
            // 
            // grpbxOperation
            // 
            this.grpbxOperation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpbxOperation.Controls.Add(this.btnFileMetaData);
            this.grpbxOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxOperation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.grpbxOperation.ForeColor = System.Drawing.SystemColors.Info;
            this.grpbxOperation.Location = new System.Drawing.Point(0, 0);
            this.grpbxOperation.Name = "grpbxOperation";
            this.grpbxOperation.Size = new System.Drawing.Size(587, 127);
            this.grpbxOperation.TabIndex = 3;
            this.grpbxOperation.TabStop = false;
            this.grpbxOperation.Text = "Επιλέξτε διαδικασία κάνοντας κλικ στα κουμπιά παρακάτω:";
            // 
            // btnFileMetaData
            // 
            this.btnFileMetaData.BackColor = System.Drawing.SystemColors.Info;
            this.btnFileMetaData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFileMetaData.FlatAppearance.BorderSize = 2;
            this.btnFileMetaData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnFileMetaData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnFileMetaData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileMetaData.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnFileMetaData.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnFileMetaData.Location = new System.Drawing.Point(297, 41);
            this.btnFileMetaData.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileMetaData.Name = "btnFileMetaData";
            this.btnFileMetaData.Size = new System.Drawing.Size(235, 44);
            this.btnFileMetaData.TabIndex = 4;
            this.btnFileMetaData.Text = "Meta Data Αρχείου";
            this.btnFileMetaData.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 127);
            this.Controls.Add(this.btnAddFilesFolders);
            this.Controls.Add(this.grpbxOperation);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpbxOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFilesFolders;
        private System.Windows.Forms.GroupBox grpbxOperation;
        private System.Windows.Forms.Button btnFileMetaData;
    }
}

