using DAL.Entity_Model;
using HitechTMS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;
using SharedLibrary;
using System.Security.Principal;

namespace HitechTMS.File
{
    public partial class frmSupplierTransportFile : HitechTMSSecurity.SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private Common _comm { get; set; }
        private GetResourceCaption _dbGetResourceCaption;
        public Boolean _saveClick { get; set; }
        private Guid _supplierTransporterID { get; set; }
        public FrmName _frmType { get; set; }
        public frmSupplierTransportFile(FrmName intfrmtype, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _comm = new Common();
            this.MinimizeBox = this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = this.Size;
            _frmType = intfrmtype;
            _saveClick = false;
            
            BindGrid();
            DesignGrid();
        }

        private void DesignGrid()
        {
            try
            {
                SetCaption();
                gridSupplierTransporter.ColumnHeadersHeight = 250;
                gridSupplierTransporter.AllowUserToResizeColumns = false;
                gridSupplierTransporter.AllowUserToResizeRows = false;
                gridSupplierTransporter.RowHeadersVisible = true;
                gridSupplierTransporter.RowHeadersWidth = 30;
                gridSupplierTransporter.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                gridSupplierTransporter.ReadOnly = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }


        }

        private void SetCaption()
        {
            try
            {
                lblSupplierCode.Text = "Code";
                lblSupplierName.Text = "Name";

                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportCode].Width = 75;
                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportCode].HeaderText = "Code";

                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportName].Width = 120;
                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportName].HeaderText = "Name";

                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.Email].Width = 105;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }

        }

        private void BindGrid()
        {
            try
            {

                var SupplierTransporterQuery = from SupplierTransporter in dbObj.mstSupplierTransporter
                                               where SupplierTransporter.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")
                                               orderby SupplierTransporter.SupplierCode ascending
                                               select SupplierTransporter;
                List<mstSupplierTransporter> SupplierTransporterList = SupplierTransporterQuery.ToList();
                gridSupplierTransporter.DataSource = SupplierTransporterList;

                if (gridSupplierTransporter.ColumnCount > 0)
                {
                    gridSupplierTransporter.Columns["Id"].Visible = false;
                    gridSupplierTransporter.Columns["IsSuplier"].Visible = false;

                }

                lblRecordsCount.Text = gridSupplierTransporter.RowCount.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _saveClick = true;
                GetAllControlByType objGetAllControlByType = new GetAllControlByType();
                var TextControl = objGetAllControlByType.GetAllControllType(this, typeof(TextBox));

                foreach (Control control in TextControl)
                {
                    control.Focus();
                    #region "Validation"

                    if (control.Name == "txtSupplierCode")
                    {
                        if (txtSupplierCode.Text == string.Empty)
                        {
                            DialogResult = DialogResult.None;
                            errProviderCode.SetError(txtSupplierCode, "Code required!");
                            return;
                        }
                        else
                        {
                            errProviderCode.SetError(txtSupplierCode, null);
                        }
                    }

                    if (control.Name == "txtPhone")
                    {
                        if(control.Text != string.Empty)
                        {
                            if (!Regex.IsMatch(txtPhone.Text, @"^[789]\d{9}$", RegexOptions.IgnoreCase))
                            {
                                DialogResult = DialogResult.None;
                                errProviderPhone.SetError(txtPhone, "Phone number invalid! {XXXXXXXXXX}");
                                return;
                            }
                            else
                            {
                                errProviderPhone.SetError(txtPhone, null);
                            }
                        }
                    }


                    if (control.Name == "txtFax" )
                    {
                        if (control.Text != string.Empty)
                        {
                            if (!Regex.IsMatch(txtFax.Text, @"^[789]\d{9}$", RegexOptions.IgnoreCase))
                            {
                                DialogResult = DialogResult.None;
                                errProviderFax.SetError(txtFax, "Fax number invalid! {XXXXXXXXXX}");
                                return;
                            }
                            else
                            {
                                errProviderFax.SetError(txtFax, null);
                            }
                        }
                    }

                    if (control.Name == "txtEmail")
                    {
                        if (control.Text != string.Empty)
                        {
                            if (!Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                            {
                                DialogResult = DialogResult.None;
                                errProviderEmail.SetError(txtEmail, "Email ID invalid!");
                                return;
                            }
                            else
                            {
                                errProviderEmail.SetError(txtEmail, null);
                            }
                        }

                    }                    
                    #endregion
                }



                if (txtSupplierCode.Text != string.Empty)
                {

                    var existSupplierTransporterCode = (from SupplierTransporter in dbObj.mstSupplierTransporter
                                                        where SupplierTransporter.SupplierCode == txtSupplierCode.Text && SupplierTransporter.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")
                                                        select SupplierTransporter.SupplierCode).ToList();

                    mstSupplierTransporter objSupplierTransport = new mstSupplierTransporter();
                    objSupplierTransport.SupplierCode = txtSupplierCode.Text;
                    objSupplierTransport.SupplierName = txtSupplierName.Text;
                    objSupplierTransport.Address1 = txtAddressLine1.Text;
                    objSupplierTransport.Address2 = txtAddressLine2.Text;
                    objSupplierTransport.Address3 = txtAddressLine3.Text;
                    objSupplierTransport.Phone = txtPhone.Text;
                    objSupplierTransport.Fax = txtFax.Text;
                    objSupplierTransport.Email = txtEmail.Text;
                    objSupplierTransport.IsSuplier = _frmType == FrmName.Supplier ? "2" : "3";


                    if (existSupplierTransporterCode.Count == 0)
                    {
                        objSupplierTransport.Id = Guid.NewGuid();
                        dbObj.mstSupplierTransporter.Add(objSupplierTransport);
                        if (dbObj.SaveChanges() == 1)
                        {
                            ResetCntrl();
                            BindGrid();
                            MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"), 
                                _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        objSupplierTransport.Id = _supplierTransporterID;
                        dbObj.mstSupplierTransporter.AddOrUpdate(objSupplierTransport);
                        if (dbObj.SaveChanges() == 1)
                        {
                            ResetCntrl();
                            MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_UPDATE"), 
                                _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
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

        private void ResetCntrl()
        {
            _saveClick = false;
            txtSupplierCode.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtAddressLine3.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            BindGrid();
            txtSupplierCode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mstSupplierTransporter SupplierTransporter = new mstSupplierTransporter();
            if (gridSupplierTransporter.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(_dbGetResourceCaption.GetStringValue("DELTE_POPUP"), 
                    _dbGetResourceCaption.GetStringValue("CONFIRMATION"), 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gridSupplierTransporter.SelectedRows)
                    {
                        SupplierTransporter = dbObj.mstSupplierTransporter.Where
                                                (b => b.SupplierCode == ((mstSupplierTransporter)row.DataBoundItem).SupplierCode && b.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")).First();
                        dbObj.mstSupplierTransporter.Remove(SupplierTransporter);
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
            var RepData = dbObj.mstSupplierTransporter
                .Select(x => new { x.SupplierCode, x.SupplierName, x.Address1, x.Address2, x.Address3, x.Phone, x.Fax, x.Email, x.IsSuplier })
                .Where(x => x.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3"));
            if (RepData.ToList().Count > 0)
            {
                rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), _frmType,enumProductInOut.Other);
                rptCmn.ShowDialog();
            }
            else
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("NO_DATA"), 
                    _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }

        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            if (!_saveClick)
            {
                searchGridData();

            }
        }

        private void searchGridData()
        {
            if (txtSupplierCode.Text != string.Empty)
            {
                var SupplierTransporterQuery = from SupplierTransporter in dbObj.mstSupplierTransporter
                                               where SupplierTransporter.SupplierCode == txtSupplierCode.Text && SupplierTransporter.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")
                                               select SupplierTransporter;
                List<mstSupplierTransporter> objProd = SupplierTransporterQuery.ToList();
                if (objProd.Count > 0)
                {
                    gridSupplierTransporter.DataSource = objProd;
                    _supplierTransporterID = objProd[0].Id;
                    txtSupplierName.Text = objProd[0].SupplierName.ToString();
                    txtAddressLine1.Text = objProd[0].Address1.ToString();
                    txtAddressLine2.Text = objProd[0].Address2.ToString();
                    txtAddressLine3.Text = objProd[0].Address3.ToString();
                    txtPhone.Text = objProd[0].Phone.ToString();
                    txtFax.Text = objProd[0].Fax.ToString();
                    txtEmail.Text = objProd[0].Email.ToString();
                }
                else
                {
                    //txtSupplierName.Text = string.Empty;
                    //txtAddressLine1.Text = string.Empty;
                    //txtAddressLine2.Text = string.Empty;
                    //txtAddressLine3.Text = string.Empty;
                    //txtPhone.Text = string.Empty;
                    //txtFax.Text = string.Empty;
                    //txtEmail.Text = string.Empty;
                    _supplierTransporterID = Guid.Empty;
                    BindGrid();
                }

            }
            else
            {
                BindGrid();
            }
        }

        private void gridSupplierTransporter_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fillFormInputs(e.RowIndex);
            }
            else
            {
                _supplierTransporterID = Guid.Empty;
                txtSupplierCode.Text = string.Empty;
                txtSupplierName.Text = string.Empty;
                txtAddressLine1.Text = string.Empty;
                txtAddressLine2.Text = string.Empty;
                txtAddressLine3.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtFax.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
        }

        private void fillFormInputs(int rowIndex)
        {
            DataGridViewRow row = gridSupplierTransporter.Rows[rowIndex];
            _supplierTransporterID = (Guid)row.Cells[(int)enumSupplierTransportfrm.Id].Value;
            txtSupplierCode.Text = row.Cells[(int)enumSupplierTransportfrm.SupplierTransportCode].Value.ToString();
            txtSupplierName.Text = row.Cells[(int)enumSupplierTransportfrm.SupplierTransportName].Value.ToString();
            txtAddressLine1.Text = row.Cells[(int)enumSupplierTransportfrm.Address1].Value.ToString();
            txtAddressLine2.Text = row.Cells[(int)enumSupplierTransportfrm.Address2].Value.ToString();
            txtAddressLine3.Text = row.Cells[(int)enumSupplierTransportfrm.Address3].Value.ToString();
            txtPhone.Text = row.Cells[(int)enumSupplierTransportfrm.Phone].Value.ToString();
            txtFax.Text = row.Cells[(int)enumSupplierTransportfrm.Fax].Value.ToString();
            txtEmail.Text = row.Cells[(int)enumSupplierTransportfrm.Email].Value.ToString();

        }

        private void btnEmailExcel_Click(object sender, EventArgs e)
        {
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                obj.CreateExcelAndSendEmailToList(_frmType);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') >= 0))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                btnSave_Click((object)sender, (EventArgs)e);
                //txtSupplierCode.Focus();
            }
        }

        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                txtSupplierName.Focus();
            }
        }

        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                txtAddressLine1.Focus();
            }
        }

        private void txtAddressLine1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                txtAddressLine2.Focus();
            }
        }

        private void txtAddressLine2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                txtAddressLine3.Focus();
            }
        }

        private void txtAddressLine3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                txtPhone.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                txtFax.Focus();
            }
        }

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSupplierCode.Text != string.Empty)
            {
                txtEmail.Focus();
            }
        }

        private void txtSupplierCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBoxAndUpperCase(e);
        }




        private void txtSupplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            e = _comm.RestirctTextBoxAndUpperCase(e);
        }
    }
}
