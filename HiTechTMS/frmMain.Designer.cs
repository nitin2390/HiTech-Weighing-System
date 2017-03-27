namespace HitechTMS
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
            this.Check = new System.Windows.Forms.Button();
            this.lstSerialPortCommunication = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.tabMode = new System.Windows.Forms.TabPage();
            this.tabWeighing = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transporterFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storedTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weighingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perifeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peripheralDiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabMode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Check
            // 
            this.Check.Location = new System.Drawing.Point(8, 18);
            this.Check.Margin = new System.Windows.Forms.Padding(4);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(100, 28);
            this.Check.TabIndex = 18;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // lstSerialPortCommunication
            // 
            this.lstSerialPortCommunication.FormattingEnabled = true;
            this.lstSerialPortCommunication.ItemHeight = 16;
            this.lstSerialPortCommunication.Location = new System.Drawing.Point(11, 90);
            this.lstSerialPortCommunication.Margin = new System.Windows.Forms.Padding(4);
            this.lstSerialPortCommunication.Name = "lstSerialPortCommunication";
            this.lstSerialPortCommunication.Size = new System.Drawing.Size(485, 292);
            this.lstSerialPortCommunication.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(397, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(181, 18);
            this.btnClearList.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(100, 28);
            this.btnClearList.TabIndex = 21;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFile);
            this.tabControl1.Controls.Add(this.tabMode);
            this.tabControl1.Controls.Add(this.tabWeighing);
            this.tabControl1.Location = new System.Drawing.Point(12, 103);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 363);
            this.tabControl1.TabIndex = 22;
            // 
            // tabFile
            // 
            this.tabFile.Location = new System.Drawing.Point(4, 25);
            this.tabFile.Margin = new System.Windows.Forms.Padding(4);
            this.tabFile.Name = "tabFile";
            this.tabFile.Size = new System.Drawing.Size(908, 334);
            this.tabFile.TabIndex = 2;
            this.tabFile.Text = "File";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // tabMode
            // 
            this.tabMode.Controls.Add(this.Check);
            this.tabMode.Controls.Add(this.lstSerialPortCommunication);
            this.tabMode.Controls.Add(this.btnClose);
            this.tabMode.Controls.Add(this.btnClearList);
            this.tabMode.Location = new System.Drawing.Point(4, 25);
            this.tabMode.Margin = new System.Windows.Forms.Padding(4);
            this.tabMode.Name = "tabMode";
            this.tabMode.Padding = new System.Windows.Forms.Padding(4);
            this.tabMode.Size = new System.Drawing.Size(908, 334);
            this.tabMode.TabIndex = 0;
            this.tabMode.Text = "Mode";
            this.tabMode.UseVisualStyleBackColor = true;
            // 
            // tabWeighing
            // 
            this.tabWeighing.Location = new System.Drawing.Point(4, 25);
            this.tabWeighing.Margin = new System.Windows.Forms.Padding(4);
            this.tabWeighing.Name = "tabWeighing";
            this.tabWeighing.Padding = new System.Windows.Forms.Padding(4);
            this.tabWeighing.Size = new System.Drawing.Size(908, 334);
            this.tabWeighing.TabIndex = 1;
            this.tabWeighing.Text = "Weighing";
            this.tabWeighing.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.weighingToolStripMenuItem,
            this.ticketsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.perifeToolStripMenuItem,
            this.peripheralDiagnosticsToolStripMenuItem,
            this.utilityToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(955, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productFileToolStripMenuItem,
            this.supplierFileToolStripMenuItem,
            this.transporterFileToolStripMenuItem,
            this.storedTToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // productFileToolStripMenuItem
            // 
            this.productFileToolStripMenuItem.Name = "productFileToolStripMenuItem";
            this.productFileToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.productFileToolStripMenuItem.Text = "1 Product File";
            this.productFileToolStripMenuItem.Click += new System.EventHandler(this.productFileToolStripMenuItem_Click);
            // 
            // supplierFileToolStripMenuItem
            // 
            this.supplierFileToolStripMenuItem.Name = "supplierFileToolStripMenuItem";
            this.supplierFileToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.supplierFileToolStripMenuItem.Text = "2 Supplier File";
            this.supplierFileToolStripMenuItem.Click += new System.EventHandler(this.supplierFileToolStripMenuItem_Click);
            // 
            // transporterFileToolStripMenuItem
            // 
            this.transporterFileToolStripMenuItem.Name = "transporterFileToolStripMenuItem";
            this.transporterFileToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.transporterFileToolStripMenuItem.Text = "3 Transporter File";
            // 
            // storedTToolStripMenuItem
            // 
            this.storedTToolStripMenuItem.Name = "storedTToolStripMenuItem";
            this.storedTToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.storedTToolStripMenuItem.Text = "4 Stored Tare File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.modeToolStripMenuItem.Text = "&Mode";
            // 
            // weighingToolStripMenuItem
            // 
            this.weighingToolStripMenuItem.Name = "weighingToolStripMenuItem";
            this.weighingToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.weighingToolStripMenuItem.Text = "&Weighing";
            // 
            // ticketsToolStripMenuItem
            // 
            this.ticketsToolStripMenuItem.Name = "ticketsToolStripMenuItem";
            this.ticketsToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.ticketsToolStripMenuItem.Text = "&Tickets";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // perifeToolStripMenuItem
            // 
            this.perifeToolStripMenuItem.Name = "perifeToolStripMenuItem";
            this.perifeToolStripMenuItem.Size = new System.Drawing.Size(12, 24);
            // 
            // peripheralDiagnosticsToolStripMenuItem
            // 
            this.peripheralDiagnosticsToolStripMenuItem.Name = "peripheralDiagnosticsToolStripMenuItem";
            this.peripheralDiagnosticsToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.peripheralDiagnosticsToolStripMenuItem.Text = "&Peripheral Diagnostics";
            // 
            // utilityToolStripMenuItem
            // 
            this.utilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseBackupToolStripMenuItem});
            this.utilityToolStripMenuItem.Name = "utilityToolStripMenuItem";
            this.utilityToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.utilityToolStripMenuItem.Text = "&Utility";
            // 
            // databaseBackupToolStripMenuItem
            // 
            this.databaseBackupToolStripMenuItem.Name = "databaseBackupToolStripMenuItem";
            this.databaseBackupToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.databaseBackupToolStripMenuItem.Text = "Database Backup";
            this.databaseBackupToolStripMenuItem.Click += new System.EventHandler(this.databaseBackupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailConfigToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // emailConfigToolStripMenuItem
            // 
            this.emailConfigToolStripMenuItem.Name = "emailConfigToolStripMenuItem";
            this.emailConfigToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.emailConfigToolStripMenuItem.Text = "Email Config";
            this.emailConfigToolStripMenuItem.Click += new System.EventHandler(this.emailConfigToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 24;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 591);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HiTech Weighing System";
            this.UserIsAllowed += new System.EventHandler(this.frmMain_UserIsAllowed);
            this.tabControl1.ResumeLayout(false);
            this.tabMode.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.ListBox lstSerialPortCommunication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.TabPage tabMode;
        private System.Windows.Forms.TabPage tabWeighing;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weighingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perifeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transporterFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storedTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peripheralDiagnosticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseBackupToolStripMenuItem;
    }
}

