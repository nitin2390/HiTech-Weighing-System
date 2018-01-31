using DAL.Entity_Model;
using HitechTMS.Classes;
using HitechTMSSecurity;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;
namespace HitechTMS.File
{
    public partial class frmStoredTareFile : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        HitechTMS.Classes.ReadSerialPortData _readSerialPortData;
        public Guid _StoredTareRecordsID { get; set; }
        private EncryptionAndDecryption objEncryptionAndDecryption;
        private EmailConfig objEmailConfig;
        private Boolean _editGrid { get; set; }
        public Boolean _saveClick { get; set; }

        public FrmName _frmName { get; set; }
        public enumWeightMode _mode { get; set; }
        public frmStoredTareFile(FrmName intfrmtype, IPrincipal userPrincipal, enumWeightMode Mode) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            try
            {
                InitializeComponent();
                _dbGetResourceCaption = new GetResourceCaption();
                this.MaximumSize = this.MinimumSize = this.Size;
                this.MinimizeBox = this.MaximizeBox = false;
                this._frmName = intfrmtype;
                this._mode = Mode;
                dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
                objEncryptionAndDecryption = new EncryptionAndDecryption();
                _readSerialPortData = new ReadSerialPortData();
                objEmailConfig = new EmailConfig();
                BindTransportCode();
                BindGrid();
                SetFrmMode();
                _editGrid = false;
                _saveClick = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void SetFrmMode()
        {
            try
            {
                txtMode.Text = _mode.ToString();

                if (_mode == enumWeightMode.Auto)
                {
                    txtTareWeight.ReadOnly = true;
                    btnWeight.Visible = true;
                }
                else
                {
                    txtTareWeight.ReadOnly = false;
                    btnWeight.Visible = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void BindTransportCode()
        {
            try
            {
                var listTransportCode = dbObj.mstSupplierTransporter
                    .Where(x => x.IsSuplier == ((int)FrmName.Transport).ToString())
                    .Select(x => x).ToList();
                listTransportCode.Insert(0, new mstSupplierTransporter() { SupplierCode = "Select", SupplierName = string.Empty });
                cmbTransportCode.DataSource = listTransportCode;
                cmbTransportCode.DisplayMember = "SupplierCode";
                cmbTransportCode.ValueMember = "SupplierCode";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {           
                try
                {
                    _saveClick = true;

                    #region "validation"
                    GetAllControlByType objGetAllControlByType = new GetAllControlByType();
                    var TextControl = objGetAllControlByType.GetAllControllType(this, typeof(TextBox));
                    foreach (Control control in TextControl)
                    {
                        control.Focus();

                        if (control.Name == "txtTruck")
                        {
                            if (txtTruck.Text.Trim() == string.Empty)
                            {
                                DialogResult = DialogResult.None;
                                errTruck.SetError(txtTruck, "Truck required!");
                                return;
                            }
                            else
                            {
                                errTruck.SetError(txtTruck, null);
                            }
                        }

                        if (control.Name == "txtTareWeight")
                        {
                            if (txtTareWeight.Text == string.Empty)
                            {
                                DialogResult = DialogResult.None;
                                errTareWeight.SetError(txtTareWeight, "Tare Weight required!");
                                return;
                            }
                            else
                            {
                                errTareWeight.SetError(txtTareWeight, null);
                            }
                        }
                    }
                    
                        if (cmbTransportCode.SelectedIndex == 0)
                        {
                            DialogResult = DialogResult.None;
                            errTransportCode.SetError(cmbTransportCode, "Tare Weight required!");
                            cmbTransportCode.Focus();
                            return;
                        }
                        else
                        {
                            errTransportCode.SetError(cmbTransportCode, null);
                        }

                    #endregion
                    
                    if (txtTruck.Text != string.Empty && txtTareWeight.Text != string.Empty && cmbTransportCode.SelectedIndex != 0)
                    {


                        mstStoredTareRecords objStoredTareRecords = new mstStoredTareRecords();
                        objStoredTareRecords.Mode = (int)enumWeightMode.Manual;
                        objStoredTareRecords.Truck = txtTruck.Text;
                        objStoredTareRecords.TruckType = txtTruckType.Text;
                        objStoredTareRecords.mstSupplierTransporterID = ((mstSupplierTransporter)cmbTransportCode.SelectedItem).Id;
                        objStoredTareRecords.TareWeight = decimal.Parse(txtTareWeight.Text);
                        objStoredTareRecords.DateIn = DateTime.ParseExact(txtDateIn.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
                        objStoredTareRecords.TimeIn = TimeSpan.Parse(txtTimeIn.Text);

                        if (_StoredTareRecordsID == Guid.Empty)
                        {
                            
                            objStoredTareRecords.Id = Guid.NewGuid();

                            dbObj.mstStoredTareRecords.Add(objStoredTareRecords);
                            if (dbObj.SaveChanges() == 1)
                            {
                                ResetCntrl();
                                BindGrid();
                                MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"), 
                                    _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            var varStoredTareRecords = (from StoredTareRecords in dbObj.mstStoredTareRecords
                                                     where StoredTareRecords.Id == _StoredTareRecordsID
                                                     select StoredTareRecords).FirstOrDefault();

                            objStoredTareRecords.Id = _StoredTareRecordsID;
                            dbObj.mstStoredTareRecords.AddOrUpdate(objStoredTareRecords);
                            if (dbObj.SaveChanges() == 1)
                            {
                                ResetCntrl();
                                BindGrid();
                                MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_UPDATE"), 
                                    _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message, 
                        _dbGetResourceCaption.GetStringValue("ERROR"), 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }

            
        }
        private void BindGrid()
        {
            try
            {
                var StoredTareRecordsQuery = from StoredTareRecords in dbObj.mstStoredTareRecords
                                             join s in dbObj.mstSupplierTransporter on StoredTareRecords.mstSupplierTransporterID equals s.Id into joinedmm
                                             from pm in joinedmm.DefaultIfEmpty()
                                             orderby StoredTareRecords.Truck
                                             select new
                                             {
                                                 StoredTareRecords.Id,
                                                 StoredTareRecords.Truck,
                                                 StoredTareRecords.TruckType,
                                                 pm.SupplierCode,
                                                 pm.SupplierName,
                                                 StoredTareRecords.DateIn,
                                                 StoredTareRecords.TimeIn,
                                                 StoredTareRecords.TareWeight
                                             };
                
                #region "Bind Columns"

                gridStoredTare.AutoGenerateColumns = false;
                gridStoredTare.Columns.Clear();

                int colWidth = 150;

                #region "Add Column"


                DataGridViewColumn ColID = new DataGridViewTextBoxColumn();
                ColID.DataPropertyName = "ID";
                ColID.HeaderText = FormNormalPendingCaptions.ID;
                ColID.Width = colWidth;
                ColID.Name = FormStoredTareCaptions.ID;
                ColID.Visible = false;
                gridStoredTare.Columns.Add(ColID);

                DataGridViewColumn ColTruck = new DataGridViewTextBoxColumn();
                ColTruck.DataPropertyName = "Truck";
                ColTruck.HeaderText = FormStoredTareCaptions.Truck;
                ColTruck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColTruck.Width = colWidth;
                ColTruck.ReadOnly = true;
                gridStoredTare.Columns.Add(ColTruck);

                DataGridViewColumn colTruckType = new DataGridViewTextBoxColumn();
                colTruckType.DataPropertyName = "TruckType";
                colTruckType.HeaderText = FormStoredTareCaptions.TruckType;
                colTruckType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colTruckType.Width = colWidth;
                colTruckType.ReadOnly = true;
                gridStoredTare.Columns.Add(colTruckType);

                DataGridViewColumn colSupplierCode = new DataGridViewTextBoxColumn();
                colSupplierCode.HeaderText = FormStoredTareCaptions.SupplierCode;
                colSupplierCode.DataPropertyName = "SupplierCode";
                colSupplierCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colSupplierCode.Width = colWidth + 100;
                colSupplierCode.ReadOnly = true;
                gridStoredTare.Columns.Add(colSupplierCode);

                DataGridViewColumn colSupplierName = new DataGridViewTextBoxColumn();
                colSupplierName.HeaderText = FormStoredTareCaptions.SupplierName;
                colSupplierName.DataPropertyName = "SupplierName";
                colSupplierName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colSupplierName.Width = colWidth + 100;
                colSupplierName.ReadOnly = true;
                gridStoredTare.Columns.Add(colSupplierName);

                DataGridViewColumn colDateIn = new DataGridViewTextBoxColumn();
                colDateIn.HeaderText = FormStoredTareCaptions.DateIn;
                colDateIn.DataPropertyName = "DateIn";
                colDateIn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDateIn.Width = colWidth;
                colDateIn.ReadOnly = true;
                gridStoredTare.Columns.Add(colDateIn);

                DataGridViewColumn colTimeIn = new DataGridViewTextBoxColumn();
                colTimeIn.HeaderText = FormStoredTareCaptions.TimeIn;
                colTimeIn.DataPropertyName = "TimeIn";
                colTimeIn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colTimeIn.Width = colWidth;
                colTimeIn.ReadOnly = true;
                gridStoredTare.Columns.Add(colTimeIn);

                DataGridViewColumn colTareWeight = new DataGridViewTextBoxColumn();
                colTareWeight.HeaderText = FormStoredTareCaptions.TareWeight;
                colTareWeight.DataPropertyName = "TareWeight";
                colTareWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colTareWeight.Width = colWidth;
                colTareWeight.ReadOnly = true;
                gridStoredTare.Columns.Add(colTareWeight);

                #endregion

                var result = StoredTareRecordsQuery.ToList();
                List<StoredTareRecords> _result = new List<StoredTareRecords>();
                foreach (var item in result)
                {
                    StoredTareRecords _storedtarerecords = new StoredTareRecords();
                    _storedtarerecords.ID = item.Id;
                    _storedtarerecords.Truck = item.Truck;
                    _storedtarerecords.TruckType = item.TruckType;
                    _storedtarerecords.SupplierCode = item.SupplierCode;
                    _storedtarerecords.SupplierName = item.SupplierName;
                    _storedtarerecords.DateIn = item.DateIn;
                    _storedtarerecords.TimeIn = item.TimeIn;
                    _storedtarerecords.TareWeight = item.TareWeight;
                    _result.Add(_storedtarerecords);
                }
                gridStoredTare.DataSource = _result;
                lblRecordsCount.Text = gridStoredTare.RowCount.ToString();
                #endregion

                DesignGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
        private void DesignGrid()
        {
            try
            {
                //gridProduct.DefaultCellStyle.Font.Style = 
                //gridStoredTare.Columns[(int)enumStoredTareFilefrm.Truck].Width = 150;
                //gridStoredTare.Columns[(int)enumStoredTareFilefrm.TruckType].Width = 150;
                //gridStoredTare.Columns[(int)enumStoredTareFilefrm.TransportCode].Width =150;
                //gridStoredTare.Columns[(int)enumStoredTareFilefrm.TransportName].Width =150;
                //gridStoredTare.Columns[(int)enumStoredTareFilefrm.DateIn].Width =100;
                //gridStoredTare.Columns[(int)enumStoredTareFilefrm.TimeIn].Width =100;
                //gridStoredTare.Columns[(int)enumStoredTareFilefrm.TareWeight].Width =100;

                gridStoredTare.ColumnHeadersHeight = 250;
                gridStoredTare.AllowUserToResizeColumns = false;
                gridStoredTare.AllowUserToResizeRows = false;
                gridStoredTare.RowHeadersVisible = true;
                gridStoredTare.RowHeadersWidth = 30;
                gridStoredTare.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                gridStoredTare.ReadOnly = true;
                gridStoredTare.ScrollBars = ScrollBars.Both;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message
                , _dbGetResourceCaption.GetStringValue("ERROR")
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }

        }
        private void ResetCntrl()
        {
            try
            {
                _saveClick = false;
                GetAllControlByType objGetAllControlByType = new GetAllControlByType();
                var TextControl = objGetAllControlByType.GetAllControllType(this, typeof(TextBox));
                foreach (Control control in TextControl)
                {
                    if(control.Name != "txtMode")
                    {
                        control.Text = string.Empty;
                    }
                    
                }
                _StoredTareRecordsID = Guid.Empty;
                cmbTransportCode.SelectedIndex = 0;
                _editGrid = false;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void cmbTransportCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtTransportName.Text = ((DAL.Entity_Model.mstSupplierTransporter)cmbTransportCode.SelectedItem).SupplierName;

        }

        private void txtTareWeight_TextChanged(object sender, EventArgs e)
        {
            if(!_editGrid)
            {
                if (txtTareWeight.Text.Trim() != string.Empty)
                {
                    txtDateIn.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    txtTimeIn.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    txtDateIn.Text = string.Empty;
                    txtTimeIn.Text = string.Empty;
                }
            }
            else
            {
                _editGrid = false;
            }

        }

        private void txtTareWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > 0))
            {
                e.Handled = true;
            }
        }

        private void gridStoredTare_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            DataGridViewRow row = gridStoredTare.Rows[rowIndex];
            _StoredTareRecordsID = (Guid)row.Cells[(int)enumStoredTareFilefrm.Id].Value;
            //txtMode.Text = row.Cells[(int)enumStoredTareFilefrm.].Value.ToString();
            txtTruck.Text = row.Cells[(int)enumStoredTareFilefrm.Truck].Value.ToString();
            txtTruckType.Text = row.Cells[(int)enumStoredTareFilefrm.TruckType].Value.ToString();
            cmbTransportCode.SelectedIndex = cmbTransportCode.FindString(row.Cells[(int)enumStoredTareFilefrm.TransportCode].Value == null  ? "Select" : row.Cells[(int)enumStoredTareFilefrm.TransportCode].Value.ToString());
            //txtTransportName.Text = row.Cells[(int)enumStoredTareFilefrm.TruckType].Value.ToString();
            txtDateIn.Text = DateTime.Parse(row.Cells[(int)enumStoredTareFilefrm.DateIn].Value.ToString()).ToString("dd/MM/yyyy");
            txtTimeIn.Text = row.Cells[(int)enumStoredTareFilefrm.TimeIn].Value.ToString();
            txtTareWeight.Text = row.Cells[(int)enumStoredTareFilefrm.TareWeight].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mstStoredTareRecords StoredTareRecords = new mstStoredTareRecords();
            if (gridStoredTare.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(_dbGetResourceCaption.GetStringValue("DELTE_POPUP"), 
                                    _dbGetResourceCaption.GetStringValue("CONFIRMATION"), 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gridStoredTare.SelectedRows)
                    {
                        var _deleteID = (Guid)row.Cells[0].Value;
                        StoredTareRecords = dbObj.mstStoredTareRecords.Where
                                               (b => b.Id == _deleteID).FirstOrDefault();
                        dbObj.mstStoredTareRecords.Remove(StoredTareRecords);
                        dbObj.SaveChanges();
                    }
                    ResetCntrl();
                }

            }
            else
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("SELECT_ROW_TO_DELETE"),
                                    _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var RepData = from StoredTareRecords in dbObj.mstStoredTareRecords.AsEnumerable()
                          join s in dbObj.mstSupplierTransporter.AsEnumerable() on StoredTareRecords.mstSupplierTransporterID equals s.Id into joinedmm
                          from pm in joinedmm.DefaultIfEmpty()
                          orderby StoredTareRecords.Truck
                          select new
                          {
                              StoredTareRecords.Truck,
                              StoredTareRecords.TruckType,
                              pm.SupplierCode,
                              pm.SupplierName,
                              DateIn = Convert.ToDateTime(StoredTareRecords.DateIn).ToString("dd/MM/yyyy"),
                              StoredTareRecords.TimeIn,
                              StoredTareRecords.TareWeight
                          };
            if (RepData.ToList().Count > 0)
            {
                rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), _frmName,enumProductInOut.Other);
                rptCmn.ShowDialog();
            }
            else
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("NO_DATA"), 
                    _dbGetResourceCaption.GetStringValue("INFORMATION"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        private void btnEmailExcel_Click(object sender, EventArgs e)
        {
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                obj.CreateExcelAndSendEmailToList(_frmName);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtTruck.Text != string.Empty)
            {
                txtTruckType.Focus();
            }
        }

        private void txtTruckType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtTruckType.Text != string.Empty)
            {
                cmbTransportCode.Focus();
            }
        }

        private void cmbTransportCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbTransportCode.SelectedIndex != 0)
            {
                txtTareWeight.Focus();
            }
        }

        private void txtTareWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtTareWeight.Text != string.Empty)
            {
                btnSave_Click(null, null);
            }
        }

        private void txtTruck_Leave(object sender, EventArgs e)
        {
            if (!_saveClick)
            {
                searchGridData();
            }
        }

        private void txtTruck_TextChanged(object sender, EventArgs e)
        {
        }

        private void searchGridData()
        {

            {
                if (txtTruck.Text != string.Empty)
                {
                    var storedTareRecordsQuery = from storedTareRecords in dbObj.mstStoredTareRecords
                                                   where storedTareRecords.Truck == txtTruck.Text
                                                   select storedTareRecords;
                    List<mstStoredTareRecords> objstoredTareRecords = storedTareRecordsQuery.ToList();
                    if (objstoredTareRecords.Count > 0)
                    {
                        gridStoredTare.DataSource = objstoredTareRecords;
                        _StoredTareRecordsID = objstoredTareRecords[0].Id;
                        txtTruck.Text = objstoredTareRecords[0].Truck.ToString();
                        txtTruckType.Text = objstoredTareRecords[0].TruckType.ToString();
                        cmbTransportCode.SelectedIndex = cmbTransportCode.FindString(objstoredTareRecords[0].mstSupplierTransporterID.ToString()); ;
                        txtTareWeight.Text = objstoredTareRecords[0].TareWeight.ToString();
                        txtDateIn.Text = objstoredTareRecords[0].DateIn.ToString();
                        txtTimeIn.Text = objstoredTareRecords[0].TimeIn.ToString();
                    }
                    else
                    {
                        //txtTruckType.Text = string.Empty;
                        //cmbTransportCode.SelectedIndex = 0;
                        //txtTareWeight.Text = string.Empty;
                        //txtDateIn.Text = string.Empty;
                        //txtTimeIn.Text = string.Empty;
                        _StoredTareRecordsID = Guid.Empty;
                        BindGrid();
                    }

                }
                else
                {
                    BindGrid();
                }
            }
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            try
            {
                txtTareWeight.Text = btnWeight.Text = _readSerialPortData.ReadSerialPortCommunication().ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message
                                , _dbGetResourceCaption.GetStringValue("ERROR")
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);
            }
        }


    }

    class StoredTareRecords
    {
        public System.Guid ID { get; set; }
        public byte Mode { get; set; }
        public string Truck { get; set; }
        public string TruckType { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public decimal TareWeight { get; set; }
        public System.DateTime DateIn { get; set; }
        public System.TimeSpan TimeIn { get; set; }
    }
}
