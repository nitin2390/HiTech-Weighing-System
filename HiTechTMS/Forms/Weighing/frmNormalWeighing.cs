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
using System.Security.Principal;
using SerialPortListener.Serial;
using SerialPortListener;
using System.Text;

namespace HitechTMS.Weighing
{
    public partial class frmNormalWeighing :HitechTMSSecurity.SecureBaseForm
    {
        #region "Private Variables"
        private enumProductInOut _enumProductInOut { get; set; }
        private Boolean _isTareWeight { get; set; }
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        HitechTMS.Classes.ReadSerialPortData _readSerialPortData;
        private SerialPortManager _spManager;
        private GetResourceCaption _dbGetResourceCaption;
        CalculateNetWeight _objCalculateNetWeight;
        public enumWeightMode _weightMode { get; set; }
        private Boolean _dbReturn { get; set; }
        private Boolean _saveClick { get; set; }
        public Guid _transNormalWeightID { get; set; }
        private Common _comm { get; set; }
        private FrmName _frmName { get; set; }
        private Guid transNormalWeightID;
        private string _AutoWeight { get; set; } = "0";
        private bool isPortSettingWorking { get; set; } = false;
        #endregion

        readonly double _MaxWeight;

        /// <summary>
        /// Constructor for intialise settings
        /// </summary>
        /// <param name="enumProductInOut"></param>
        /// <param name="Mode"></param>
        /// <param name="userPrincipal"></param>
        public frmNormalWeighing(enumProductInOut enumProductInOut, enumWeightMode Mode, IPrincipal userPrincipal) 
            : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _readSerialPortData = new ReadSerialPortData();
            _MaxWeight = Convert.ToDouble(_dbObj.mstWeighBridgeSetup.Select(x=>x.WeighCapacity).First());
            _weightMode = Mode;
            _objCalculateNetWeight = new CalculateNetWeight();
            _dbGetResourceCaption = new GetResourceCaption();
            _comm = new Common();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            _dbReturn = false;
            _saveClick = false;
            _enumProductInOut = enumProductInOut;
            Text = "Normal Weighing (Product " + _enumProductInOut.ToString() + ")";
            bindComboBox();
            _isTareWeight = true;
            
            ///Pass database setting to open a connection
            _spManager = new SerialPortManager(1);

            setEnableDisable();
            
            
        }

