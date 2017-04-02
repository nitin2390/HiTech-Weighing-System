using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.Weighing
{
    public partial class frmProductInOut : Form
    {
        public enumProductNormalPublicMulti _enumProductNormalPublicMulti { get; set; }
        public enumProductInOut _enumProductInOut { get; set; }
        public frmProductInOut(enumProductNormalPublicMulti EnumProductInOut)
        {
            InitializeComponent();
            _enumProductNormalPublicMulti = EnumProductInOut;
            this.Text = _enumProductNormalPublicMulti.ToString() + " Weighing";
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _enumProductInOut = rdbProductIn.Checked == true ? enumProductInOut.In : enumProductInOut.Out;
            frmNormalWeighing objfrmNormalWeighing = new frmNormalWeighing(_enumProductInOut);
            objfrmNormalWeighing.StartPosition = FormStartPosition.CenterParent;
            objfrmNormalWeighing.ShowDialog();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
