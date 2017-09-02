﻿namespace HitechTMS.File
{
    partial class frmPendingFile
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
            this.grpboxPendingFile = new System.Windows.Forms.GroupBox();
            this.btnEmailAsExcel = new System.Windows.Forms.Button();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.chkCompleteFile = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gridPendingFile = new System.Windows.Forms.DataGridView();
            this.rdbMultiWeight = new System.Windows.Forms.RadioButton();
            this.rdbPublicWeight = new System.Windows.Forms.RadioButton();
            this.rdbNormalWeight = new System.Windows.Forms.RadioButton();
            this.bgWorkerProcessor = new System.ComponentModel.BackgroundWorker();
            this.grpboxPendingFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingFile)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxPendingFile
            // 
            this.grpboxPendingFile.Controls.Add(this.btnEmailAsExcel);
            this.grpboxPendingFile.Controls.Add(this.lblRecCount);
            this.grpboxPendingFile.Controls.Add(this.lblRecordsCount);
            this.grpboxPendingFile.Controls.Add(this.chkCompleteFile);
            this.grpboxPendingFile.Controls.Add(this.btnPrint);
            this.grpboxPendingFile.Controls.Add(this.gridPendingFile);
            this.grpboxPendingFile.Controls.Add(this.rdbMultiWeight);
            this.grpboxPendingFile.Controls.Add(this.rdbPublicWeight);
            this.grpboxPendingFile.Controls.Add(this.rdbNormalWeight);
            this.grpboxPendingFile.Location = new System.Drawing.Point(12, 12);
            this.grpboxPendingFile.Name = "grpboxPendingFile";
            this.grpboxPendingFile.Size = new System.Drawing.Size(1228, 699);
            this.grpboxPendingFile.TabIndex = 0;
            this.grpboxPendingFile.TabStop = false;
            this.grpboxPendingFile.Text = "Pending File";
            // 
            // btnEmailAsExcel
            // 
            this.btnEmailAsExcel.Location = new System.Drawing.Point(158, 637);
            this.btnEmailAsExcel.Name = "btnEmailAsExcel";
            this.btnEmailAsExcel.Size = new System.Drawing.Size(121, 56);
            this.btnEmailAsExcel.TabIndex = 29;
            this.btnEmailAsExcel.Text = "&Email as Excel";
            this.btnEmailAsExcel.UseVisualStyleBackColor = true;
            this.btnEmailAsExcel.Click += new System.EventHandler(this.btnEmailAsExcel_Click);
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.Location = new System.Drawing.Point(989, 637);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(136, 22);
            this.lblRecCount.TabIndex = 28;
            this.lblRecCount.Text = "Records Count";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecordsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(1145, 637);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(60, 22);
            this.lblRecordsCount.TabIndex = 27;
            this.lblRecordsCount.Text = "Count";
            // 
            // chkCompleteFile
            // 
            this.chkCompleteFile.AutoSize = true;
            this.chkCompleteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompleteFile.Location = new System.Drawing.Point(18, 42);
            this.chkCompleteFile.Name = "chkCompleteFile";
            this.chkCompleteFile.Size = new System.Drawing.Size(157, 24);
            this.chkCompleteFile.TabIndex = 5;
            this.chkCompleteFile.Text = "Complete Files";
            this.chkCompleteFile.UseVisualStyleBackColor = true;
            this.chkCompleteFile.CheckedChanged += new System.EventHandler(this.chkCompleteFile_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(18, 637);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(121, 56);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gridPendingFile
            // 
            this.gridPendingFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPendingFile.Location = new System.Drawing.Point(18, 100);
            this.gridPendingFile.Name = "gridPendingFile";
            this.gridPendingFile.RowTemplate.Height = 24;
            this.gridPendingFile.Size = new System.Drawing.Size(1187, 516);
            this.gridPendingFile.TabIndex = 3;
            // 
            // rdbMultiWeight
            // 
            this.rdbMultiWeight.AutoSize = true;
            this.rdbMultiWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMultiWeight.Location = new System.Drawing.Point(745, 42);
            this.rdbMultiWeight.Name = "rdbMultiWeight";
            this.rdbMultiWeight.Size = new System.Drawing.Size(149, 24);
            this.rdbMultiWeight.TabIndex = 2;
            this.rdbMultiWeight.TabStop = true;
            this.rdbMultiWeight.Text = "&Multi Weghing";
            this.rdbMultiWeight.UseVisualStyleBackColor = true;
            this.rdbMultiWeight.CheckedChanged += new System.EventHandler(this.rdbMultiWeight_CheckedChanged);
            // 
            // rdbPublicWeight
            // 
            this.rdbPublicWeight.AutoSize = true;
            this.rdbPublicWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPublicWeight.Location = new System.Drawing.Point(525, 42);
            this.rdbPublicWeight.Name = "rdbPublicWeight";
            this.rdbPublicWeight.Size = new System.Drawing.Size(160, 24);
            this.rdbPublicWeight.TabIndex = 1;
            this.rdbPublicWeight.TabStop = true;
            this.rdbPublicWeight.Text = "&Public Weghing";
            this.rdbPublicWeight.UseVisualStyleBackColor = true;
            this.rdbPublicWeight.CheckedChanged += new System.EventHandler(this.rdbPublicWeight_CheckedChanged);
            // 
            // rdbNormalWeight
            // 
            this.rdbNormalWeight.AutoSize = true;
            this.rdbNormalWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNormalWeight.Location = new System.Drawing.Point(290, 42);
            this.rdbNormalWeight.Name = "rdbNormalWeight";
            this.rdbNormalWeight.Size = new System.Drawing.Size(168, 24);
            this.rdbNormalWeight.TabIndex = 0;
            this.rdbNormalWeight.TabStop = true;
            this.rdbNormalWeight.Text = "&Normal Weghing";
            this.rdbNormalWeight.UseVisualStyleBackColor = true;
            this.rdbNormalWeight.CheckedChanged += new System.EventHandler(this.rdbNormalWeight_CheckedChanged);
            // 
            // bgWorkerProcessor
            // 
            this.bgWorkerProcessor.WorkerReportsProgress = true;
            this.bgWorkerProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerProcessor_DoWork);
            this.bgWorkerProcessor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerProcessor_ProgressChanged);
            this.bgWorkerProcessor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerProcessor_RunWorkerCompleted);
            // 
            // frmPendingFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 723);
            this.Controls.Add(this.grpboxPendingFile);
            this.Name = "frmPendingFile";
            this.Text = "frmPendingFile";
            this.grpboxPendingFile.ResumeLayout(false);
            this.grpboxPendingFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxPendingFile;
        private System.Windows.Forms.RadioButton rdbMultiWeight;
        private System.Windows.Forms.RadioButton rdbPublicWeight;
        private System.Windows.Forms.RadioButton rdbNormalWeight;
        private System.Windows.Forms.DataGridView gridPendingFile;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkCompleteFile;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnEmailAsExcel;
        private System.ComponentModel.BackgroundWorker bgWorkerProcessor;
    }
}