        #region "Private methods"
        private void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            lock (this)
            {
                if (this.InvokeRequired)
                {
                    // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                    this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                    return;
                }
                double weight = Convert.ToDouble(e.Data.Replace("\u0002", "").Replace("\u0003", "").Replace("\r", "")); //_readSerialPortData.ReadSerialPortCommunication();
                if (weight.ToString() != _AutoWeight)
                {
                    _AutoWeight = weight.ToString();
                    btnWeight_Click(null, null);
                }

                if (_isTareWeight)
                {
                    _AutoWeight = txtTareWeight.Text;
                }
                else
                {
                    _AutoWeight = txtGrossWeight.Text;
                }
            }
               
        }
        private void setEnableDisable()
        {
            try
            {
                txtMode.Text = _weightMode.ToString();
                txtProductName.ReadOnly = txtCustomerName.ReadOnly = txtTranspoterName.ReadOnly = true;
                txtDateIn.ReadOnly = txtDateOut.ReadOnly = true;
                txtTimeIn.ReadOnly = txtTimeOut.ReadOnly = true;
                btnTicket.Enabled = false;
                lstTruck.Visible = false;
                txtChallanDate.ReadOnly = true;

                if(_enumProductInOut == enumProductInOut.In)
                {
                   
                    lblGrossWeight.Text = _dbGetResourceCaption.GetStringValue("Tare Weight");
                    lblTareWeight.Text = _dbGetResourceCaption.GetStringValue("GROSS_WEIGHT");
                    txtGrossWeight.ReadOnly = true;
                }

                if(_weightMode == enumWeightMode.Auto)
                {
                    
                    grpboxAutoWeight.Visible = true;
                    txtTareWeight.ReadOnly = true;
                    txtGrossWeight.ReadOnly = true;
                    //btnWeight.Enabled = false;

                    if (_spManager.StartListening() != -1)
                    {
                        _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
                        isPortSettingWorking = true;
                        btnWeight_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Check you Serial port settings!");
                    }
                    
                }
                else if(_weightMode == enumWeightMode.Manual)
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
                if(!isPortSettingWorking && _weightMode == enumWeightMode.Auto )
                {
                    MessageBox.Show("Can not save data please check your port settings!");
                    return;
                }
                if(txtTruck.Text.Trim().Length < 1)
                {
                    errProvWeight.SetError(txtTruck,_dbGetResourceCaption.GetStringValue("TRUCK_CAN_NOT_BLANK"));
                    return;
                }
                List<transNormalWeight> existsQuery = new List<transNormalWeight>();
                _saveClick = true;
                existsQuery = _dbObj.transNormalWeight.Select(x => x).Where(x => x.ID == _transNormalWeightID && x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();
                transNormalWeight objtransNormalWeight = new transNormalWeight();
                objtransNormalWeight.Mode = (byte)_weightMode;
                objtransNormalWeight.Truck = txtTruck.Text;
                objtransNormalWeight.ProductCode = cmbProductCode.SelectedValue.ToString() !="Select" ? cmbProductCode.SelectedValue.ToString() : null;
                objtransNormalWeight.SupplierCode = cmbCustomerCode.SelectedIndex !=0 ? (Guid)cmbCustomerCode.SelectedValue : Guid.Empty;
                objtransNormalWeight.TransporterCode = cmbTranspoterCode.SelectedIndex != 0 ?  (Guid)cmbTranspoterCode.SelectedValue : Guid.Empty;
                objtransNormalWeight.ChallanNumber = txtChallanNumber.Text;
                objtransNormalWeight.ChallanDate = (txtChallanDate.Text != "" ? DateTime.ParseExact(txtChallanDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null);

                objtransNormalWeight.ChallanWeight = txtChallanWeight.Text != "" ? Convert.ToDecimal(txtChallanWeight.Text) : (Decimal?)null ;

                objtransNormalWeight.ChallanWeightUnit = cmbChallanWeight.SelectedIndex > -1 ? Convert.ToByte(cmbChallanWeight.SelectedIndex) : (Byte?)null;

                objtransNormalWeight.Miscellaneous = txtMiscellaneous.Text + ";" + txtMiscellaneous1.Text;
                objtransNormalWeight.DeliveryNoteN = txtDeliveryNoteN.Text;


                objtransNormalWeight.DateIn = (txtDateIn.Text != "" ? DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null); //DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.TimeIn = txtTimeIn.Text != "" ? TimeSpan.Parse(txtTimeIn.Text): (TimeSpan?)null ;

                objtransNormalWeight.DateOut = (txtDateOut.Text != "" ? DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null); //DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.TimeOut = txtTimeOut.Text != "" ? TimeSpan.Parse(txtTimeOut.Text) : (TimeSpan?)null;

                objtransNormalWeight.TareWeight = _enumProductInOut == enumProductInOut.In ? txtGrossWeight.Text != "" ? Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null : txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text): (Decimal?)null;
                objtransNormalWeight.GrossWeight = _enumProductInOut == enumProductInOut.In ? txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text) : (Decimal?)null: txtGrossWeight.Text != "" ?  Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null;

                objtransNormalWeight.NetWeight = txtNetWeight.Text != "" ?  Convert.ToDecimal(txtNetWeight.Text) : (Decimal?)null;
                objtransNormalWeight.UpdatedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.IsPending = (byte)(txtNetWeight.Text != "" ? (Convert.ToDecimal(txtNetWeight.Text) > 0 ? 1 : 0) : 0);
                objtransNormalWeight.ProdInOut = (byte)_enumProductInOut;

                if (existsQuery.Count > 0)
                {
                    objtransNormalWeight.AddedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransNormalWeight.ID = _transNormalWeightID;
                    _dbObj.transNormalWeight.AddOrUpdate(objtransNormalWeight);
                    if (_dbObj.SaveChanges() > 0 && !_isTareWeight)
                    {
                        transNormalWeightID = _transNormalWeightID;
                        DisableAllExceptTicket();
                        //ResetCntrl();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_UPDATE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    objtransNormalWeight.AddedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransNormalWeight.ID = Guid.NewGuid();
                    _dbObj.transNormalWeight.Add(objtransNormalWeight);
                    if (_dbObj.SaveChanges() == 1)
                    {
                        ResetCntrl();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Reset all the controlls
        /// </summary>
        private void ResetCntrl()
        {
            try
            {
                _dbReturn = false;
                _saveClick = false;
                _isTareWeight = true;
                cmbProductCode.SelectedIndex = 0;
                cmbCustomerCode.SelectedIndex = 0;
                cmbTranspoterCode.SelectedIndex = 0;
                cmbChallanWeight.SelectedIndex = 0;
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
                _transNormalWeightID = Guid.Empty;
                btnWeight.Text = "";
                errProvWeight.Clear();
                setEnableDisable();
                EnableAllExceptTicket();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// Combo box index change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        private void txtGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if (!_dbReturn)
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
                
            }
            CalNetWeight();
        }
        private void CalNetWeight()
        {
            try
            {
                if (txtGrossWeight.Text.Trim() != "" && txtTareWeight.Text.Trim() != "")
                {
                    string GrossWeight = _enumProductInOut == enumProductInOut.In ? txtTareWeight.Text : txtGrossWeight.Text;
                    string TareWeight = _enumProductInOut == enumProductInOut.In ? txtGrossWeight.Text : txtTareWeight.Text;

                    txtNetWeight.Text = _objCalculateNetWeight.netWeight(double.Parse(GrossWeight), double.Parse(TareWeight)).ToString();
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
            List<transNormalWeight> listNomralWeighing = new List<transNormalWeight>();


            listNomralWeighing = _dbObj.transNormalWeight
                            .Where(x => x.IsPending == 0 && x.Truck.Contains(txtTruck.Text) && x.ProdInOut == (byte)_enumProductInOut)
                            .Select(x =>  x ).ToList();

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
                lstTruck.SelectedIndex = -1;
                _transNormalWeightID = Guid.Empty;
            }
        }
        private void FillTrucAndSetEditId()
        {
            if (_dbReturn)
            {
                cmbProductCode.SelectedIndex = 0;
                cmbCustomerCode.SelectedIndex = 0;
                cmbTranspoterCode.SelectedIndex = 0;
                cmbChallanWeight.SelectedIndex = 0;
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
                _transNormalWeightID = Guid.Empty;
                setEnableDisable();
                //_editGrid = true;
            }
            if (lstTruck.SelectedIndex > -1)
            {
                _dbReturn = true;
                txtTruck.Text = lstTruck.GetItemText(lstTruck.SelectedItem);
                _transNormalWeightID = (Guid)(lstTruck.SelectedValue);
                lstTruck.Visible = false;
                FillFormData();
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
                List<transNormalWeight> lsttransNormalWeight = new List<transNormalWeight>();
                lsttransNormalWeight = _dbObj.transNormalWeight.Select(x => x).Where(x => x.ID == _transNormalWeightID && x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();


                if(lsttransNormalWeight.Count>0)
                {
                    var guidCustomerCode = lsttransNormalWeight[0].SupplierCode;
                    var guidTransporterCode = lsttransNormalWeight[0].TransporterCode;

                    var objCustomerCode = _dbObj.mstSupplierTransporter.FirstOrDefault(x => x.Id == guidCustomerCode);
                    var objTransporterCode = _dbObj.mstSupplierTransporter.FirstOrDefault(x => x.Id == guidTransporterCode);

                    cmbProductCode.SelectedIndex = lsttransNormalWeight[0].ProductCode != null ? cmbProductCode.FindString(lsttransNormalWeight[0].ProductCode) : 0;
                    cmbCustomerCode.SelectedIndex = objCustomerCode != null ? cmbCustomerCode.FindString(objCustomerCode.SupplierCode) : 0;
                    cmbTranspoterCode.SelectedIndex = objTransporterCode != null ? cmbTranspoterCode.FindString(objTransporterCode.SupplierCode): 0;
                    cmbChallanWeight.SelectedIndex = cmbChallanWeight.FindString(lsttransNormalWeight[0].ChallanWeightUnit == 0 ? "t" : "kg");


                    txtChallanNumber.Text = lsttransNormalWeight[0].ChallanNumber;
                    txtChallanDate.Text = lsttransNormalWeight[0].ChallanDate != null ? DateTime.Parse(lsttransNormalWeight[0].ChallanDate.ToString()).ToString("dd/MM/yyyy") : "";
                    txtChallanWeight.Text = lsttransNormalWeight[0].ChallanWeight.ToString();
                    txtMiscellaneous.Text = lsttransNormalWeight[0].Miscellaneous.Split(';')[0];
                    txtMiscellaneous1.Text = lsttransNormalWeight[0].Miscellaneous.Split(';')[1];
                    txtDeliveryNoteN.Text = lsttransNormalWeight[0].DeliveryNoteN;

                    if (_enumProductInOut == enumProductInOut.Out)
                    {
                        txtDateIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "" : lsttransNormalWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "";
                        txtDateOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "" : lsttransNormalWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "";
                        txtTimeIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeOut.ToString()).ToString() : "" : lsttransNormalWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeIn.ToString()).ToString() : "";
                        txtTimeOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeIn.ToString()).ToString() : "" : lsttransNormalWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeOut.ToString()).ToString() : "";
                    }
                    else
                    {
                        txtDateOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "" : lsttransNormalWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "";
                        txtDateIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].DateIn.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateIn.ToString()).ToString("dd/MM/yyyy") : "" : lsttransNormalWeight[0].DateOut.ToString() != "" ? DateTime.Parse(lsttransNormalWeight[0].DateOut.ToString()).ToString("dd/MM/yyyy") : "";
                        txtTimeOut.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeOut.ToString()).ToString() : "" : lsttransNormalWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeIn.ToString()).ToString() : "";
                        txtTimeIn.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].TimeIn.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeIn.ToString()).ToString() : "" : lsttransNormalWeight[0].TimeOut.ToString() != "" ? TimeSpan.Parse(lsttransNormalWeight[0].TimeOut.ToString()).ToString() : "";
                    }

                    


                    txtTareWeight.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].GrossWeight.ToString() != "" ? lsttransNormalWeight[0].GrossWeight.ToString() : "" : lsttransNormalWeight[0].TareWeight.ToString() != "" ? lsttransNormalWeight[0].TareWeight.ToString() : "";
                    txtGrossWeight.Text = _enumProductInOut == enumProductInOut.In ? lsttransNormalWeight[0].TareWeight.ToString() != "" ? lsttransNormalWeight[0].TareWeight.ToString() : "" : lsttransNormalWeight[0].GrossWeight.ToString() != "" ? lsttransNormalWeight[0].GrossWeight.ToString() : "";

                    txtNetWeight.Text = lsttransNormalWeight[0].NetWeight.ToString() != "" ? lsttransNormalWeight[0].NetWeight.ToString() : "";
                    //_editGrid = false;
                }
                if(lsttransNormalWeight[0].GrossWeight > 0 || lsttransNormalWeight[0].TareWeight > 0)
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

            if(e.KeyCode == Keys.Escape)
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

            if(e.KeyCode == Keys.Escape)
            {
                lstTruck.SelectedItem = -1;
                lstTruck.Visible = false;
            }

        }
        private void txtTruck_Leave(object sender, EventArgs e)
        {
            //if (!_dbReturn)
            //{
            //    FillTrucAndSetEditId();
            //}
        }
        private void dtPickChallanDate_ValueChanged(object sender, EventArgs e)
        {
            txtChallanDate.Text = dtPickChallanDate.Value.ToString("dd/MM/yyyy");
        }
        private void txtChallanWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.OnlyNumericValue(sender,e);
        }
        private void txtChallanWeight_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtChallanWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(txtChallanWeight.Text !="")
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
        private void lstTruck_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void lstTruck_Leave(object sender, EventArgs e)
        {

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
                    else if(_enumProductInOut == enumProductInOut.In)
                    {
                        isGrossWeight  = Double.TryParse(txtTareWeight.Text, out GrossWeight );
                        isTareWeight  = Double.TryParse(txtGrossWeight.Text, out TareWeight );
                    }

                    if (isGrossWeight && isTareWeight &&  TareWeight > GrossWeight)
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
            if(
                txtTruck.Text.Trim() != "" ||
                txtChallanNumber.Text.Trim() != "" ||
                txtChallanDate.Text.Trim() != "" ||
                txtChallanWeight.Text.Trim() !="" ||
                txtMiscellaneous.Text.Trim() !="" ||
                txtMiscellaneous1.Text.Trim() !="" ||
                txtDeliveryNoteN.Text.Trim() != "" ||
                txtTareWeight.Text.Trim() != "" ||
                txtGrossWeight.Text.Trim() !="" ||
                cmbProductCode.SelectedIndex > 0 ||
                cmbCustomerCode.SelectedIndex > 0 ||
                cmbTranspoterCode.SelectedIndex > 0
                )
            {
                if(MessageBox.Show(_dbGetResourceCaption.GetStringValue("ADD_NEW"), _dbGetResourceCaption.GetStringValue("INFORMATION"),MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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
                double weight = Convert.ToDouble(_AutoWeight);

                if (weight > _MaxWeight)
                {
                    errProvWeight.SetError(btnWeight, string.Format(_dbGetResourceCaption.GetStringValue("MAX_WEIGHT"),_MaxWeight));
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
            catch (Exception)
            {

                //MessageBox.Show(ex.Message);
                _spManager.StopListening();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_weightMode == enumWeightMode.Auto)
                {
                    if (_spManager.CurrentSerialSettings.PortName.Length > 0)
                    {
                        _spManager.StopListening();
                        _spManager.Dispose();
                    }
                }
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                _spManager.StopListening();
            }

        }
        private void btnTicket_Click(object sender, EventArgs e)
        {
            var RepData = _dbObj.rptNormalTicket
                .Where(x => x.ID == transNormalWeightID.ToString())
                .Select(x => new { ID = x.ID ?? "" ,
                                    Truck = x.Truck ?? "",
                                    ProductCode = x.ProductCode ?? "",
                                    Name = x.Name,
                                    SupplierCode = x.SupplierCode,
                                    SupplierName = x.SupplierName,
                                    TransporterCode = x.TransporterCode ?? "",
                                    TarnsPorterName = x.TarnsPorterName ?? "",
                                    ChallanNumber = x.ChallanNumber ?? "",
                                    Miscellaneous = x.Miscellaneous ?? "" ,
                                    DeliveryNoteN = x.DeliveryNoteN ?? "",
                                    ChallanWeight = x.ChallanWeight ?? "",
                                    ChallanDate = x.ChallanDate ?? "" ,
                                    DateIn = x.DateIn ?? "",
                                    TimeIn = x.TimeIn ?? "",
                                    DateOut = x.DateOut ?? "",
                                    TimeOut = x.TimeOut ?? "",
                                    TareWeight = x.TareWeight ?? "",
                                    GrossWeight = x.GrossWeight ?? "",
                                    NetWeight = x.NetWeight ?? "",
                                    ProdInOut =x.ProdInOut
                });
            rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), FrmName.NormalWeighing, _enumProductInOut);
            rptCmn.ShowDialog();
        }
        private void frmNormalWeighing_Load(object sender, EventArgs e)
        {

        }
        private void DisableAllExceptTicket()
        {
            txtTruck.Enabled = false;
            lstTruck.Visible = false;
            cmbProductCode.Enabled = false;
            cmbCustomerCode.Enabled = false;
            cmbTranspoterCode.Enabled = false;
            cmbChallanWeight.Enabled = false;
            txtChallanNumber.Enabled = false;
            txtChallanDate.Enabled = false;
            dtPickChallanDate.Enabled = false;
            txtChallanWeight.Enabled = false;
            txtMiscellaneous.Enabled = false;
            txtMiscellaneous1.Enabled = false;
            txtDeliveryNoteN.Enabled = false;
            btnSave.Enabled = false;
            btnWeight.Enabled = false;
            btnTicket.Enabled = true;
        }
        private void EnableAllExceptTicket()
        {
            txtTruck.Enabled = true;
            cmbProductCode.Enabled = true;
            cmbCustomerCode.Enabled = true;
            cmbTranspoterCode.Enabled = true;
            cmbChallanWeight.Enabled = true;
            txtChallanNumber.Enabled = true;
            txtChallanDate.Enabled = true;
            dtPickChallanDate.Enabled = true;
            txtChallanWeight.Enabled = true;
            txtMiscellaneous.Enabled = true;
            txtMiscellaneous1.Enabled = true;
            txtDeliveryNoteN.Enabled = true;
            btnSave.Enabled = true;
            btnWeight.Enabled = true;
            btnTicket.Enabled = false;
        }
        #endregion

        private void txtTruck_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_saveClick)
            {
                AutoFill();
                //FillTrucAndSetEditId();
            }
        }
    }
}
