using System;
using System.Windows.Forms;
using DAL;
using DAL.Entity_Model;
using System.Security.Principal;
using OD.Forms.Security;
using HitechTMS.MasterForms;
using HitechTMS.Classes;
using HitechTMS.File;
using HitechTMS.Weighing;
using static HitechTMS.HitechEnums;
using HitechTMS.Config;
using SharedLibrary;
using System.Collections.Generic;


namespace HitechTMS
{
    public partial class frmMain : SecureBaseForm
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private IPrincipal _nextFormPrincipal;
        private GetResourceCaption dbGetResourceCaption;
        public enumProductNormalPublicMulti _enumProductInOut { get; set; }
        string str;
        enumWeightMode _mode;
        public frmMain(IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            _nextFormPrincipal = userPrincipal;
            InitializeComponent();
            _mode = enumWeightMode.Auto;
            dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
        }


        HyperTerminalAdapter ht = new HyperTerminalAdapter();

        private void Check_Click(object sender, EventArgs e)
        {
            ReadSerialPortCommunication();

        }
        private void ReadSerialPortCommunication()
        {
            try
            {
                int ReadSerialPortValue = 0;

                //ht.Connect();
                //str = ht.ReadSerialPort().Replace("\u0002", "").Replace("\u0003", "").Replace("\r", "");
                str = "123456";
                DialogResult rsltReadSerialPort;

                if (int.TryParse(str, out ReadSerialPortValue))
                {
                    lstSerialPortCommunication.Items.Add(ReadSerialPortValue);
                    str = "";
                }
                else
                {
                    rsltReadSerialPort = MessageBox.Show(str, dbGetResourceCaption.GetStringValue("SYS_ERR"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                    if (rsltReadSerialPort == DialogResult.Retry)
                    {
                        ReadSerialPortCommunication();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMain_UserIsAllowed(object sender, EventArgs e)
        {
            button1.Enabled = this.ValidatedUserRoles.Contains("Admin");
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstSerialPortCommunication.Items.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }

        private void productFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct productForm = new frmProduct(FrmName.ProductDetail);
            productForm.StartPosition = FormStartPosition.CenterParent;
            productForm.ShowDialog();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //frmStoredTareFile objfrmTransportFile = new frmStoredTareFile(FrmName.StoredTareFile, _nextFormPrincipal);
            //objfrmTransportFile.Text = @"Stored Tare File";
            //objfrmTransportFile.StartPosition = FormStartPosition.CenterParent;
            //objfrmTransportFile.ShowDialog();
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
            frmDatabaseBackup objDatabaseBackup = new frmDatabaseBackup();
            objDatabaseBackup.StartPosition = FormStartPosition.CenterParent;
            objDatabaseBackup.ShowDialog();
        }

        private void supplierFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierTransportFile objfrmSupplierFile = new frmSupplierTransportFile(FrmName.Supplier);
            objfrmSupplierFile.Text = "Supplier File";
            objfrmSupplierFile.StartPosition = FormStartPosition.CenterParent;
            objfrmSupplierFile.ShowDialog();
        }

        private void transporterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierTransportFile objfrmTransportFile = new frmSupplierTransportFile(FrmName.Transport);
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

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _enumProductInOut = enumProductNormalPublicMulti.Normal;
            frmProductInOut objfrmProductInOut = new frmProductInOut(_enumProductInOut, _mode);
            objfrmProductInOut.StartPosition = FormStartPosition.CenterParent;
            objfrmProductInOut.ShowDialog();
        }

        private void multiWeighingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
