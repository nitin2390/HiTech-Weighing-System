using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DAL.Entity_Model;
using HitechTMS.Classes;
using static HitechTMS.HitechEnums;
using System.Data.Entity.Migrations;
using SharedLibrary;
using System.Security.Principal;

namespace HitechTMS.File
{
    public partial class frmProduct : HitechTMSSecurity.SecureBaseForm
    {

        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        private Common _comm { get; set; }
        private FrmName _frmName { get; set; }
        public frmProduct(FrmName frmName,IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(),HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            this._frmName = frmName;
            _dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _comm = new Common();
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
                gridProduct.ReadOnly = true;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }

        }
        private void ResetCntrl()
        {
            try
            {
                txtProductCode.Text = string.Empty;
                txtProductName.Text = string.Empty;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
        #endregion

        #region "Button_Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductCode.Text != string.Empty 
                        && txtProductName.Text != string.Empty)
                {

                    var existProdCode = (from prod in dbObj.Products
                                         where prod.Code == txtProductCode.Text
                                         select prod.Code).ToList();
                    Product objProd = new Product();
                    objProd.Code = txtProductCode.Text;
                    objProd.Name = txtProductName.Text;

                    if (existProdCode.Count == 0)
                    {
                        dbObj.Products.Add(objProd);
                        if (dbObj.SaveChanges() ==1)
                        {
                            ResetCntrl();
                            MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"), 
                                _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                        }                       
                    }
                    else
                    {

                        dbObj.Products.AddOrUpdate(objProd);
                        if (dbObj.SaveChanges() == 1)
                        {
                            ResetCntrl();
                            MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_UPDATE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text != string.Empty)
            {
                errProductCode.Clear();
                var ProdQuery = from prod in dbObj.Products
                                where prod.Code.Contains(txtProductCode.Text)
                                select prod;
                List<Product> objProd = ProdQuery.ToList();
                if (objProd.Count > 0)
                {
                    gridProduct.DataSource = objProd;
                }
                else
                {
                    MessageBox.Show(
                        _dbGetResourceCaption.GetStringValue("RECORDS_NOT_FOUND"),
                        _dbGetResourceCaption.GetStringValue("INFORMATION"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
            }
            else
            {
                errProductCode.SetError(txtProductCode, _dbGetResourceCaption.GetStringValue("CAN_NOT_BLANK_PRD_CD"));
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
                if (MessageBox.Show(_dbGetResourceCaption.GetStringValue("DELTE_POPUP"), 
                        _dbGetResourceCaption.GetStringValue("CONFIRMATION"), 
                            MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == DialogResult.Yes)
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
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("SELECT_ROW_TO_DELETE"),
                                    _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
            }


        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            var RepData = dbObj.Products.Select(x => new { x.Code, x.Name });
            rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(),_frmName,enumProductInOut.Other);
            rptCmn.ShowDialog();
        }
        private void btnEmailExcel_Click(object sender, EventArgs e)
        {
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                obj.CreateExcelAndSendEmailToList(FrmName.ProductDetail);
            }

        }
        #endregion

        #region "Validating"
        private void txtProductCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtProductCode.Text = txtProductCode.Text.ToUpper();

            if (txtProductCode.Text == string.Empty)
            {
                errProductCode.SetError(txtProductCode, _dbGetResourceCaption.GetStringValue("CAN_NOT_BLANK_PRD_CD"));
            }
            else
            {
                errProductCode.Clear();
            }

            if (txtProductName.Text == string.Empty)
            {
                errProductName.SetError(txtProductName, _dbGetResourceCaption.GetStringValue("CAN_NOT_BLANK_PRD_NM"));
            }
            else
            {
                errProductName.Clear();
            }
        }
        private void txtProductName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtProductCode.Text == string.Empty)
            {
                errProductCode.SetError(txtProductCode, _dbGetResourceCaption.GetStringValue("CAN_NOT_BLANK_PRD_CD"));
            }
            else
            {
                errProductCode.Clear();
            }

            if (txtProductName.Text == string.Empty)
            {
                errProductName.SetError(txtProductName, _dbGetResourceCaption.GetStringValue("CAN_NOT_BLANK_PRD_NM"));
            }
            else
            {
                errProductName.Clear();
            }
        }
        #endregion

        private void txtlblProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtProductCode.Text != string.Empty)
            {
                btnSave_Click((object)sender, (EventArgs)e);
                txtProductCode.Focus();
            }
        }

        private void txtlblProductCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && txtProductCode.Text != string.Empty)
            {
                txtProductName.Focus();
            }
        }
        private void fillFormInputs(int rowIndex)
        {
            DataGridViewRow row = gridProduct.Rows[rowIndex];
            txtProductCode.Text = row.Cells[(int)enumProduct.Code].Value.ToString();
            txtProductName.Text = row.Cells[(int)enumProduct.Name].Value.ToString();
        }

        private void gridProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                fillFormInputs(e.RowIndex);
            }
        }

        private void searchGridData()
        {
            if (txtProductCode.Text != string.Empty)
            {
                var ProdQuery = from prod in dbObj.Products
                                where prod.Code.Contains(txtProductCode.Text)
                                select prod;
                List<Product> objProd = ProdQuery.ToList();
                if (objProd.Count > 0)
                {
                    gridProduct.DataSource = objProd;
                    txtProductName.Text = objProd[0].Name.ToString();
                }
                else
                {
                    BindGrid();
                }
            }
            else
            {
                BindGrid();
            }
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            searchGridData();
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBoxAndUpperCase(e);
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBoxAndUpperCase(e);
        }
    }
}
