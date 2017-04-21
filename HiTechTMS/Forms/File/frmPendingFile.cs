using DAL.Entity_Model;
using HitechTMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.File
{
    public partial class frmPendingFile : HitechTMSSecurity.SecureBaseForm
    {
        private GetResourceCaption _dbGetResourceCaption;
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        public FrmName _frmName { get; set; }
        public frmPendingFile(FrmName FrmName,IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Supervisor.ToString(), HitechEnums.AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _frmName = FrmName;
            _dbGetResourceCaption = new GetResourceCaption();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            LoadCaption();
            LoadGridData();
        }

        private void LoadGridData()
        {
            try
            {
                if (rdbNormalWeight.Checked == true)
                {
                   var QueryNormalWeight = _dbObj.transNormalWeight.Where(x => x.IsPending == 0).ToList();
                    gridPendingFile.DataSource = QueryNormalWeight;
                }
                else if(rdbPublicWeight.Checked == true)
                {
                    var QueryPublicWeight = _dbObj.transPublicWeight.Where(x => x.IsPending == 0).ToList();
                    gridPendingFile.DataSource = QueryPublicWeight;
                }
                else if(rdbMultiWeight.Checked == true)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCaption()
        {
            try
            {
                rdbNormalWeight.Text = _dbGetResourceCaption.GetStringValue("NORMAL_WEIGHING");
                rdbPublicWeight.Text = _dbGetResourceCaption.GetStringValue("PUBLIC_WEIGHING");
                rdbMultiWeight.Text = _dbGetResourceCaption.GetStringValue("MULTI_WEIGHING");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbNormalWeight_CheckedChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void rdbPublicWeight_CheckedChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void rdbMultiWeight_CheckedChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }
    }
}
