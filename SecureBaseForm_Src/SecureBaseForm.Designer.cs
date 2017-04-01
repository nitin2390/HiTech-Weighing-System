namespace OD.Forms.Security
{
	partial class SecureBaseForm
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
            this.SuspendLayout();
            // 
            // SecureBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 336);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SecureBaseForm";
            this.Text = "SecureBaseForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SecureBaseForm_FormClosed);
            this.Load += new System.EventHandler(this.SecureBaseForm_Load);
            this.ResumeLayout(false);

		}

		#endregion
	}
}