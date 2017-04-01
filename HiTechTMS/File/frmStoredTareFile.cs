using DAL.Entity_Model;
using HitechTMS.Classes;
using OD.Forms.Security;
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
        private GetResourceCaption dbGetResourceCaption;
        public Guid _StoredTareRecordsID { get; set; }
        private EncryptionAndDecryption objEncryptionAndDecryption;
        private EmailConfig objEmailConfig;
        private Boolean _editGrid { get; set; }
        public FrmName _frmName { get; set; }
        public frmStoredTareFile(FrmName intfrmtype, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            try
            {
                InitializeComponent();
                dbGetResourceCaption = new GetResourceCaption();
                this.MaximumSize = this.MinimumSize = this.Size;
                this.MinimizeBox = this.MaximizeBox = false;
                this._frmName = intfrmtype;
                dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
                objEncryptionAndDecryption = new EncryptionAndDecryption();
                objEmailConfig = new EmailConfig();
                BindTransportCode();
                BindGrid();
                txtMode.Text = "Manual";
                _editGrid = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindTransportCode()
        {
            try
            {
                var listTransportCode = dbObj.mstSupplierTransporter
                    .Where(x => x.IsSuplier == ((int)FrmName.Transport).ToString())
                    .Select(x => x).ToList();
                listTransportCode.Insert(0, new mstSupplierTransporter() { SupplierCode = "Select", SupplierName = "" });
                cmbTransportCode.DataSource = listTransportCode;
                cmbTransportCode.DisplayMember = "SupplierCode";
                cmbTransportCode.ValueMember = "SupplierCode";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public IEnumerable<Control> GetAllControllType(Control control, Type type)
        {
            try
            {

            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControllType(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            {
                try
                {

                    if (txtTruck.Text != "" && txtTruckType.Text != "" && txtTareWeight.Text != "" && cmbTransportCode.Text != "Select")
                    {


                        mstStoredTareRecords objStoredTareRecords = new mstStoredTareRecords();
                        objStoredTareRecords.Mode = (int)enumStoredTareFileMode.Manual;
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
                                MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_SAVE"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_UPDATE"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
                gridStoredTare.DataSource = StoredTareRecordsQuery.ToList();

                if (gridStoredTare.ColumnCount > 0)
                {
                    gridStoredTare.Columns["Id"].Visible = false;
                }
                lblRecordsCount.Text = gridStoredTare.RowCount.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCntrl()
        {
            try
            {
                var TextControl = GetAllControllType(this, typeof(TextBox));
                foreach (Control control in TextControl)
                {
                    if(control.Name != "txtMode")
                    {
                        control.Text = "";
                    }
                    
                }
                _StoredTareRecordsID = Guid.Empty;
                cmbTransportCode.SelectedIndex = 0;
                _editGrid = false;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cmbTransportCode.SelectedIndex = cmbTransportCode.FindString(row.Cells[(int)enumStoredTareFilefrm.TransportCode].Value.ToString());
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
                if (MessageBox.Show(dbGetResourceCaption.GetStringValue("DELTE_POPUP"), dbGetResourceCaption.GetStringValue("CONFIRMATION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                MessageBox.Show("Please select records rows to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), _frmName);
                rptCmn.ShowDialog();
            }
            else
            {
                MessageBox.Show("No data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEmailExcel_Click(object sender, EventArgs e)
        {
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                if (obj.CreateExcelAndSendEmailToList(_frmName))
                {
                    MessageBox.Show(dbGetResourceCaption.GetStringValue("EMAIL_SENT"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dbGetResourceCaption.GetStringValue("ERR_EMAIL_CHK_CONFIG"), dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtTruck.Text != "")
            {
                txtTruckType.Focus();
            }
        }

        private void txtTruckType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtTruckType.Text != "")
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
            if (e.KeyCode == Keys.Enter && txtTareWeight.Text != "")
            {
                btnSave_Click(null, null);
            }
        }

        private void txtTruck_Leave(object sender, EventArgs e)
        {

        }
    }
}
