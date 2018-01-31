namespace HitechTMS.File
{
    partial class frmTransactionForm
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
            this.grpboxTransactionForm = new System.Windows.Forms.GroupBox();
            this.grpBoxFileType = new System.Windows.Forms.GroupBox();
            this.rdbPendingFile = new System.Windows.Forms.RadioButton();
            this.rdbCompleteFile = new System.Windows.Forms.RadioButton();
            this.btnSearchRecords = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtPicketToDate = new System.Windows.Forms.DateTimePicker();
            this.dtPicketFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEmailAsExcel = new System.Windows.Forms.Button();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.chkCompleteFile = new System.Windows.Forms.CheckBox();
            this.gridPendingFile = new System.Windows.Forms.DataGridView();
            this.rdbMultiWeight = new System.Windows.Forms.RadioButton();
            this.rdbPublicWeight = new System.Windows.Forms.RadioButton();
            this.rdbNormalWeight = new System.Windows.Forms.RadioButton();
            this.bgWorkerProcessor = new System.ComponentModel.BackgroundWorker();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpboxTransactionForm.SuspendLayout();
            this.grpBoxFileType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxTransactionForm
            // 
            this.grpboxTransactionForm.Controls.Add(this.grpBoxFileType);
            this.grpboxTransactionForm.Controls.Add(this.btnSearchRecords);
            this.grpboxTransactionForm.Controls.Add(this.lblDateTo);
            this.grpboxTransactionForm.Controls.Add(this.lblDateFrom);
            this.grpboxTransactionForm.Controls.Add(this.dtPicketToDate);
            this.grpboxTransactionForm.Controls.Add(this.dtPicketFromDate);
            this.grpboxTransactionForm.Controls.Add(this.btnPrint);
            this.grpboxTransactionForm.Controls.Add(this.btnDelete);
            this.grpboxTransactionForm.Controls.Add(this.btnExit);
            this.grpboxTransactionForm.Controls.Add(this.btnEmailAsExcel);
            this.grpboxTransactionForm.Controls.Add(this.lblRecCount);
            this.grpboxTransactionForm.Controls.Add(this.lblRecordsCount);
            this.grpboxTransactionForm.Controls.Add(this.chkCompleteFile);
            this.grpboxTransactionForm.Controls.Add(this.gridPendingFile);
            this.grpboxTransactionForm.Controls.Add(this.rdbMultiWeight);
            this.grpboxTransactionForm.Controls.Add(this.rdbPublicWeight);
            this.grpboxTransactionForm.Controls.Add(this.rdbNormalWeight);
            this.grpboxTransactionForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxTransactionForm.Location = new System.Drawing.Point(12, 12);
            this.grpboxTransactionForm.Name = "grpboxTransactionForm";
            this.grpboxTransactionForm.Size = new System.Drawing.Size(1283, 759);
            this.grpboxTransactionForm.TabIndex = 0;
            this.grpboxTransactionForm.TabStop = false;
            this.grpboxTransactionForm.Text = "Transaction Files";
            // 
            // grpBoxFileType
            // 
            this.grpBoxFileType.Controls.Add(this.rdbPendingFile);
            this.grpBoxFileType.Controls.Add(this.rdbCompleteFile);
            this.grpBoxFileType.Location = new System.Drawing.Point(282, 11);
            this.grpBoxFileType.Name = "grpBoxFileType";
            this.grpBoxFileType.Size = new System.Drawing.Size(200, 100);
            this.grpBoxFileType.TabIndex = 40;
            this.grpBoxFileType.TabStop = false;
            // 
            // rdbPendingFile
            // 
            this.rdbPendingFile.AutoSize = true;
            this.rdbPendingFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPendingFile.Location = new System.Drawing.Point(6, 26);
            this.rdbPendingFile.Name = "rdbPendingFile";
            this.rdbPendingFile.Size = new System.Drawing.Size(134, 24);
            this.rdbPendingFile.TabIndex = 39;
            this.rdbPendingFile.TabStop = true;
            this.rdbPendingFile.Text = "Pending File";
            this.rdbPendingFile.UseVisualStyleBackColor = true;
            this.rdbPendingFile.CheckedChanged += new System.EventHandler(this.rdbPendingFile_CheckedChanged);
            // 
            // rdbCompleteFile
            // 
            this.rdbCompleteFile.AutoSize = true;
            this.rdbCompleteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCompleteFile.Location = new System.Drawing.Point(6, 64);
            this.rdbCompleteFile.Name = "rdbCompleteFile";
            this.rdbCompleteFile.Size = new System.Drawing.Size(146, 24);
            this.rdbCompleteFile.TabIndex = 38;
            this.rdbCompleteFile.TabStop = true;
            this.rdbCompleteFile.Text = "Complete File";
            this.rdbCompleteFile.UseVisualStyleBackColor = true;
            this.rdbCompleteFile.CheckedChanged += new System.EventHandler(this.rdbCompleteFile_CheckedChanged);
            // 
            // btnSearchRecords
            // 
            this.btnSearchRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearchRecords.Location = new System.Drawing.Point(819, 17);
            this.btnSearchRecords.Name = "btnSearchRecords";
            this.btnSearchRecords.Size = new System.Drawing.Size(134, 50);
            this.btnSearchRecords.TabIndex = 37;
            this.btnSearchRecords.Text = "&Search";
            this.btnSearchRecords.UseVisualStyleBackColor = true;
            this.btnSearchRecords.Click += new System.EventHandler(this.btnSearchRecords_Click);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateTo.Location = new System.Drawing.Point(13, 70);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(76, 20);
            this.lblDateTo.TabIndex = 36;
            this.lblDateTo.Text = "Date To";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateFrom.Location = new System.Drawing.Point(13, 33);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(98, 20);
            this.lblDateFrom.TabIndex = 35;
            this.lblDateFrom.Text = "Date From";
            // 
            // dtPicketToDate
            // 
            this.dtPicketToDate.AllowDrop = true;
            this.dtPicketToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicketToDate.Location = new System.Drawing.Point(120, 70);
            this.dtPicketToDate.Name = "dtPicketToDate";
            this.dtPicketToDate.Size = new System.Drawing.Size(151, 26);
            this.dtPicketToDate.TabIndex = 34;
            // 
            // dtPicketFromDate
            // 
            this.dtPicketFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicketFromDate.Location = new System.Drawing.Point(120, 29);
            this.dtPicketFromDate.Name = "dtPicketFromDate";
            this.dtPicketFromDate.Size = new System.Drawing.Size(151, 26);
            this.dtPicketFromDate.TabIndex = 33;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPrint.Location = new System.Drawing.Point(819, 72);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(134, 50);
            this.btnPrint.TabIndex = 32;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Location = new System.Drawing.Point(1115, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 50);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Location = new System.Drawing.Point(1115, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(134, 50);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEmailAsExcel
            // 
            this.btnEmailAsExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEmailAsExcel.Location = new System.Drawing.Point(979, 14);
            this.btnEmailAsExcel.Name = "btnEmailAsExcel";
            this.btnEmailAsExcel.Size = new System.Drawing.Size(115, 105);
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
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecCount.Location = new System.Drawing.Point(1033, 723);
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
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(1189, 723);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(60, 22);
            this.lblRecordsCount.TabIndex = 27;
            this.lblRecordsCount.Text = "Count";
            // 
            // chkCompleteFile
            // 
            this.chkCompleteFile.AutoSize = true;
            this.chkCompleteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompleteFile.Location = new System.Drawing.Point(683, 98);
            this.chkCompleteFile.Name = "chkCompleteFile";
            this.chkCompleteFile.Size = new System.Drawing.Size(157, 24);
            this.chkCompleteFile.TabIndex = 5;
            this.chkCompleteFile.Text = "Complete Files";
            this.chkCompleteFile.UseVisualStyleBackColor = true;
            this.chkCompleteFile.Visible = false;
            this.chkCompleteFile.CheckedChanged += new System.EventHandler(this.chkCompleteFile_CheckedChanged);
            // 
            // gridPendingFile
            // 
            this.gridPendingFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPendingFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.gridPendingFile.Location = new System.Drawing.Point(18, 127);
            this.gridPendingFile.MultiSelect = false;
            this.gridPendingFile.Name = "gridPendingFile";
            this.gridPendingFile.RowTemplate.Height = 24;
            this.gridPendingFile.Size = new System.Drawing.Size(1234, 590);
            this.gridPendingFile.TabIndex = 3;
            this.gridPendingFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPendingFile_CellContentClick);
            // 
            // rdbMultiWeight
            // 
            this.rdbMultiWeight.AutoSize = true;
            this.rdbMultiWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMultiWeight.Location = new System.Drawing.Point(683, 68);
            this.rdbMultiWeight.Name = "rdbMultiWeight";
            this.rdbMultiWeight.Size = new System.Drawing.Size(149, 24);
            this.rdbMultiWeight.TabIndex = 2;
            this.rdbMultiWeight.TabStop = true;
            this.rdbMultiWeight.Text = "&Multi Weghing";
            this.rdbMultiWeight.UseVisualStyleBackColor = true;
            this.rdbMultiWeight.Visible = false;
            this.rdbMultiWeight.CheckedChanged += new System.EventHandler(this.rdbMultiWeight_CheckedChanged);
            // 
            // rdbPublicWeight
            // 
            this.rdbPublicWeight.AutoSize = true;
            this.rdbPublicWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPublicWeight.Location = new System.Drawing.Point(684, 35);
            this.rdbPublicWeight.Name = "rdbPublicWeight";
            this.rdbPublicWeight.Size = new System.Drawing.Size(160, 24);
            this.rdbPublicWeight.TabIndex = 1;
            this.rdbPublicWeight.TabStop = true;
            this.rdbPublicWeight.Text = "&Public Weghing";
            this.rdbPublicWeight.UseVisualStyleBackColor = true;
            this.rdbPublicWeight.Visible = false;
            this.rdbPublicWeight.CheckedChanged += new System.EventHandler(this.rdbPublicWeight_CheckedChanged);
            // 
            // rdbNormalWeight
            // 
            this.rdbNormalWeight.AutoSize = true;
            this.rdbNormalWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNormalWeight.Location = new System.Drawing.Point(499, 56);
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
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 785);
            this.Controls.Add(this.grpboxTransactionForm);
            this.Name = "frmTransactionForm";
            this.Text = "Transaction Form";
            this.grpboxTransactionForm.ResumeLayout(false);
            this.grpboxTransactionForm.PerformLayout();
            this.grpBoxFileType.ResumeLayout(false);
            this.grpBoxFileType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxTransactionForm;
        private System.Windows.Forms.RadioButton rdbMultiWeight;
        private System.Windows.Forms.RadioButton rdbPublicWeight;
        private System.Windows.Forms.RadioButton rdbNormalWeight;
        private System.Windows.Forms.DataGridView gridPendingFile;
        private System.Windows.Forms.CheckBox chkCompleteFile;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnEmailAsExcel;
        private System.ComponentModel.BackgroundWorker bgWorkerProcessor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtPicketToDate;
        private System.Windows.Forms.DateTimePicker dtPicketFromDate;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Button btnSearchRecords;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.RadioButton rdbPendingFile;
        private System.Windows.Forms.RadioButton rdbCompleteFile;
        private System.Windows.Forms.GroupBox grpBoxFileType;
    }
}