using DAL.Entity_Model;
using HitechTMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.File
{
    public partial class frmSupplierTrasnportFile : Form
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption dbGetResourceCaption;
        private Guid _supplierTransporterID { get; set; }
        public FrmName _frmType { get; set; }
        public frmSupplierTrasnportFile(FrmName intfrmtype)
        {
            InitializeComponent();
            dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            this.MinimizeBox = this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = this.Size;
            _frmType = intfrmtype;
            BindGrid();
            DesignGrid();
        }

        private void DesignGrid()
        {
            try
            {
                SetCaqption();
                gridSupplierTransporter.ColumnHeadersHeight = 250;
                gridSupplierTransporter.AllowUserToResizeColumns = false;
                gridSupplierTransporter.AllowUserToResizeRows = false;
                gridSupplierTransporter.RowHeadersVisible = true;
                gridSupplierTransporter.RowHeadersWidth = 30;
                gridSupplierTransporter.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message.ToString());
            }


        }

        private void SetCaqption()
        {
            try
            {
                lblSupplierCode.Text = "Code";
                lblSupplierName.Text = "Name";

                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportCode].Width = 75;
                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportCode].HeaderText = "Code";

                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportName].Width = 120;
                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.SupplierTransportName].HeaderText = "Name";

                gridSupplierTransporter.Columns[(int)enumSupplierTransportfrm.Email].Width = 105;
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message.ToString());
            }

        }

        private void BindGrid()
        {
            try
            {

                var SupplierTransporterQuery = from SupplierTransporter in dbObj.mstSupplierTransporter
                                               where SupplierTransporter.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")
                                               orderby SupplierTransporter.SupplierCode ascending
                                               select SupplierTransporter;
                List<mstSupplierTransporter> SupplierTransporterList = SupplierTransporterQuery.ToList();
                gridSupplierTransporter.DataSource = SupplierTransporterList;

                if (gridSupplierTransporter.ColumnCount > 0)
                {
                    gridSupplierTransporter.Columns["Id"].Visible = false;
                    gridSupplierTransporter.Columns["IsSuplier"].Visible = false;

                }

                lblRecordsCount.Text = gridSupplierTransporter.RowCount.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierCode.Text != "")
                {

                    var existSupplierTransporterCode = (from SupplierTransporter in dbObj.mstSupplierTransporter
                                                        where SupplierTransporter.SupplierCode == txtSupplierCode.Text && SupplierTransporter.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")
                                                        select SupplierTransporter.SupplierCode).ToList();

                    mstSupplierTransporter objSupplierTransport = new mstSupplierTransporter();
                    objSupplierTransport.SupplierCode = txtSupplierCode.Text;
                    objSupplierTransport.SupplierName = txtSupplierName.Text;
                    objSupplierTransport.Address1 = txtAddressLine1.Text;
                    objSupplierTransport.Address2 = txtAddressLine2.Text;
                    objSupplierTransport.Address3 = txtAddressLine3.Text;
                    objSupplierTransport.Phone = txtPhone.Text;
                    objSupplierTransport.Fax = txtFax.Text;
                    objSupplierTransport.Email = txtEmail.Text;
                    objSupplierTransport.IsSuplier = _frmType == FrmName.Supplier ? "2" : "3";


                    if (existSupplierTransporterCode.Count == 0)
                    {
                        objSupplierTransport.Id = Guid.NewGuid();
                        dbObj.mstSupplierTransporter.Add(objSupplierTransport);
                        if (dbObj.SaveChanges() == 1)
                        {
                            ResetCntrl();
                            BindGrid();
                            MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_SAVE"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        objSupplierTransport.Id = _supplierTransporterID;
                        dbObj.mstSupplierTransporter.AddOrUpdate(objSupplierTransport);
                        if (dbObj.SaveChanges() == 1)
                        {
                            ResetCntrl();
                            MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_UPDATE"), dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }

                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message.ToString());
            }
        }

        private void ResetCntrl()
        {
            txtSupplierCode.Text = "";
            txtSupplierName.Text = "";
            txtAddressLine1.Text = "";
            txtAddressLine2.Text = "";
            txtAddressLine3.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            BindGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mstSupplierTransporter SupplierTransporter = new mstSupplierTransporter();
            if (gridSupplierTransporter.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(dbGetResourceCaption.GetStringValue("DELTE_POPUP"), dbGetResourceCaption.GetStringValue("CONFIRMATION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in gridSupplierTransporter.SelectedRows)
                    {
                        SupplierTransporter = dbObj.mstSupplierTransporter.Where
                                                (b => b.SupplierCode == ((mstSupplierTransporter)row.DataBoundItem).SupplierCode && b.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")).First();
                        dbObj.mstSupplierTransporter.Remove(SupplierTransporter);
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
            var RepData = dbObj.mstSupplierTransporter
                .Select(x => new { x.SupplierCode, x.SupplierName, x.Address1, x.Address2, x.Address3, x.Phone, x.Fax, x.Email, x.IsSuplier })
                .Where(x => x.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3"));
            if (RepData.ToList().Count > 0)
            {
                rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), _frmType);
                rptCmn.ShowDialog();
            }
            else
            {
                MessageBox.Show("No data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            searchGridData();
        }

        private void searchGridData()
        {
            if (txtSupplierCode.Text != "")
            {
                var SupplierTransporterQuery = from SupplierTransporter in dbObj.mstSupplierTransporter
                                               where SupplierTransporter.SupplierCode == txtSupplierCode.Text && SupplierTransporter.IsSuplier == (_frmType == FrmName.Supplier ? "2" : "3")
                                               select SupplierTransporter;
                List<mstSupplierTransporter> objProd = SupplierTransporterQuery.ToList();
                if (objProd.Count > 0)
                {
                    gridSupplierTransporter.DataSource = objProd;
                    txtSupplierName.Text = objProd[0].SupplierName.ToString();
                    _supplierTransporterID = objProd[0].Id;
                }
                else
                {
                    txtSupplierName.Text = "";
                    _supplierTransporterID = Guid.Empty;
                }

            }
        }

        private void gridSupplierTransporter_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fillFormInputs(e.RowIndex);
            }
        }

        private void fillFormInputs(int rowIndex)
        {
            DataGridViewRow row = gridSupplierTransporter.Rows[rowIndex];
            _supplierTransporterID = (Guid)row.Cells[(int)enumSupplierTransportfrm.Id].Value;
            txtSupplierCode.Text = row.Cells[(int)enumSupplierTransportfrm.SupplierTransportCode].Value.ToString();
            txtSupplierName.Text = row.Cells[(int)enumSupplierTransportfrm.SupplierTransportName].Value.ToString();
        }
    }
}
