﻿namespace HitechTMS.File
{
    partial class frmProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
            this.grpboxProduct = new System.Windows.Forms.GroupBox();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnEmailExcel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridProduct = new System.Windows.Forms.DataGridView();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.errProductCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errProductName = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpboxProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProductName)).BeginInit();
            this.SuspendLayout();
            // 
            // grpboxProduct
            // 
            this.grpboxProduct.Controls.Add(this.lblRecCount);
            this.grpboxProduct.Controls.Add(this.lblRecordsCount);
            this.grpboxProduct.Controls.Add(this.btnEmailExcel);
            this.grpboxProduct.Controls.Add(this.btnReport);
            this.grpboxProduct.Controls.Add(this.btnDelete);
            this.grpboxProduct.Controls.Add(this.btnRefresh);
            this.grpboxProduct.Controls.Add(this.btnSearch);
            this.grpboxProduct.Controls.Add(this.btnExit);
            this.grpboxProduct.Controls.Add(this.btnSave);
            this.grpboxProduct.Controls.Add(this.gridProduct);
            this.grpboxProduct.Controls.Add(this.lblProductName);
            this.grpboxProduct.Controls.Add(this.lblProductCode);
            this.grpboxProduct.Controls.Add(this.txtProductName);
            this.grpboxProduct.Controls.Add(this.txtProductCode);
            this.grpboxProduct.Location = new System.Drawing.Point(23, 21);
            this.grpboxProduct.Name = "grpboxProduct";
            this.grpboxProduct.Size = new System.Drawing.Size(759, 569);
            this.grpboxProduct.TabIndex = 0;
            this.grpboxProduct.TabStop = false;
            this.grpboxProduct.Text = "Add/Edit Product";
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCount.Location = new System.Drawing.Point(522, 534);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(136, 22);
            this.lblRecCount.TabIndex = 21;
            this.lblRecCount.Text = "Records Count";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRecordsCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(678, 534);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(60, 22);
            this.lblRecordsCount.TabIndex = 20;
            this.lblRecordsCount.Text = "Count";
            // 
            // btnEmailExcel
            // 
            this.btnEmailExcel.Location = new System.Drawing.Point(461, 167);
            this.btnEmailExcel.Name = "btnEmailExcel";
            this.btnEmailExcel.Size = new System.Drawing.Size(115, 27);
            this.btnEmailExcel.TabIndex = 10;
            this.btnEmailExcel.Text = "E&mail As Excel";
            this.btnEmailExcel.UseVisualStyleBackColor = true;
            this.btnEmailExcel.Click += new System.EventHandler(this.btnEmailExcel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(339, 167);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 27);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "&Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 167);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 27);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(552, 90);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(552, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(598, 167);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 27);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(85, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridProduct.Location = new System.Drawing.Point(124, 219);
            this.gridProduct.Name = "gridProduct";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridProduct.RowTemplate.Height = 24;
            this.gridProduct.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProduct.Size = new System.Drawing.Size(531, 311);
            this.gridProduct.TabIndex = 5;
            this.gridProduct.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridProduct_CellMouseClick);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(121, 95);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(98, 17);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = "Product Name";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(121, 42);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(94, 17);
            this.lblProductCode.TabIndex = 2;
            this.lblProductCode.Text = "Product Code";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(241, 90);
            this.txtProductName.MaxLength = 25;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(162, 22);
            this.txtProductName.TabIndex = 2;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlblProductName_KeyDown);
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductName_KeyPress);
            this.txtProductName.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductName_Validating);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(241, 42);
            this.txtProductCode.MaxLength = 5;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(162, 22);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlblProductCode_KeyDown);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            this.txtProductCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductCode_Validating);
            // 
            // errProductCode
            // 
            this.errProductCode.ContainerControl = this;
            // 
            // errProductName
            // 
            this.errProductName.ContainerControl = this;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 605);
            this.Controls.Add(this.grpboxProduct);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
            this.grpboxProduct.ResumeLayout(false);
            this.grpboxProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProductName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxProduct;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ErrorProvider errProductCode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ErrorProvider errProductName;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnEmailExcel;
        private System.Windows.Forms.DataGridView gridProduct;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblRecordsCount;
    }
}