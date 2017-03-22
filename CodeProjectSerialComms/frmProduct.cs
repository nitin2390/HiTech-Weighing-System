using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DAL.Entity_Model;
using CodeProjectSerialComms.Classes;

namespace CodeProjectSerialComms
{
    public partial class frmProduct : Form
    {
        enum eProduct
        {
            Code = 0,
            Name = 1
        }

        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        public frmProduct()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.ControlBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            BindGrid();
            DesignGrid();

        }


        #region "PrivateMethods"
        private void DesignGrid()
        {
            try
            {
                //gridProduct.DefaultCellStyle.Font.Style = 
                gridProduct.Columns[(int)eProduct.Code].Width = 239;
                gridProduct.Columns[(int)eProduct.Name].Width = 239;
                
                gridProduct.ColumnHeadersHeight = 250;
                gridProduct.AllowUserToResizeColumns = false;
                gridProduct.AllowUserToResizeRows = false;
                gridProduct.RowHeadersVisible = true;
                gridProduct.RowHeadersWidth = 30;
                gridProduct.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message.ToString());
            }

        }
        private void ResetCntrl()
        {
            try
            {
                txtProductCode.Text = "";
                txtProductName.Text = "";
                BindGrid();
            }
            catch (Exception err)
            {
                string errorMsg = err.Message;
                throw;
            }
        }
        private void BindGrid()
        {
            try
            {
                var prodQuery = from prod in dbObj.Products
                                orderby prod.Code ascending
                                select prod;
                List<Product> prodList = prodQuery.ToList();
                gridProduct.DataSource = prodList;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Button_Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductCode.Text != "" && txtProductName.Text !="")
                {

                    var existProdCode = (from prod in dbObj.Products
                                         where prod.Code == txtProductCode.Text
                                         select prod.Code).ToList();

                    if (existProdCode.Count == 0)
                    {
                        Product objProd = new Product();
                        objProd.Code = txtProductCode.Text;
                        objProd.Name = txtProductName.Text;
                        dbObj.Products.Add(objProd);
                        if (dbObj.SaveChanges() ==1)
                        {
                            MessageBox.Show("Data saved!");
                            ResetCntrl();
                        }                       
                    }
                    else
                    {
                        MessageBox.Show("Entered data is duplicate!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message.ToString());
            }


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text !="")
            {
                errProductCode.Clear();
                var ProdQuery = from prod in dbObj.Products
                                where prod.Code == txtProductCode.Text
                                select prod;
                List<Product> objEmp = ProdQuery.ToList();
                if (objEmp.Count > 0)
                {
                    gridProduct.DataSource = objEmp;
                }
                else
                {
                    MessageBox.Show("Records not found!");
                }
            }
            else
            {
                errProductCode.SetError(txtProductCode, "Product code can't be blank");
            }

            
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetCntrl();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            if (gridProduct.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gridProduct.SelectedRows)
                    {
                        prod = (Product)dbObj.Products.Where(b => b.Code == ((Product)row.DataBoundItem).Code).First();
                        dbObj.Products.Remove(prod);
                        dbObj.SaveChanges();
                    }
                    ResetCntrl();
                }

            }
            else
            {
                MessageBox.Show("Please select records rows to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            var RepData = dbObj.Products.Select(x => new { x.Code, x.Name });
            rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable());
            rptCmn.ShowDialog();
        }
        private void btnEmailExcel_Click(object sender, EventArgs e)
        {
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                if (obj.CreateExcelAndSendEmailToList(HitechEnums.FrmName.ProductDetail))
                {
                    MessageBox.Show("Email Sent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error in email sending", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion

        #region "Validating"
        private void txtProductCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                errProductCode.SetError(txtProductCode, "Product code can't be blank");
            }
            else
            {
                errProductCode.Clear();
            }

            if (txtProductName.Text == "")
            {
                errProductName.SetError(txtProductName, "Product name can't be blank");
            }
            else
            {
                errProductName.Clear();
            }
        }
        private void txtProductName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                errProductCode.SetError(txtProductCode, "Product code can't be blank");
            }
            else
            {
                errProductCode.Clear();
            }

            if (txtProductName.Text == "")
            {
                errProductName.SetError(txtProductName, "Product name can't be blank");
            }
            else
            {
                errProductName.Clear();
            }
        }
        #endregion

        private void gridProduct_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult response = MessageBox.Show("Are you sure you want to delete this row?", "Delete row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if ((response == DialogResult.No))
            {
                e.Cancel = true;
            }
        }
        private void txtlblProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click((object)sender, (EventArgs)e);
                txtProductCode.Focus();
            }
        }
    }
}
