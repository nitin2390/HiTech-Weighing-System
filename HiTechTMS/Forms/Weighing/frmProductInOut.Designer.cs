namespace HitechTMS.Weighing
{
    partial class frmProductInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductInOut));
            this.grpBoxProductInOut = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rdbProductOut = new System.Windows.Forms.RadioButton();
            this.rdbProductIn = new System.Windows.Forms.RadioButton();
            this.lblTypeOfWeighing = new System.Windows.Forms.Label();
            this.grpBoxProductInOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxProductInOut
            // 
            this.grpBoxProductInOut.Controls.Add(this.btnCancel);
            this.grpBoxProductInOut.Controls.Add(this.btnOk);
            this.grpBoxProductInOut.Controls.Add(this.rdbProductOut);
            this.grpBoxProductInOut.Controls.Add(this.rdbProductIn);
            this.grpBoxProductInOut.Controls.Add(this.lblTypeOfWeighing);
            this.grpBoxProductInOut.Location = new System.Drawing.Point(12, 9);
            this.grpBoxProductInOut.Name = "grpBoxProductInOut";
            this.grpBoxProductInOut.Size = new System.Drawing.Size(423, 302);
            this.grpBoxProductInOut.TabIndex = 3;
            this.grpBoxProductInOut.TabStop = false;
            this.grpBoxProductInOut.Text = "Select Product In / Out";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(209, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 36);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(101, 222);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 36);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rdbProductOut
            // 
            this.rdbProductOut.AutoSize = true;
            this.rdbProductOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProductOut.Location = new System.Drawing.Point(150, 157);
            this.rdbProductOut.Name = "rdbProductOut";
            this.rdbProductOut.Size = new System.Drawing.Size(131, 24);
            this.rdbProductOut.TabIndex = 5;
            this.rdbProductOut.Text = "Product Out";
            this.rdbProductOut.UseVisualStyleBackColor = true;
            // 
            // rdbProductIn
            // 
            this.rdbProductIn.AutoSize = true;
            this.rdbProductIn.Checked = true;
            this.rdbProductIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbProductIn.Location = new System.Drawing.Point(150, 109);
            this.rdbProductIn.Name = "rdbProductIn";
            this.rdbProductIn.Size = new System.Drawing.Size(116, 24);
            this.rdbProductIn.TabIndex = 4;
            this.rdbProductIn.TabStop = true;
            this.rdbProductIn.Text = "Product In";
            this.rdbProductIn.UseVisualStyleBackColor = true;
            // 
            // lblTypeOfWeighing
            // 
            this.lblTypeOfWeighing.AutoSize = true;
            this.lblTypeOfWeighing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTypeOfWeighing.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeOfWeighing.Location = new System.Drawing.Point(98, 46);
            this.lblTypeOfWeighing.Name = "lblTypeOfWeighing";
            this.lblTypeOfWeighing.Size = new System.Drawing.Size(262, 31);
            this.lblTypeOfWeighing.TabIndex = 3;
            this.lblTypeOfWeighing.Text = "TYPE OF WEIGHING";
            // 
            // frmProductInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 325);
            this.Controls.Add(this.grpBoxProductInOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductInOut";
            this.Tag = "ProductInOut";
            this.Text = "frmProductInOut";
            this.grpBoxProductInOut.ResumeLayout(false);
            this.grpBoxProductInOut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxProductInOut;
        private System.Windows.Forms.RadioButton rdbProductOut;
        private System.Windows.Forms.RadioButton rdbProductIn;
        private System.Windows.Forms.Label lblTypeOfWeighing;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}