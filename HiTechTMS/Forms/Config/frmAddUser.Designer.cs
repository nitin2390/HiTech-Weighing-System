namespace HitechTMS.Config
{
    partial class frmAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUser));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.gridUser = new System.Windows.Forms.DataGridView();
            this.btnEmailExcel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbRoleType = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.errProviderUserName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProviderRole = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderRole)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRecCount);
            this.groupBox1.Controls.Add(this.lblRecordsCount);
            this.groupBox1.Controls.Add(this.gridUser);
            this.groupBox1.Controls.Add(this.btnEmailExcel);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cmbRoleType);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.lblRole);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 595);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Edit User";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.Location = new System.Drawing.Point(564, 546);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(136, 22);
            this.lblRecCount.TabIndex = 30;
            this.lblRecCount.Text = "Records Count";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecordsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(720, 546);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(60, 22);
            this.lblRecordsCount.TabIndex = 29;
            this.lblRecordsCount.Text = "Count";
            // 
            // gridUser
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridUser.Location = new System.Drawing.Point(74, 287);
            this.gridUser.Name = "gridUser";
            this.gridUser.RowTemplate.Height = 24;
            this.gridUser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridUser.Size = new System.Drawing.Size(706, 243);
            this.gridUser.TabIndex = 31;
            this.gridUser.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridUser_CellMouseClick);
            // 
            // btnEmailExcel
            // 
            this.btnEmailExcel.Location = new System.Drawing.Point(487, 228);
            this.btnEmailExcel.Name = "btnEmailExcel";
            this.btnEmailExcel.Size = new System.Drawing.Size(115, 27);
            this.btnEmailExcel.TabIndex = 27;
            this.btnEmailExcel.Text = "E&mail As Excel";
            this.btnEmailExcel.UseVisualStyleBackColor = true;
            this.btnEmailExcel.Click += new System.EventHandler(this.btnEmailExcel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(369, 228);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 27);
            this.btnReport.TabIndex = 26;
            this.btnReport.Text = "&Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(241, 228);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 27);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(620, 228);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 27);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(107, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbRoleType
            // 
            this.cmbRoleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbRoleType.FormattingEnabled = true;
            this.cmbRoleType.Location = new System.Drawing.Point(368, 161);
            this.cmbRoleType.Name = "cmbRoleType";
            this.cmbRoleType.Size = new System.Drawing.Size(121, 24);
            this.cmbRoleType.TabIndex = 5;
            this.cmbRoleType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRoleType_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(368, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(133, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(264, 164);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(37, 17);
            this.lblRole.TabIndex = 3;
            this.lblRole.Text = "Role";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(264, 111);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(264, 57);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 17);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(368, 57);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(133, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // errProviderUserName
            // 
            this.errProviderUserName.ContainerControl = this;
            // 
            // errProviderPassword
            // 
            this.errProviderPassword.ContainerControl = this;
            // 
            // errProviderRole
            // 
            this.errProviderRole.ContainerControl = this;
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 623);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddUser";
            this.Tag = "AddUser";
            this.Text = "frmAddUser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRoleType;
        private System.Windows.Forms.Button btnEmailExcel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.DataGridView gridUser;
        private System.Windows.Forms.ErrorProvider errProviderUserName;
        private System.Windows.Forms.ErrorProvider errProviderPassword;
        private System.Windows.Forms.ErrorProvider errProviderRole;
    }
}