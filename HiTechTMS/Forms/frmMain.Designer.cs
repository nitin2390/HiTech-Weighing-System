﻿namespace HitechTMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transporterFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storedTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionPendingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weighingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiWeighingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
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
            this.switchUserToolStripMenuItem,
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
            this.storedTToolStripMenuItem,
            this.transactionPendingFileToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // productFileToolStripMenuItem
            // 
            this.productFileToolStripMenuItem.Name = "productFileToolStripMenuItem";
            this.productFileToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.productFileToolStripMenuItem.Text = "1 Product File";
            this.productFileToolStripMenuItem.Click += new System.EventHandler(this.productFileToolStripMenuItem_Click);
            // 
            // supplierFileToolStripMenuItem
            // 
            this.supplierFileToolStripMenuItem.Name = "supplierFileToolStripMenuItem";
            this.supplierFileToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.supplierFileToolStripMenuItem.Text = "2 Supplier File";
            this.supplierFileToolStripMenuItem.Click += new System.EventHandler(this.supplierFileToolStripMenuItem_Click);
            // 
            // transporterFileToolStripMenuItem
            // 
            this.transporterFileToolStripMenuItem.Name = "transporterFileToolStripMenuItem";
            this.transporterFileToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.transporterFileToolStripMenuItem.Text = "3 Transporter File";
            this.transporterFileToolStripMenuItem.Click += new System.EventHandler(this.transporterFileToolStripMenuItem_Click);
            // 
            // storedTToolStripMenuItem
            // 
            this.storedTToolStripMenuItem.Name = "storedTToolStripMenuItem";
            this.storedTToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.storedTToolStripMenuItem.Text = "4 Stored Tare File";
            this.storedTToolStripMenuItem.Click += new System.EventHandler(this.storedTToolStripMenuItem_Click);
            // 
            // transactionPendingFileToolStripMenuItem
            // 
            this.transactionPendingFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionFileToolStripMenuItem,
            this.pendingFileToolStripMenuItem,
            this.deletePendingToolStripMenuItem,
            this.deleteTransactionToolStripMenuItem});
            this.transactionPendingFileToolStripMenuItem.Name = "transactionPendingFileToolStripMenuItem";
            this.transactionPendingFileToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.transactionPendingFileToolStripMenuItem.Text = "Transaction / Pending File";
            // 
            // transactionFileToolStripMenuItem
            // 
            this.transactionFileToolStripMenuItem.Name = "transactionFileToolStripMenuItem";
            this.transactionFileToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.transactionFileToolStripMenuItem.Text = "Transaction File";
            // 
            // pendingFileToolStripMenuItem
            // 
            this.pendingFileToolStripMenuItem.Name = "pendingFileToolStripMenuItem";
            this.pendingFileToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.pendingFileToolStripMenuItem.Text = "Pending File";
            this.pendingFileToolStripMenuItem.Click += new System.EventHandler(this.pendingFileToolStripMenuItem_Click);
            // 
            // deletePendingToolStripMenuItem
            // 
            this.deletePendingToolStripMenuItem.Name = "deletePendingToolStripMenuItem";
            this.deletePendingToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.deletePendingToolStripMenuItem.Text = "Delete Pending";
            // 
            // deleteTransactionToolStripMenuItem
            // 
            this.deleteTransactionToolStripMenuItem.Name = "deleteTransactionToolStripMenuItem";
            this.deleteTransactionToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.deleteTransactionToolStripMenuItem.Text = "Delete Transaction";
            // 
            // switchUserToolStripMenuItem
            // 
            this.switchUserToolStripMenuItem.Name = "switchUserToolStripMenuItem";
            this.switchUserToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.switchUserToolStripMenuItem.Text = "&Switch user";
            this.switchUserToolStripMenuItem.Click += new System.EventHandler(this.switchUserToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
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
            this.weighingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.publicToolStripMenuItem,
            this.multiWeighingToolStripMenuItem});
            this.weighingToolStripMenuItem.Name = "weighingToolStripMenuItem";
            this.weighingToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.weighingToolStripMenuItem.Text = "&Weighing";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.normalToolStripMenuItem.Text = "1 Normal Weighing";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // publicToolStripMenuItem
            // 
            this.publicToolStripMenuItem.Name = "publicToolStripMenuItem";
            this.publicToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.publicToolStripMenuItem.Text = "2 Public Weighing";
            this.publicToolStripMenuItem.Click += new System.EventHandler(this.publicToolStripMenuItem_Click);
            // 
            // multiWeighingToolStripMenuItem
            // 
            this.multiWeighingToolStripMenuItem.Name = "multiWeighingToolStripMenuItem";
            this.multiWeighingToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.multiWeighingToolStripMenuItem.Text = "3 Multi Weighing";
            this.multiWeighingToolStripMenuItem.Click += new System.EventHandler(this.multiWeighingToolStripMenuItem_Click);
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
            this.emailConfigToolStripMenuItem,
            this.addUserToolStripMenuItem});
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
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(565, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
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
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "main";
            this.Text = "HiTech Weighing System";
            this.UserIsAllowed += new System.EventHandler(this.frmMain_UserIsAllowed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionPendingFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiWeighingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchUserToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

