namespace HitechTMS.Weighing
{
    partial class frmPublicWeighing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpboxPublicWeighing = new System.Windows.Forms.GroupBox();
            this.lblTruck = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.txtTruck = new System.Windows.Forms.TextBox();
            this.lblMiscellaneous = new System.Windows.Forms.Label();
            this.txtMiscellaneous1 = new System.Windows.Forms.TextBox();
            this.txtMiscellaneous = new System.Windows.Forms.TextBox();
            this.grpboxOperation = new System.Windows.Forms.GroupBox();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.grpboxWeightInfo = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTonneNetWeight = new System.Windows.Forms.Label();
            this.lblTonneGrossWeight = new System.Windows.Forms.Label();
            this.lblTonneTareWeight = new System.Windows.Forms.Label();
            this.lblNetWeight = new System.Windows.Forms.Label();
            this.lblGrossWeight = new System.Windows.Forms.Label();
            this.lblTareWeight = new System.Windows.Forms.Label();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.lblDateOut = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblDateIn = new System.Windows.Forms.Label();
            this.txtNetWeight = new System.Windows.Forms.TextBox();
            this.txtGrossWeight = new System.Windows.Forms.TextBox();
            this.txtTareWeight = new System.Windows.Forms.TextBox();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.txtDateOut = new System.Windows.Forms.TextBox();
            this.txtTimeIn = new System.Windows.Forms.TextBox();
            this.txtDateIn = new System.Windows.Forms.TextBox();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.gridSupplierTransporter = new System.Windows.Forms.DataGridView();
            this.grpboxPublicWeighing.SuspendLayout();
            this.grpboxOperation.SuspendLayout();
            this.grpboxWeightInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplierTransporter)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxPublicWeighing
            // 
            this.grpboxPublicWeighing.Controls.Add(this.lblRecCount);
            this.grpboxPublicWeighing.Controls.Add(this.lblRecordsCount);
            this.grpboxPublicWeighing.Controls.Add(this.gridSupplierTransporter);
            this.grpboxPublicWeighing.Controls.Add(this.lblTruck);
            this.grpboxPublicWeighing.Controls.Add(this.txtMode);
            this.grpboxPublicWeighing.Controls.Add(this.lblMode);
            this.grpboxPublicWeighing.Controls.Add(this.txtTruck);
            this.grpboxPublicWeighing.Controls.Add(this.lblMiscellaneous);
            this.grpboxPublicWeighing.Controls.Add(this.txtMiscellaneous1);
            this.grpboxPublicWeighing.Controls.Add(this.txtMiscellaneous);
            this.grpboxPublicWeighing.Controls.Add(this.grpboxOperation);
            this.grpboxPublicWeighing.Controls.Add(this.grpboxWeightInfo);
            this.grpboxPublicWeighing.Location = new System.Drawing.Point(12, 12);
            this.grpboxPublicWeighing.Name = "grpboxPublicWeighing";
            this.grpboxPublicWeighing.Size = new System.Drawing.Size(1154, 713);
            this.grpboxPublicWeighing.TabIndex = 47;
            this.grpboxPublicWeighing.TabStop = false;
            this.grpboxPublicWeighing.Text = "Public Weighing";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruck.Location = new System.Drawing.Point(110, 40);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(49, 17);
            this.lblTruck.TabIndex = 55;
            this.lblTruck.Text = "Truck";
            // 
            // txtMode
            // 
            this.txtMode.AutoSize = true;
            this.txtMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMode.Location = new System.Drawing.Point(999, 45);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(47, 17);
            this.txtMode.TabIndex = 54;
            this.txtMode.Text = "Mode";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(907, 45);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(47, 17);
            this.lblMode.TabIndex = 53;
            this.lblMode.Text = "Mode";
            // 
            // txtTruck
            // 
            this.txtTruck.Location = new System.Drawing.Point(182, 40);
            this.txtTruck.MaxLength = 12;
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(193, 22);
            this.txtTruck.TabIndex = 49;
            // 
            // lblMiscellaneous
            // 
            this.lblMiscellaneous.AutoSize = true;
            this.lblMiscellaneous.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiscellaneous.Location = new System.Drawing.Point(62, 89);
            this.lblMiscellaneous.Name = "lblMiscellaneous";
            this.lblMiscellaneous.Size = new System.Drawing.Size(110, 17);
            this.lblMiscellaneous.TabIndex = 52;
            this.lblMiscellaneous.Text = "Miscellaneous";
            // 
            // txtMiscellaneous1
            // 
            this.txtMiscellaneous1.Location = new System.Drawing.Point(182, 122);
            this.txtMiscellaneous1.MaxLength = 25;
            this.txtMiscellaneous1.Name = "txtMiscellaneous1";
            this.txtMiscellaneous1.Size = new System.Drawing.Size(395, 22);
            this.txtMiscellaneous1.TabIndex = 51;
            // 
            // txtMiscellaneous
            // 
            this.txtMiscellaneous.Location = new System.Drawing.Point(182, 86);
            this.txtMiscellaneous.MaxLength = 25;
            this.txtMiscellaneous.Name = "txtMiscellaneous";
            this.txtMiscellaneous.Size = new System.Drawing.Size(395, 22);
            this.txtMiscellaneous.TabIndex = 50;
            // 
            // grpboxOperation
            // 
            this.grpboxOperation.Controls.Add(this.btnTicket);
            this.grpboxOperation.Controls.Add(this.btnSave);
            this.grpboxOperation.Controls.Add(this.btnExit);
            this.grpboxOperation.Controls.Add(this.btnAddNew);
            this.grpboxOperation.Location = new System.Drawing.Point(851, 162);
            this.grpboxOperation.Name = "grpboxOperation";
            this.grpboxOperation.Size = new System.Drawing.Size(283, 263);
            this.grpboxOperation.TabIndex = 48;
            this.grpboxOperation.TabStop = false;
            this.grpboxOperation.Text = "Operation";
            // 
            // btnTicket
            // 
            this.btnTicket.Location = new System.Drawing.Point(15, 147);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(112, 52);
            this.btnTicket.TabIndex = 20;
            this.btnTicket.Text = "&Ticket";
            this.btnTicket.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(151, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 52);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(151, 147);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 52);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(15, 56);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(112, 52);
            this.btnAddNew.TabIndex = 16;
            this.btnAddNew.Text = "&Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // grpboxWeightInfo
            // 
            this.grpboxWeightInfo.Controls.Add(this.label23);
            this.grpboxWeightInfo.Controls.Add(this.label22);
            this.grpboxWeightInfo.Controls.Add(this.lblTonneNetWeight);
            this.grpboxWeightInfo.Controls.Add(this.lblTonneGrossWeight);
            this.grpboxWeightInfo.Controls.Add(this.lblTonneTareWeight);
            this.grpboxWeightInfo.Controls.Add(this.lblNetWeight);
            this.grpboxWeightInfo.Controls.Add(this.lblGrossWeight);
            this.grpboxWeightInfo.Controls.Add(this.lblTareWeight);
            this.grpboxWeightInfo.Controls.Add(this.lblTimeOut);
            this.grpboxWeightInfo.Controls.Add(this.lblDateOut);
            this.grpboxWeightInfo.Controls.Add(this.lblTimeIn);
            this.grpboxWeightInfo.Controls.Add(this.lblDateIn);
            this.grpboxWeightInfo.Controls.Add(this.txtNetWeight);
            this.grpboxWeightInfo.Controls.Add(this.txtGrossWeight);
            this.grpboxWeightInfo.Controls.Add(this.txtTareWeight);
            this.grpboxWeightInfo.Controls.Add(this.txtTimeOut);
            this.grpboxWeightInfo.Controls.Add(this.txtDateOut);
            this.grpboxWeightInfo.Controls.Add(this.txtTimeIn);
            this.grpboxWeightInfo.Controls.Add(this.txtDateIn);
            this.grpboxWeightInfo.Location = new System.Drawing.Point(22, 162);
            this.grpboxWeightInfo.Name = "grpboxWeightInfo";
            this.grpboxWeightInfo.Size = new System.Drawing.Size(819, 263);
            this.grpboxWeightInfo.TabIndex = 47;
            this.grpboxWeightInfo.TabStop = false;
            this.grpboxWeightInfo.Text = "Weight Info";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(738, 127);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 17);
            this.label23.TabIndex = 38;
            this.label23.Text = "kbd";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(738, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 17);
            this.label22.TabIndex = 37;
            this.label22.Text = "kbd";
            // 
            // lblTonneNetWeight
            // 
            this.lblTonneNetWeight.AutoSize = true;
            this.lblTonneNetWeight.Location = new System.Drawing.Point(669, 191);
            this.lblTonneNetWeight.Name = "lblTonneNetWeight";
            this.lblTonneNetWeight.Size = new System.Drawing.Size(44, 17);
            this.lblTonneNetWeight.TabIndex = 36;
            this.lblTonneNetWeight.Text = "tonne";
            // 
            // lblTonneGrossWeight
            // 
            this.lblTonneGrossWeight.AutoSize = true;
            this.lblTonneGrossWeight.Location = new System.Drawing.Point(669, 127);
            this.lblTonneGrossWeight.Name = "lblTonneGrossWeight";
            this.lblTonneGrossWeight.Size = new System.Drawing.Size(44, 17);
            this.lblTonneGrossWeight.TabIndex = 35;
            this.lblTonneGrossWeight.Text = "tonne";
            // 
            // lblTonneTareWeight
            // 
            this.lblTonneTareWeight.AutoSize = true;
            this.lblTonneTareWeight.Location = new System.Drawing.Point(669, 60);
            this.lblTonneTareWeight.Name = "lblTonneTareWeight";
            this.lblTonneTareWeight.Size = new System.Drawing.Size(44, 17);
            this.lblTonneTareWeight.TabIndex = 34;
            this.lblTonneTareWeight.Text = "tonne";
            // 
            // lblNetWeight
            // 
            this.lblNetWeight.AutoSize = true;
            this.lblNetWeight.Location = new System.Drawing.Point(420, 191);
            this.lblNetWeight.Name = "lblNetWeight";
            this.lblNetWeight.Size = new System.Drawing.Size(78, 17);
            this.lblNetWeight.TabIndex = 33;
            this.lblNetWeight.Text = "Net Weight";
            // 
            // lblGrossWeight
            // 
            this.lblGrossWeight.AutoSize = true;
            this.lblGrossWeight.Location = new System.Drawing.Point(511, 104);
            this.lblGrossWeight.Name = "lblGrossWeight";
            this.lblGrossWeight.Size = new System.Drawing.Size(94, 17);
            this.lblGrossWeight.TabIndex = 32;
            this.lblGrossWeight.Text = "Gross Weight";
            // 
            // lblTareWeight
            // 
            this.lblTareWeight.AutoSize = true;
            this.lblTareWeight.Location = new System.Drawing.Point(511, 35);
            this.lblTareWeight.Name = "lblTareWeight";
            this.lblTareWeight.Size = new System.Drawing.Size(86, 17);
            this.lblTareWeight.TabIndex = 31;
            this.lblTareWeight.Text = "Tare Weight";
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(277, 104);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(66, 17);
            this.lblTimeOut.TabIndex = 30;
            this.lblTimeOut.Text = "Time Out";
            // 
            // lblDateOut
            // 
            this.lblDateOut.AutoSize = true;
            this.lblDateOut.Location = new System.Drawing.Point(14, 104);
            this.lblDateOut.Name = "lblDateOut";
            this.lblDateOut.Size = new System.Drawing.Size(65, 17);
            this.lblDateOut.TabIndex = 29;
            this.lblDateOut.Text = "Date Out";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Location = new System.Drawing.Point(277, 35);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(54, 17);
            this.lblTimeIn.TabIndex = 28;
            this.lblTimeIn.Text = "Time In";
            // 
            // lblDateIn
            // 
            this.lblDateIn.AutoSize = true;
            this.lblDateIn.Location = new System.Drawing.Point(14, 35);
            this.lblDateIn.Name = "lblDateIn";
            this.lblDateIn.Size = new System.Drawing.Size(53, 17);
            this.lblDateIn.TabIndex = 27;
            this.lblDateIn.Text = "Date In";
            // 
            // txtNetWeight
            // 
            this.txtNetWeight.Location = new System.Drawing.Point(515, 191);
            this.txtNetWeight.Name = "txtNetWeight";
            this.txtNetWeight.Size = new System.Drawing.Size(148, 22);
            this.txtNetWeight.TabIndex = 25;
            // 
            // txtGrossWeight
            // 
            this.txtGrossWeight.Location = new System.Drawing.Point(515, 124);
            this.txtGrossWeight.Name = "txtGrossWeight";
            this.txtGrossWeight.Size = new System.Drawing.Size(148, 22);
            this.txtGrossWeight.TabIndex = 14;
            // 
            // txtTareWeight
            // 
            this.txtTareWeight.Location = new System.Drawing.Point(515, 55);
            this.txtTareWeight.Name = "txtTareWeight";
            this.txtTareWeight.Size = new System.Drawing.Size(148, 22);
            this.txtTareWeight.TabIndex = 13;
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(280, 124);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(148, 22);
            this.txtTimeOut.TabIndex = 22;
            this.txtTimeOut.TabStop = false;
            // 
            // txtDateOut
            // 
            this.txtDateOut.Location = new System.Drawing.Point(17, 124);
            this.txtDateOut.Name = "txtDateOut";
            this.txtDateOut.Size = new System.Drawing.Size(148, 22);
            this.txtDateOut.TabIndex = 21;
            this.txtDateOut.TabStop = false;
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Location = new System.Drawing.Point(280, 55);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Size = new System.Drawing.Size(148, 22);
            this.txtTimeIn.TabIndex = 20;
            this.txtTimeIn.TabStop = false;
            // 
            // txtDateIn
            // 
            this.txtDateIn.Location = new System.Drawing.Point(17, 55);
            this.txtDateIn.Name = "txtDateIn";
            this.txtDateIn.Size = new System.Drawing.Size(148, 22);
            this.txtDateIn.TabIndex = 19;
            this.txtDateIn.TabStop = false;
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.Location = new System.Drawing.Point(932, 679);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(136, 22);
            this.lblRecCount.TabIndex = 57;
            this.lblRecCount.Text = "Records Count";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecordsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(1088, 679);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(60, 22);
            this.lblRecordsCount.TabIndex = 56;
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
            this.gridSupplierTransporter.Location = new System.Drawing.Point(22, 431);
            this.gridSupplierTransporter.Name = "gridSupplierTransporter";
            this.gridSupplierTransporter.RowTemplate.Height = 24;
            this.gridSupplierTransporter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridSupplierTransporter.Size = new System.Drawing.Size(1112, 243);
            this.gridSupplierTransporter.TabIndex = 58;
            // 
            // PublicWeighing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 734);
            this.Controls.Add(this.grpboxPublicWeighing);
            this.Name = "PublicWeighing";
            this.Text = "PublicWeighing";
            this.grpboxPublicWeighing.ResumeLayout(false);
            this.grpboxPublicWeighing.PerformLayout();
            this.grpboxOperation.ResumeLayout(false);
            this.grpboxWeightInfo.ResumeLayout(false);
            this.grpboxWeightInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplierTransporter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxPublicWeighing;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.Label txtMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TextBox txtTruck;
        private System.Windows.Forms.Label lblMiscellaneous;
        private System.Windows.Forms.TextBox txtMiscellaneous1;
        private System.Windows.Forms.TextBox txtMiscellaneous;
        private System.Windows.Forms.GroupBox grpboxOperation;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.GroupBox grpboxWeightInfo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTonneNetWeight;
        private System.Windows.Forms.Label lblTonneGrossWeight;
        private System.Windows.Forms.Label lblTonneTareWeight;
        private System.Windows.Forms.Label lblNetWeight;
        private System.Windows.Forms.Label lblGrossWeight;
        private System.Windows.Forms.Label lblTareWeight;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Label lblDateOut;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblDateIn;
        private System.Windows.Forms.TextBox txtNetWeight;
        private System.Windows.Forms.TextBox txtGrossWeight;
        private System.Windows.Forms.TextBox txtTareWeight;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.TextBox txtDateOut;
        private System.Windows.Forms.TextBox txtTimeIn;
        private System.Windows.Forms.TextBox txtDateIn;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.DataGridView gridSupplierTransporter;
    }
}