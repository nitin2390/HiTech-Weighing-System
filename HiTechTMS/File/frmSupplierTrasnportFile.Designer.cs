namespace HitechTMS.File
{
    partial class frmSupplierTransportFile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierTransportFile));
            this.grpboxSupplierFile = new System.Windows.Forms.GroupBox();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.gridSupplierTransporter = new System.Windows.Forms.DataGridView();
            this.btnEmailExcel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpboxSupplimantaryDetails = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblbFax = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.grpboxMainDetails = new System.Windows.Forms.GroupBox();
            this.txtAddressLine3 = new System.Windows.Forms.TextBox();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.errProviderEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderFax = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpboxSupplierFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplierTransporter)).BeginInit();
            this.grpboxSupplimantaryDetails.SuspendLayout();
            this.grpboxMainDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderFax)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxSupplierFile
            // 
            this.grpboxSupplierFile.Controls.Add(this.lblRecCount);
            this.grpboxSupplierFile.Controls.Add(this.lblRecordsCount);
            this.grpboxSupplierFile.Controls.Add(this.gridSupplierTransporter);
            this.grpboxSupplierFile.Controls.Add(this.btnEmailExcel);
            this.grpboxSupplierFile.Controls.Add(this.btnReport);
            this.grpboxSupplierFile.Controls.Add(this.btnDelete);
            this.grpboxSupplierFile.Controls.Add(this.btnExit);
            this.grpboxSupplierFile.Controls.Add(this.btnSave);
            this.grpboxSupplierFile.Controls.Add(this.grpboxSupplimantaryDetails);
            this.grpboxSupplierFile.Controls.Add(this.grpboxMainDetails);
            this.grpboxSupplierFile.Location = new System.Drawing.Point(12, 12);
            this.grpboxSupplierFile.Name = "grpboxSupplierFile";
            this.grpboxSupplierFile.Size = new System.Drawing.Size(875, 582);
            this.grpboxSupplierFile.TabIndex = 0;
            this.grpboxSupplierFile.TabStop = false;
            this.grpboxSupplierFile.Text = "Create/Modify records";
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.Location = new System.Drawing.Point(637, 543);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(136, 22);
            this.lblRecCount.TabIndex = 19;
            this.lblRecCount.Text = "Records Count";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecordsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(793, 543);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(60, 22);
            this.lblRecordsCount.TabIndex = 18;
            this.lblRecordsCount.Text = "Count";
            // 
            // gridSupplierTransporter
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSupplierTransporter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSupplierTransporter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSupplierTransporter.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSupplierTransporter.Location = new System.Drawing.Point(20, 297);
            this.gridSupplierTransporter.Name = "gridSupplierTransporter";
            this.gridSupplierTransporter.RowTemplate.Height = 24;
            this.gridSupplierTransporter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridSupplierTransporter.Size = new System.Drawing.Size(833, 243);
            this.gridSupplierTransporter.TabIndex = 24;
            this.gridSupplierTransporter.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridSupplierTransporter_CellMouseClick);
            // 
            // btnEmailExcel
            // 
            this.btnEmailExcel.Location = new System.Drawing.Point(504, 258);
            this.btnEmailExcel.Name = "btnEmailExcel";
            this.btnEmailExcel.Size = new System.Drawing.Size(115, 27);
            this.btnEmailExcel.TabIndex = 22;
            this.btnEmailExcel.Text = "E&mail As Excel";
            this.btnEmailExcel.UseVisualStyleBackColor = true;
            this.btnEmailExcel.Click += new System.EventHandler(this.btnEmailExcel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(386, 258);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 27);
            this.btnReport.TabIndex = 21;
            this.btnReport.Text = "&Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(258, 258);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 27);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(637, 258);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 27);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpboxSupplimantaryDetails
            // 
            this.grpboxSupplimantaryDetails.Controls.Add(this.txtEmail);
            this.grpboxSupplimantaryDetails.Controls.Add(this.lblPhone);
            this.grpboxSupplimantaryDetails.Controls.Add(this.txtFax);
            this.grpboxSupplimantaryDetails.Controls.Add(this.lblbFax);
            this.grpboxSupplimantaryDetails.Controls.Add(this.txtPhone);
            this.grpboxSupplimantaryDetails.Controls.Add(this.lblEmail);
            this.grpboxSupplimantaryDetails.Location = new System.Drawing.Point(457, 31);
            this.grpboxSupplimantaryDetails.Name = "grpboxSupplimantaryDetails";
            this.grpboxSupplimantaryDetails.Size = new System.Drawing.Size(383, 216);
            this.grpboxSupplimantaryDetails.TabIndex = 7;
            this.grpboxSupplimantaryDetails.TabStop = false;
            this.grpboxSupplimantaryDetails.Text = "Supplimantary Details";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(180, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(146, 22);
            this.txtEmail.TabIndex = 18;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(40, 22);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 17);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(180, 64);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(146, 22);
            this.txtFax.TabIndex = 17;
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFax_KeyDown);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // lblbFax
            // 
            this.lblbFax.AutoSize = true;
            this.lblbFax.Location = new System.Drawing.Point(40, 64);
            this.lblbFax.Name = "lblbFax";
            this.lblbFax.Size = new System.Drawing.Size(30, 17);
            this.lblbFax.TabIndex = 4;
            this.lblbFax.Text = "Fax";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(180, 28);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(146, 22);
            this.txtPhone.TabIndex = 16;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(40, 107);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email";
            // 
            // grpboxMainDetails
            // 
            this.grpboxMainDetails.Controls.Add(this.txtAddressLine3);
            this.grpboxMainDetails.Controls.Add(this.txtAddressLine2);
            this.grpboxMainDetails.Controls.Add(this.txtAddressLine1);
            this.grpboxMainDetails.Controls.Add(this.txtSupplierName);
            this.grpboxMainDetails.Controls.Add(this.txtSupplierCode);
            this.grpboxMainDetails.Controls.Add(this.lblAddress);
            this.grpboxMainDetails.Controls.Add(this.lblSupplierCode);
            this.grpboxMainDetails.Controls.Add(this.lblSupplierName);
            this.grpboxMainDetails.Location = new System.Drawing.Point(23, 28);
            this.grpboxMainDetails.Name = "grpboxMainDetails";
            this.grpboxMainDetails.Size = new System.Drawing.Size(404, 219);
            this.grpboxMainDetails.TabIndex = 6;
            this.grpboxMainDetails.TabStop = false;
            this.grpboxMainDetails.Text = "Main Details";
            // 
            // txtAddressLine3
            // 
            this.txtAddressLine3.Location = new System.Drawing.Point(189, 184);
            this.txtAddressLine3.Name = "txtAddressLine3";
            this.txtAddressLine3.Size = new System.Drawing.Size(146, 22);
            this.txtAddressLine3.TabIndex = 15;
            this.txtAddressLine3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddressLine3_KeyDown);
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Location = new System.Drawing.Point(189, 149);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(146, 22);
            this.txtAddressLine2.TabIndex = 14;
            this.txtAddressLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddressLine2_KeyDown);
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Location = new System.Drawing.Point(189, 110);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(146, 22);
            this.txtAddressLine1.TabIndex = 13;
            this.txtAddressLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddressLine1_KeyDown);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(189, 67);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(146, 22);
            this.txtSupplierName.TabIndex = 12;
            this.txtSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierName_KeyDown);
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Location = new System.Drawing.Point(189, 31);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(146, 22);
            this.txtSupplierCode.TabIndex = 11;
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierCode_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(49, 110);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 17);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address";
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(49, 31);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(97, 17);
            this.lblSupplierCode.TabIndex = 8;
            this.lblSupplierCode.Text = "Supplier Code";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(49, 67);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(101, 17);
            this.lblSupplierName.TabIndex = 9;
            this.lblSupplierName.Text = "Supplier Name";
            // 
            // errProviderEmail
            // 
            this.errProviderEmail.ContainerControl = this;
            // 
            // errProviderPhone
            // 
            this.errProviderPhone.ContainerControl = this;
            // 
            // errProviderCode
            // 
            this.errProviderCode.ContainerControl = this;
            // 
            // errProviderFax
            // 
            this.errProviderFax.ContainerControl = this;
            // 
            // frmSupplierTransportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 606);
            this.Controls.Add(this.grpboxSupplierFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSupplierTransportFile";
            this.Text = "SupplierFile";
            this.grpboxSupplierFile.ResumeLayout(false);
            this.grpboxSupplierFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplierTransporter)).EndInit();
            this.grpboxSupplimantaryDetails.ResumeLayout(false);
            this.grpboxSupplimantaryDetails.PerformLayout();
            this.grpboxMainDetails.ResumeLayout(false);
            this.grpboxMainDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderFax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxSupplierFile;
        private System.Windows.Forms.GroupBox grpboxSupplimantaryDetails;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblbFax;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox grpboxMainDetails;
        private System.Windows.Forms.TextBox txtAddressLine3;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Button btnEmailExcel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.DataGridView gridSupplierTransporter;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.ErrorProvider errProviderEmail;
        private System.Windows.Forms.ErrorProvider errProviderPhone;
        private System.Windows.Forms.ErrorProvider errProviderCode;
        private System.Windows.Forms.ErrorProvider errProviderFax;
    }
}