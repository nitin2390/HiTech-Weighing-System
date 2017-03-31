using System;
using System.Windows.Forms;
using DAL;
using DAL.Entity_Model;
using System.Security.Principal;
using OD.Forms.Security;
using HitechTMS.MasterForms;
using HitechTMS.Classes;
using HitechTMS.File;
using static HitechTMS.HitechEnums;
using HitechTMS.Config;

namespace HitechTMS
{
    public partial class frmMain : SecureBaseForm
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private IPrincipal _nextFormPrincipal;
        private GetResourceCaption dbGetResourceCaption;
        string str;

        public frmMain(IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            _nextFormPrincipal = userPrincipal;
            InitializeComponent();
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

        private void frmMain_UserIsAllowed(object sender, EventArgs e)
        {
            button1.Enabled = this.ValidatedUserRoles.Contains("Admin");
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
            catch (Exception)
            {

                throw;
            }
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
            frmStoredTareFile objfrmTrasnportFile = new frmStoredTareFile(FrmName.AddEditUser, _nextFormPrincipal);
            objfrmTrasnportFile.Text = @"Stored Tare File";
            objfrmTrasnportFile.StartPosition = FormStartPosition.CenterParent;
            objfrmTrasnportFile.ShowDialog();
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
            frmSupplierTrasnportFile objfrmSupplierFile = new frmSupplierTrasnportFile(FrmName.Supplier);
            objfrmSupplierFile.Text = "Supplier File";
            objfrmSupplierFile.StartPosition = FormStartPosition.CenterParent;
            objfrmSupplierFile.ShowDialog();
        }

        private void transporterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierTrasnportFile objfrmTrasnportFile = new frmSupplierTrasnportFile(FrmName.Transport);
            objfrmTrasnportFile.Text = "Trasnport File";
            objfrmTrasnportFile.StartPosition = FormStartPosition.CenterParent;
            objfrmTrasnportFile.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser objfrmTrasnportFile = new frmAddUser(FrmName.AddEditUser,_nextFormPrincipal);
            if (objfrmTrasnportFile.UserCanOpenForm == false)
            {
                MessageBox.Show(dbGetResourceCaption.GetStringValue("DENIED"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objfrmTrasnportFile.Text = @"Add\Edit user";
                objfrmTrasnportFile.StartPosition = FormStartPosition.CenterParent;
                objfrmTrasnportFile.ShowDialog();
            }
        }

        private void storedTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStoredTareFile objfrmTrasnportFile = new frmStoredTareFile(FrmName.AddEditUser, _nextFormPrincipal);

            if (objfrmTrasnportFile.UserCanOpenForm == false)
            {
                MessageBox.Show(dbGetResourceCaption.GetStringValue("DENIED"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objfrmTrasnportFile.Text = @"Stored Tare File";
                objfrmTrasnportFile.StartPosition = FormStartPosition.CenterParent;
                objfrmTrasnportFile.ShowDialog();
            }

        }
    }
}
