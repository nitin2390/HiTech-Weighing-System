using System;
using System.Windows.Forms;
using DAL;
using DAL.Entity_Model;
using System.Security.Principal;
using OD.Forms.Security;
using HitechTMS.MasterForms;
using HitechTMS.Classes;
using HitechTMS.File;

namespace HitechTMS
{
    public partial class frmMain : SecureBaseForm
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private IPrincipal _nextFormPrincipal;
        private GetResourceCaption dbGetResourceCaption;
        string str;

        public frmMain(IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString() }, userPrincipal)
        {
            _nextFormPrincipal = userPrincipal;
            InitializeComponent();
            dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            //this.ControlBox = false;
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
            Close();
        }

        private void productFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct productForm = new frmProduct();
            productForm.ShowDialog();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void emailConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmailConfig objEmailConfig = new frmEmailConfig();
            objEmailConfig.StartPosition = FormStartPosition.CenterParent;
            objEmailConfig.ShowDialog();
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseBackup objEmailConfig = new frmDatabaseBackup();
            objEmailConfig.StartPosition = FormStartPosition.CenterParent;
            objEmailConfig.ShowDialog();
        }
    }
}
