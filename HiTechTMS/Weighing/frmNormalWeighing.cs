using DAL.Entity_Model;
using HitechTMS.Classes;
using SharedLibrary;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;
using Business;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;

namespace HitechTMS.Weighing
{
    public partial class frmNormalWeighing : Form
    {
        public enumProductInOut _enumProductInOut { get; set; }
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        CalculateNetWeight _objCalculateNetWeight;
        public enumWeightMode _weightMode { get; set; }
        private Boolean _editGrid { get; set; }
        public Boolean _saveClick { get; set; }
        public Guid _transNormalWeightID { get; set; }
        private Common _comm { get; set; }
        private FrmName _frmName { get; set; }
        public frmNormalWeighing(enumProductInOut EnumProductNormalPublicMulti, enumWeightMode Mode)
        {
            InitializeComponent();

            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _weightMode = Mode;
            _objCalculateNetWeight = new CalculateNetWeight();
            _dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            _editGrid = false;
            _saveClick = false;
            _enumProductInOut = EnumProductNormalPublicMulti;
            Text = "Normal Weighing (Product " + _enumProductInOut.ToString() + ")";
            bindComboBox();
            setEnableDisable();
        }

        private void setEnableDisable()
        {
            try
            {
                txtMode.Text = _weightMode.ToString();
                txtProductName.ReadOnly = txtCustomerName.ReadOnly = txtTranspoterName.ReadOnly = true;
                txtDateIn.ReadOnly = txtDateOut.ReadOnly = true;
                txtTimeIn.ReadOnly = txtTimeOut.ReadOnly = true;
                txtNetWeight.ReadOnly = true;
                lstTruck.Visible = false;


                if(_enumProductInOut == enumProductInOut.In)
                {
                    // Gross :  txt : 515, 124 lbl : 511, 104

                    //Tare : txt : 515, 55 lbl : 511, 35

                    txtGrossWeight.Location = new Point(515,55);
                    lblGrossWeight.Location = new Point(511,35);

                    txtTareWeight.Location = new Point(515,124);
                    lblTareWeight.Location = new Point(511,104);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindComboBox()
        {
            try
            {
                var productList = _dbObj.Products.Select(x => x).ToList();
                productList.Insert(0, new Product() { Code = "Select" , Name =""});
                cmbProductCode.DataSource = productList;
                cmbProductCode.DisplayMember = "Code";
                cmbProductCode.ValueMember = "Code";


                var supplierList = _dbObj.mstSupplierTransporter
                    .Where(x => x.IsSuplier == ((int)FrmName.Supplier).ToString())
                    .Select(x => x).ToList();
                supplierList.Insert(0, new mstSupplierTransporter() { Id = Guid.NewGuid(), SupplierCode = "Select", SupplierName = "" });

                cmbCustomerCode.DataSource = supplierList;
                cmbCustomerCode.DisplayMember = "SupplierCode";
                cmbCustomerCode.ValueMember = "Id";
                              
                var transporterList = _dbObj.mstSupplierTransporter
                    .Where(x => x.IsSuplier == ((int)FrmName.Transport).ToString())
                    .Select(x => x).ToList();
                transporterList.Insert(0, new mstSupplierTransporter() { Id= Guid.NewGuid(), SupplierCode = "Select", SupplierName = "" });

                cmbTranspoterCode.DataSource = transporterList;
                cmbTranspoterCode.DisplayMember = "SupplierCode";
                cmbTranspoterCode.ValueMember = "Id";

                //cmbTruck.DataSource = Enum.GetValues(typeof(enumWeightUnit));


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                List<transNormalWeight> existsQuery = new List<transNormalWeight>();
                _saveClick = true;
                if(_enumProductInOut == enumProductInOut.Out)
                {
                    existsQuery = _dbObj.transNormalWeight.Select(x => x).Where(x => x.ID == _transNormalWeightID && x.IsPending == 0).ToList();

                }
                else
                {
                    existsQuery = _dbObj.transNormalWeight.Select(x => x).Where(x => x.ID == _transNormalWeightID && x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();
                }

                transNormalWeight objtransNormalWeight = new transNormalWeight();
                objtransNormalWeight.Mode = (byte)_weightMode;
                objtransNormalWeight.Truck = txtTruck.Text;
                objtransNormalWeight.ProductCode = cmbProductCode.SelectedValue.ToString();
                objtransNormalWeight.SupplierCode = (Guid)cmbCustomerCode.SelectedValue;
                objtransNormalWeight.TransporterCode = (Guid)cmbTranspoterCode.SelectedValue;
                objtransNormalWeight.ChallanNumber = txtChallanNumber.Text;
                objtransNormalWeight.ChallanDate = DateTime.ParseExact(txtChallanDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.ChallanWeight = Convert.ToDecimal(txtChallanWeight.Text);
                objtransNormalWeight.ChallanWeightUnit = Convert.ToByte(cmbChallanWeight.SelectedIndex);
                objtransNormalWeight.Miscellaneous = txtMiscellaneous.Text + ";" + txtMiscellaneous1.Text;
                objtransNormalWeight.DeliveryNoteN = txtDeliveryNoteN.Text;
                objtransNormalWeight.DateIn = DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.TimeIn = TimeSpan.Parse(txtTimeIn.Text);
                objtransNormalWeight.DateOut = DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.TimeOut = TimeSpan.Parse(txtTimeOut.Text);
                objtransNormalWeight.TareWeight = Convert.ToDecimal(txtTareWeight.Text);
                objtransNormalWeight.GrossWeight = Convert.ToDecimal(txtGrossWeight.Text);
                objtransNormalWeight.NetWeight = Convert.ToDecimal(txtNetWeight.Text);
                objtransNormalWeight.UpdatedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.IsPending = (byte)(_enumProductInOut == enumProductInOut.In ? 0 : 1);
                objtransNormalWeight.ProdInOut = (byte)_enumProductInOut;

                if (existsQuery.Count > 0)
                {
                    objtransNormalWeight.AddedDate = DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransNormalWeight.ID = _transNormalWeightID;
                    _dbObj.transNormalWeight.AddOrUpdate(objtransNormalWeight);
                    if (_dbObj.SaveChanges() > 0)
                    {
                        ResetCntrl();
                        //BindGrid();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_UPDATE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    objtransNormalWeight.AddedDate = DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransNormalWeight.ID = Guid.NewGuid();
                    _dbObj.transNormalWeight.Add(objtransNormalWeight);
                    if (_dbObj.SaveChanges() == 1)
                    {
                        ResetCntrl();
                        //BindGrid();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCntrl()
        {
            try
            {
                _editGrid = false;
                _saveClick = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cmbProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductCode.SelectedIndex != 0)
            {
                txtProductName.Text = ((DAL.Entity_Model.Product)cmbProductCode.SelectedItem).Name;
            }
            else
            {
                txtProductName.Text = "";
            }
        }

        private void cmbCustomerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerCode.SelectedIndex > 0)
            {
                txtCustomerName.Text = ((DAL.Entity_Model.mstSupplierTransporter)cmbCustomerCode.SelectedItem).SupplierName;
            }
            else
            {
                txtCustomerName.Text = "";
            }
        }

        private void cmbTranspoterCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTranspoterCode.SelectedIndex != 0)
            {
                txtTranspoterName.Text = ((DAL.Entity_Model.mstSupplierTransporter)cmbTranspoterCode.SelectedItem).SupplierName;
            }
            else
            {
                txtTranspoterName.Text = "";
            }
        }

        private void txtTareWeight_TextChanged(object sender, EventArgs e)
        {
            if (!_editGrid)
            {
                if (txtTareWeight.Text.Trim() != "")
                {
                    txtDateIn.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    txtTimeIn.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    txtDateIn.Text = "";
                    txtTimeIn.Text = "";
                }
                CalNetWeight();
            }
        }

        private void txtGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if (!_editGrid)
            {
                if (txtGrossWeight.Text.Trim() != "")
                {
                    txtDateOut.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    txtTimeOut.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    txtDateOut.Text = "";
                    txtTimeOut.Text = "";
                }
                CalNetWeight();
            }
        }

        private void CalNetWeight()
        {
            try
            {
                if (txtGrossWeight.Text.Trim() != "" && txtTareWeight.Text.Trim() != "")
                {
                    txtNetWeight.Text = _objCalculateNetWeight.netWeight(double.Parse(txtGrossWeight.Text), double.Parse(txtTareWeight.Text)).ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTruck_TextChanged(object sender, EventArgs e)
        {
            if (!_saveClick)
            {
                AutoFill();
            }
        }

        private void AutoFill()
        {
            List<transNormalWeight> listNomralWeighing = new List<transNormalWeight>();

            if (_enumProductInOut == enumProductInOut.Out)
            {
                listNomralWeighing = _dbObj.transNormalWeight
                            .Where(x => x.IsPending == 0 && x.Truck.Contains(txtTruck.Text))
                            .Select(x => x).ToList();
            }
            else
            {
            listNomralWeighing = _dbObj.transNormalWeight
                            .Where(x => x.IsPending == 0 && x.Truck.Contains(txtTruck.Text) && x.ProdInOut == (byte)_enumProductInOut)
                            .Select(x =>  x ).ToList();
            }

            if (listNomralWeighing.Count > 0)
            {

                lstTruck.Visible = true;
                lstTruck.DataSource = listNomralWeighing;
                lstTruck.DisplayMember = "Truck";
                lstTruck.ValueMember = "Id";
            }
            else
            {
                lstTruck.Visible = false;
                _transNormalWeightID = Guid.Empty;
            }
        }

        private void FillTrucAndSetEditId()
        {
            if (lstTruck.SelectedIndex > -1)
            {
                _editGrid = true;
                txtTruck.Text = lstTruck.GetItemText(lstTruck.SelectedItem);
                _transNormalWeightID = (Guid)(lstTruck.SelectedValue);
                lstTruck.Visible = false;
                FillFormData();
            }
            else
            {
                _editGrid = false;
                txtTruck.Text = "";
                _transNormalWeightID = Guid.Empty;
            }
        }

        private void FillFormData()
        {
            try
            {
                List<transNormalWeight> lsttransNormalWeight = new List<transNormalWeight>();
                if (_enumProductInOut == enumProductInOut.Out)
                {
                    lsttransNormalWeight = _dbObj.transNormalWeight.Select(x => x).Where(x => x.ID == _transNormalWeightID && x.IsPending == 0).ToList();
                }
                else
                {
                    lsttransNormalWeight = _dbObj.transNormalWeight.Select(x => x).Where(x => x.ID == _transNormalWeightID && x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();
                }

                var guidCustomerCode = lsttransNormalWeight[0].SupplierCode;
                var guidTransporterCode = lsttransNormalWeight[0].TransporterCode;

                var objCustomerCode = _dbObj.mstSupplierTransporter.FirstOrDefault(x => x.Id == guidCustomerCode);
                var objTransporterCode = _dbObj.mstSupplierTransporter.FirstOrDefault(x => x.Id == guidTransporterCode);

                cmbProductCode.SelectedIndex = cmbProductCode.FindString(lsttransNormalWeight[0].ProductCode);
                cmbCustomerCode.SelectedIndex = cmbCustomerCode.FindString(objCustomerCode.SupplierCode);
                cmbTranspoterCode.SelectedIndex = cmbTranspoterCode.FindString(objTransporterCode.SupplierCode);
                cmbChallanWeight.SelectedIndex = cmbChallanWeight.FindString(lsttransNormalWeight[0].ChallanWeightUnit ==0 ? "t" : "kg");


                txtChallanNumber.Text = lsttransNormalWeight[0].ChallanNumber;
                txtChallanDate.Text = DateTime.Parse(lsttransNormalWeight[0].ChallanDate.ToString()).ToString("dd/MM/yyyy");
                txtChallanWeight.Text = lsttransNormalWeight[0].ChallanWeight.ToString();
                txtMiscellaneous.Text = lsttransNormalWeight[0].Miscellaneous.Split(';')[0];
                txtMiscellaneous1.Text = lsttransNormalWeight[0].Miscellaneous.Split(';')[1];
                txtDeliveryNoteN.Text = lsttransNormalWeight[0].DeliveryNoteN;
                txtDateIn.Text = DateTime.Parse(lsttransNormalWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy");
                txtTimeIn.Text = TimeSpan.Parse(lsttransNormalWeight[0].TimeIn.ToString()).ToString();
                txtDateOut.Text = DateTime.Parse(lsttransNormalWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy");
                txtTimeOut.Text = TimeSpan.Parse(lsttransNormalWeight[0].TimeOut.ToString()).ToString();
                txtTareWeight.Text = lsttransNormalWeight[0].TareWeight.ToString();
                txtGrossWeight.Text = lsttransNormalWeight[0].GrossWeight.ToString();
                txtNetWeight.Text = lsttransNormalWeight[0].NetWeight.ToString();
                _editGrid = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstTruck_DoubleClick(object sender, EventArgs e)
        {
            FillTrucAndSetEditId();
        }

        private void lstTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillTrucAndSetEditId();
            }
        }

        private void txtTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                lstTruck.Focus();
            }
        }
    }
}
