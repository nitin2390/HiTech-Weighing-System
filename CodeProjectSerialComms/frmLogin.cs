using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DAL.Entity_Model;



namespace CodeProjectSerialComms
{
    public partial class frmLogin : Form
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private Bitmap MyImage;
        public frmLogin()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.ControlBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //var UserRole = dbObj.UserRoles.Where(x => x.Name == txtUserName.Text && x.Password==txtPassword.Text).Select(x => x.UserRoleType ).Single();

            var varUserRole = dbObj.UserRoleTypes.Join(dbObj.UserRoles, x => x.Id, s=> s.UserRoleType,(x,s) => new { x.RoleName,s.Name,s.Password }).Where(xs => xs.Name == txtUserName.Text && xs.Password == txtPassword.Text).Select( x => x.RoleName).ToList().SingleOrDefault();

            if (varUserRole != null && varUserRole != "")
            {
                // Initialize a test Principal 
                IPrincipal userPrincipal = new GenericPrincipal(WindowsIdentity.GetCurrent(),
                    new string[] { varUserRole });
                //new string[] { "Admin", "User" });
                frmMain objHiTechWeighingSystem = new frmMain(userPrincipal);
                // Set form to be main window in order to Exit the application.
                this.Hide();
                objHiTechWeighingSystem.IsMainWindow = true;
                objHiTechWeighingSystem.ShowDialog();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("User name and Password doesn't match!");
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
    }
}
