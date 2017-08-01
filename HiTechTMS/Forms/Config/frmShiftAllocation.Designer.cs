namespace HitechTMS.MasterForms
{
    partial class frmShiftAllocation
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpBoxShiftAllocation = new System.Windows.Forms.GroupBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.dtpEndC = new System.Windows.Forms.DateTimePicker();
            this.dtpStartC = new System.Windows.Forms.DateTimePicker();
            this.dtpEndB = new System.Windows.Forms.DateTimePicker();
            this.dtpStartB = new System.Windows.Forms.DateTimePicker();
            this.dtpEndA = new System.Windows.Forms.DateTimePicker();
            this.dtpStartA = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblC = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.LblA = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblNoofShifts = new System.Windows.Forms.Label();
            this.grpBoxShiftAllocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 6000;
            // 
            // grpBoxShiftAllocation
            // 
            this.grpBoxShiftAllocation.Controls.Add(this.lblStartTime);
            this.grpBoxShiftAllocation.Controls.Add(this.lblEndTime);
            this.grpBoxShiftAllocation.Controls.Add(this.cmbShift);
            this.grpBoxShiftAllocation.Controls.Add(this.dtpEndC);
            this.grpBoxShiftAllocation.Controls.Add(this.dtpStartC);
            this.grpBoxShiftAllocation.Controls.Add(this.dtpEndB);
            this.grpBoxShiftAllocation.Controls.Add(this.dtpStartB);
            this.grpBoxShiftAllocation.Controls.Add(this.dtpEndA);
            this.grpBoxShiftAllocation.Controls.Add(this.dtpStartA);
            this.grpBoxShiftAllocation.Controls.Add(this.btnClose);
            this.grpBoxShiftAllocation.Controls.Add(this.btnOK);
            this.grpBoxShiftAllocation.Controls.Add(this.lblC);
            this.grpBoxShiftAllocation.Controls.Add(this.lblB);
            this.grpBoxShiftAllocation.Controls.Add(this.LblA);
            this.grpBoxShiftAllocation.Controls.Add(this.lblShift);
            this.grpBoxShiftAllocation.Controls.Add(this.lblNoofShifts);
            this.grpBoxShiftAllocation.Location = new System.Drawing.Point(12, 12);
            this.grpBoxShiftAllocation.Name = "grpBoxShiftAllocation";
            this.grpBoxShiftAllocation.Size = new System.Drawing.Size(494, 354);
            this.grpBoxShiftAllocation.TabIndex = 26;
            this.grpBoxShiftAllocation.TabStop = false;
            this.grpBoxShiftAllocation.Text = "Shift Allocation";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(152, 87);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(102, 19);
            this.lblStartTime.TabIndex = 41;
            this.lblStartTime.Text = "START TIME";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(316, 87);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(83, 19);
            this.lblEndTime.TabIndex = 40;
            this.lblEndTime.Text = "END TIME";
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(152, 41);
            this.cmbShift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(179, 24);
            this.cmbShift.TabIndex = 1;
            this.cmbShift.SelectedIndexChanged += new System.EventHandler(this.cmbShift_SelectedIndexChanged);
            // 
            // dtpEndC
            // 
            this.dtpEndC.CustomFormat = "hh:mm:ss";
            this.dtpEndC.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndC.Location = new System.Drawing.Point(314, 236);
            this.dtpEndC.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndC.Name = "dtpEndC";
            this.dtpEndC.ShowUpDown = true;
            this.dtpEndC.Size = new System.Drawing.Size(124, 22);
            this.dtpEndC.TabIndex = 7;
            // 
            // dtpStartC
            // 
            this.dtpStartC.CustomFormat = "hh:mm:ss";
            this.dtpStartC.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartC.Location = new System.Drawing.Point(152, 236);
            this.dtpStartC.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartC.Name = "dtpStartC";
            this.dtpStartC.ShowUpDown = true;
            this.dtpStartC.Size = new System.Drawing.Size(124, 22);
            this.dtpStartC.TabIndex = 6;
            // 
            // dtpEndB
            // 
            this.dtpEndB.CustomFormat = "hh:mm:ss";
            this.dtpEndB.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndB.Location = new System.Drawing.Point(316, 178);
            this.dtpEndB.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndB.Name = "dtpEndB";
            this.dtpEndB.ShowUpDown = true;
            this.dtpEndB.Size = new System.Drawing.Size(124, 22);
            this.dtpEndB.TabIndex = 5;
            // 
            // dtpStartB
            // 
            this.dtpStartB.CustomFormat = "hh:mm:ss";
            this.dtpStartB.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartB.Location = new System.Drawing.Point(152, 178);
            this.dtpStartB.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartB.Name = "dtpStartB";
            this.dtpStartB.ShowUpDown = true;
            this.dtpStartB.Size = new System.Drawing.Size(124, 22);
            this.dtpStartB.TabIndex = 4;
            // 
            // dtpEndA
            // 
            this.dtpEndA.CustomFormat = "hh:mm:ss";
            this.dtpEndA.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndA.Location = new System.Drawing.Point(316, 125);
            this.dtpEndA.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndA.Name = "dtpEndA";
            this.dtpEndA.ShowUpDown = true;
            this.dtpEndA.Size = new System.Drawing.Size(124, 22);
            this.dtpEndA.TabIndex = 3;
            // 
            // dtpStartA
            // 
            this.dtpStartA.CustomFormat = "hh:mm:ss";
            this.dtpStartA.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartA.Location = new System.Drawing.Point(152, 125);
            this.dtpStartA.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartA.Name = "dtpStartA";
            this.dtpStartA.ShowUpDown = true;
            this.dtpStartA.Size = new System.Drawing.Size(124, 22);
            this.dtpStartA.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(316, 285);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(152, 285);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(54, 241);
            this.lblC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(17, 17);
            this.lblC.TabIndex = 30;
            this.lblC.Text = "C";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(54, 181);
            this.lblB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(17, 17);
            this.lblB.TabIndex = 29;
            this.lblB.Text = "B";
            // 
            // LblA
            // 
            this.LblA.AutoSize = true;
            this.LblA.Location = new System.Drawing.Point(54, 130);
            this.LblA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblA.Name = "LblA";
            this.LblA.Size = new System.Drawing.Size(17, 17);
            this.LblA.TabIndex = 28;
            this.LblA.Text = "A";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(57, 87);
            this.lblShift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(54, 19);
            this.lblShift.TabIndex = 27;
            this.lblShift.Text = "SHIFT";
            // 
            // lblNoofShifts
            // 
            this.lblNoofShifts.AutoSize = true;
            this.lblNoofShifts.Location = new System.Drawing.Point(54, 41);
            this.lblNoofShifts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoofShifts.Name = "lblNoofShifts";
            this.lblNoofShifts.Size = new System.Drawing.Size(81, 17);
            this.lblNoofShifts.TabIndex = 26;
            this.lblNoofShifts.Text = "No of Shifts";
            // 
            // frmShiftAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 378);
            this.Controls.Add(this.grpBoxShiftAllocation);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmShiftAllocation";
            this.Text = "Shift Allocation";
            this.Load += new System.EventHandler(this.frmShiftAllocation_Load);
            this.grpBoxShiftAllocation.ResumeLayout(false);
            this.grpBoxShiftAllocation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grpBoxShiftAllocation;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.DateTimePicker dtpEndC;
        private System.Windows.Forms.DateTimePicker dtpStartC;
        private System.Windows.Forms.DateTimePicker dtpEndB;
        private System.Windows.Forms.DateTimePicker dtpStartB;
        private System.Windows.Forms.DateTimePicker dtpEndA;
        private System.Windows.Forms.DateTimePicker dtpStartA;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label LblA;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblNoofShifts;
    }
}