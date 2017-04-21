using DAL.Entity_Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace HitechTMS
{
    public partial class frmDatabaseBackup : HitechTMSSecurity.SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        public frmDatabaseBackup(IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.ControlBox = false;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

            SaveFileDialog SaveFD = new SaveFileDialog();
            string FileName = "";
            SaveFD.FileName = "";
            SaveFD.Title = "Backup ";
            SaveFD.Filter = "Database files (*.mdf)|*.mdf";
            SaveFD.FilterIndex = 1;
            SaveFD.DefaultExt = "mdf";
            SaveFD.RestoreDirectory = true;
            if (SaveFD.ShowDialog() == DialogResult.OK)
            {
                //dbObj.Database.Connection.Close();
                FileName = SaveFD.FileName;
                string sourcePath = Environment.CurrentDirectory +  "\\db\\HitechTruckMngtSystmDataBaseFile.mdf";
                string src = sourcePath + "\\Test.mdf";
                string dst = @"C:\Bill";
                System.IO.File.Copy(sourcePath, dst, true);
                //dbObj.Database.Connection.Open();

                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.CreateNoWindow = false;
                //startInfo.UseShellExecute = false;
                ////Give the name as Xcopy
                //startInfo.FileName = "xcopy";
                //startInfo.Arguments = "\"" + sourcePath + "\"" + " " + "\"" + dst + "\"" + @" /e /y /I";
                //try
                //{
                //    // Start the process with the info we specified.
                //    // Call WaitForExit and then the using statement will close.
                //    using (Process exeProcess = Process.Start(startInfo))
                //    {
                //        exeProcess.WaitForExit();
                //    }
                //}
                //catch (Exception exp)
                //{
                //    throw exp;
                //}
            }
        }
    }
}
