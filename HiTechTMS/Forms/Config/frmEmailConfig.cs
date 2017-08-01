using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DAL.Entity_Model;
using SharedLibrary;
using System.Data.Entity.Migrations;
using System.Text.RegularExpressions;
using HitechTMS.Classes;
using System.Security.Principal;
using HitechTMSSecurity;

namespace HitechTMS.MasterForms
{
    public partial class frmEmailConfig : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        public Guid ID { get; set; }
        EncryptionAndDecryption objEncryptionAndDecryption;
        EmailConfig objEmailConfig;
        // declare Resource manager to access to specific cultureinfo
        public frmEmailConfig(IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString() , HitechEnums.AppRole.SuperAdmin.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            objEmailConfig = new EmailConfig();
            LoadData();
            btnExit.CausesValidation = false;
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
                ID = emailConfigData[0].Id == Guid.Empty ? Guid.NewGuid() : emailConfigData[0].Id;
                txtEmailId.Text = emailConfigData[0].EmailID == null ? "" : emailConfigData[0].EmailID.ToString();
                txtPassword.Text = emailConfigData[0].Password == null ? "" : objEncryptionAndDecryption.Decrypt(emailConfigData[0].Password).ToString();
                txtEmailServerPort.Text = emailConfigData[0].EmailServerPort.ToString();
                txtEmailSmtpServer.Text = emailConfigData[0].EmailSmtpServer == null ? "" : emailConfigData[0].EmailSmtpServer.ToString();
                chkIsActive.Checked = emailConfigData[0].IsActive == "1" ? true : false;
                txtEmailBody.Text = emailConfigData[0].EmailBody == null ? "" : emailConfigData[0].EmailBody.ToString();
                txtEmailSubject.Text = emailConfigData[0].EmailSubject == null ? "" : emailConfigData[0].EmailSubject.ToString();
                txtEmailRecipient.Text = emailConfigData[0].EmailRecipient == null ? "" : emailConfigData[0].EmailRecipient.ToString();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls[0].Controls.OfType<TextBox>())
            {
                control.Focus();
                #region "Validation"
                if (control.Name == "txtEmailId")
                {

                    if (string.IsNullOrEmpty(txtEmailId.Text))
                    {
                        DialogResult = DialogResult.None;
                        errProviderEmailID.SetError(txtEmailId, "Email ID required!");
                        return;
                    }
                    else if (!Regex.IsMatch(txtEmailId.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    {
                        DialogResult = DialogResult.None;
                        errProviderEmailID.SetError(txtEmailId, "Email ID invalid!");
                        return;
                    }
                    else
                    {
                        errProviderEmailID.SetError(txtEmailId, null);
                    }
                }
                if (control.Name == "txtEmailServerPort")
                {
                    if (string.IsNullOrEmpty(txtEmailServerPort.Text))
                    {
                        DialogResult = DialogResult.None;
                        errProviderSMTPServerPort.SetError(txtEmailServerPort, "Server Port required!");
                        return;
                    }
                    else if(!Regex.IsMatch(txtEmailServerPort.Text, @"^\d+$"))
                    {
                        DialogResult = DialogResult.None;
                        errProviderSMTPServerPort.SetError(txtEmailServerPort, "Server Port is invalid!");
                        return;
                    }
                    else
                    {
                        errProviderSMTPServerPort.SetError(txtEmailServerPort, null);
                    }
                }

                if (control.Name == "txtPassword")
                {
                    if (string.IsNullOrEmpty(txtPassword.Text))
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

                if (control.Name == "txtEmailRecipient")
                {

                    if (string.IsNullOrEmpty(txtEmailRecipient.Text))
                    {
                        DialogResult = DialogResult.None;
                        errProviderRecipient.SetError(txtEmailRecipient, "Recipient email ID required!");
                        return;
                    }
                    else if (!Regex.IsMatch(txtEmailRecipient.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    {
                        DialogResult = DialogResult.None;
                        errProviderRecipient.SetError(txtEmailRecipient, "Recipient email ID invalid!");
                        return;
                    }
                    else
                    {
                        errProviderRecipient.SetError(txtEmailRecipient, null);
                    }
                }

                if (control.Name == "txtEmailSmtpServer")
                {
                    if (string.IsNullOrEmpty(txtEmailSmtpServer.Text))
                    {
                        DialogResult = DialogResult.None;
                        errProviderSMTPServer.SetError(txtEmailSmtpServer, "Smtp server is required!");
                        return;
                    }
                    else if(!Regex.IsMatch(txtEmailSmtpServer.Text, @"^\w+\.\w+\.[a-zA-z]{1,3}$",RegexOptions.IgnoreCase))
                    {
                        DialogResult = DialogResult.None;
                        errProviderSMTPServer.SetError(txtEmailSmtpServer, "Smtp server is invalid!");
                        return;
                    }
                    else
                    {
                        errProviderSMTPServer.SetError(txtEmailSmtpServer, null);
                    }
                }

                if (control.Name == "txtEmailSubject")
                {
                    if (string.IsNullOrEmpty(txtEmailSubject.Text))
                    {
                        DialogResult = DialogResult.None;
                        errProviderEmailSubject.SetError(txtEmailSubject, "Email subject required!");
                        return;
                    }
                    else
                    {
                        errProviderEmailSubject.SetError(txtEmailSubject, null);
                    }
                }

                if (control.Name == "txtEmailBody")
                {
                    if (string.IsNullOrEmpty(txtEmailBody.Text))
                    {
                        DialogResult = DialogResult.None;
                        errProviderEmailBody.SetError(txtEmailBody, "Email body required!");
                        return;
                    }
                    else
                    {
                        errProviderEmailBody.SetError(txtEmailBody, null);
                    }
                }
                #endregion
            }
            objEmailConfig.Id = ID;
            objEmailConfig.EmailID = txtEmailId.Text.ToString();
            objEmailConfig.Password = objEncryptionAndDecryption.Encrypt(txtPassword.Text.ToString());
            objEmailConfig.EmailServerPort = Convert.ToInt32(txtEmailServerPort.Text);
            objEmailConfig.EmailSmtpServer = txtEmailSmtpServer.Text.ToString();
            objEmailConfig.IsActive = (chkIsActive.Checked == true ? "1" : "0");
            objEmailConfig.EmailBody = txtEmailBody.Text.ToString();
            objEmailConfig.EmailSubject = txtEmailSubject.Text.ToString();
            objEmailConfig.EmailRecipient = txtEmailRecipient.Text.ToString();
            dbObj.EmailConfigs.AddOrUpdate(objEmailConfig);
            if (dbObj.SaveChanges() == 1)
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"));
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmailConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
