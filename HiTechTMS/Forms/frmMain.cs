using System;
using System.Windows.Forms;
using DAL;
using DAL.Entity_Model;
using System.Security.Principal;
using HitechTMSSecurity;
using HitechTMS.MasterForms;
using HitechTMS.Classes;
using HitechTMS.File;
using HitechTMS.Weighing;
using static HitechTMS.HitechEnums;
using HitechTMS.Config;
using System.Collections.Generic;
using System.Linq;

namespace HitechTMS
{
    public partial class frmMain : SecureBaseForm
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private IPrincipal _nextFormPrincipal;
        private GetResourceCaption dbGetResourceCaption;
        public enumProductNormalPublicMulti _enumProductNormalPublicMulti { get; set; }
        public string str;
        public string _role { get; set; }
        HyperTerminalAdapter ht = new HyperTerminalAdapter();
        enumWeightMode _mode;

        public frmMain(IPrincipal userPrincipal,string role) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Supervisor.ToString(), HitechEnums.AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            _nextFormPrincipal = userPrincipal;
            InitializeComponent();
            _role = role;
            _mode = enumWeightMode.Auto;
            dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            HideMenuOnBasisOfRole();
        }

        private void HideMenuOnBasisOfRole()
        {
            try
            {
                foreach (ToolStripMenuItem mainMenu in menuStrip1.Items)
                {
                    // Level 1 menu
                    if(mainMenu.Text == "Configuration" && _role != HitechEnums.AppRole.SuperAdmin.ToString())
                    {
                        mainMenu.Visible = false;
                    }

                    if (!mainMenu.Visible)
                    {
                        SetToolStripItems(mainMenu.DropDownItems);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // if we have a MenuStrip named ts.

        private void SetToolStripItems(ToolStripItemCollection dropDownItems )
        {
            try
            {
                foreach (object obj in dropDownItems)
                {
                    if (obj.GetType().Equals(typeof(ToolStripMenuItem)))
                    {
                        //Level 2 menu
                        ToolStripMenuItem subMenu = (ToolStripMenuItem)obj;
                        if (subMenu.Text != null)
                        {
                            if (subMenu.Text == "Transaction / Pending File" && _role != HitechEnums.AppRole.SuperAdmin.ToString())
                            {
                                subMenu.Visible = false;
                            }
                        }

                        if (subMenu.HasDropDownItems)
                        {
                            SetToolStripItems(subMenu.DropDownItems);
                        }
                        else // Do the desired operations here.
                        {
                            //Level 3 menu
                            if (subMenu.Text != null)
                            {
                              if(subMenu.Text == "Transaction / Pending File" && _role != HitechEnums.AppRole.SuperAdmin.ToString())
                                {
                                    subMenu.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetToolStripItems",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_UserIsAllowed(object sender, EventArgs e)
        {
            
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }

        private void productFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct productForm = new frmProduct(FrmName.ProductDetail, _nextFormPrincipal);
            productForm.StartPosition = FormStartPosition.CenterParent;
            productForm.ShowDialog();
        }

        private void emailConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmailConfig objEmailConfig = new frmEmailConfig(_nextFormPrincipal);
            if (objEmailConfig.UserCanOpenForm == false)
            {
                MessageBox.Show(dbGetResourceCaption.GetStringValue("DENIED"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objEmailConfig.StartPosition = FormStartPosition.CenterParent;
                objEmailConfig.ShowDialog();
            }

        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseBackup objDatabaseBackup = new frmDatabaseBackup(_nextFormPrincipal);
            objDatabaseBackup.StartPosition = FormStartPosition.CenterParent;
            objDatabaseBackup.ShowDialog();
        }

        private void supplierFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierTransportFile objfrmSupplierFile = new frmSupplierTransportFile(FrmName.Supplier, _nextFormPrincipal);
            objfrmSupplierFile.Text = "Supplier File";
            objfrmSupplierFile.StartPosition = FormStartPosition.CenterParent;
            objfrmSupplierFile.ShowDialog();
        }

        private void transporterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierTransportFile objfrmTransportFile = new frmSupplierTransportFile(FrmName.Transport, _nextFormPrincipal);
            objfrmTransportFile.Text = "Transport File";
            objfrmTransportFile.StartPosition = FormStartPosition.CenterParent;
            objfrmTransportFile.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser objfrmTransportFile = new frmAddUser(FrmName.AddEditUser,_nextFormPrincipal);
            if (objfrmTransportFile.UserCanOpenForm == false)
            {
                MessageBox.Show(dbGetResourceCaption.GetStringValue("DENIED"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objfrmTransportFile.Text = @"Add\Edit user";
                objfrmTransportFile.StartPosition = FormStartPosition.CenterParent;
                objfrmTransportFile.ShowDialog();
            }
        }

        private void storedTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmStoredTareFile objfrmTransportFile = new frmStoredTareFile(FrmName.StoredTareFile, _nextFormPrincipal, _mode);

            if (objfrmTransportFile.UserCanOpenForm == false)
            {
                MessageBox.Show(dbGetResourceCaption.GetStringValue("DENIED"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objfrmTransportFile.Text = @"Stored Tare File";
                objfrmTransportFile.StartPosition = FormStartPosition.CenterParent;
                objfrmTransportFile.ShowDialog();
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                // For each of the top menu items, get all sub items recursively
                allItems.AddRange(GetItems(item));
            }

        }
        private IEnumerable<ToolStripMenuItem> GetItems(ToolStripMenuItem item)
        {
            foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
            {
                if (dropDownItem.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem subItem in GetItems(dropDownItem))
                        yield return subItem;
                }
                yield return dropDownItem;
            }
        }

        private void publicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _enumProductNormalPublicMulti = enumProductNormalPublicMulti.Public;
            frmProductInOut objfrmProductInOut = new frmProductInOut(_enumProductNormalPublicMulti, _mode);
            objfrmProductInOut.StartPosition = FormStartPosition.CenterParent;
            objfrmProductInOut.ShowDialog();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _enumProductNormalPublicMulti = enumProductNormalPublicMulti.Normal;
            frmProductInOut objfrmProductInOut = new frmProductInOut(_enumProductNormalPublicMulti, _mode);
            objfrmProductInOut.StartPosition = FormStartPosition.CenterParent;
            objfrmProductInOut.ShowDialog();
        }

        private void multiWeighingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pendingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPendingFile objfrmSupplierFile = new frmPendingFile(FrmName.Supplier, _nextFormPrincipal);
            objfrmSupplierFile.Text = "Pending File";
            objfrmSupplierFile.StartPosition = FormStartPosition.CenterParent;
            objfrmSupplierFile.ShowDialog();
        }

        private void switchUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin objfrmLogin = new frmLogin();
            objfrmLogin.StartPosition = FormStartPosition.CenterParent;
            objfrmLogin.ShowDialog();
            this.Close();
        }
    }
}
