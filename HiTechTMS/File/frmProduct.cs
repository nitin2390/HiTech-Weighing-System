using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DAL.Entity_Model;
using HitechTMS.Classes;
using static HitechTMS.HitechEnums;

namespace HitechTMS.File
{
    public partial class frmProduct : Form
    {

        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption dbGetResourceCaption;
        public frmProduct()
        {
            InitializeComponent();
            dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            this.MinimizeBox = this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = this.Size;
            BindGrid();
            DesignGrid();

        }


        #region "PrivateMethods"
        private void DesignGrid()
        {
            try
            {
                //gridProduct.DefaultCellStyle.Font.Style = 
                gridProduct.Columns[(int)enumProduct.Code].Width = 239;
                gridProduct.Columns[(int)enumProduct.Name].Width = 239;
                
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
                lblRecordsCount.Text = prodList.Count().ToString();
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
                            ResetCntrl();
                            MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_SAVE"));
                        }                       
                    }
                    else
                    {
                        MessageBox.Show(dbGetResourceCaption.GetStringValue("DUPLICATE_DATA"), dbGetResourceCaption.GetStringValue("ALERT"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(dbGetResourceCaption.GetStringValue("RECORDS_NOT_FOUND"));
                }
            }
            else
            {
                errProductCode.SetError(txtProductCode, dbGetResourceCaption.GetStringValue("PRD_CD_CAN_NOT_BLANK"));
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
                if (MessageBox.Show(dbGetResourceCaption.GetStringValue("DELTE_POPUP"), dbGetResourceCaption.GetStringValue("CONFIRMATION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show(dbGetResourceCaption.GetStringValue("EMAIL_SENT"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dbGetResourceCaption.GetStringValue("ERR_EMAIL_CHK_CONFIG"), dbGetResourceCaption.GetStringValue("ERROR") , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion

        #region "Validating"
        private void txtProductCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                errProductCode.SetError(txtProductCode, dbGetResourceCaption.GetStringValue("PRD_CD_CAN_NOT_BLANK"));
            }
            else
            {
                errProductCode.Clear();
            }

            if (txtProductName.Text == "")
            {
                errProductName.SetError(txtProductName, dbGetResourceCaption.GetStringValue("PRD_NM_CAN_NOT_BLANK"));
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
                errProductCode.SetError(txtProductCode, dbGetResourceCaption.GetStringValue("PRD_CD_CAN_NOT_BLANK"));
            }
            else
            {
                errProductCode.Clear();
            }

            if (txtProductName.Text == "")
            {
                errProductName.SetError(txtProductName, dbGetResourceCaption.GetStringValue("PRD_NM_CAN_NOT_BLANK"));
            }
            else
            {
                errProductName.Clear();
            }
        }
        #endregion

        private void txtlblProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtProductCode.Text != "")
            {
                btnSave_Click((object)sender, (EventArgs)e);
                txtProductCode.Focus();
            }
        }

        private void txtlblProductCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && txtProductCode.Text != "")
            {
                txtProductName.Focus();
            }
        }

        private void grpboxProduct_Enter(object sender, EventArgs e)
        {

        }
    }
}
