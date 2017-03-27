using DAL.Entity_Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace HitechTMS
{
    public partial class frmDatabaseBackup : Form
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        public frmDatabaseBackup()
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
            SaveFD.FileName = "Test";
            SaveFD.Title = "Backup ";
            SaveFD.Filter = "Database files (*.mdf)|*.mdf";
            SaveFD.FilterIndex = 1;
            SaveFD.DefaultExt = "mdf";
            SaveFD.RestoreDirectory = true;
            if (SaveFD.ShowDialog() == DialogResult.OK)
            {
                FileName = SaveFD.FileName;
                string sourcePath = Application.StartupPath.ToString() + "\\HitechTruckMngtSystmDataBaseFile.mdf";
                AppDomain.CurrentDomain.SetData("DataDirectory", sourcePath);
                //string src = sourcePath + "\\Test.mdf";
                string dst = @"C:\Bill";
                System.IO.File.Copy(sourcePath, dst, true);
            }
        }
    }
}
