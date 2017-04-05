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
        public enumWeightMode _weightMode { get; set; }
        public enumProductInOut _enumProductInOut { get; set; }
        public frmProductInOut(enumProductNormalPublicMulti EnumProductInOut, enumWeightMode Mode)
        {
            InitializeComponent();
            _enumProductNormalPublicMulti = EnumProductInOut;
            _weightMode = Mode;
            this.Text = _enumProductNormalPublicMulti.ToString() + " Weighing";
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            _enumProductInOut = rdbProductIn.Checked == true ? enumProductInOut.In : enumProductInOut.Out;
            frmNormalWeighing objfrmNormalWeighing = new frmNormalWeighing(_enumProductInOut, _weightMode);
            objfrmNormalWeighing.StartPosition = FormStartPosition.CenterParent;
            objfrmNormalWeighing.ShowDialog();
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
