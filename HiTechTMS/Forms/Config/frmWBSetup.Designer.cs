﻿namespace HitechTMS.MasterForms
{
    partial class frmWBSetup
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
            this.errorWBSetup = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBoxWeighBridge = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWBCapacity = new System.Windows.Forms.TextBox();
            this.lblWt = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbUnits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorWBSetup)).BeginInit();
            this.grpBoxWeighBridge.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorWBSetup
            // 
            this.errorWBSetup.ContainerControl = this;
            // 
            // grpBoxWeighBridge
            // 
            this.grpBoxWeighBridge.Controls.Add(this.label1);
            this.grpBoxWeighBridge.Controls.Add(this.txtWBCapacity);
            this.grpBoxWeighBridge.Controls.Add(this.lblWt);
            this.grpBoxWeighBridge.Controls.Add(this.btnClose);
            this.grpBoxWeighBridge.Controls.Add(this.btnOk);
            this.grpBoxWeighBridge.Controls.Add(this.cmbUnits);
            this.grpBoxWeighBridge.Controls.Add(this.label2);
            this.grpBoxWeighBridge.Controls.Add(this.txtUnits);
            this.grpBoxWeighBridge.Location = new System.Drawing.Point(13, 13);
            this.grpBoxWeighBridge.Name = "grpBoxWeighBridge";
            this.grpBoxWeighBridge.Size = new System.Drawing.Size(297, 209);
            this.grpBoxWeighBridge.TabIndex = 26;
            this.grpBoxWeighBridge.TabStop = false;
            this.grpBoxWeighBridge.Text = "Weigh Bridge Setup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Capacity";
            // 
            // txtWBCapacity
            // 
            this.txtWBCapacity.Location = new System.Drawing.Point(112, 91);
            this.txtWBCapacity.MaxLength = 6;
            this.txtWBCapacity.Name = "txtWBCapacity";
            this.txtWBCapacity.Size = new System.Drawing.Size(135, 20);
            this.txtWBCapacity.TabIndex = 4;
            this.txtWBCapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWBCapacity_KeyPress);
            // 
            // lblWt
            // 
            this.lblWt.AutoSize = true;
            this.lblWt.Location = new System.Drawing.Point(253, 94);
            this.lblWt.Name = "lblWt";
            this.lblWt.Size = new System.Drawing.Size(20, 13);
            this.lblWt.TabIndex = 31;
            this.lblWt.Text = "Kg";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(175, 145);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(62, 145);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 32);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbUnits
            // 
            this.cmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.Location = new System.Drawing.Point(112, 45);
            this.cmbUnits.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(135, 21);
            this.cmbUnits.TabIndex = 2;
            this.cmbUnits.SelectedIndexChanged += new System.EventHandler(this.cmbUnits_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Weigh Bridge ";
            // 
            // txtUnits
            // 
            this.txtUnits.AutoSize = true;
            this.txtUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnits.Location = new System.Drawing.Point(19, 45);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(31, 13);
            this.txtUnits.TabIndex = 1;
            this.txtUnits.Text = "Units";
            // 
            // frmWBSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 234);
            this.Controls.Add(this.grpBoxWeighBridge);
            this.Name = "frmWBSetup";
            this.Text = "Weigh Bridge Setup";
            ((System.ComponentModel.ISupportInitialize)(this.errorWBSetup)).EndInit();
            this.grpBoxWeighBridge.ResumeLayout(false);
            this.grpBoxWeighBridge.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorWBSetup;
        private System.Windows.Forms.GroupBox grpBoxWeighBridge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWBCapacity;
        private System.Windows.Forms.Label lblWt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbUnits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtUnits;
    }
}