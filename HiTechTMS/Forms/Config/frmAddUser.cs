using DAL.Entity_Model;
using HitechTMS.Classes;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using SharedLibrary;
using HitechTMSSecurity;
using System.Security.Principal;

namespace HitechTMS.Config
{
    public partial class frmAddUser : SecureBaseForm
    { 
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        EncryptionAndDecryption objEncryptionAndDecryption;
        private FrmName _frmName { get; set; }
        public Boolean _saveClick { get; set; }
        public Guid _userRoleID { get; private set; }

        public frmAddUser(FrmName frmName,IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString() }, userPrincipal)
        {
            InitializeComponent();
            this._frmName = frmName;
            _dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            this.MinimizeBox = this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = this.Size;
            BindGrid();
            BindDropDown();
            DesignGrid();
            _saveClick = false;
        }

        private void BindDropDown()
        {
            var objRoleType = dbObj.UserRoleTypes.Where(x => x.RoleName != HitechEnums.AppRole.SuperAdmin.ToString()).ToList();
            objRoleType.Insert(0, new UserRoleType() { Id = Guid.NewGuid(), RoleName = "Select" });
            if (objRoleType.Count > 0)
            {
                cmbRoleType.DataSource = objRoleType;
                cmbRoleType.DisplayMember = "RoleName";
                cmbRoleType.ValueMember = "ID";
            }

        }

        private void DesignGrid()
        {
            SetCaption();
            gridUser.ColumnHeadersHeight = 250;
            gridUser.AllowUserToResizeColumns = false;
            gridUser.AllowUserToResizeRows = false;
            gridUser.RowHeadersVisible = true;
            gridUser.RowHeadersWidth = 30;
            gridUser.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gridUser.ReadOnly = true;
        }

