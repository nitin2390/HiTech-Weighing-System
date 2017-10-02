using DAL.Entity_Model;
using HitechTMS.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.File
{
    
    public partial class frmTransactionForm : HitechTMSSecurity.SecureBaseForm
    {
        #region "Public and Private Property"
        private GetResourceCaption _dbGetResourceCaption;
        public int _chkCompleteFile { get; set; }
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        public FrmName _frmName { get; set; }
        public frmTransactionForm(FrmName FrmName,IPrincipal userPrincipal) : base(new string[] { AppRole.Admin.ToString(), AppRole.SuperAdmin.ToString(), AppRole.Supervisor.ToString(), AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            InitializeComponent();
            MaximumSize = MinimumSize = Size;
            MinimizeBox = MaximizeBox = false;
            _frmName = FrmName;
            _dbGetResourceCaption = new GetResourceCaption();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            rdbPendingFile.Checked = true;
            LoadCaption();
            LoadGridData();
            _chkCompleteFile = 0;
            SetGridLayout();
        }

        private void SetGridLayout()
        {
            try
            {
                int rowheight = 30;
                gridPendingFile.RowTemplate.Height = rowheight;
                gridPendingFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                gridPendingFile.ColumnHeadersHeight = rowheight;
                gridPendingFile.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif",8.75F, FontStyle.Bold);
                gridPendingFile.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                gridPendingFile.AllowUserToResizeRows = false;
                gridPendingFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                gridPendingFile.AllowUserToResizeColumns = false;
                gridPendingFile.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion

        private void LoadGridData()
        {
            try
            {
                if (rdbNormalWeight.Checked)
                {
                    var QueryNormalWeight = _dbObj
                                            .viewNormalPendingFile
                                            .Where(x => x.IsPending == _chkCompleteFile)
                                            .Select(
                                                x => new {
                                                x.ID,
                                                x.Truck,
                                                x.ProductName,
                                                x.SupplierName,
                                                x.TransporterName,
                                                x.ChallanNumber,
                                                x.ChallanDate,
                                                x.ChallanWeight,
                                                x.ChallanWeightUnit,
                                                x.Miscellaneous,
                                                x.Mode,
                                                x.GrossWeight,
                                                x.TareWeight,
                                                x.ProdInOut,
                                                x.DateIn,
                                                x.DateOut

                                            })
                                            .Where(x=> x.DateIn >= dtPicketFromDate.Value.Date && x.DateIn <= dtPicketToDate.Value.Date)
                                            .OrderBy(x=> x.DateIn).ThenBy(x=>x.Truck)
                                            .ToList();

                    lblRecordsCount.Text = QueryNormalWeight.Count().ToString();
                    
                    #region "Bind Columns"

                    gridPendingFile.AutoGenerateColumns = false;
                    gridPendingFile.Columns.Clear();

                    int colWidth = 150;


                    #region "Add Column"
                    DataGridViewCheckBoxColumn ColPrintTicket = new DataGridViewCheckBoxColumn();
                    //ColPrintTicket.DataPropertyName = "ID";
                    ColPrintTicket.HeaderText = FormNormalPendingCaptions.PrintTicket;
                    ColPrintTicket.Width = colWidth - 20;
                    ColPrintTicket.TrueValue = true;
                    ColPrintTicket.FalseValue = false;
                    ColPrintTicket.Width = 100;
                    ColPrintTicket.ReadOnly = false;
                    gridPendingFile.Columns.Add(ColPrintTicket);
                    

                    DataGridViewColumn ColID = new DataGridViewTextBoxColumn();
                    ColID.DataPropertyName = "ID";
                    ColID.HeaderText = FormNormalPendingCaptions.ID;
                    ColID.Width = colWidth;
                    ColID.Name = FormNormalPendingCaptions.ID;
                    ColID.Visible = false;
                    gridPendingFile.Columns.Add(ColID);

                    DataGridViewColumn ColTruck = new DataGridViewTextBoxColumn();
                    ColTruck.DataPropertyName = "Truck";
                    ColTruck.HeaderText = FormNormalPendingCaptions.Truck;
                    ColTruck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    ColTruck.Width = colWidth;
                    ColTruck.ReadOnly = true;
                    gridPendingFile.Columns.Add(ColTruck);

                    DataGridViewColumn colProductName = new DataGridViewTextBoxColumn();
                    colProductName.DataPropertyName = "ProductName";
                    colProductName.HeaderText = FormNormalPendingCaptions.ProductName.ToString();
                    colProductName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colProductName.Width = colWidth;
                    colProductName.ReadOnly = true;
                    gridPendingFile.Columns.Add(colProductName);

                    DataGridViewColumn colSupplierName = new DataGridViewTextBoxColumn();
                    colSupplierName.HeaderText = FormNormalPendingCaptions.SupplierName;
                    colSupplierName.DataPropertyName = "SupplierName";
                    colSupplierName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colSupplierName.Width = colWidth;
                    colSupplierName.ReadOnly = true;
                    gridPendingFile.Columns.Add(colSupplierName);

                    DataGridViewColumn colTransporterName = new DataGridViewTextBoxColumn();
                    colTransporterName.HeaderText = FormNormalPendingCaptions.TransporterName;
                    colTransporterName.DataPropertyName = "TransporterName";
                    colTransporterName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colTransporterName.Width = colWidth;
                    colTransporterName.ReadOnly = true;
                    gridPendingFile.Columns.Add(colTransporterName);

                    DataGridViewColumn colDateIn = new DataGridViewTextBoxColumn();
                    colDateIn.HeaderText = FormNormalPendingCaptions.DateIn;
                    colDateIn.DataPropertyName = "DateIn";
                    colDateIn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colDateIn.Width = colWidth;
                    colDateIn.ReadOnly = true;
                    gridPendingFile.Columns.Add(colDateIn);

                    DataGridViewColumn colDateOut = new DataGridViewTextBoxColumn();
                    colDateOut.HeaderText = FormNormalPendingCaptions.DateOut;
                    colDateOut.DataPropertyName = "DateOut";
                    colDateOut.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colDateOut.Width = colWidth;
                    colDateOut.ReadOnly = true;
                    gridPendingFile.Columns.Add(colDateOut);

                    DataGridViewColumn colChallanNumber = new DataGridViewTextBoxColumn();
                    colChallanNumber.HeaderText = FormNormalPendingCaptions.ChallanNumber;
                    colChallanNumber.DataPropertyName = "ChallanNumber";
                    colChallanNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colChallanNumber.Width = colWidth;
                    colChallanNumber.ReadOnly = true;
                    gridPendingFile.Columns.Add(colChallanNumber);

                    DataGridViewColumn colChallanDate = new DataGridViewTextBoxColumn();
                    colChallanDate.HeaderText = FormNormalPendingCaptions.ChallanDate;
                    colChallanDate.DataPropertyName = "ChallanDate";
                    colChallanDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colChallanDate.Width = colWidth;
                    colChallanDate.ReadOnly = true;
                    gridPendingFile.Columns.Add(colChallanDate);

                    DataGridViewColumn colChallanWeight = new DataGridViewTextBoxColumn();
                    colChallanWeight.HeaderText = FormNormalPendingCaptions.ChallanWeight;
                    colChallanWeight.DataPropertyName = "ChallanWeight";
                    colChallanWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colChallanWeight.Width = colWidth;
                    colChallanWeight.ReadOnly = true;
                    gridPendingFile.Columns.Add(colChallanWeight);

                    DataGridViewColumn colChallanWeightUnit = new DataGridViewTextBoxColumn();
                    colChallanWeightUnit.HeaderText = FormNormalPendingCaptions.ChallanWeightUnit;
                    colChallanWeightUnit.DataPropertyName = "ChallanWeightUnit";
                    colChallanWeightUnit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colChallanWeightUnit.Width = colWidth;
                    colChallanWeightUnit.ReadOnly = true;
                    gridPendingFile.Columns.Add(colChallanWeightUnit);

                    DataGridViewColumn colGrossWeight = new DataGridViewTextBoxColumn();
                    colGrossWeight.HeaderText = FormNormalPendingCaptions.GrossWeight;
                    colGrossWeight.DataPropertyName = "GrossWeight";
                    colGrossWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colGrossWeight.Width = colWidth;
                    colGrossWeight.ReadOnly = true;
                    gridPendingFile.Columns.Add(colGrossWeight);

                    DataGridViewColumn colTareWeight = new DataGridViewTextBoxColumn();
                    colTareWeight.HeaderText = FormNormalPendingCaptions.TareWeight;
                    colTareWeight.DataPropertyName = "TareWeight";
                    colTareWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colTareWeight.Width = colWidth;
                    colTareWeight.ReadOnly = true;
                    gridPendingFile.Columns.Add(colTareWeight);

                    DataGridViewColumn ColMode = new DataGridViewTextBoxColumn();
                    ColMode.DataPropertyName = "Mode";
                    ColMode.HeaderText = FormNormalPendingCaptions.Mode;
                    ColMode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ColMode.Width = colWidth;
                    ColMode.ReadOnly = true;
                    gridPendingFile.Columns.Add(ColMode);


                    DataGridViewColumn ColProdInOut = new DataGridViewTextBoxColumn();
                    ColProdInOut.DataPropertyName = "ProdInOut";
                    ColProdInOut.HeaderText = FormNormalPendingCaptions.ProdInOut;
                    ColProdInOut.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ColProdInOut.Width = colWidth;
                    ColProdInOut.ReadOnly = true;
                    gridPendingFile.Columns.Add(ColProdInOut);

                    #endregion
                    List<PendingCompleteColumns> _result = new List<PendingCompleteColumns>();
                    foreach (var item in QueryNormalWeight)
                    {
                        PendingCompleteColumns _PendingCompleteColumns = new PendingCompleteColumns();
                        _PendingCompleteColumns.ID = item.ID;
                        _PendingCompleteColumns.Truck = item.Truck;
                        _PendingCompleteColumns.ProductName = item.ProductName;
                        _PendingCompleteColumns.SupplierName = item.SupplierName;
                        _PendingCompleteColumns.TransporterName = item.TransporterName;
                        _PendingCompleteColumns.DateIn = item.DateIn;
                        _PendingCompleteColumns.DateOut = item.DateOut.Year == 1900 ? (DateTime?)null : item.DateOut;
                        _PendingCompleteColumns.ChallanNumber = item.ChallanNumber;
                        _PendingCompleteColumns.ChallanDate = item.ChallanDate.Year == 1900 ? (DateTime?)null : item.ChallanDate;
                        _PendingCompleteColumns.ChallanWeight = item.ChallanWeight;
                        _PendingCompleteColumns.ChallanWeightUnit = item.ChallanWeightUnit;
                        _PendingCompleteColumns.GrossWeight = item.GrossWeight;
                        _PendingCompleteColumns.TareWeight = item.TareWeight;
                        _PendingCompleteColumns.Mode = item.Mode;
                        _PendingCompleteColumns.ProdInOut = item.ProdInOut;
                        _result.Add(_PendingCompleteColumns);
                    }

                    gridPendingFile.DataSource = _result;

                    #endregion
                }
                else if(rdbPublicWeight.Checked )
                {
                    var QueryPublicWeight = _dbObj.transPublicWeight.Where(x => x.IsPending == _chkCompleteFile).ToList();
                    gridPendingFile.DataSource = QueryPublicWeight;
                    lblRecordsCount.Text = QueryPublicWeight.Count().ToString();
                }
                else if(rdbMultiWeight.Checked )
                {
                    var QueryMultiWeight = _dbObj.viewNormalPendingFile.Where(x => x.IsPending == _chkCompleteFile).ToList();
                    gridPendingFile.DataSource = QueryMultiWeight;
                    lblRecordsCount.Text = QueryMultiWeight.Count().ToString();
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
        private void HideColumns(FrmName frmName)
        {
            try
            {
                if(gridPendingFile.ColumnCount > 0)
                {
                    if (gridPendingFile.Columns.Contains("ID") )
                        gridPendingFile.Columns["ID"].Visible = false;

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
        private void LoadCaption()
        {
            try
            {
                rdbNormalWeight.Text = _dbGetResourceCaption.GetStringValue("NORMAL_WEIGHING");
                rdbPublicWeight.Text = _dbGetResourceCaption.GetStringValue("PUBLIC_WEIGHING");
                rdbMultiWeight.Text = _dbGetResourceCaption.GetStringValue("MULTI_WEIGHING");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    _dbGetResourceCaption.GetStringValue("ERROR"), 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        #region CheckedChanged
        private void rdbNormalWeight_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(rdbCompleteFile.Checked);
            LoadGridData();
        }
        private void rdbPublicWeight_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(rdbCompleteFile.Checked);
            LoadGridData();
        }
        private void rdbMultiWeight_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(rdbCompleteFile.Checked);
            LoadGridData();
        }
        private void chkCompleteFile_CheckedChanged(object sender, EventArgs e)
        {
            //_chkCompleteFile = Convert.ToInt16(chkCompleteFile.Checked);
            //LoadGridData();
        }
        #endregion

        #region EmailAsExcel
        private void btnEmailAsExcel_Click(object sender, EventArgs e)
        {
            FrmName _frmNameCombination = FrmName.NormalPendingFile;
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                if (_chkCompleteFile == 0)
                {
                    if (rdbNormalWeight.Checked )
                    {
                        _frmNameCombination = FrmName.NormalPendingFile;
                    }
                    else if (rdbPublicWeight.Checked )
                    {
                        _frmNameCombination = FrmName.PublicPendingFile;
                    }
                    else if (rdbMultiWeight.Checked )
                    {
                        _frmNameCombination = FrmName.MultiPendingFile;
                    }
                }
                else
                {
                    if (rdbNormalWeight.Checked )
                    {
                        _frmNameCombination = FrmName.NormalCompleteFile;
                    }
                    else if (rdbPublicWeight.Checked )
                    {
                        _frmNameCombination = FrmName.PublicCompleteFile;
                    }
                    else if (rdbMultiWeight.Checked )
                    {
                        _frmNameCombination = FrmName.MultiCompleteFile;
                    }
                }
                obj.CreateExcelAndSendEmailToList(_frmNameCombination);
            }
        }
        #endregion

        #region PrintTicket

        private bool PrintTicket(Guid PrintID)
        {
            bool TicketPrinted = false;
            if (PrintID != null)
            {
                if (rdbNormalWeight.Checked)
                {
                    var RepData = _dbObj.rptNormalTicket
                        .Where(x => x.ID == PrintID.ToString())
                        .Select(x => new
                        {
                            ID = x.ID ?? string.Empty,
                            Truck = x.Truck ?? string.Empty,
                            Mode = x.Mode,
                            ProductCode = x.ProductCode ?? string.Empty,
                            Name = x.Name,
                            SupplierCode = x.SupplierCode,
                            SupplierName = x.SupplierName,
                            TransporterCode = x.TransporterCode ?? string.Empty,
                            TarnsPorterName = x.TarnsPorterName ?? string.Empty,
                            ChallanNumber = x.ChallanNumber ?? string.Empty,
                            Miscellaneous = x.Miscellaneous ?? string.Empty,
                            DeliveryNoteN = x.DeliveryNoteN ?? string.Empty,
                            ChallanWeight = x.ChallanWeight ?? string.Empty,
                            ChallanDate = x.ChallanDate ?? string.Empty,
                            DateIn = x.DateIn ?? string.Empty,
                            TimeIn = x.TimeIn ?? string.Empty,
                            DateOut = x.DateOut ?? string.Empty,
                            TimeOut = x.TimeOut ?? string.Empty,
                            TareWeight = x.TareWeight ?? string.Empty,
                            GrossWeight = x.GrossWeight ?? string.Empty,
                            NetWeight = x.NetWeight ?? string.Empty,
                            ProdInOut = x.ProdInOut
                        });

                    if (RepData.Count() > 0)
                    {
                        rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), 
                                                            FrmName.NormalWeighingTicket, 
                                                            enumProductInOut.Other);
                        rptCmn.ShowDialog();
                    }
                    else
                    {
                        string errorMessage = "No data to print";
                        MessageBox.Show(errorMessage
                                        , _dbGetResourceCaption.GetStringValue("ERROR")
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Error);
                    }
                }
            }
            return TicketPrinted;
        }
        private void gridPendingFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex != 0 || e.RowIndex < 0)
            //{
            //    return;
            //}
            //var senderGrid = (DataGridView)sender;
            //Guid PrintID = (Guid)gridPendingFile[gridPendingFile.Columns.IndexOf(gridPendingFile.Columns["ID"]), e.RowIndex].Value;
            //PrintTicket(PrintID);
        }
        #endregion

        #region Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<Guid> selectedCheckbox = GetListOfSelectCheckBox();
            if (selectedCheckbox.Count() <= 0)
            {
                errProvider.SetError(btnPrint, _dbGetResourceCaption.GetStringValue("SELECT_PRINT"));
            }else
            {
                foreach (var item in selectedCheckbox)
                {
                    PrintTicket(item);
                }
                LoadGridData();
            }

        }

        private List<Guid> GetListOfSelectCheckBox()
        {
            try
            {
                List<Guid> selectedCheckbox = new List<Guid>();
                //int id;
                for (int i = 0; i < gridPendingFile.Rows.Count; i++)
                {
                    //Assume that 0th Row of grid named grdDisplayAll contains Checkbox
                    if (Convert.ToBoolean(gridPendingFile.Rows[i].Cells[0].Value) == true)
                    {
                        selectedCheckbox.Add((Guid)gridPendingFile.Rows[i].Cells["Id"].Value);
                        //You may use columnIndex of column instead of ColumnName (i.e. Here "Id")

                        //Code here to make whatever you want to perform on selected record
                    }
                }
                return selectedCheckbox;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using(HitechTruckMngtSystmDataBaseFileEntities dbobj = new HitechTruckMngtSystmDataBaseFileEntities())
            {
                List<Guid> selectedCheckbox = GetListOfSelectCheckBox();
                foreach (var item in selectedCheckbox)
                {
                    var entity = dbobj.transNormalWeight.Where(x => x.ID == item).Single();
                    dbobj.transNormalWeight.Remove(entity);
                    dbobj.SaveChanges();
                }
            }
            LoadGridData();
        }

        private void btnSearchRecords_Click(object sender, EventArgs e)
        {
            if (dtPicketFromDate.Value.Date > dtPicketToDate.Value.Date)
            {
                errProvider.SetError(dtPicketFromDate, 
                    _dbGetResourceCaption.GetStringValue("GREATER_DATE_ERR"));
            }
            else
            {
                errProvider.Clear();
                LoadGridData();
            }
        }

        private void rdbPendingFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPendingFile.Checked)
            {
                _chkCompleteFile = Convert.ToInt16(!rdbPendingFile.Checked);
                LoadGridData();
            }
        }

        private void rdbCompleteFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompleteFile.Checked)
            {
                _chkCompleteFile = Convert.ToInt16(rdbCompleteFile.Checked);
                LoadGridData();
            }
        }
    }
    class PendingCompleteColumns
    {
        public Guid ID { get; set; }
        public string Truck { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string TransporterName { get; set; }
        public string ChallanNumber { get; set; }
        public DateTime? ChallanDate { get; set; }
        public decimal ChallanWeight { get; set; }
        public byte ChallanWeightUnit { get; set; }
        public string Miscellaneous { get; set; }
        public string Mode { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal TareWeight { get; set; }
        public string ProdInOut { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
    }
}
