using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DAL.Entity_Model;
using SharedLibrary;
using System.Data.Entity.Migrations;

namespace CodeProjectSerialComms.MasterForms
{
    public partial class frmEmailConfig : Form
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        EncryptionAndDecryption objEncryptionAndDecryption;
        EmailConfig objEmailConfig;
        public frmEmailConfig()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.ControlBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            objEmailConfig = new EmailConfig();
            LoadData();
        }

        private void LoadData()
        {
            var emailConfigData = dbObj.EmailConfigs.Select(
                x => new {
                    x.Id,
                    x.EmailID,
                    x.EmailServerPort,
                    x.EmailSmtpServer,
                    x.Password,
                    x.IsActive,
                    x.EmailBody,
                    x.EmailSubject,
                    x.EmailRecipient
                }).ToList();
            if (emailConfigData.Count > 0)
            {
                txtEmailId.Text = emailConfigData[0].EmailID == null ? "" : emailConfigData[0].EmailID.ToString();
                txtPassword.Text = emailConfigData[0].Password ==null ? "" : objEncryptionAndDecryption.Decrypt(emailConfigData[0].Password).ToString();
                txtEmailServerPort.Text = emailConfigData[0].EmailServerPort.ToString();
                txtEmailSmtpServer.Text = emailConfigData[0].EmailSmtpServer ==null ? "" : emailConfigData[0].EmailSmtpServer.ToString();
                chkIsActive.Checked = emailConfigData[0].IsActive == "1" ? true : false;
                txtEmailBody.Text = emailConfigData[0].EmailBody ==null ? "" : emailConfigData[0].EmailBody.ToString();
                txtEmailSubject.Text = emailConfigData[0].EmailSubject ==null ? "" : emailConfigData[0].EmailSubject.ToString();
                txtEmailRecipient.Text = emailConfigData[0].EmailRecipient ==null ? "" : emailConfigData[0].EmailRecipient.ToString();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            objEmailConfig.Id = Guid.NewGuid();
            objEmailConfig.EmailID = txtEmailId.Text.ToString();
            objEmailConfig.Password = objEncryptionAndDecryption.Encrypt(txtPassword.Text.ToString());
            objEmailConfig.EmailServerPort = Convert.ToInt32(txtEmailServerPort.Text);
            objEmailConfig.EmailSmtpServer = txtEmailSmtpServer.Text.ToString();
            objEmailConfig.IsActive = (chkIsActive.Checked == true ? "1" : "0");
            objEmailConfig.EmailBody = txtEmailBody.Text.ToString();
            objEmailConfig.EmailSubject = txtEmailSubject.Text.ToString();
            objEmailConfig.EmailRecipient = txtEmailRecipient.Text.ToString();
            dbObj.EmailConfigs.AddOrUpdate(objEmailConfig);
            if(dbObj.SaveChanges()==1)
            {
                MessageBox.Show("Data Saved!");
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmailId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEmailId.Text == "")
            {
                errProvider.SetError(txtEmailId, "Email ID can't be blank");
            }
            else
            {
                errProvider.Clear();
            }
        }
    }
}
