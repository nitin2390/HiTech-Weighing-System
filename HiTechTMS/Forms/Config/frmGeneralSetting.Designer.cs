namespace HitechTMS.MasterForms
{
    partial class frmGeneralSetting
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
            this.gpBoxGenralSetting = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbTicketReportPrintingMode = new System.Windows.Forms.ComboBox();
            this.cmbReportFormat = new System.Windows.Forms.ComboBox();
            this.cmbTicketFormat = new System.Windows.Forms.ComboBox();
            this.cmbFirstWeightTicket = new System.Windows.Forms.ComboBox();
            this.cmbStoredTare = new System.Windows.Forms.ComboBox();
            this.txtMinimumNetWtLimit = new System.Windows.Forms.TextBox();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.gpBoxDraftModeTicketPrintingSetting = new System.Windows.Forms.GroupBox();
            this.txtFooterBlankLine = new System.Windows.Forms.TextBox();
            this.txtHeaderBlankLine = new System.Windows.Forms.TextBox();
            this.lblFooterBlankLine = new System.Windows.Forms.Label();
            this.lblHeaderBlankLine = new System.Windows.Forms.Label();
            this.lblTicketReportPrintingMode = new System.Windows.Forms.Label();
            this.lblReportFormat = new System.Windows.Forms.Label();
            this.lblTicketFormat = new System.Windows.Forms.Label();
            this.lblFirstWeightTicket = new System.Windows.Forms.Label();
            this.lblStoredTare = new System.Windows.Forms.Label();
            this.lblMinimumNetWtLimit = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblTransactionNo = new System.Windows.Forms.Label();
            this.errorProviderSetting = new System.Windows.Forms.ErrorProvider(this.components);
            this.gpBoxGenralSetting.SuspendLayout();
            this.gpBoxDraftModeTicketPrintingSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // gpBoxGenralSetting
            // 
            this.gpBoxGenralSetting.Controls.Add(this.btnClose);
            this.gpBoxGenralSetting.Controls.Add(this.btnOk);
            this.gpBoxGenralSetting.Controls.Add(this.cmbTicketReportPrintingMode);
            this.gpBoxGenralSetting.Controls.Add(this.cmbReportFormat);
            this.gpBoxGenralSetting.Controls.Add(this.cmbTicketFormat);
            this.gpBoxGenralSetting.Controls.Add(this.cmbFirstWeightTicket);
            this.gpBoxGenralSetting.Controls.Add(this.cmbStoredTare);
            this.gpBoxGenralSetting.Controls.Add(this.txtMinimumNetWtLimit);
            this.gpBoxGenralSetting.Controls.Add(this.cmbMode);
            this.gpBoxGenralSetting.Controls.Add(this.txtTransactionNo);
            this.gpBoxGenralSetting.Controls.Add(this.gpBoxDraftModeTicketPrintingSetting);
            this.gpBoxGenralSetting.Controls.Add(this.lblTicketReportPrintingMode);
            this.gpBoxGenralSetting.Controls.Add(this.lblReportFormat);
            this.gpBoxGenralSetting.Controls.Add(this.lblTicketFormat);
            this.gpBoxGenralSetting.Controls.Add(this.lblFirstWeightTicket);
            this.gpBoxGenralSetting.Controls.Add(this.lblStoredTare);
            this.gpBoxGenralSetting.Controls.Add(this.lblMinimumNetWtLimit);
            this.gpBoxGenralSetting.Controls.Add(this.lblMode);
            this.gpBoxGenralSetting.Controls.Add(this.lblTransactionNo);
            this.gpBoxGenralSetting.Location = new System.Drawing.Point(12, 12);
            this.gpBoxGenralSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpBoxGenralSetting.Name = "gpBoxGenralSetting";
            this.gpBoxGenralSetting.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpBoxGenralSetting.Size = new System.Drawing.Size(559, 634);
            this.gpBoxGenralSetting.TabIndex = 0;
            this.gpBoxGenralSetting.TabStop = false;
            this.gpBoxGenralSetting.Text = "General Setting";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(297, 571);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 39);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(171, 571);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 39);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbTicketReportPrintingMode
            // 
            this.cmbTicketReportPrintingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTicketReportPrintingMode.FormattingEnabled = true;
            this.cmbTicketReportPrintingMode.Location = new System.Drawing.Point(323, 362);
            this.cmbTicketReportPrintingMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTicketReportPrintingMode.Name = "cmbTicketReportPrintingMode";
            this.cmbTicketReportPrintingMode.Size = new System.Drawing.Size(179, 24);
            this.cmbTicketReportPrintingMode.TabIndex = 8;
            // 
            // cmbReportFormat
            // 
            this.cmbReportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportFormat.FormattingEnabled = true;
            this.cmbReportFormat.Location = new System.Drawing.Point(323, 316);
            this.cmbReportFormat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbReportFormat.Name = "cmbReportFormat";
            this.cmbReportFormat.Size = new System.Drawing.Size(179, 24);
            this.cmbReportFormat.TabIndex = 7;
            // 
            // cmbTicketFormat
            // 
            this.cmbTicketFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTicketFormat.FormattingEnabled = true;
            this.cmbTicketFormat.Location = new System.Drawing.Point(323, 270);
            this.cmbTicketFormat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTicketFormat.Name = "cmbTicketFormat";
            this.cmbTicketFormat.Size = new System.Drawing.Size(179, 24);
            this.cmbTicketFormat.TabIndex = 6;
            // 
            // cmbFirstWeightTicket
            // 
            this.cmbFirstWeightTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFirstWeightTicket.FormattingEnabled = true;
            this.cmbFirstWeightTicket.Location = new System.Drawing.Point(323, 219);
            this.cmbFirstWeightTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFirstWeightTicket.Name = "cmbFirstWeightTicket";
            this.cmbFirstWeightTicket.Size = new System.Drawing.Size(179, 24);
            this.cmbFirstWeightTicket.TabIndex = 5;
            // 
            // cmbStoredTare
            // 
            this.cmbStoredTare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoredTare.FormattingEnabled = true;
            this.cmbStoredTare.Location = new System.Drawing.Point(323, 175);
            this.cmbStoredTare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbStoredTare.Name = "cmbStoredTare";
            this.cmbStoredTare.Size = new System.Drawing.Size(179, 24);
            this.cmbStoredTare.TabIndex = 4;
            // 
            // txtMinimumNetWtLimit
            // 
            this.txtMinimumNetWtLimit.AcceptsReturn = true;
            this.txtMinimumNetWtLimit.Location = new System.Drawing.Point(323, 128);
            this.txtMinimumNetWtLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMinimumNetWtLimit.MaxLength = 6;
            this.txtMinimumNetWtLimit.Name = "txtMinimumNetWtLimit";
            this.txtMinimumNetWtLimit.Size = new System.Drawing.Size(179, 22);
            this.txtMinimumNetWtLimit.TabIndex = 3;
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Location = new System.Drawing.Point(323, 76);
            this.cmbMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(179, 24);
            this.cmbMode.TabIndex = 2;
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Location = new System.Drawing.Point(323, 34);
            this.txtTransactionNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTransactionNo.MaxLength = 5;
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(179, 22);
            this.txtTransactionNo.TabIndex = 1;
            // 
            // gpBoxDraftModeTicketPrintingSetting
            // 
            this.gpBoxDraftModeTicketPrintingSetting.Controls.Add(this.txtFooterBlankLine);
            this.gpBoxDraftModeTicketPrintingSetting.Controls.Add(this.txtHeaderBlankLine);
            this.gpBoxDraftModeTicketPrintingSetting.Controls.Add(this.lblFooterBlankLine);
            this.gpBoxDraftModeTicketPrintingSetting.Controls.Add(this.lblHeaderBlankLine);
            this.gpBoxDraftModeTicketPrintingSetting.Location = new System.Drawing.Point(143, 415);
            this.gpBoxDraftModeTicketPrintingSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpBoxDraftModeTicketPrintingSetting.Name = "gpBoxDraftModeTicketPrintingSetting";
            this.gpBoxDraftModeTicketPrintingSetting.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpBoxDraftModeTicketPrintingSetting.Size = new System.Drawing.Size(292, 130);
            this.gpBoxDraftModeTicketPrintingSetting.TabIndex = 10;
            this.gpBoxDraftModeTicketPrintingSetting.TabStop = false;
            this.gpBoxDraftModeTicketPrintingSetting.Text = "Draft Mode Ticket Printing Setting";
            // 
            // txtFooterBlankLine
            // 
            this.txtFooterBlankLine.Location = new System.Drawing.Point(177, 75);
            this.txtFooterBlankLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFooterBlankLine.MaxLength = 2;
            this.txtFooterBlankLine.Name = "txtFooterBlankLine";
            this.txtFooterBlankLine.Size = new System.Drawing.Size(89, 22);
            this.txtFooterBlankLine.TabIndex = 10;
            // 
            // txtHeaderBlankLine
            // 
            this.txtHeaderBlankLine.Location = new System.Drawing.Point(177, 32);
            this.txtHeaderBlankLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHeaderBlankLine.MaxLength = 2;
            this.txtHeaderBlankLine.Name = "txtHeaderBlankLine";
            this.txtHeaderBlankLine.Size = new System.Drawing.Size(89, 22);
            this.txtHeaderBlankLine.TabIndex = 9;
            // 
            // lblFooterBlankLine
            // 
            this.lblFooterBlankLine.AutoSize = true;
            this.lblFooterBlankLine.Location = new System.Drawing.Point(37, 79);
            this.lblFooterBlankLine.Name = "lblFooterBlankLine";
            this.lblFooterBlankLine.Size = new System.Drawing.Size(115, 17);
            this.lblFooterBlankLine.TabIndex = 12;
            this.lblFooterBlankLine.Text = "Fotter Blank Line";
            // 
            // lblHeaderBlankLine
            // 
            this.lblHeaderBlankLine.AutoSize = true;
            this.lblHeaderBlankLine.Location = new System.Drawing.Point(37, 32);
            this.lblHeaderBlankLine.Name = "lblHeaderBlankLine";
            this.lblHeaderBlankLine.Size = new System.Drawing.Size(125, 17);
            this.lblHeaderBlankLine.TabIndex = 11;
            this.lblHeaderBlankLine.Text = "Header Blank Line";
            // 
            // lblTicketReportPrintingMode
            // 
            this.lblTicketReportPrintingMode.AutoSize = true;
            this.lblTicketReportPrintingMode.Location = new System.Drawing.Point(99, 369);
            this.lblTicketReportPrintingMode.Name = "lblTicketReportPrintingMode";
            this.lblTicketReportPrintingMode.Size = new System.Drawing.Size(184, 17);
            this.lblTicketReportPrintingMode.TabIndex = 7;
            this.lblTicketReportPrintingMode.Text = "Ticket\\Report Printing Mode";
            // 
            // lblReportFormat
            // 
            this.lblReportFormat.AutoSize = true;
            this.lblReportFormat.Location = new System.Drawing.Point(99, 322);
            this.lblReportFormat.Name = "lblReportFormat";
            this.lblReportFormat.Size = new System.Drawing.Size(99, 17);
            this.lblReportFormat.TabIndex = 6;
            this.lblReportFormat.Text = "Report Format";
            // 
            // lblTicketFormat
            // 
            this.lblTicketFormat.AutoSize = true;
            this.lblTicketFormat.Location = new System.Drawing.Point(99, 273);
            this.lblTicketFormat.Name = "lblTicketFormat";
            this.lblTicketFormat.Size = new System.Drawing.Size(94, 17);
            this.lblTicketFormat.TabIndex = 5;
            this.lblTicketFormat.Text = "Ticket Format";
            // 
            // lblFirstWeightTicket
            // 
            this.lblFirstWeightTicket.AutoSize = true;
            this.lblFirstWeightTicket.Location = new System.Drawing.Point(99, 226);
            this.lblFirstWeightTicket.Name = "lblFirstWeightTicket";
            this.lblFirstWeightTicket.Size = new System.Drawing.Size(125, 17);
            this.lblFirstWeightTicket.TabIndex = 4;
            this.lblFirstWeightTicket.Text = "First Weight Ticket";
            // 
            // lblStoredTare
            // 
            this.lblStoredTare.AutoSize = true;
            this.lblStoredTare.Location = new System.Drawing.Point(99, 178);
            this.lblStoredTare.Name = "lblStoredTare";
            this.lblStoredTare.Size = new System.Drawing.Size(88, 17);
            this.lblStoredTare.TabIndex = 3;
            this.lblStoredTare.Text = " Stored Tare";
            // 
            // lblMinimumNetWtLimit
            // 
            this.lblMinimumNetWtLimit.AutoSize = true;
            this.lblMinimumNetWtLimit.Location = new System.Drawing.Point(99, 128);
            this.lblMinimumNetWtLimit.Name = "lblMinimumNetWtLimit";
            this.lblMinimumNetWtLimit.Size = new System.Drawing.Size(143, 17);
            this.lblMinimumNetWtLimit.TabIndex = 2;
            this.lblMinimumNetWtLimit.Text = "Minimum Net Wt Limit";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(99, 85);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(43, 17);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "Mode";
            // 
            // lblTransactionNo
            // 
            this.lblTransactionNo.AutoSize = true;
            this.lblTransactionNo.Location = new System.Drawing.Point(99, 39);
            this.lblTransactionNo.Name = "lblTransactionNo";
            this.lblTransactionNo.Size = new System.Drawing.Size(105, 17);
            this.lblTransactionNo.TabIndex = 0;
            this.lblTransactionNo.Text = "Transaction No";
            // 
            // errorProviderSetting
            // 
            this.errorProviderSetting.ContainerControl = this;
            // 
            // frmGeneralSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 658);
            this.Controls.Add(this.gpBoxGenralSetting);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGeneralSetting";
            this.Text = "General Setting";
            this.gpBoxGenralSetting.ResumeLayout(false);
            this.gpBoxGenralSetting.PerformLayout();
            this.gpBoxDraftModeTicketPrintingSetting.ResumeLayout(false);
            this.gpBoxDraftModeTicketPrintingSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpBoxGenralSetting;
        private System.Windows.Forms.GroupBox gpBoxDraftModeTicketPrintingSetting;
        private System.Windows.Forms.Label lblFooterBlankLine;
        private System.Windows.Forms.Label lblHeaderBlankLine;
        private System.Windows.Forms.Label lblTicketReportPrintingMode;
        private System.Windows.Forms.Label lblReportFormat;
        private System.Windows.Forms.Label lblTicketFormat;
        private System.Windows.Forms.Label lblFirstWeightTicket;
        private System.Windows.Forms.Label lblStoredTare;
        private System.Windows.Forms.Label lblMinimumNetWtLimit;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblTransactionNo;
        private System.Windows.Forms.ComboBox cmbTicketReportPrintingMode;
        private System.Windows.Forms.ComboBox cmbReportFormat;
        private System.Windows.Forms.ComboBox cmbTicketFormat;
        private System.Windows.Forms.ComboBox cmbFirstWeightTicket;
        private System.Windows.Forms.ComboBox cmbStoredTare;
        private System.Windows.Forms.TextBox txtMinimumNetWtLimit;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.TextBox txtFooterBlankLine;
        private System.Windows.Forms.TextBox txtHeaderBlankLine;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ErrorProvider errorProviderSetting;
    }
}