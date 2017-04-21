namespace HitechTMS.Forms.File
{
    partial class frmTransactionFile
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
            this.grpBoxTransactionFile = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpBoxTransactionFile
            // 
            this.grpBoxTransactionFile.Location = new System.Drawing.Point(13, 13);
            this.grpBoxTransactionFile.Name = "grpBoxTransactionFile";
            this.grpBoxTransactionFile.Size = new System.Drawing.Size(1135, 689);
            this.grpBoxTransactionFile.TabIndex = 0;
            this.grpBoxTransactionFile.TabStop = false;
            this.grpBoxTransactionFile.Text = "Transaction File";
            // 
            // frmTransactionFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 714);
            this.Controls.Add(this.grpBoxTransactionFile);
            this.Name = "frmTransactionFile";
            this.Text = "frmTransactionFile";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxTransactionFile;
    }
}