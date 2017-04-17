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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.Weighing
{
    public partial class frmPublicWeighing : Form
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
        public Guid _transPublicWeightID { get; set; }
        private Common _comm { get; set; }
        private FrmName _frmName { get; set; }

        readonly double _MaxWeight;
        public frmPublicWeighing(enumProductInOut EnumProductNormalPublicMulti, enumWeightMode Mode)
        {
            InitializeComponent();
            _MaxWeight = 150;
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _readSerialPortData = new ReadSerialPortData();
            _weightMode = Mode;
            _objCalculateNetWeight = new CalculateNetWeight();
            _dbGetResourceCaption = new GetResourceCaption();
            _comm = new Common();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            _dbReturn = false;
            _saveClick = false;
            _enumProductInOut = EnumProductNormalPublicMulti;
            Text = "Public Weighing (Product " + _enumProductInOut.ToString() + ")";
            LoadGridWithPendingData();
            setEnableDisable();
            _isTareWeight = true;
            BindGrid();
        }

        private void BindGrid()
        {
            try
            {

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
                txtDateIn.ReadOnly = txtDateOut.ReadOnly = true;
                txtTimeIn.ReadOnly = txtTimeOut.ReadOnly = true;
                if (_enumProductInOut == enumProductInOut.In)
                {

                    lblGrossWeight.Text = _dbGetResourceCaption.GetStringValue("Tare Weight");
                    lblTareWeight.Text = _dbGetResourceCaption.GetStringValue("GROSS_WEIGHT");
                    txtGrossWeight.ReadOnly = true;
                }

                if (_weightMode == enumWeightMode.Auto)
                {
                    grpboxAutoWeight.Visible = true;
                    txtTareWeight.ReadOnly = true;
                    txtGrossWeight.ReadOnly = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTruck.Text.Trim().Length < 1)
                {
                    return;
                }
                List<transPublicWeight> existsQuery = new List<transPublicWeight>();
                _saveClick = true;
                existsQuery = _dbObj.transPublicWeight.Select(x => x).Where(x => x.ID == _transPublicWeightID && x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();
                transPublicWeight objtransNormalWeight = new transPublicWeight();
                objtransNormalWeight.Mode = (byte)_weightMode;
                objtransNormalWeight.Truck = txtTruck.Text;
                objtransNormalWeight.Miscellaneous = txtMiscellaneous.Text + ";" + txtMiscellaneous1.Text;
                objtransNormalWeight.DateIn = (txtDateIn.Text != "" ? DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null); //DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                objtransNormalWeight.TimeIn = txtTimeIn.Text != "" ? TimeSpan.Parse(txtTimeIn.Text) : (TimeSpan?)null;
                objtransNormalWeight.DateOut = (txtDateOut.Text != "" ? DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null); //DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                objtransNormalWeight.TimeOut = txtTimeOut.Text != "" ? TimeSpan.Parse(txtTimeOut.Text) : (TimeSpan?)null;
                objtransNormalWeight.TareWeight = _enumProductInOut == enumProductInOut.In ? txtGrossWeight.Text != "" ? Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null : txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text) : (Decimal?)null;
                objtransNormalWeight.GrossWeight = _enumProductInOut == enumProductInOut.In ? txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text) : (Decimal?)null : txtGrossWeight.Text != "" ? Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null;
                objtransNormalWeight.NetWeight = txtNetWeight.Text != "" ? Convert.ToDecimal(txtNetWeight.Text) : (Decimal?)null;
                objtransNormalWeight.UpdatedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.IsPending = (byte)(txtNetWeight.Text != "" ? (Convert.ToDecimal(txtNetWeight.Text) > 0 ? 1 : 0) : 0);
                objtransNormalWeight.ProdInOut = (byte)_enumProductInOut;

                if (existsQuery.Count > 0)
                {
                    objtransNormalWeight.AddedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransNormalWeight.ID = _transPublicWeightID;
                    _dbObj.transPublicWeight.AddOrUpdate(objtransNormalWeight);
                    if (_dbObj.SaveChanges() > 0)
                    {
                        _isTareWeight = true;
                        ResetCntrl();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_UPDATE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    objtransNormalWeight.AddedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objtransNormalWeight.ID = Guid.NewGuid();
                    _dbObj.transPublicWeight.Add(objtransNormalWeight);
                    if (_dbObj.SaveChanges() == 1)
                    {
                        ResetCntrl();
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                LoadGridWithPendingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void ResetCntrl()
        {
            try
            {
                _dbReturn = false;
                _saveClick = false;

                txtTruck.Text = "";
                txtMiscellaneous.Text = "";
                txtMiscellaneous1.Text = "";
                txtDateIn.Text = "";
                txtTimeIn.Text = "";
                txtDateOut.Text = "";
                txtTimeOut.Text = "";
                txtTareWeight.Text = "";
                txtGrossWeight.Text = "";
                txtGrossWeight.Text = "";
                txtNetWeight.Text = "";
                btnWeight.Text = "";
                _transPublicWeightID = Guid.Empty;
                errProvWeight.Clear();
                setEnableDisable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LoadGridWithPendingData()
        {
            try
            {
                List<transPublicWeight> existsQuery = new List<transPublicWeight>();
                _saveClick = true;
                existsQuery = _dbObj.transPublicWeight.Where(x => x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();
                gridSupplierTransporter.DataSource = existsQuery;
                setHeaderAndEnableDisable();
                lblRecordsCount.Text = gridSupplierTransporter.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setHeaderAndEnableDisable()
        {
            try
            {

                if(gridSupplierTransporter.ColumnCount > 0)
                {
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Truck].DisplayIndex = 0;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Truck].Width = 100;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Truck].HeaderText = _dbGetResourceCaption.GetStringValue("TRUCK");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Miscellaneous].DisplayIndex = 1;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Miscellaneous].Width = 125;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Miscellaneous].HeaderText = _dbGetResourceCaption.GetStringValue("MISCELLANEOUS");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TareWeight].DisplayIndex = 2;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TareWeight].Width = 135;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TareWeight].HeaderText = _dbGetResourceCaption.GetStringValue("TAREWEIGHT");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.GrossWeight].DisplayIndex = 3;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.GrossWeight].Width = 135;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.GrossWeight].HeaderText = _dbGetResourceCaption.GetStringValue("GROSSWEIGHT");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.NetWeight].DisplayIndex = 4;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.NetWeight].Width = 135;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.NetWeight].HeaderText = _dbGetResourceCaption.GetStringValue("NETWEIGHT");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateIn].DisplayIndex = 5;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateIn].HeaderText = _dbGetResourceCaption.GetStringValue("DATEIN");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeIn].DisplayIndex = 6;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeIn].HeaderText = _dbGetResourceCaption.GetStringValue("TIMEIN");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateOut].DisplayIndex = 7;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateOut].HeaderText = _dbGetResourceCaption.GetStringValue("DATEOUT");

                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeOut].DisplayIndex = 8;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeOut].HeaderText = _dbGetResourceCaption.GetStringValue("TIMEOUT");




                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Id].Visible = false;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.Mode].Visible = false;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.AddedDate].Visible = false;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.UpdatedDate].Visible = false;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.IsPending].Visible = false;
                    gridSupplierTransporter.Columns[(int)enumTransPublicWeight.ProdInOut].Visible = false;
                }


                gridSupplierTransporter.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                gridSupplierTransporter.AllowUserToResizeColumns = false;
                gridSupplierTransporter.AllowUserToResizeRows = false;

                gridSupplierTransporter.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillTrucAndSetEditId()
        {
            if (_dbReturn)
            {
                txtMiscellaneous.Text = "";
                txtMiscellaneous1.Text = "";
                txtDateIn.Text = "";
                txtTimeIn.Text = "";
                txtDateOut.Text = "";
                txtTimeOut.Text = "";
                txtTareWeight.Text = "";
                txtGrossWeight.Text = "";
                txtGrossWeight.Text = "";
                txtNetWeight.Text = "";
                _transPublicWeightID = Guid.Empty;
                setEnableDisable();
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }

        private void btnTicket_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

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

        private void txtTareWeight_Validating(object sender, CancelEventArgs e)
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

        private void btnWeight_Click(object sender, EventArgs e)
        {
            try
            {
                //_MaxWeight
                double weight = _readSerialPortData.ReadSerialPortCommunication();

                if (weight > _MaxWeight)
                {
                    errProvWeight.SetError(btnWeight, _dbGetResourceCaption.GetStringValue("MAX_WEIGHT"));
                    btnWeight.Text = weight.ToString();
                    return;
                }
                else
                {
                    errProvWeight.Clear();
                }

                if (_isTareWeight)
                {
                    txtTareWeight.Text = btnWeight.Text = weight.ToString();
                    txtTareWeight.Focus();
                }
                else
                {
                    txtGrossWeight.Text = btnWeight.Text = weight.ToString();
                    txtGrossWeight.Focus();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
