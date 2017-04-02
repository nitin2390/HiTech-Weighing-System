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
    public partial class frmNormalWeighing : Form
    {
        public enumProductInOut _enumProductInOut { get; set; }
        public frmNormalWeighing(enumProductInOut EnumProductNormalPublicMulti)
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            _enumProductInOut = EnumProductNormalPublicMulti;
            Text = "Normal Weighing (Product " + _enumProductInOut.ToString() + ")";
            BindGrid();
        }
        private void BindGrid()
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
