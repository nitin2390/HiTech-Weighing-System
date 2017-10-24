namespace HitechTMS
{
    partial class frmDateFiltersForReports
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
            this.grpBoxProductInOut = new System.Windows.Forms.GroupBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtPicketToDate = new System.Windows.Forms.DateTimePicker();
            this.dtPicketFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblTypeOfWeighing = new System.Windows.Forms.Label();
            this.grpBoxProductInOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxProductInOut
            // 
            this.grpBoxProductInOut.Controls.Add(this.lblDateTo);
            this.grpBoxProductInOut.Controls.Add(this.lblDateFrom);
            this.grpBoxProductInOut.Controls.Add(this.dtPicketToDate);
            this.grpBoxProductInOut.Controls.Add(this.dtPicketFromDate);
            this.grpBoxProductInOut.Controls.Add(this.btnCancel);
            this.grpBoxProductInOut.Controls.Add(this.btnOk);
            this.grpBoxProductInOut.Controls.Add(this.lblTypeOfWeighing);
            this.grpBoxProductInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxProductInOut.Location = new System.Drawing.Point(12, 9);
            this.grpBoxProductInOut.Name = "grpBoxProductInOut";
            this.grpBoxProductInOut.Size = new System.Drawing.Size(462, 327);
            this.grpBoxProductInOut.TabIndex = 4;
            this.grpBoxProductInOut.TabStop = false;
            this.grpBoxProductInOut.Text = "Select Date Range";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(77, 159);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(76, 20);
            this.lblDateTo.TabIndex = 40;
            this.lblDateTo.Text = "Date To";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(77, 117);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(98, 20);
            this.lblDateFrom.TabIndex = 39;
            this.lblDateFrom.Text = "Date From";
            // 
            // dtPicketToDate
            // 
            this.dtPicketToDate.AllowDrop = true;
            this.dtPicketToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicketToDate.Location = new System.Drawing.Point(184, 159);
            this.dtPicketToDate.Name = "dtPicketToDate";
            this.dtPicketToDate.Size = new System.Drawing.Size(151, 26);
            this.dtPicketToDate.TabIndex = 38;
            // 
            // dtPicketFromDate
            // 
            this.dtPicketFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPicketFromDate.Location = new System.Drawing.Point(184, 113);
            this.dtPicketFromDate.Name = "dtPicketFromDate";
            this.dtPicketFromDate.Size = new System.Drawing.Size(151, 26);
            this.dtPicketFromDate.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 50);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(77, 222);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(134, 50);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblTypeOfWeighing
            // 
            this.lblTypeOfWeighing.AutoSize = true;
            this.lblTypeOfWeighing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTypeOfWeighing.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeOfWeighing.Location = new System.Drawing.Point(58, 46);
            this.lblTypeOfWeighing.Name = "lblTypeOfWeighing";
            this.lblTypeOfWeighing.Size = new System.Drawing.Size(318, 31);
            this.lblTypeOfWeighing.TabIndex = 3;
            this.lblTypeOfWeighing.Text = "Select Date From To Date";
            // 
            // frmDateFiltersForReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 348);
            this.Controls.Add(this.grpBoxProductInOut);
            this.Name = "frmDateFiltersForReports";
            this.Text = "frmDateFiltersForReports";
            this.grpBoxProductInOut.ResumeLayout(false);
            this.grpBoxProductInOut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxProductInOut;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblTypeOfWeighing;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtPicketToDate;
        private System.Windows.Forms.DateTimePicker dtPicketFromDate;
    }
}