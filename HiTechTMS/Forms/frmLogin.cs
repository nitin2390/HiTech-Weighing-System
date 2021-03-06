﻿using System;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DAL.Entity_Model;
using HitechTMS.Classes;
using SharedLibrary;
using HitechTMS.Config;

namespace HitechTMS
{
    public partial class frmLogin : Form
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private EncryptionAndDecryption objEncryptionAndDecryption;
        private GetResourceCaption _dbGetResourceCaption;
        public frmLogin()
        {
            InitializeComponent();
            _dbGetResourceCaption = new GetResourceCaption();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            var password = objEncryptionAndDecryption.Encrypt(txtPassword.Text.ToUpper());
            var varUserRole = dbObj.UserRoleTypes
                            .Join(dbObj.UserRole, x => x.Id, s => s.UserRoleType, 
                                    (x, s) => new { x.RoleName, s.Name, s.Password })
                .Where(xs => xs.Name == txtUserName.Text && xs.Password == password).Select(x => x.RoleName).ToList().SingleOrDefault();

            if (varUserRole != null && varUserRole != string.Empty)
            {

                // Initialize a test Principal 
                IPrincipal userPrincipal = new GenericPrincipal(WindowsIdentity.GetCurrent(),
                    new string[] { varUserRole });
                //new string[] { "Admin", "User" });

                frmMain objHiTechWeighingSystem = new frmMain(txtUserName.Text, userPrincipal, varUserRole);
                // Set form to be main window in order to Exit the application.
                this.Hide();
                objHiTechWeighingSystem.IsMainWindow = true;
                objHiTechWeighingSystem.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("USER_NAME_PASSWORD_MISTMATCH"),
                    _dbGetResourceCaption.GetStringValue("ERROR"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click((object)sender, (EventArgs)e);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtUserName.Text != string.Empty)
            {
                txtPassword.Focus();
            }
        }
    }
}
