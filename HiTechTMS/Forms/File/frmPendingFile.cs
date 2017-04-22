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
                    //var query = dbObj.UserRoleTypes
                    //    .Join(dbObj.UserRole, x => x.Id, s => s.UserRoleType, (x, s) => new { s.Name, x.RoleName })
                    //    .Where(x => x.RoleName != HitechEnums.AppRole.SuperAdmin.ToString())
                    //    .Select(x => x);

                    var QueryNormalWeight = _dbObj.viewNormalPendingFile.ToList();
                    gridPendingFile.DataSource = QueryNormalWeight;
                    HideColumns(HitechEnums.FrmName.NormalWeighing);
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

        private void HideColumns(HitechEnums.FrmName frmName)
        {
            try
            {
                if(gridPendingFile.ColumnCount > 0)
                {
                    if (gridPendingFile.Columns.Contains("ID") == true)
                        gridPendingFile.Columns["ID"].Visible = false;

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
