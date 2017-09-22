using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using SharedLibrary;

namespace HitechTMSActivation
{
    public partial class Form1 : Form
    {
        public EncryptionAndDecryption _encryptionAndDecryption = new EncryptionAndDecryption();
        public Form1()
        {
            //_encryptionAndDecryption = new EncryptionAndDecryption();
            InitializeComponent();
        }
        List<Guid> getpassword;
        string regPath;
        public Form1(List<Guid> passname, String path)
        {
            InitializeComponent();
            getpassword = passname;
            regPath = path;
        }

        public bool passwordEntry(List<Guid> originalPass, Guid password)
        {
            Guid pass = new Guid();
            pass = password;
            if (originalPass.Contains(pass))
            {
                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.CreateSubKey(regPath); //path

                if (regkey != null)
                {
                    regkey.SetValue("Password",_encryptionAndDecryption.Encrypt(pass.ToString()).ToString()); //Value Name,Value Data
                }
                return true;
            }
            else
                return false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtProductKey.Text.Trim() != string.Empty)
            {
                //if password true then send true			
                bool value = passwordEntry(getpassword, new Guid(txtProductKey.Text));
                if (value)
                {
                    MessageBox.Show("Thank you for activation!", "Activate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Product Key is not valid! Please Enter a valid Product Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //----------------------------------------------		
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
