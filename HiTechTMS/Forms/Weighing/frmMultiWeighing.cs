using DAL.Entity_Model;
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

namespace HitechTMS.Weighing
{
    public partial class frmMultiWeighing : HitechTMSSecurity.SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        public frmMultiWeighing(IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //transNormalWeight objtransNormalWeight = new transNormalWeight();
        }

        private void grpboxNormalWeighing_Enter(object sender, EventArgs e)
        {
            //var a = _dbObj.
        }
    }
}
