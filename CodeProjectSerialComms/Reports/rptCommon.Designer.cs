namespace HitechTMS
{
    partial class rptCommon
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
            this.cryRepViewCommon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cryRepViewCommon
            // 
            this.cryRepViewCommon.ActiveViewIndex = -1;
            this.cryRepViewCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryRepViewCommon.Cursor = System.Windows.Forms.Cursors.Default;
            this.cryRepViewCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryRepViewCommon.Location = new System.Drawing.Point(0, 0);
            this.cryRepViewCommon.Name = "cryRepViewCommon";
            this.cryRepViewCommon.Size = new System.Drawing.Size(974, 693);
            this.cryRepViewCommon.TabIndex = 0;
            // 
            // rptCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 693);
            this.Controls.Add(this.cryRepViewCommon);
            this.Name = "rptCommon";
            this.Text = "rptCommon";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cryRepViewCommon;

    }
}