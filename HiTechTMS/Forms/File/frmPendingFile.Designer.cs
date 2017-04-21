namespace HitechTMS.File
{
    partial class frmPendingFile
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
            this.grpboxPendingFile = new System.Windows.Forms.GroupBox();
            this.gridPendingFile = new System.Windows.Forms.DataGridView();
            this.rdbMultiWeight = new System.Windows.Forms.RadioButton();
            this.rdbPublicWeight = new System.Windows.Forms.RadioButton();
            this.rdbNormalWeight = new System.Windows.Forms.RadioButton();
            this.grpboxPendingFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingFile)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxPendingFile
            // 
            this.grpboxPendingFile.Controls.Add(this.gridPendingFile);
            this.grpboxPendingFile.Controls.Add(this.rdbMultiWeight);
            this.grpboxPendingFile.Controls.Add(this.rdbPublicWeight);
            this.grpboxPendingFile.Controls.Add(this.rdbNormalWeight);
            this.grpboxPendingFile.Location = new System.Drawing.Point(12, 12);
            this.grpboxPendingFile.Name = "grpboxPendingFile";
            this.grpboxPendingFile.Size = new System.Drawing.Size(1228, 699);
            this.grpboxPendingFile.TabIndex = 0;
            this.grpboxPendingFile.TabStop = false;
            this.grpboxPendingFile.Text = "Pending File";
            // 
            // gridPendingFile
            // 
            this.gridPendingFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPendingFile.Location = new System.Drawing.Point(18, 100);
            this.gridPendingFile.Name = "gridPendingFile";
            this.gridPendingFile.RowTemplate.Height = 24;
            this.gridPendingFile.Size = new System.Drawing.Size(1187, 516);
            this.gridPendingFile.TabIndex = 3;
            // 
            // rdbMultiWeight
            // 
            this.rdbMultiWeight.AutoSize = true;
            this.rdbMultiWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMultiWeight.Location = new System.Drawing.Point(745, 42);
            this.rdbMultiWeight.Name = "rdbMultiWeight";
            this.rdbMultiWeight.Size = new System.Drawing.Size(149, 24);
            this.rdbMultiWeight.TabIndex = 2;
            this.rdbMultiWeight.TabStop = true;
            this.rdbMultiWeight.Text = "Multi Weghing";
            this.rdbMultiWeight.UseVisualStyleBackColor = true;
            this.rdbMultiWeight.CheckedChanged += new System.EventHandler(this.rdbMultiWeight_CheckedChanged);
            // 
            // rdbPublicWeight
            // 
            this.rdbPublicWeight.AutoSize = true;
            this.rdbPublicWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPublicWeight.Location = new System.Drawing.Point(525, 42);
            this.rdbPublicWeight.Name = "rdbPublicWeight";
            this.rdbPublicWeight.Size = new System.Drawing.Size(160, 24);
            this.rdbPublicWeight.TabIndex = 1;
            this.rdbPublicWeight.TabStop = true;
            this.rdbPublicWeight.Text = "Public Weghing";
            this.rdbPublicWeight.UseVisualStyleBackColor = true;
            this.rdbPublicWeight.CheckedChanged += new System.EventHandler(this.rdbPublicWeight_CheckedChanged);
            // 
            // rdbNormalWeight
            // 
            this.rdbNormalWeight.AutoSize = true;
            this.rdbNormalWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNormalWeight.Location = new System.Drawing.Point(290, 42);
            this.rdbNormalWeight.Name = "rdbNormalWeight";
            this.rdbNormalWeight.Size = new System.Drawing.Size(168, 24);
            this.rdbNormalWeight.TabIndex = 0;
            this.rdbNormalWeight.TabStop = true;
            this.rdbNormalWeight.Text = "Normal Weghing";
            this.rdbNormalWeight.UseVisualStyleBackColor = true;
            this.rdbNormalWeight.CheckedChanged += new System.EventHandler(this.rdbNormalWeight_CheckedChanged);
            // 
            // frmPendingFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 723);
            this.Controls.Add(this.grpboxPendingFile);
            this.Name = "frmPendingFile";
            this.Text = "frmPendingFile";
            this.grpboxPendingFile.ResumeLayout(false);
            this.grpboxPendingFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxPendingFile;
        private System.Windows.Forms.RadioButton rdbMultiWeight;
        private System.Windows.Forms.RadioButton rdbPublicWeight;
        private System.Windows.Forms.RadioButton rdbNormalWeight;
        private System.Windows.Forms.DataGridView gridPendingFile;
    }
}