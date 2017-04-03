using DAL.Entity_Model;
using HitechTMS.Classes;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        public enumWeightMode _weightMode { get; set; }
        public Guid _transNormalWeightID { get; set; }
        //private GetResourceCaption _dbGetResourceCaption;
        private Common _comm { get; set; }
        private FrmName _frmName { get; set; }
        public frmNormalWeighing(enumProductInOut EnumProductNormalPublicMulti, enumWeightMode Mode)
        {
            InitializeComponent();

            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _weightMode = Mode;
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            _enumProductInOut = EnumProductNormalPublicMulti;
            Text = "Normal Weighing (Product " + _enumProductInOut.ToString() + ")";
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            var existsQuery = _dbObj.transNormalWeight.Select(x => x).Where(x => x.ID == _transNormalWeightID).ToList();

            transNormalWeight objtransNormalWeight = new transNormalWeight();
            objtransNormalWeight.Mode = (byte)_weightMode;
            objtransNormalWeight.Truck = txtTruck.Text;
            objtransNormalWeight.ProductCode = cmbProductCode.SelectedValue.ToString();
            objtransNormalWeight.SupplierCode = (Guid)cmbCustomerCode.SelectedValue;
            objtransNormalWeight.TransporterCode = (Guid)cmbCustomerCode.SelectedValue;
            objtransNormalWeight.ChallanNumber = txtChallanNumber.Text;
            objtransNormalWeight.ChallanDate = DateTime.ParseExact(txtChallanDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objtransNormalWeight.ChallanWeight = Convert.ToDecimal(txtChallanWeight.Text);
            objtransNormalWeight.Miscellaneous = txtMiscellaneous.Text + " ; " + txtMiscellaneous1.Text;
            objtransNormalWeight.DeliveryNoteN = txtDeliveryNoteN.Text;
            objtransNormalWeight.DateIn = DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objtransNormalWeight.TimeIn = TimeSpan.Parse(txtTimeIn.Text);
            objtransNormalWeight.DateOut = DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objtransNormalWeight.TimeOut = TimeSpan.Parse(txtTimeOut.Text);
            objtransNormalWeight.TareWeight = Convert.ToDecimal(txtTareWeight.Text);
            objtransNormalWeight.GrossWeight = Convert.ToDecimal(txtGrossWeight.Text);
            objtransNormalWeight.NetWeight = Convert.ToDecimal(txtNetWeight.Text);

            if (existsQuery.Count > 0)
            {
                objtransNormalWeight.ID = _transNormalWeightID;
            }
            else
            {
                objtransNormalWeight.ID = Guid.NewGuid();
            }
        }
    }
}
