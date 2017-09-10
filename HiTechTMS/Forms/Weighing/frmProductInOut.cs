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

namespace HitechTMS.Weighing
{
    public partial class frmProductInOut : HitechTMSSecurity.SecureBaseForm
    {
        public IPrincipal _iPrincipal { get; set; }
        public enumProductNormalPublicMulti _enumProductNormalPublicMulti { get; set; }
        public enumWeightMode _weightMode { get; set; }
        public enumProductInOut _enumProductInOut { get; set; }
        public frmProductInOut(enumProductNormalPublicMulti EnumProductInOut, enumWeightMode Mode ,IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _iPrincipal = userPrincipal;
            _enumProductNormalPublicMulti = EnumProductInOut;
            _weightMode = Mode;
            this.Text = _enumProductNormalPublicMulti.ToString() + " Weighing";
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            _enumProductInOut = rdbProductIn.Checked  ? enumProductInOut.In : enumProductInOut.Out;

            if(_enumProductNormalPublicMulti == enumProductNormalPublicMulti.Normal)
            {
                frmNormalWeighing objfrmNormalWeighing = new frmNormalWeighing(_enumProductInOut, _weightMode, _iPrincipal);
                objfrmNormalWeighing.StartPosition = FormStartPosition.CenterParent;
                objfrmNormalWeighing.ShowDialog();
            }
            else if(_enumProductNormalPublicMulti == enumProductNormalPublicMulti.Public)
            {
                frmPublicWeighing objfrmPublicWeighing = new frmPublicWeighing(_enumProductInOut, _weightMode,_iPrincipal);
                objfrmPublicWeighing.StartPosition = FormStartPosition.CenterParent;
                objfrmPublicWeighing.ShowDialog();
            }
            else if (_enumProductNormalPublicMulti == enumProductNormalPublicMulti.Multi)
            {
                frmMultiWeighing objfrmPublicWeighing = new frmMultiWeighing(_enumProductInOut, _weightMode, _iPrincipal);
                objfrmPublicWeighing.StartPosition = FormStartPosition.CenterParent;
                objfrmPublicWeighing.ShowDialog();
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