        private void SetCaption()
        {
            try
            {
                lblUserName.Text = "User name";
                lblPassword.Text = "Password";
                lblRole.Text = "Role";

                gridUser.Columns[(int)AddUser.UserName].Width = 200;
                gridUser.Columns[(int)AddUser.UserName].HeaderText = "User name";

                gridUser.Columns[(int)AddUser.RoleType].Width = 120;
                gridUser.Columns[(int)AddUser.RoleType].HeaderText = "Role";

                //gridUser.Columns[(int)enumSupplierTransportfrm.Email].Width = 105;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }
        }

        private void fillFormInputs(int rowIndex)
        {

            DataGridViewRow row = gridUser.Rows[rowIndex];
            _userRoleID = (Guid)row.Cells[(int)AddUser.RoleId].Value;
            txtUserName.Text = row.Cells[(int)AddUser.UserName].Value.ToString();
            txtPassword.Text = objEncryptionAndDecryption.Decrypt(row.Cells[(int)AddUser.Password].Value.ToString());
            cmbRoleType.SelectedIndex = cmbRoleType.FindString(row.Cells[(int)AddUser.RoleType].Value.ToString());
        }
        private void BindGrid()
        {
            try
            {


                var UserRoleQuery = dbObj.UserRoleTypes
                    .Join(dbObj.UserRole, x => x.Id, s => s.UserRoleType, (x, s) => new { s.Id, s.Name, s.Password, x.RoleName })
                    .Where(x => x.RoleName != HitechEnums.AppRole.SuperAdmin.ToString())
                    .Select(x => x);
                gridUser.DataSource = UserRoleQuery.ToList();
                if (gridUser.ColumnCount > 0)
                {
                    gridUser.Columns["Id"].Visible = false;
                    gridUser.Columns["Password"].Visible = false;
                }

                lblRecordsCount.Text = gridUser.RowCount.ToString();
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
                #region "Validation"
                GetAllControlByType objGetAllControlByType = new GetAllControlByType();
                var TextControl = objGetAllControlByType.GetAllControllType(this, typeof(TextBox));
                foreach (Control control in TextControl)
                {
                    control.Focus();


                    if (control.Name == "txtUserName")
                    {
                        if (txtUserName.Text == string.Empty)
                        {
                            DialogResult = DialogResult.None;
                            errProviderUserName.SetError(txtUserName, "User name required!");
                            return;
                        }
                        else
                        {
                            errProviderUserName.SetError(txtUserName, null);
                        }
                    }

                    if (control.Name == "txtPassword")
                    {
                        if (txtPassword.Text == string.Empty)
                        {
                            DialogResult = DialogResult.None;
                            errProviderPassword.SetError(txtPassword, "Password required!");
                            return;
                        }
                        else
                        {
                            errProviderPassword.SetError(txtPassword, null);
                        }
                    }
                }

                if(cmbRoleType.SelectedIndex ==0)
                {
                    DialogResult = DialogResult.None;
                    errProviderRole.SetError(cmbRoleType, "Select Role!");
                    cmbRoleType.Focus();
                    return;
                }
                else
                {
                    errProviderRole.SetError(cmbRoleType, null);
                }

                    #endregion
                    if (txtUserName.Text != string.Empty 
                            && txtPassword.Text != string.Empty 
                                && cmbRoleType.Text != "Select")
                    {

                        var existUserRoleCode = (from UserRole in dbObj.UserRole
                                                 where UserRole.Id == _userRoleID
                                                 select UserRole).FirstOrDefault();

                        if (_userRoleID == Guid.Empty)
                        {
                            UserRole objUserRole = new UserRole();

                            objUserRole.Name = txtUserName.Text;
                            objUserRole.Password = objEncryptionAndDecryption.Encrypt(txtPassword.Text);
                            objUserRole.UserRoleType = (Guid)cmbRoleType.SelectedValue;

                            objUserRole.Id = Guid.NewGuid();
                            dbObj.UserRole.Add(objUserRole);
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

                            existUserRoleCode.Name = txtUserName.Text;
                            existUserRoleCode.Password = objEncryptionAndDecryption.Encrypt(txtPassword.Text);
                            existUserRoleCode.UserRoleType = (Guid)cmbRoleType.SelectedValue;

                            if (dbObj.SaveChanges() > 0 )
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
            catch (Exception err)
            {

                MessageBox.Show(err.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }

        }

        private void ResetCntrl()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbRoleType.SelectedIndex = 0;
            _userRoleID = Guid.Empty;
            BindGrid();
        }

        private void gridUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fillFormInputs(e.RowIndex);
            }
            else
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cmbRoleType.SelectedIndex = 0;
            }
        }

        #region "KeyDown"
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtUserName.Text != string.Empty)
            {                
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPassword.Text != string.Empty)
            {
                cmbRoleType.Focus();
            }
        }

        private void cmbRoleType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbRoleType.SelectedIndex != 0)
            {
                btnSave_Click(null, null);
            }
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UserRole objUserRole = new UserRole();
            if (gridUser.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(_dbGetResourceCaption.GetStringValue("DELTE_POPUP"), 
                    _dbGetResourceCaption.GetStringValue("CONFIRMATION"), 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gridUser.SelectedRows)
                    {
                        var _deleteID = (Guid)row.Cells[0].Value;
                        objUserRole = dbObj.UserRole.Where
                                                (b => b.Id == _deleteID).FirstOrDefault();
                        dbObj.UserRole.Remove(objUserRole);
                    }
                    if (dbObj.SaveChanges() == 1)
                    {
                        ResetCntrl();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select records rows to delete!", 
                    "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        private void btnEmailExcel_Click(object sender, EventArgs e)
        {
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                obj.CreateExcelAndSendEmailToList(_frmName);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var RepData = dbObj.UserRoleTypes
                .Join(dbObj.UserRole, x => x.Id, s => s.UserRoleType, (x, s) => new { s.Id, s.Code, s.Name, s.Password, s.UserRoleType , x.RoleName })
                .Where(x => x.RoleName != HitechEnums.AppRole.SuperAdmin.ToString())
                .Select(x => x);
            if (RepData.ToList().Count > 0)
            {
                rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), _frmName,enumProductInOut.Other);
                rptCmn.ShowDialog();
            }
            else
            {
                MessageBox.Show("No data!", "Information", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            searchGridData();
        }

        private void searchGridData()
        {
            if(!_saveClick)
            {
                if (txtUserName.Text != string.Empty)
                {
                    var userRoleQuery = dbObj.UserRoleTypes
                            .Join(dbObj.UserRole, x => x.Id, s => s.UserRoleType, (x, s) => new { s.Id, s.Name, s.Password, x.RoleName })
                            .Where(x => x.Id == _userRoleID || x.Name == txtUserName.Text)
                            .Select(x => x);

                    var objUser = userRoleQuery.ToList();

                    if (objUser.Count > 0)
                    {
                        gridUser.DataSource = objUser;
                        _userRoleID = objUser[0].Id;
                        cmbRoleType.SelectedIndex = cmbRoleType.FindString(objUser[0].RoleName);
                    }
                    else
                    {
                        //txtPassword.Text = string.Empty;
                        //cmbRoleType.SelectedIndex =0;
                        _userRoleID = Guid.Empty;
                    }

                }
                else
                {
                    BindGrid();
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
