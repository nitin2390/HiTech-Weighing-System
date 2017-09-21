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
    public partial class frmPublicWeighing : HitechTMSSecurity.SecureBaseForm
    {
        public enumProductInOut _enumProductInOut { get; set; }
        private Boolean _isTareWeight { get; set; }
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        HitechTMS.Classes.ReadSerialPortData _readSerialPortData;
        private GetResourceCaption _dbGetResourceCaption;
        CalculateNetWeight _objCalculateNetWeight;
        public enumWeightMode _weightMode { get; set; }
        private Boolean _editGrid { get; set; }

        private Boolean _dbReturn { get; set; }
        public Boolean _saveClick { get; set; }
        public Guid _transPublicWeightID { get; set; }
        private Common _comm { get; set; }
        private FrmName _frmName { get; set; }

        readonly double _MaxWeight;
        public frmPublicWeighing(enumProductInOut EnumProductNormalPublicMulti, enumWeightMode Mode, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
             InitializeComponent();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _readSerialPortData = new ReadSerialPortData();
            _objCalculateNetWeight = new CalculateNetWeight();
            _dbGetResourceCaption = new GetResourceCaption();
            _comm = new Common();

            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;

            _dbReturn = false;
            _saveClick = false;
            _editGrid = false;
            _isTareWeight = true;

            _enumProductInOut = EnumProductNormalPublicMulti;
            _weightMode = Mode;
            _MaxWeight = 150;
            Text = "Public Weighing (Product " + _enumProductInOut.ToString() + ")";
            //LoadGridWithPendingData();
            //setEnableDisable();
            ResetCntrl();


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

                    lblGrossWeight.Text = _dbGetResourceCaption.GetStringValue("TARE_WEIGHT");
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
                //setHeaderAndEnableDisable();
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
                List<transPublicWeight> existsQuery = new List<transPublicWeight>();
                _saveClick = true;
                existsQuery = _dbObj.transPublicWeight.Select(x => x).Where(x => x.ID == _transPublicWeightID && x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();
                transPublicWeight objtransNormalWeight = new transPublicWeight();
                objtransNormalWeight.Mode = (byte)_weightMode;
                objtransNormalWeight.Truck = txtTruck.Text;
                objtransNormalWeight.Miscellaneous = txtMiscellaneous.Text + (txtMiscellaneous1.Text != "" ? ";" + txtMiscellaneous1.Text : "");
                objtransNormalWeight.DateIn = (txtDateIn.Text != "" ? DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null); //DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                objtransNormalWeight.TimeIn = txtTimeIn.Text != "" ? TimeSpan.Parse(txtTimeIn.Text) : (TimeSpan?)null;
                objtransNormalWeight.DateOut = (txtDateOut.Text != "" ? DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null); //DateTime.ParseExact(txtDateOut.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                objtransNormalWeight.TimeOut = txtTimeOut.Text != "" ? TimeSpan.Parse(txtTimeOut.Text) : (TimeSpan?)null;
                objtransNormalWeight.TareWeight = _enumProductInOut == enumProductInOut.In ? txtGrossWeight.Text != "" ? Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null : txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text) : (Decimal?)null;
                objtransNormalWeight.GrossWeight = _enumProductInOut == enumProductInOut.In ? txtTareWeight.Text != "" ? Convert.ToDecimal(txtTareWeight.Text) : (Decimal?)null : txtGrossWeight.Text != "" ? Convert.ToDecimal(txtGrossWeight.Text) : (Decimal?)null;
                objtransNormalWeight.NetWeight = txtNetWeight.Text != "" ? Convert.ToDecimal(txtNetWeight.Text) : (Decimal?)null;
                objtransNormalWeight.UpdatedDate = DateTime.ParseExact(DateTime.Now.Date.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objtransNormalWeight.IsPending = (byte)(txtNetWeight.Text != "" ? (Convert.ToDecimal(txtNetWeight.Text) >= 0 ? 1 : 0) : 0);
                objtransNormalWeight.ProdInOut = (byte)_enumProductInOut;

                if (existsQuery.Count > 0)
                {
                    btnTicket.Enabled = true;
                    if (objtransNormalWeight.NetWeight != null && objtransNormalWeight.NetWeight > 0)
                    {
                        if (MessageBox.Show("Want to print the Ticket", _dbGetResourceCaption.GetStringValue("CONFIRMATION"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show("Print!");
                        }

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
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("SAME_GROSS_AND_TARE_WEIGHT"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //LoadGridWithPendingData();
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
                _isTareWeight = true;

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
                btnTicket.Enabled = false;
                _transPublicWeightID = Guid.Empty;
                errProvWeight.Clear();
                setEnableDisable();
                txtTruck.Focus();
                LoadGridWithPendingData();
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
                List<transPublicWeight> transPublicWeightQuery = new List<transPublicWeight>();
                _saveClick = true;
                transPublicWeightQuery = _dbObj.transPublicWeight.Where(x => x.ProdInOut == (byte)_enumProductInOut && x.IsPending == 0).ToList();
                gridPublicWeghing.DataSource = transPublicWeightQuery;
                setHeaderAndEnableDisable();
                lblRecordsCount.Text = gridPublicWeghing.RowCount.ToString();
                gridPublicWeghing.Update();
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

                if (gridPublicWeghing.ColumnCount > 0)
                {
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Truck].DisplayIndex = 0;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Truck].Width = 100;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Truck].HeaderText = _dbGetResourceCaption.GetStringValue("TRUCK");

                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Miscellaneous].DisplayIndex = 1;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Miscellaneous].Width = 162;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Miscellaneous].HeaderText = _dbGetResourceCaption.GetStringValue("MISCELLANEOUS");

                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.TareWeight].DisplayIndex = 2;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.TareWeight].Width = 135;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.TareWeight].HeaderText = _dbGetResourceCaption.GetStringValue("TARE_WEIGHT");

                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.GrossWeight].DisplayIndex = 3;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.GrossWeight].Width = 135;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.GrossWeight].HeaderText = _dbGetResourceCaption.GetStringValue("GROSS_WEIGHT");

                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.NetWeight].DisplayIndex = 4;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.NetWeight].Width = 135;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.NetWeight].HeaderText = _dbGetResourceCaption.GetStringValue("NET_WEIGHT");

                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateIn].DisplayIndex = 5;
                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateIn].HeaderText = _dbGetResourceCaption.GetStringValue("DATEIN");

                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeIn].DisplayIndex = 6;
                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeIn].HeaderText = _dbGetResourceCaption.GetStringValue("TIMEIN");

                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateOut].DisplayIndex = 7;
                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.DateOut].HeaderText = _dbGetResourceCaption.GetStringValue("DATEOUT");

                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeOut].DisplayIndex = 8;
                    //gridSupplierTransporter.Columns[(int)enumTransPublicWeight.TimeOut].HeaderText = _dbGetResourceCaption.GetStringValue("TIMEOUT");

                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Id].Visible = false;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.Mode].Visible = false;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.AddedDate].Visible = false;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.UpdatedDate].Visible = false;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.IsPending].Visible = false;
                    gridPublicWeghing.Columns[(int)enumTransPublicWeight.ProdInOut].Visible = false;
                }


                gridPublicWeghing.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                gridPublicWeghing.AllowUserToResizeColumns = false;
                gridPublicWeghing.AllowUserToResizeRows = false;

                gridPublicWeghing.ReadOnly = true;
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
            if (
                txtTruck.Text.Trim() != "" ||
                txtMiscellaneous.Text.Trim() != "" ||
                txtMiscellaneous1.Text.Trim() != "" ||
                txtTareWeight.Text.Trim() != "" ||
                txtGrossWeight.Text.Trim() != ""
                )
            {
                if (MessageBox.Show(_dbGetResourceCaption.GetStringValue("ADD_NEW"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetCntrl();
                }
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTareWeight_TextChanged(object sender, EventArgs e)
        {
            if (!_dbReturn && !_editGrid)
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
            if (!_dbReturn && !_editGrid)
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
                    errProvWeight.SetError(btnWeight, string.Format(_dbGetResourceCaption.GetStringValue("MAX_WEIGHT"), _MaxWeight));
                    btnWeight.Text = weight.ToString();
                    return;
                }
                else
                {
                    errProvWeight.Clear();
                    _editGrid = false;
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
                    btnTicket.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }
        }

        private void gridSupplierTransporter_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _editGrid = true;
                fillFormInputs(e.RowIndex);
            }
            else
            {
                ResetCntrl();
            }
        }
        private void fillFormInputs(int rowIndex)
        {
            try
            {
                DataGridViewRow row = gridPublicWeghing.Rows[rowIndex];
                _transPublicWeightID = (Guid)row.Cells[(int)enumTransPublicWeight.Id].Value;

                var varMiscellaneous = row.Cells[(int)enumTransPublicWeight.Miscellaneous].Value.ToString().Split(';');

                txtMode.Text = _weightMode.ToString();
                txtTruck.Text = row.Cells[(int)enumTransPublicWeight.Truck].Value.ToString();
                txtMiscellaneous.Text = varMiscellaneous.Count() > 0 ? varMiscellaneous[0] : "";
                txtMiscellaneous1.Text = varMiscellaneous.Count() > 1 ? varMiscellaneous[1] : "";

                if (_enumProductInOut == enumProductInOut.Out)
                {
                    txtDateIn.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.DateOut].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateOut].Value.ToString()).ToString("dd/MM/yyyy") : "" : row.Cells[(int)enumTransPublicWeight.DateIn].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateIn].Value.ToString()).ToString("dd/MM/yyyy") : "";
                    txtDateOut.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.DateIn].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateIn].Value.ToString()).ToString("dd/MM/yyyy") : "" : row.Cells[(int)enumTransPublicWeight.DateOut].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateOut].Value.ToString()).ToString("dd/MM/yyyy") : "";
                    txtTimeIn.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.TimeOut].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeOut].Value.ToString()).ToString() : "" : row.Cells[(int)enumTransPublicWeight.TimeIn].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeIn].Value.ToString()).ToString() : "";
                    txtTimeOut.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.TimeIn].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeIn].Value.ToString()).ToString() : "" : row.Cells[(int)enumTransPublicWeight.TimeOut].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeOut].Value.ToString()).ToString() : "";
                }
                else
                {
                    txtDateOut.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.DateOut].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateOut].Value.ToString()).ToString("dd/MM/yyyy") : "" : row.Cells[(int)enumTransPublicWeight.DateIn].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateIn].Value.ToString()).ToString("dd/MM/yyyy") : "";
                    txtDateIn.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.DateIn].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateIn].Value.ToString()).ToString("dd/MM/yyyy") : "" : row.Cells[(int)enumTransPublicWeight.DateOut].Value != null ? DateTime.Parse(row.Cells[(int)enumTransPublicWeight.DateOut].Value.ToString()).ToString("dd/MM/yyyy") : "";
                    txtTimeOut.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.TimeOut].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeOut].Value.ToString()).ToString() : "" : row.Cells[(int)enumTransPublicWeight.TimeIn].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeIn].Value.ToString()).ToString() : "";
                    txtTimeIn.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.TimeIn].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeIn].Value.ToString()).ToString() : "" : row.Cells[(int)enumTransPublicWeight.TimeOut].Value != null ? TimeSpan.Parse(row.Cells[(int)enumTransPublicWeight.TimeOut].Value.ToString()).ToString() : "";
                }


                txtTareWeight.Text = _enumProductInOut == enumProductInOut.In ? row.Cells[(int)enumTransPublicWeight.GrossWeight].Value != null ? row.Cells[(int)enumTransPublicWeight.GrossWeight].Value.ToString() : "" : row.Cells[(int)enumTransPublicWeight.TareWeight].Value != null ? row.Cells[(int)enumTransPublicWeight.TareWeight].Value.ToString() : "";

                //if(txtTareWeight.Text !="")
                //{
                //    txtGrossWeight.ReadOnly = false;
                //    txtTareWeight.ReadOnly = true;
                //}
                //else
                //{
                //    txtGrossWeight.ReadOnly = true;
                //    txtTareWeight.ReadOnly = false;
                //}


                if (Convert.ToDouble(row.Cells[(int)enumTransPublicWeight.GrossWeight].Value) > 0 || Convert.ToDouble(row.Cells[(int)enumTransPublicWeight.TareWeight].Value) > 0)
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


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGrossWeight_Validating(object sender, CancelEventArgs e)
        {
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
                    //txtGrossWeight.Select(0, txtGrossWeight.Text.Length);
                    errProvWeight.SetError(txtGrossWeight, string.Format(_enumProductInOut == enumProductInOut.Out ? _dbGetResourceCaption.GetStringValue("GROSS_WEIGHT_CAN_NOT_BE_LESS_THAN_TARE_WEIGHT") : _dbGetResourceCaption.GetStringValue("TARE_WEIGHT_CAN_NOT_BE_GREATER_THAN_GROSS_WEIGHT"), txtGrossWeight.Text.ToString()));
                    txtGrossWeight.Text = "";
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

        private void txtTruck_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = _comm.RestirctTextBoxAndUpperCase(e);
        }

        private void txtTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMiscellaneous.Focus();
            }
        }

        private void txtMiscellaneous_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMiscellaneous1.Focus();
            }
        }

        private void txtMiscellaneous1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
    }
}
