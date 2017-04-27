using Business;
using DAL.Entity_Model;
using HitechTMS.Classes;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.Weighing
{
    public partial class frmMultiWeighing : HitechTMSSecurity.SecureBaseForm
    {
        public enumProductInOut _enumProductInOut { get; set; }
        private Boolean _isTareWeight { get; set; }
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        HitechTMS.Classes.ReadSerialPortData _readSerialPortData;

        private GetResourceCaption _dbGetResourceCaption;
        CalculateNetWeight _objCalculateNetWeight;
        public enumWeightMode _weightMode { get; set; }
        private Boolean _dbReturn { get; set; }
        public Boolean _saveClick { get; set; }
        public Boolean _unloadCompleteClick { get; set; }
        public Guid _transMultiWeightID { get; set; }
        private Common _comm { get; set; }
        private FrmName _frmName { get; set; }

        readonly double _MaxWeight;
        public frmMultiWeighing(enumProductInOut EnumProductNormalPublicMulti, enumWeightMode Mode, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _MaxWeight = 150;
            _readSerialPortData = new ReadSerialPortData();
            _weightMode = Mode;
            _objCalculateNetWeight = new CalculateNetWeight();
            _dbGetResourceCaption = new GetResourceCaption();
            _comm = new Common();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            _dbReturn = false;
            _saveClick = false;
            _unloadCompleteClick = false;
            _enumProductInOut = EnumProductNormalPublicMulti;
            Text = "Normal Weighing (Product " + _enumProductInOut.ToString() + ")";
            bindComboBox();
            setEnableDisable();
            _isTareWeight = true;
            //LoadGridWithPendingData();
        }
        private void bindComboBox()
        {
            try
            {
                var unloadProductList = _dbObj.Products.Select(x => x).ToList();
                unloadProductList.Insert(0, new Product() { Code = "Select", Name = "" });
                cmbUnloadedProductCode.DataSource = unloadProductList;
                cmbUnloadedProductCode.DisplayMember = "Code";
                cmbUnloadedProductCode.ValueMember = "Code";


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
                transporterList.Insert(0, new mstSupplierTransporter() { Id = Guid.NewGuid(), SupplierCode = "Select", SupplierName = "" });

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
                if (txtTruck.Text.Trim().Length < 1)
                {
                    errProvWeight.SetError(txtTruck, _dbGetResourceCaption.GetStringValue("TRUCK_CAN_NOT_BLANK"));
                    return;
                }
                transMultiWeight objtransMultiWeight = new transMultiWeight();

                var existsTransMultiWeight = (_dbObj.transMultiWeight.Where(x => x.ID == _transMultiWeightID && x.IsPending == 0 && x.ProdInOut == (byte)_enumProductInOut));
                objtransMultiWeight.Truck = txtTruck.Text;
                objtransMultiWeight.SupplierCode = cmbCustomerCode.SelectedIndex != 0 ? (Guid)cmbCustomerCode.SelectedValue : Guid.Empty;
                objtransMultiWeight.TransporterCode = cmbTranspoterCode.SelectedIndex != 0 ? (Guid)cmbTranspoterCode.SelectedValue : Guid.Empty;
                objtransMultiWeight.Mode = (byte)_weightMode;
                objtransMultiWeight.ChallanNumber = txtChallanNumber.Text;
                objtransMultiWeight.Miscellaneous = txtMiscellaneous.Text + ";" + txtMiscellaneous1.Text;
                objtransMultiWeight.ChallanDate = (txtChallanDate.Text != "" ? DateTime.ParseExact(txtChallanDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null);
                objtransMultiWeight.ChallanWeight = txtChallanWeight.Text != "" ? Convert.ToDecimal(txtChallanWeight.Text) : (Decimal?)null;
                objtransMultiWeight.DeliveryNoteN = txtDeliveryNoteN.Text;
                objtransMultiWeight.DateIn = (txtDateIn.Text != "" ? DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null);
                objtransMultiWeight.TimeIn = txtTimeIn.Text != "" ? TimeSpan.Parse(txtTimeIn.Text) : (TimeSpan?)null;
                objtransMultiWeight.TareWeight = _enumProductInOut == enumProductInOut.In ? txtGrossWeight.Text != "" ? Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null : txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text) : (Decimal?)null;
                objtransMultiWeight.DateOut = (txtDateOut.Text != "" ? DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null);
                objtransMultiWeight.TimeOut = txtTimeOut.Text != "" ? TimeSpan.Parse(txtTimeOut.Text) : (TimeSpan?)null;
                objtransMultiWeight.GrossWeight = _enumProductInOut == enumProductInOut.In ? txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text) : (Decimal?)null : txtGrossWeight.Text != "" ? Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null;
                objtransMultiWeight.UpdatedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransMultiWeight.IsPending = _unloadCompleteClick == true ? (byte)1 : (byte)0; //(byte)(txtNetWeight.Text != "" ? (Convert.ToDecimal(txtNetWeight.Text) > 0 ? 1 : 0) : 0);
                objtransMultiWeight.ProdInOut = (byte)_enumProductInOut;

                if (existsTransMultiWeight.Count() > 0)
                {
                    objtransMultiWeight.AddedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransMultiWeight.ID = _transMultiWeightID;
                    _dbObj.transMultiWeight.AddOrUpdate(objtransMultiWeight);
                    if (_dbObj.SaveChanges() > 0)
                    {
                        _isTareWeight = true;
                        SaveProductInfo();
                        LoadGridWithPendingData();
                        ResetCntrl();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_UPDATE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    objtransMultiWeight.AddedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransMultiWeight.ID = Guid.NewGuid();
                    _dbObj.transMultiWeight.Add(objtransMultiWeight);
                    if (_dbObj.SaveChanges() == 1)
                    {
                        ResetCntrl();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


                //SaveProductInfo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveProductInfo()
        {
            //objtransNormalWeight.ProductCode = cmbProductCode.SelectedValue.ToString() != "Select" ? cmbProductCode.SelectedValue.ToString() : null;
            MultiPrdWeight objMultiPrdWeight = new MultiPrdWeight();
            var existsMultiPrdWeight = 
                (_dbObj.MultiPrdWeight
                    .Select(x => x)
                    .Where(x => x.TruckID == _transMultiWeightID)).ToList();
            if(txtProductWeight.Text != "" && cmbUnloadedProductCode.SelectedValue.ToString() != "Select")
            {
                objMultiPrdWeight.Id = Guid.NewGuid();
                objMultiPrdWeight.TruckID = _transMultiWeightID;
                objMultiPrdWeight.UnloadedPrdCode = cmbUnloadedProductCode.SelectedValue.ToString() != "Select" ? cmbUnloadedProductCode.SelectedValue.ToString() : null;
                objMultiPrdWeight.UnloadedPrdWeight = txtProductWeight.Text != "" ?Convert.ToDecimal(txtProductWeight.Text): (Decimal?)null;
                _dbObj.MultiPrdWeight.Add(objMultiPrdWeight);

                if (_dbObj.SaveChanges() > 0)
                {
                    LoadGridWithPendingData();
                }
            }

            //if (existsMultiPrdWeight.Count > 0)
            //{

            //}
            //else
            //{

            //}

        }

        private void LoadGridWithPendingData()
        {
            try
            {
                //List<MultiPrdWeight> multiPrdWeightQuery = new List<MultiPrdWeight>();
                //_saveClick = true;
                var multiPrdWeightQuery = _dbObj.ViewMultiProduct
                    .Where(x => x.TruckID == _transMultiWeightID)
                    .Select(x => new { x.ProductCode,x.ProductName,x.Weight }).ToList();

                if (multiPrdWeightQuery.Count() > 0)
                {
                    gridMultiWeghing.Visible = true;
                    lblRecordsCount.Visible = lblRecCount.Visible = true;
                    gridMultiWeghing.DataSource = multiPrdWeightQuery;
                    lblRecordsCount.Text = gridMultiWeghing.RowCount.ToString();

                    SetGridHeader();
                }
                else
                {
                    gridMultiWeghing.DataSource = null; ;
                    lblRecordsCount.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetGridHeader()
        {
            try
            {
                if(gridMultiWeghing.Columns.Count>0)
                {
                    if(gridMultiWeghing.Columns.Contains("PRODUCTCODE"))
                    {
                        gridMultiWeghing.Columns["PRODUCTCODE"].HeaderText = _dbGetResourceCaption.GetStringValue("PRODUCT_CODE");
                    }
                    if (gridMultiWeghing.Columns.Contains("PRODUCTNAME"))
                    {
                        gridMultiWeghing.Columns["PRODUCTNAME"].HeaderText = _dbGetResourceCaption.GetStringValue("PRODUCT_NAME");
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
                _dbReturn = false;
                _saveClick = false;
                _isTareWeight = true;
                _unloadCompleteClick = false;
                cmbUnloadedProductCode.SelectedIndex = 0;
                cmbCustomerCode.SelectedIndex = 0;
                cmbTranspoterCode.SelectedIndex = 0;
                cmbChallanWeight.SelectedIndex = 0;
                txtProductWeight.Text = "";
                txtTruck.Text = "";
                txtChallanNumber.Text = "";
                txtChallanWeight.Text = "";
                txtMiscellaneous.Text = "";
                txtMiscellaneous1.Text = "";
                txtDeliveryNoteN.Text = "";
                txtChallanDate.Text = "";
                txtDateIn.Text = "";
                txtTimeIn.Text = "";
                txtDateOut.Text = "";
                txtTimeOut.Text = "";
                txtTareWeight.Text = "";
                txtGrossWeight.Text = "";
                txtGrossWeight.Text = "";
                txtNetWeight.Text = "";
                _transMultiWeightID = Guid.Empty;
                btnWeight.Text = "";
                errProvWeight.Clear();
                setEnableDisable();
                //LoadGridWithPendingData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void setEnableDisable()
        {
            try
            {
                txtMode.Text = _weightMode.ToString();
                //txtProductName.ReadOnly = 
                txtCustomerName.ReadOnly = txtTranspoterName.ReadOnly = true;
                txtDateIn.ReadOnly = txtDateOut.ReadOnly = true;
                txtTimeIn.ReadOnly = txtTimeOut.ReadOnly = true;
                gridMultiWeghing.DataSource = null;
                lstTruck.Visible = false;
                lblRecordsCount.Text = "0";
                txtUnloadedProductName.ReadOnly = txtChallanDate.ReadOnly = true;
                //gridMultiWeghing.Visible = true;
                //lblRecordsCount.Visible = lblRecCount.Visible = false;


                if (_enumProductInOut == enumProductInOut.In)
                {

                    lblGrossWeight.Text = _dbGetResourceCaption.GetStringValue("TARE_WEIGHT");
                    lblTareWeight.Text = _dbGetResourceCaption.GetStringValue("GROSS_WEIGHT");
                    txtGrossWeight.ReadOnly = true;
                }

                if (_weightMode == enumWeightMode.Auto)
                {
                    grpboxAutoWeight.Visible = true;
                    txtTareWeight.ReadOnly = true;
                    txtGrossWeight.ReadOnly = true;
                    txtProductWeight.ReadOnly = true;
                }
                else if (_weightMode == enumWeightMode.Manual)
                {
                    grpboxAutoWeight.Visible = false;
                    txtTareWeight.ReadOnly = false;
                    txtGrossWeight.ReadOnly = true;
                }

                txtNetWeight.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!_dbReturn)
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

            }
            CalNetWeight();
        }

        private void txtProductWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if (!_dbReturn)
            {
                if (txtGrossWeight.Text.Trim() != "")
                {
                    txtDateOut.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    txtTimeOut.Text = DateTime.Now.ToString("HH:mm:ss");


                        var totalProductWeight = _dbObj.MultiPrdWeight
                            .Where(x => x.TruckID == _transMultiWeightID)
                            .Select(x => x.UnloadedPrdWeight).ToList().Sum();

                    decimal ProductWeight = 0;
                    if (_enumProductInOut == enumProductInOut.In)
                    {
                         ProductWeight = Convert.ToDecimal(txtTareWeight.Text) - (Convert.ToDecimal(totalProductWeight) + Convert.ToDecimal(txtGrossWeight.Text));

                    }
                    else
                    {
                         ProductWeight = Convert.ToDecimal(txtGrossWeight.Text) - (Convert.ToDecimal(txtTareWeight.Text) + Convert.ToDecimal(totalProductWeight)) ;
                        
                    }

                    if (!_unloadCompleteClick)
                    {
                        if (ProductWeight > 0)
                        {
                            txtProductWeight.Text = ProductWeight.ToString();
                        }
                        else
                        {
                            txtProductWeight.Text = "0";
                        }
                    }
                }

                else
                {
                    txtDateOut.Text = "";
                    txtTimeOut.Text = "";
                }

            }
            CalNetWeight();
           
        }
        private void CalNetWeight()
        {
            try
            {
                if (txtGrossWeight.Text.Trim() != "" && txtTareWeight.Text.Trim() != "")
                {
                    if(_enumProductInOut == enumProductInOut.In)
                    {
                        var weight = _dbObj.MultiPrdWeight.Where(x => x.TruckID == _transMultiWeightID).Select(x => x.UnloadedPrdWeight).ToList().Sum();

                        string GrossWeight = _enumProductInOut == enumProductInOut.In ?
                           (Convert.ToDecimal(txtTareWeight.Text) - weight).ToString() : txtGrossWeight.Text;
                        string TareWeight = _enumProductInOut == enumProductInOut.In ? txtGrossWeight.Text : txtTareWeight.Text;

                        txtNetWeight.Text = _objCalculateNetWeight.netWeight(double.Parse(GrossWeight), double.Parse(TareWeight)).ToString();
                    }
                    else
                    {
                        txtNetWeight.Text = txtGrossWeight.Text;
                    }

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
                //FillTrucAndSetEditId();
            }
        }

        private void AutoFill()
        {
            List<transMultiWeight> listMultiWeight = new List<transMultiWeight>();


            listMultiWeight = _dbObj.transMultiWeight
                            .Where(x => x.IsPending == 0 && x.Truck.Contains(txtTruck.Text) && x.ProdInOut == (byte)_enumProductInOut)
                            .Select(x => x).ToList();

            if (listMultiWeight.Count > 0)
            {

                lstTruck.Visible = true;
                lstTruck.DataSource = listMultiWeight;
                lstTruck.DisplayMember = "Truck";
                lstTruck.ValueMember = "Id";
            }
            else
            {
                lstTruck.Visible = false;
                lstTruck.SelectedIndex = -1;
                _transMultiWeightID = Guid.Empty;
            }
        }

        private void FillTrucAndSetEditId()
        {
            //if (_dbReturn)
            //{
            //    //cmbProductCode.SelectedIndex = 0;
            //    cmbCustomerCode.SelectedIndex = 0;
            //    cmbTranspoterCode.SelectedIndex = 0;
            //    cmbChallanWeight.SelectedIndex = 0;
            //    txtChallanNumber.Text = "";
            //    txtChallanWeight.Text = "";
            //    txtMiscellaneous.Text = "";
            //    txtMiscellaneous1.Text = "";
            //    txtDeliveryNoteN.Text = "";
            //    txtChallanDate.Text = "";
            //    txtDateIn.Text = "";
            //    txtTimeIn.Text = "";
            //    txtDateOut.Text = "";
            //    txtTimeOut.Text = "";
            //    txtTareWeight.Text = "";
            //    txtGrossWeight.Text = "";
            //    txtGrossWeight.Text = "";
            //    txtNetWeight.Text = "";
            //    _transMultiWeightID = Guid.Empty;
            //    setEnableDisable();
            //    //_editGrid = true;
            //}
            if (lstTruck.SelectedIndex > -1)
            {
                _dbReturn = true;
                txtTruck.Text = lstTruck.GetItemText(lstTruck.SelectedItem);
                _transMultiWeightID = (Guid)(lstTruck.SelectedValue);
                lstTruck.Visible = false;
                FillFormData();
                LoadGridWithPendingData();


            }
            else
            {
                _dbReturn = false;
            }

        }
        private void FillFormData()
        {
            try
            {
                List<transMultiWeight> lsttransMultiWeight = new List<transMultiWeight>();
                lsttransMultiWeight = _dbObj.transMultiWeight.Select(x => x).Where(x => x.ID == _transMultiWeightID && x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();


                if (lsttransMultiWeight.Count > 0)
                {
                    var guidCustomerCode = lsttransMultiWeight[0].SupplierCode;
                    var guidTransporterCode = lsttransMultiWeight[0].TransporterCode;

                    var objCustomerCode = _dbObj.mstSupplierTransporter.FirstOrDefault(x => x.Id == guidCustomerCode);
                    var objTransporterCode = _dbObj.mstSupplierTransporter.FirstOrDefault(x => x.Id == guidTransporterCode);

                    //cmbProductCode.SelectedIndex = lsttransNormalWeight[0].ProductCode != null ? cmbProductCode.FindString(lsttransNormalWeight[0].ProductCode) : 0;
                    cmbCustomerCode.SelectedIndex = objCustomerCode != null ? cmbCustomerCode.FindString(objCustomerCode.SupplierCode) : 0;
                    cmbTranspoterCode.SelectedIndex = objTransporterCode != null ? cmbTranspoterCode.FindString(objTransporterCode.SupplierCode) : 0;
                    cmbChallanWeight.SelectedIndex = cmbChallanWeight.FindString(lsttransMultiWeight[0].ChallanWeightUnit == 0 ? "t" : "kg");


                    txtChallanNumber.Text = lsttransMultiWeight[0].ChallanNumber;
                    txtChallanDate.Text = lsttransMultiWeight[0].ChallanDate != null ? DateTime.Parse(lsttransMultiWeight[0].ChallanDate.ToString()).ToString("dd/MM/yyyy") : "";
                    txtChallanWeight.Text = lsttransMultiWeight[0].ChallanWeight.ToString();
                    txtMiscellaneous.Text = lsttransMultiWeight[0].Miscellaneous.Split(';')[0];
                    txtMiscellaneous1.Text = lsttransMultiWeight[0].Miscellaneous.Split(';')[1];
                    txtDeliveryNoteN.Text = lsttransMultiWeight[0].DeliveryNoteN;

                    if (_enumProductInOut == enumProductInOut.Out)
                    {
                        txtDateIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "" : lsttransMultiWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "";
                        txtDateOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "" : lsttransMultiWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "";
                        txtTimeIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeOut.ToString()).ToString() : "" : lsttransMultiWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeIn.ToString()).ToString() : "";
                        txtTimeOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeIn.ToString()).ToString() : "" : lsttransMultiWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeOut.ToString()).ToString() : "";
                    }
                    else
                    {
                        txtDateOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "" : lsttransMultiWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "";
                        txtDateIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "" : lsttransMultiWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransMultiWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "";
                        txtTimeOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeOut.ToString()).ToString() : "" : lsttransMultiWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeIn.ToString()).ToString() : "";
                        txtTimeIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeIn.ToString()).ToString() : "" : lsttransMultiWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransMultiWeight[0].TimeOut.ToString()).ToString() : "";
                    }




                    txtTareWeight.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].GrossWeight.ToString() != "" ? lsttransMultiWeight[0].GrossWeight.ToString() : "" : lsttransMultiWeight[0].TareWeight.ToString() != "" ? lsttransMultiWeight[0].TareWeight.ToString() : "";
                    txtGrossWeight.Text = _enumProductInOut == enumProductInOut.In ? lsttransMultiWeight[0].TareWeight.ToString() != "" ? lsttransMultiWeight[0].TareWeight.ToString() : "" : lsttransMultiWeight[0].GrossWeight.ToString() != "" ? lsttransMultiWeight[0].GrossWeight.ToString() : "";

                    txtNetWeight.Text = lsttransMultiWeight[0].NetWeight.ToString() != "" ? lsttransMultiWeight[0].NetWeight.ToString() : "";
                    //_editGrid = false;
                }
                if (lsttransMultiWeight[0].GrossWeight > 0 || lsttransMultiWeight[0].TareWeight > 0)
                {
                    if (_weightMode == enumWeightMode.Auto)
                    {
                        _isTareWeight = false;
                        txtTareWeight.ReadOnly = true;
                        txtGrossWeight.ReadOnly = true;
                    }
                    else
                    {
                        txtTareWeight.ReadOnly = true;
                        txtGrossWeight.ReadOnly = false;
                    }
                }


                //if (lsttransNormalWeight[0].TareWeight > 0)
                //{
                //    txtTareWeight.ReadOnly = true;
                //    txtGrossWeight.ReadOnly = false;
                //}
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

            if (e.KeyCode == Keys.Escape)
            {
                lstTruck.SelectedIndex = -1;
                lstTruck.Visible = false;
                txtTruck.Focus();
            }
        }

        private void txtTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                lstTruck.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                lstTruck.SelectedItem = -1;
                lstTruck.Visible = false;
            }

        }

        private void txtChallanWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.OnlyNumericValue(sender, e);
        }


        private void txtChallanWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtChallanWeight.Text != "")
            {
                double input = 0;
                bool isNum = Double.TryParse(txtChallanWeight.Text, out input);

                if (!isNum || input < 0 || input > _MaxWeight)
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    txtChallanWeight.Select(0, txtChallanWeight.Text.Length);
                    errProvWeight.SetError(txtChallanWeight, _dbGetResourceCaption.GetStringValue("MAX_WEIGHT"));
                }
                else
                {
                    errProvWeight.Clear();
                }
            }
        }

        private void lstTruck_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            FillTrucAndSetEditId();
            lstTruck.Visible = false;

        }

        private void txtTruck_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtTruck.Text = txtTruck.Text.ToUpper();
        }

        private void txtGrossWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Check for -ve Weight


            if (txtGrossWeight.Text != "")
            {

                double TareWeight = 0;
                double GrossWeight = 0;
                bool isTareWeight = false;
                bool isGrossWeight = false;

                if (_enumProductInOut == enumProductInOut.Out)
                {
                    isTareWeight = Double.TryParse(txtTareWeight.Text, out TareWeight);
                    isGrossWeight = Double.TryParse(txtGrossWeight.Text, out GrossWeight);
                }
                else if (_enumProductInOut == enumProductInOut.In)
                {
                    isGrossWeight = Double.TryParse(txtTareWeight.Text, out GrossWeight);
                    isTareWeight = Double.TryParse(txtGrossWeight.Text, out TareWeight);
                }

                if (isGrossWeight && isTareWeight && TareWeight > GrossWeight)
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    txtGrossWeight.Select(0, txtGrossWeight.Text.Length);
                    errProvWeight.SetError(txtGrossWeight, _enumProductInOut == enumProductInOut.Out ? _dbGetResourceCaption.GetStringValue("GROSS_WEIGHT_CAN_NOT_BE_LESS_THAN_TARE_WEIGHT") : _dbGetResourceCaption.GetStringValue("TARE_WEIGHT_CAN_NOT_BE_GREATER_THAN_GROSS_WEIGHT"));
                }
                else
                {
                    errProvWeight.Clear();
                }
            }
            else
            {
                errProvWeight.Clear();
            }
        }

        private void txtTareWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.OnlyNumericValue(sender, e);
        }

        private void txtGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.OnlyNumericValue(sender, e);
        }

        private void txtTareWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtTareWeight.Text != "")
            {
                double input = 0;
                bool isNum = Double.TryParse(txtTareWeight.Text, out input);

                if (!isNum || input < 0 || input > _MaxWeight)
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    txtTareWeight.Select(0, txtTareWeight.Text.Length);
                    errProvWeight.SetError(txtTareWeight, _dbGetResourceCaption.GetStringValue("MAX_WEIGHT"));
                }
                else
                {
                    errProvWeight.Clear();
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (
                txtTruck.Text.Trim() != "" ||
                txtChallanNumber.Text.Trim() != "" ||
                txtChallanDate.Text.Trim() != "" ||
                txtChallanWeight.Text.Trim() != "" ||
                txtMiscellaneous.Text.Trim() != "" ||
                txtMiscellaneous1.Text.Trim() != "" ||
                txtDeliveryNoteN.Text.Trim() != "" ||
                txtTareWeight.Text.Trim() != "" ||
                txtGrossWeight.Text.Trim() != "" ||
                //cmbProductCode.SelectedIndex > 0 ||
                cmbCustomerCode.SelectedIndex > 0 ||
                cmbTranspoterCode.SelectedIndex > 0
                )
            {
                if (MessageBox.Show(_dbGetResourceCaption.GetStringValue("ADD_NEW"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetCntrl();
                }
            }

        }

        private void txtTruck_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBoxAndUpperCase(e);
        }

        private void txtMiscellaneous_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBox(e);
        }

        private void txtMiscellaneous1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBox(e);
        }

        private void txtDeliveryNoteN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBox(e);
        }

        private void txtChallanNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBox(e);
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            try
            {
                //_MaxWeight
                double weight = _readSerialPortData.ReadSerialPortCommunication();

                if (weight > _MaxWeight)
                {
                    errProvWeight.SetError(btnWeight, string.Format(_dbGetResourceCaption.GetStringValue("MAX_WEIGHT"), _MaxWeight));
                    btnWeight.Text = weight.ToString();
                    return;
                }
                else
                {
                    errProvWeight.Clear();
                }

                if (_isTareWeight)
                {
                    _dbReturn = false;
                    txtTareWeight.Text = btnWeight.Text = weight.ToString();
                    txtTareWeight.Focus();
                }
                else
                {
                    _dbReturn = false;
                    txtGrossWeight.Text = btnWeight.Text = weight.ToString();
                    txtGrossWeight.Focus();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {

        }

        private void cmbUnloadedProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUnloadedProductCode.SelectedIndex != 0)
            {
                txtUnloadedProductName.Text = ((DAL.Entity_Model.Product)cmbUnloadedProductCode.SelectedItem).Name;
            }
            else
            {
                txtUnloadedProductName.Text = "";
            }
        }

        private void btnUnloadComplete_Click(object sender, EventArgs e)
        {
            _unloadCompleteClick = true;
        }
    }


}

