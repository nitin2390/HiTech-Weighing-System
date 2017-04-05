﻿namespace HitechTMS.Weighing
{
    partial class frmNormalWeighing
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
            this.grpboxNormalWeighing = new System.Windows.Forms.GroupBox();
            this.lstTruck = new System.Windows.Forms.ListBox();
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
            this.grpboxChallanInfo = new System.Windows.Forms.GroupBox();
            this.txtChallanWeight = new System.Windows.Forms.TextBox();
            this.lblDeliveryNoteN = new System.Windows.Forms.Label();
            this.lblMiscellaneous = new System.Windows.Forms.Label();
            this.txtDeliveryNoteN = new System.Windows.Forms.TextBox();
            this.txtMiscellaneous1 = new System.Windows.Forms.TextBox();
            this.txtMiscellaneous = new System.Windows.Forms.TextBox();
            this.cmbChallanWeight = new System.Windows.Forms.ComboBox();
            this.lblChallanWeight = new System.Windows.Forms.Label();
            this.txtChallanDate = new System.Windows.Forms.TextBox();
            this.txtChallanNumber = new System.Windows.Forms.TextBox();
            this.lblChallanDate = new System.Windows.Forms.Label();
            this.lblChallanNumber = new System.Windows.Forms.Label();
            this.grpboxOperation = new System.Windows.Forms.GroupBox();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtTranspoterName = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblTransporterCode = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.cmbTranspoterCode = new System.Windows.Forms.ComboBox();
            this.cmbCustomerCode = new System.Windows.Forms.ComboBox();
            this.cmbProductCode = new System.Windows.Forms.ComboBox();
            this.txtTruck = new System.Windows.Forms.TextBox();
            this.lblTruck = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.grpboxNormalWeighing.SuspendLayout();
            this.grpboxWeightInfo.SuspendLayout();
            this.grpboxChallanInfo.SuspendLayout();
            this.grpboxOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpboxNormalWeighing
            // 
            this.grpboxNormalWeighing.Controls.Add(this.lstTruck);
            this.grpboxNormalWeighing.Controls.Add(this.grpboxWeightInfo);
            this.grpboxNormalWeighing.Controls.Add(this.grpboxChallanInfo);
            this.grpboxNormalWeighing.Controls.Add(this.grpboxOperation);
            this.grpboxNormalWeighing.Controls.Add(this.txtTranspoterName);
            this.grpboxNormalWeighing.Controls.Add(this.txtCustomerName);
            this.grpboxNormalWeighing.Controls.Add(this.txtProductName);
            this.grpboxNormalWeighing.Controls.Add(this.lblTransporterCode);
            this.grpboxNormalWeighing.Controls.Add(this.lblCustomerCode);
            this.grpboxNormalWeighing.Controls.Add(this.lblProductCode);
            this.grpboxNormalWeighing.Controls.Add(this.cmbTranspoterCode);
            this.grpboxNormalWeighing.Controls.Add(this.cmbCustomerCode);
            this.grpboxNormalWeighing.Controls.Add(this.cmbProductCode);
            this.grpboxNormalWeighing.Controls.Add(this.txtTruck);
            this.grpboxNormalWeighing.Controls.Add(this.lblTruck);
            this.grpboxNormalWeighing.Controls.Add(this.txtMode);
            this.grpboxNormalWeighing.Controls.Add(this.lblMode);
            this.grpboxNormalWeighing.Location = new System.Drawing.Point(13, 13);
            this.grpboxNormalWeighing.Name = "grpboxNormalWeighing";
            this.grpboxNormalWeighing.Size = new System.Drawing.Size(1204, 718);
            this.grpboxNormalWeighing.TabIndex = 0;
            this.grpboxNormalWeighing.TabStop = false;
            this.grpboxNormalWeighing.Text = "Normal Weighing";
            // 
            // lstTruck
            // 
            this.lstTruck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTruck.FormattingEnabled = true;
            this.lstTruck.ItemHeight = 16;
            this.lstTruck.Location = new System.Drawing.Point(35, 133);
            this.lstTruck.Name = "lstTruck";
            this.lstTruck.Size = new System.Drawing.Size(193, 50);
            this.lstTruck.TabIndex = 2;
            this.lstTruck.DoubleClick += new System.EventHandler(this.lstTruck_DoubleClick);
            this.lstTruck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTruck_KeyDown);
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
            this.grpboxWeightInfo.Location = new System.Drawing.Point(23, 455);
            this.grpboxWeightInfo.Name = "grpboxWeightInfo";
            this.grpboxWeightInfo.Size = new System.Drawing.Size(819, 263);
            this.grpboxWeightInfo.TabIndex = 12;
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
            this.txtGrossWeight.TextChanged += new System.EventHandler(this.txtGrossWeight_TextChanged);
            // 
            // txtTareWeight
            // 
            this.txtTareWeight.Location = new System.Drawing.Point(515, 55);
            this.txtTareWeight.Name = "txtTareWeight";
            this.txtTareWeight.Size = new System.Drawing.Size(148, 22);
            this.txtTareWeight.TabIndex = 13;
            this.txtTareWeight.TextChanged += new System.EventHandler(this.txtTareWeight_TextChanged);
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
            // grpboxChallanInfo
            // 
            this.grpboxChallanInfo.Controls.Add(this.txtChallanWeight);
            this.grpboxChallanInfo.Controls.Add(this.lblDeliveryNoteN);
            this.grpboxChallanInfo.Controls.Add(this.lblMiscellaneous);
            this.grpboxChallanInfo.Controls.Add(this.txtDeliveryNoteN);
            this.grpboxChallanInfo.Controls.Add(this.txtMiscellaneous1);
            this.grpboxChallanInfo.Controls.Add(this.txtMiscellaneous);
            this.grpboxChallanInfo.Controls.Add(this.cmbChallanWeight);
            this.grpboxChallanInfo.Controls.Add(this.lblChallanWeight);
            this.grpboxChallanInfo.Controls.Add(this.txtChallanDate);
            this.grpboxChallanInfo.Controls.Add(this.txtChallanNumber);
            this.grpboxChallanInfo.Controls.Add(this.lblChallanDate);
            this.grpboxChallanInfo.Controls.Add(this.lblChallanNumber);
            this.grpboxChallanInfo.Location = new System.Drawing.Point(23, 185);
            this.grpboxChallanInfo.Name = "grpboxChallanInfo";
            this.grpboxChallanInfo.Size = new System.Drawing.Size(819, 263);
            this.grpboxChallanInfo.TabIndex = 5;
            this.grpboxChallanInfo.TabStop = false;
            this.grpboxChallanInfo.Text = "Challan Info";
            // 
            // txtChallanWeight
            // 
            this.txtChallanWeight.Location = new System.Drawing.Point(17, 222);
            this.txtChallanWeight.Name = "txtChallanWeight";
            this.txtChallanWeight.Size = new System.Drawing.Size(148, 22);
            this.txtChallanWeight.TabIndex = 7;
            // 
            // lblDeliveryNoteN
            // 
            this.lblDeliveryNoteN.AutoSize = true;
            this.lblDeliveryNoteN.Location = new System.Drawing.Point(315, 186);
            this.lblDeliveryNoteN.Name = "lblDeliveryNoteN";
            this.lblDeliveryNoteN.Size = new System.Drawing.Size(107, 17);
            this.lblDeliveryNoteN.TabIndex = 26;
            this.lblDeliveryNoteN.Text = "Delivery Note N";
            // 
            // lblMiscellaneous
            // 
            this.lblMiscellaneous.AutoSize = true;
            this.lblMiscellaneous.Location = new System.Drawing.Point(315, 35);
            this.lblMiscellaneous.Name = "lblMiscellaneous";
            this.lblMiscellaneous.Size = new System.Drawing.Size(97, 17);
            this.lblMiscellaneous.TabIndex = 25;
            this.lblMiscellaneous.Text = "Miscellaneous";
            // 
            // txtDeliveryNoteN
            // 
            this.txtDeliveryNoteN.Location = new System.Drawing.Point(318, 224);
            this.txtDeliveryNoteN.Name = "txtDeliveryNoteN";
            this.txtDeliveryNoteN.Size = new System.Drawing.Size(247, 22);
            this.txtDeliveryNoteN.TabIndex = 11;
            // 
            // txtMiscellaneous1
            // 
            this.txtMiscellaneous1.Location = new System.Drawing.Point(318, 106);
            this.txtMiscellaneous1.Name = "txtMiscellaneous1";
            this.txtMiscellaneous1.Size = new System.Drawing.Size(247, 22);
            this.txtMiscellaneous1.TabIndex = 10;
            // 
            // txtMiscellaneous
            // 
            this.txtMiscellaneous.Location = new System.Drawing.Point(318, 70);
            this.txtMiscellaneous.Name = "txtMiscellaneous";
            this.txtMiscellaneous.Size = new System.Drawing.Size(247, 22);
            this.txtMiscellaneous.TabIndex = 9;
            // 
            // cmbChallanWeight
            // 
            this.cmbChallanWeight.FormattingEnabled = true;
            this.cmbChallanWeight.Items.AddRange(new object[] {
            "t",
            "Kg"});
            this.cmbChallanWeight.Location = new System.Drawing.Point(171, 222);
            this.cmbChallanWeight.Name = "cmbChallanWeight";
            this.cmbChallanWeight.Size = new System.Drawing.Size(45, 24);
            this.cmbChallanWeight.TabIndex = 8;
            // 
            // lblChallanWeight
            // 
            this.lblChallanWeight.AutoSize = true;
            this.lblChallanWeight.Location = new System.Drawing.Point(14, 186);
            this.lblChallanWeight.Name = "lblChallanWeight";
            this.lblChallanWeight.Size = new System.Drawing.Size(103, 17);
            this.lblChallanWeight.TabIndex = 21;
            this.lblChallanWeight.Text = "Challan Weight";
            // 
            // txtChallanDate
            // 
            this.txtChallanDate.Location = new System.Drawing.Point(17, 144);
            this.txtChallanDate.Name = "txtChallanDate";
            this.txtChallanDate.Size = new System.Drawing.Size(148, 22);
            this.txtChallanDate.TabIndex = 6;
            // 
            // txtChallanNumber
            // 
            this.txtChallanNumber.Location = new System.Drawing.Point(17, 70);
            this.txtChallanNumber.Name = "txtChallanNumber";
            this.txtChallanNumber.Size = new System.Drawing.Size(148, 22);
            this.txtChallanNumber.TabIndex = 5;
            // 
            // lblChallanDate
            // 
            this.lblChallanDate.AutoSize = true;
            this.lblChallanDate.Location = new System.Drawing.Point(14, 111);
            this.lblChallanDate.Name = "lblChallanDate";
            this.lblChallanDate.Size = new System.Drawing.Size(89, 17);
            this.lblChallanDate.TabIndex = 18;
            this.lblChallanDate.Text = "Challan Date";
            // 
            // lblChallanNumber
            // 
            this.lblChallanNumber.AutoSize = true;
            this.lblChallanNumber.Location = new System.Drawing.Point(14, 35);
            this.lblChallanNumber.Name = "lblChallanNumber";
            this.lblChallanNumber.Size = new System.Drawing.Size(109, 17);
            this.lblChallanNumber.TabIndex = 17;
            this.lblChallanNumber.Text = "Challan Number";
            // 
            // grpboxOperation
            // 
            this.grpboxOperation.Controls.Add(this.btnTicket);
            this.grpboxOperation.Controls.Add(this.btnSave);
            this.grpboxOperation.Controls.Add(this.btnSendEmail);
            this.grpboxOperation.Controls.Add(this.btnCancel);
            this.grpboxOperation.Controls.Add(this.btnAddNew);
            this.grpboxOperation.Location = new System.Drawing.Point(848, 185);
            this.grpboxOperation.Name = "grpboxOperation";
            this.grpboxOperation.Size = new System.Drawing.Size(335, 375);
            this.grpboxOperation.TabIndex = 15;
            this.grpboxOperation.TabStop = false;
            this.grpboxOperation.Text = "Operation";
            // 
            // btnTicket
            // 
            this.btnTicket.Location = new System.Drawing.Point(114, 246);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(106, 58);
            this.btnTicket.TabIndex = 20;
            this.btnTicket.Text = "&Ticket";
            this.btnTicket.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(196, 47);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 58);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(24, 154);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(106, 58);
            this.btnSendEmail.TabIndex = 18;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(196, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 58);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(24, 47);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(106, 58);
            this.btnAddNew.TabIndex = 16;
            this.btnAddNew.Text = "&Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // txtTranspoterName
            // 
            this.txtTranspoterName.Location = new System.Drawing.Point(623, 138);
            this.txtTranspoterName.Name = "txtTranspoterName";
            this.txtTranspoterName.Size = new System.Drawing.Size(247, 22);
            this.txtTranspoterName.TabIndex = 12;
            this.txtTranspoterName.TabStop = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(623, 81);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(247, 22);
            this.txtCustomerName.TabIndex = 11;
            this.txtCustomerName.TabStop = false;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(623, 33);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(247, 22);
            this.txtProductName.TabIndex = 10;
            this.txtProductName.TabStop = false;
            // 
            // lblTransporterCode
            // 
            this.lblTransporterCode.AutoSize = true;
            this.lblTransporterCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransporterCode.Location = new System.Drawing.Point(258, 138);
            this.lblTransporterCode.Name = "lblTransporterCode";
            this.lblTransporterCode.Size = new System.Drawing.Size(130, 17);
            this.lblTransporterCode.TabIndex = 9;
            this.lblTransporterCode.Text = "Transpoter Code";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.Location = new System.Drawing.Point(270, 89);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(118, 17);
            this.lblCustomerCode.TabIndex = 8;
            this.lblCustomerCode.Text = "Customer Code";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(290, 30);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(106, 17);
            this.lblProductCode.TabIndex = 7;
            this.lblProductCode.Text = "Product Code";
            // 
            // cmbTranspoterCode
            // 
            this.cmbTranspoterCode.FormattingEnabled = true;
            this.cmbTranspoterCode.Location = new System.Drawing.Point(404, 135);
            this.cmbTranspoterCode.Name = "cmbTranspoterCode";
            this.cmbTranspoterCode.Size = new System.Drawing.Size(169, 24);
            this.cmbTranspoterCode.TabIndex = 4;
            this.cmbTranspoterCode.SelectedIndexChanged += new System.EventHandler(this.cmbTranspoterCode_SelectedIndexChanged);
            // 
            // cmbCustomerCode
            // 
            this.cmbCustomerCode.FormattingEnabled = true;
            this.cmbCustomerCode.Location = new System.Drawing.Point(404, 86);
            this.cmbCustomerCode.Name = "cmbCustomerCode";
            this.cmbCustomerCode.Size = new System.Drawing.Size(169, 24);
            this.cmbCustomerCode.TabIndex = 3;
            this.cmbCustomerCode.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerCode_SelectedIndexChanged);
            // 
            // cmbProductCode
            // 
            this.cmbProductCode.FormattingEnabled = true;
            this.cmbProductCode.Location = new System.Drawing.Point(404, 30);
            this.cmbProductCode.Name = "cmbProductCode";
            this.cmbProductCode.Size = new System.Drawing.Size(169, 24);
            this.cmbProductCode.TabIndex = 2;
            this.cmbProductCode.SelectedIndexChanged += new System.EventHandler(this.cmbProductCode_SelectedIndexChanged);
            // 
            // txtTruck
            // 
            this.txtTruck.Location = new System.Drawing.Point(35, 112);
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(193, 22);
            this.txtTruck.TabIndex = 1;
            this.txtTruck.TextChanged += new System.EventHandler(this.txtTruck_TextChanged);
            this.txtTruck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTruck_KeyDown);
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruck.Location = new System.Drawing.Point(77, 81);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(49, 17);
            this.lblTruck.TabIndex = 2;
            this.lblTruck.Text = "Truck";
            // 
            // txtMode
            // 
            this.txtMode.AutoSize = true;
            this.txtMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMode.Location = new System.Drawing.Point(124, 39);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(47, 17);
            this.txtMode.TabIndex = 1;
            this.txtMode.Text = "Mode";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(32, 39);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(47, 17);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Mode";
            // 
            // frmNormalWeighing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 743);
            this.Controls.Add(this.grpboxNormalWeighing);
            this.Name = "frmNormalWeighing";
            this.Text = "frmNormalWeighing";
            this.grpboxNormalWeighing.ResumeLayout(false);
            this.grpboxNormalWeighing.PerformLayout();
            this.grpboxWeightInfo.ResumeLayout(false);
            this.grpboxWeightInfo.PerformLayout();
            this.grpboxChallanInfo.ResumeLayout(false);
            this.grpboxChallanInfo.PerformLayout();
            this.grpboxOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxNormalWeighing;
        private System.Windows.Forms.TextBox txtTranspoterName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblTransporterCode;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.ComboBox cmbTranspoterCode;
        private System.Windows.Forms.ComboBox cmbCustomerCode;
        private System.Windows.Forms.ComboBox cmbProductCode;
        private System.Windows.Forms.TextBox txtTruck;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.Label txtMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.GroupBox grpboxChallanInfo;
        private System.Windows.Forms.ComboBox cmbChallanWeight;
        private System.Windows.Forms.Label lblChallanWeight;
        private System.Windows.Forms.TextBox txtChallanDate;
        private System.Windows.Forms.TextBox txtChallanNumber;
        private System.Windows.Forms.Label lblChallanDate;
        private System.Windows.Forms.Label lblChallanNumber;
        private System.Windows.Forms.GroupBox grpboxOperation;
        private System.Windows.Forms.Label lblDeliveryNoteN;
        private System.Windows.Forms.Label lblMiscellaneous;
        private System.Windows.Forms.TextBox txtDeliveryNoteN;
        private System.Windows.Forms.TextBox txtMiscellaneous1;
        private System.Windows.Forms.TextBox txtMiscellaneous;
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
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox txtChallanWeight;
        private System.Windows.Forms.ListBox lstTruck;
    }
}