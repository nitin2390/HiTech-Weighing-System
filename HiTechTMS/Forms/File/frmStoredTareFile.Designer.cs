namespace HitechTMS.File
{
    partial class frmStoredTareFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStoredTareFile));
            this.grpboxCreateEditStoredTareRecords = new System.Windows.Forms.GroupBox();
            this.btnWeight = new System.Windows.Forms.Button();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.gridStoredTare = new System.Windows.Forms.DataGridView();
            this.btnEmailExcel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTareWeight = new System.Windows.Forms.TextBox();
            this.lblTareWeight = new System.Windows.Forms.Label();
            this.txtTimeIn = new System.Windows.Forms.TextBox();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.txtDateIn = new System.Windows.Forms.TextBox();
            this.lblDateIn = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.txtTransportName = new System.Windows.Forms.TextBox();
            this.txtTruckType = new System.Windows.Forms.TextBox();
            this.txtTruck = new System.Windows.Forms.TextBox();
            this.cmbTransportCode = new System.Windows.Forms.ComboBox();
            this.lblTransportName = new System.Windows.Forms.Label();
            this.lblTransportCode = new System.Windows.Forms.Label();
            this.lblTruckType = new System.Windows.Forms.Label();
            this.lblTruck = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.errTruck = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTransportCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTareWeight = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpboxCreateEditStoredTareRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStoredTare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTransportCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTareWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxCreateEditStoredTareRecords
            // 
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.btnWeight);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblRecCount);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblRecordsCount);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.gridStoredTare);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.btnEmailExcel);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.btnReport);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.btnDelete);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.btnExit);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.btnSave);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.txtTareWeight);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblTareWeight);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.txtTimeIn);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblTimeIn);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.txtDateIn);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblDateIn);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.txtMode);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.txtTransportName);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.txtTruckType);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.txtTruck);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.cmbTransportCode);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblTransportName);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblTransportCode);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblTruckType);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblTruck);
            this.grpboxCreateEditStoredTareRecords.Controls.Add(this.lblMode);
            this.grpboxCreateEditStoredTareRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxCreateEditStoredTareRecords.Location = new System.Drawing.Point(12, 13);
            this.grpboxCreateEditStoredTareRecords.Name = "grpboxCreateEditStoredTareRecords";
            this.grpboxCreateEditStoredTareRecords.Size = new System.Drawing.Size(893, 636);
            this.grpboxCreateEditStoredTareRecords.TabIndex = 0;
            this.grpboxCreateEditStoredTareRecords.TabStop = false;
            this.grpboxCreateEditStoredTareRecords.Text = "Create/Edit Stored Tare Records";
            // 
            // btnWeight
            // 
            this.btnWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnWeight.Location = new System.Drawing.Point(659, 205);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(136, 71);
            this.btnWeight.TabIndex = 27;
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecCount.Location = new System.Drawing.Point(649, 602);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(136, 22);
            this.lblRecCount.TabIndex = 26;
            this.lblRecCount.Text = "Records Count";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecordsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordsCount.Location = new System.Drawing.Point(805, 602);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(60, 22);
            this.lblRecordsCount.TabIndex = 25;
            this.lblRecordsCount.Text = "Count";
            // 
            // gridStoredTare
            // 
            this.gridStoredTare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStoredTare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.gridStoredTare.Location = new System.Drawing.Point(32, 356);
            this.gridStoredTare.Name = "gridStoredTare";
            this.gridStoredTare.RowTemplate.Height = 24;
            this.gridStoredTare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridStoredTare.Size = new System.Drawing.Size(833, 243);
            this.gridStoredTare.TabIndex = 10;
            this.gridStoredTare.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridStoredTare_CellMouseClick);
            // 
            // btnEmailExcel
            // 
            this.btnEmailExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEmailExcel.Location = new System.Drawing.Point(533, 290);
            this.btnEmailExcel.Name = "btnEmailExcel";
            this.btnEmailExcel.Size = new System.Drawing.Size(134, 50);
            this.btnEmailExcel.TabIndex = 8;
            this.btnEmailExcel.Text = "E&mail As Excel";
            this.btnEmailExcel.UseVisualStyleBackColor = true;
            this.btnEmailExcel.Click += new System.EventHandler(this.btnEmailExcel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnReport.Location = new System.Drawing.Point(384, 290);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(134, 50);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "&Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Location = new System.Drawing.Point(234, 290);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 50);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Location = new System.Drawing.Point(682, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(134, 50);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(83, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 50);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTareWeight
            // 
            this.txtTareWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTareWeight.Location = new System.Drawing.Point(455, 239);
            this.txtTareWeight.MaxLength = 4;
            this.txtTareWeight.Name = "txtTareWeight";
            this.txtTareWeight.Size = new System.Drawing.Size(135, 26);
            this.txtTareWeight.TabIndex = 4;
            this.txtTareWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTareWeight.TextChanged += new System.EventHandler(this.txtTareWeight_TextChanged);
            this.txtTareWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTareWeight_KeyDown);
            this.txtTareWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTareWeight_KeyPress);
            // 
            // lblTareWeight
            // 
            this.lblTareWeight.AutoSize = true;
            this.lblTareWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTareWeight.Location = new System.Drawing.Point(478, 205);
            this.lblTareWeight.Name = "lblTareWeight";
            this.lblTareWeight.Size = new System.Drawing.Size(111, 20);
            this.lblTareWeight.TabIndex = 16;
            this.lblTareWeight.Text = "Tare Weight";
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTimeIn.Location = new System.Drawing.Point(273, 239);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.ReadOnly = true;
            this.txtTimeIn.Size = new System.Drawing.Size(135, 26);
            this.txtTimeIn.TabIndex = 15;
            this.txtTimeIn.TabStop = false;
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimeIn.Location = new System.Drawing.Point(314, 205);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(71, 20);
            this.lblTimeIn.TabIndex = 14;
            this.lblTimeIn.Text = "Time In";
            // 
            // txtDateIn
            // 
            this.txtDateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDateIn.Location = new System.Drawing.Point(105, 239);
            this.txtDateIn.Name = "txtDateIn";
            this.txtDateIn.ReadOnly = true;
            this.txtDateIn.Size = new System.Drawing.Size(135, 26);
            this.txtDateIn.TabIndex = 13;
            this.txtDateIn.TabStop = false;
            // 
            // lblDateIn
            // 
            this.lblDateIn.AutoSize = true;
            this.lblDateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateIn.Location = new System.Drawing.Point(141, 205);
            this.lblDateIn.Name = "lblDateIn";
            this.lblDateIn.Size = new System.Drawing.Size(70, 20);
            this.lblDateIn.TabIndex = 12;
            this.lblDateIn.Text = "Date In";
            // 
            // txtMode
            // 
            this.txtMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMode.Location = new System.Drawing.Point(432, 18);
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(77, 26);
            this.txtMode.TabIndex = 11;
            this.txtMode.TabStop = false;
            // 
            // txtTransportName
            // 
            this.txtTransportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTransportName.Location = new System.Drawing.Point(659, 139);
            this.txtTransportName.Name = "txtTransportName";
            this.txtTransportName.ReadOnly = true;
            this.txtTransportName.Size = new System.Drawing.Size(135, 26);
            this.txtTransportName.TabIndex = 10;
            this.txtTransportName.TabStop = false;
            // 
            // txtTruckType
            // 
            this.txtTruckType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTruckType.Location = new System.Drawing.Point(238, 136);
            this.txtTruckType.MaxLength = 20;
            this.txtTruckType.Name = "txtTruckType";
            this.txtTruckType.Size = new System.Drawing.Size(159, 26);
            this.txtTruckType.TabIndex = 2;
            this.txtTruckType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTruckType_KeyDown);
            // 
            // txtTruck
            // 
            this.txtTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTruck.Location = new System.Drawing.Point(238, 77);
            this.txtTruck.MaxLength = 12;
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(159, 26);
            this.txtTruck.TabIndex = 1;
            this.txtTruck.TextChanged += new System.EventHandler(this.txtTruck_TextChanged);
            this.txtTruck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTruck_KeyDown);
            this.txtTruck.Leave += new System.EventHandler(this.txtTruck_Leave);
            // 
            // cmbTransportCode
            // 
            this.cmbTransportCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransportCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTransportCode.FormattingEnabled = true;
            this.cmbTransportCode.Location = new System.Drawing.Point(659, 79);
            this.cmbTransportCode.Name = "cmbTransportCode";
            this.cmbTransportCode.Size = new System.Drawing.Size(121, 28);
            this.cmbTransportCode.TabIndex = 3;
            this.cmbTransportCode.SelectedIndexChanged += new System.EventHandler(this.cmbTransportCode_SelectedIndexChanged);
            this.cmbTransportCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTransportCode_KeyDown);
            // 
            // lblTransportName
            // 
            this.lblTransportName.AutoSize = true;
            this.lblTransportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTransportName.Location = new System.Drawing.Point(466, 136);
            this.lblTransportName.Name = "lblTransportName";
            this.lblTransportName.Size = new System.Drawing.Size(144, 20);
            this.lblTransportName.TabIndex = 5;
            this.lblTransportName.Text = "Transport Name";
            // 
            // lblTransportCode
            // 
            this.lblTransportCode.AutoSize = true;
            this.lblTransportCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTransportCode.Location = new System.Drawing.Point(466, 79);
            this.lblTransportCode.Name = "lblTransportCode";
            this.lblTransportCode.Size = new System.Drawing.Size(139, 20);
            this.lblTransportCode.TabIndex = 4;
            this.lblTransportCode.Text = "Transport Code";
            // 
            // lblTruckType
            // 
            this.lblTruckType.AutoSize = true;
            this.lblTruckType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTruckType.Location = new System.Drawing.Point(99, 139);
            this.lblTruckType.Name = "lblTruckType";
            this.lblTruckType.Size = new System.Drawing.Size(102, 20);
            this.lblTruckType.TabIndex = 3;
            this.lblTruckType.Text = "Truck Type";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTruck.Location = new System.Drawing.Point(99, 82);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(56, 20);
            this.lblTruck.TabIndex = 2;
            this.lblTruck.Text = "Truck";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMode.Location = new System.Drawing.Point(331, 18);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(54, 20);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Mode";
            // 
            // errTruck
            // 
            this.errTruck.ContainerControl = this;
            // 
            // errTransportCode
            // 
            this.errTransportCode.ContainerControl = this;
            // 
            // errTareWeight
            // 
            this.errTareWeight.ContainerControl = this;
            // 
            // frmStoredTareFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 661);
            this.Controls.Add(this.grpboxCreateEditStoredTareRecords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStoredTareFile";
            this.Tag = "StoredTareFile";
            this.Text = "frmStoredTareFile";
            this.grpboxCreateEditStoredTareRecords.ResumeLayout(false);
            this.grpboxCreateEditStoredTareRecords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStoredTare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTransportCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTareWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxCreateEditStoredTareRecords;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblTransportCode;
        private System.Windows.Forms.Label lblTruckType;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.Label lblTransportName;
        private System.Windows.Forms.ComboBox cmbTransportCode;
        private System.Windows.Forms.TextBox txtTruckType;
        private System.Windows.Forms.TextBox txtTruck;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.TextBox txtTransportName;
        private System.Windows.Forms.TextBox txtTimeIn;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.TextBox txtDateIn;
        private System.Windows.Forms.Label lblDateIn;
        private System.Windows.Forms.TextBox txtTareWeight;
        private System.Windows.Forms.Label lblTareWeight;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.DataGridView gridStoredTare;
        private System.Windows.Forms.Button btnEmailExcel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errTruck;
        private System.Windows.Forms.ErrorProvider errTransportCode;
        private System.Windows.Forms.ErrorProvider errTareWeight;
        private System.Windows.Forms.Button btnWeight;
    }
}