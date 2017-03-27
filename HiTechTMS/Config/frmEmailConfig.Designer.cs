namespace HitechTMS.MasterForms
{
    partial class frmEmailConfig
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
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmailServerPort = new System.Windows.Forms.TextBox();
            this.txtEmailSmtpServer = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmailRecipient = new System.Windows.Forms.TextBox();
            this.lblEmailRecipient = new System.Windows.Forms.Label();
            this.lblEmailBody = new System.Windows.Forms.Label();
            this.lblEmailSubject = new System.Windows.Forms.Label();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errProviderEmailID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderEmailSubject = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderEmailBody = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderRecipient = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderSMTPServer = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderSMTPServerPort = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmailID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmailSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmailBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderRecipient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderSMTPServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderSMTPServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmailId
            // 
            this.txtEmailId.Location = new System.Drawing.Point(161, 37);
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(163, 22);
            this.txtEmailId.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(161, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(163, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // txtEmailServerPort
            // 
            this.txtEmailServerPort.Location = new System.Drawing.Point(497, 37);
            this.txtEmailServerPort.Name = "txtEmailServerPort";
            this.txtEmailServerPort.Size = new System.Drawing.Size(163, 22);
            this.txtEmailServerPort.TabIndex = 2;
            // 
            // txtEmailSmtpServer
            // 
            this.txtEmailSmtpServer.Location = new System.Drawing.Point(497, 80);
            this.txtEmailSmtpServer.Name = "txtEmailSmtpServer";
            this.txtEmailSmtpServer.Size = new System.Drawing.Size(163, 22);
            this.txtEmailSmtpServer.TabIndex = 3;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(161, 286);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(68, 21);
            this.chkIsActive.TabIndex = 7;
            this.chkIsActive.Text = "Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(206, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(359, 378);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 30);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmailRecipient);
            this.groupBox1.Controls.Add(this.lblEmailRecipient);
            this.groupBox1.Controls.Add(this.lblEmailBody);
            this.groupBox1.Controls.Add(this.lblEmailSubject);
            this.groupBox1.Controls.Add(this.txtEmailSubject);
            this.groupBox1.Controls.Add(this.txtEmailBody);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEmailId);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtEmailServerPort);
            this.groupBox1.Controls.Add(this.chkIsActive);
            this.groupBox1.Controls.Add(this.txtEmailSmtpServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 434);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email Configuration";
            // 
            // txtEmailRecipient
            // 
            this.txtEmailRecipient.Location = new System.Drawing.Point(497, 130);
            this.txtEmailRecipient.Name = "txtEmailRecipient";
            this.txtEmailRecipient.Size = new System.Drawing.Size(163, 22);
            this.txtEmailRecipient.TabIndex = 5;
            // 
            // lblEmailRecipient
            // 
            this.lblEmailRecipient.AutoSize = true;
            this.lblEmailRecipient.Location = new System.Drawing.Point(360, 130);
            this.lblEmailRecipient.Name = "lblEmailRecipient";
            this.lblEmailRecipient.Size = new System.Drawing.Size(105, 17);
            this.lblEmailRecipient.TabIndex = 24;
            this.lblEmailRecipient.Text = "Email Recipient";
            // 
            // lblEmailBody
            // 
            this.lblEmailBody.AutoSize = true;
            this.lblEmailBody.Location = new System.Drawing.Point(24, 175);
            this.lblEmailBody.Name = "lblEmailBody";
            this.lblEmailBody.Size = new System.Drawing.Size(78, 17);
            this.lblEmailBody.TabIndex = 17;
            this.lblEmailBody.Text = "Email Body";
            // 
            // lblEmailSubject
            // 
            this.lblEmailSubject.AutoSize = true;
            this.lblEmailSubject.Location = new System.Drawing.Point(24, 130);
            this.lblEmailSubject.Name = "lblEmailSubject";
            this.lblEmailSubject.Size = new System.Drawing.Size(93, 17);
            this.lblEmailSubject.TabIndex = 16;
            this.lblEmailSubject.Text = "Email Subject";
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Location = new System.Drawing.Point(161, 127);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(163, 22);
            this.txtEmailSubject.TabIndex = 4;
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.Location = new System.Drawing.Point(161, 172);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.Size = new System.Drawing.Size(163, 87);
            this.txtEmailBody.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Smtp Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Server Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Email ID";
            // 
            // errProviderEmailID
            // 
            this.errProviderEmailID.ContainerControl = this;
            // 
            // errProviderPassword
            // 
            this.errProviderPassword.ContainerControl = this;
            // 
            // errProviderEmailSubject
            // 
            this.errProviderEmailSubject.ContainerControl = this;
            // 
            // errProviderEmailBody
            // 
            this.errProviderEmailBody.ContainerControl = this;
            // 
            // errProviderRecipient
            // 
            this.errProviderRecipient.ContainerControl = this;
            // 
            // errProviderSMTPServer
            // 
            this.errProviderSMTPServer.ContainerControl = this;
            // 
            // errProviderSMTPServerPort
            // 
            this.errProviderSMTPServerPort.ContainerControl = this;
            // 
            // frmEmailConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 471);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmailConfig";
            this.Text = "frmEmailConfig";
            this.Load += new System.EventHandler(this.frmEmailConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmailID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmailSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderEmailBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderRecipient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderSMTPServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderSMTPServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmailServerPort;
        private System.Windows.Forms.TextBox txtEmailSmtpServer;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmailBody;
        private System.Windows.Forms.Label lblEmailSubject;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.TextBox txtEmailBody;
        private System.Windows.Forms.TextBox txtEmailRecipient;
        private System.Windows.Forms.Label lblEmailRecipient;
        private System.Windows.Forms.ErrorProvider errProviderEmailID;
        private System.Windows.Forms.ErrorProvider errProviderPassword;
        private System.Windows.Forms.ErrorProvider errProviderEmailSubject;
        private System.Windows.Forms.ErrorProvider errProviderEmailBody;
        private System.Windows.Forms.ErrorProvider errProviderRecipient;
        private System.Windows.Forms.ErrorProvider errProviderSMTPServer;
        private System.Windows.Forms.ErrorProvider errProviderSMTPServerPort;
    }
}