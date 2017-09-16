﻿using DAL.Entity_Model;
using HitechTMS.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.File
{
    public partial class frmPendingFile : HitechTMSSecurity.SecureBaseForm
    {
        #region "Public and Private Property"
        private GetResourceCaption _dbGetResourceCaption;
        public int _chkCompleteFile { get; set; }
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        public FrmName _frmName { get; set; }
        public frmPendingFile(FrmName FrmName,IPrincipal userPrincipal) : base(new string[] { AppRole.Admin.ToString(), AppRole.SuperAdmin.ToString(), AppRole.Supervisor.ToString(), AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            InitializeComponent();
            MaximumSize = MinimumSize = Size;
            MinimizeBox = MaximizeBox = false;
            _frmName = FrmName;
            _dbGetResourceCaption = new GetResourceCaption();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
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
                                                x.ProdInOut
                                            })
                                            .OrderBy(x=> x.ProdInOut).ThenBy(x=>x.Truck)
                                            .ToList();

                    lblRecordsCount.Text = QueryNormalWeight.Count().ToString();
                    
                    #region "Bind Columns"

                    gridPendingFile.AutoGenerateColumns = false;
                    gridPendingFile.Columns.Clear();

                    int colWidth = 150;


                    #region "Add Column"
                    DataGridViewButtonColumn ColPrintTicket = new DataGridViewButtonColumn();
                    ColPrintTicket.DataPropertyName = "PrintTicket";
                    ColPrintTicket.HeaderText = FormNormalPendingCaptions.PrintTicket;
                    ColPrintTicket.Width = colWidth - 20;
                    ColPrintTicket.Text = FormNormalPendingCaptions.PrintTicket;
                    ColPrintTicket.UseColumnTextForButtonValue = true;
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
                    gridPendingFile.Columns.Add(ColTruck);

                    DataGridViewColumn colProductName = new DataGridViewTextBoxColumn();
                    colProductName.DataPropertyName = "ProductName";
                    colProductName.HeaderText = FormNormalPendingCaptions.ProductName.ToString();
                    colProductName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colProductName.Width = colWidth;
                    gridPendingFile.Columns.Add(colProductName);

                    DataGridViewColumn colSupplierName = new DataGridViewTextBoxColumn();
                    colSupplierName.HeaderText = FormNormalPendingCaptions.SupplierName;
                    colSupplierName.DataPropertyName = "SupplierName";
                    colSupplierName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colSupplierName.Width = colWidth;
                    gridPendingFile.Columns.Add(colSupplierName);

                    DataGridViewColumn colTransporterName = new DataGridViewTextBoxColumn();
                    colTransporterName.HeaderText = FormNormalPendingCaptions.TransporterName;
                    colTransporterName.DataPropertyName = "TransporterName";
                    colTransporterName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colTransporterName.Width = colWidth;
                    gridPendingFile.Columns.Add(colTransporterName);

                    DataGridViewColumn colChallanNumber = new DataGridViewTextBoxColumn();
                    colChallanNumber.HeaderText = FormNormalPendingCaptions.ChallanNumber;
                    colChallanNumber.DataPropertyName = "ChallanNumber";
                    colChallanNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colChallanNumber.Width = colWidth;
                    gridPendingFile.Columns.Add(colChallanNumber);

                    DataGridViewColumn colChallanDate = new DataGridViewTextBoxColumn();
                    colChallanDate.HeaderText = FormNormalPendingCaptions.ChallanDate;
                    colChallanDate.DataPropertyName = "ChallanDate";
                    colChallanDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colChallanDate.Width = colWidth;
                    gridPendingFile.Columns.Add(colChallanDate);

                    DataGridViewColumn colChallanWeight = new DataGridViewTextBoxColumn();
                    colChallanWeight.HeaderText = FormNormalPendingCaptions.ChallanWeight;
                    colChallanWeight.DataPropertyName = "ChallanWeight";
                    colChallanWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colChallanWeight.Width = colWidth;
                    gridPendingFile.Columns.Add(colChallanWeight);

                    DataGridViewColumn colChallanWeightUnit = new DataGridViewTextBoxColumn();
                    colChallanWeightUnit.HeaderText = FormNormalPendingCaptions.ChallanWeightUnit;
                    colChallanWeightUnit.DataPropertyName = "ChallanWeightUnit";
                    colChallanWeightUnit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colChallanWeightUnit.Width = colWidth;
                    gridPendingFile.Columns.Add(colChallanWeightUnit);

                    DataGridViewColumn colGrossWeight = new DataGridViewTextBoxColumn();
                    colGrossWeight.HeaderText = FormNormalPendingCaptions.GrossWeight;
                    colGrossWeight.DataPropertyName = "GrossWeight";
                    colGrossWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colGrossWeight.Width = colWidth;
                    gridPendingFile.Columns.Add(colGrossWeight);

                    DataGridViewColumn colTareWeight = new DataGridViewTextBoxColumn();
                    colTareWeight.HeaderText = FormNormalPendingCaptions.TareWeight;
                    colTareWeight.DataPropertyName = "TareWeight";
                    colTareWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colTareWeight.Width = colWidth;
                    gridPendingFile.Columns.Add(colTareWeight);

                    DataGridViewColumn ColMode = new DataGridViewTextBoxColumn();
                    ColMode.DataPropertyName = "Mode";
                    ColMode.HeaderText = FormNormalPendingCaptions.Mode;
                    ColMode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ColMode.Width = colWidth;
                    gridPendingFile.Columns.Add(ColMode);


                    DataGridViewColumn ColProdInOut = new DataGridViewTextBoxColumn();
                    ColProdInOut.DataPropertyName = "ProdInOut";
                    ColProdInOut.HeaderText = FormNormalPendingCaptions.ProdInOut;
                    ColProdInOut.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ColProdInOut.Width = colWidth;
                    gridPendingFile.Columns.Add(ColProdInOut);

                    #endregion

                    gridPendingFile.DataSource = QueryNormalWeight;

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
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region CheckedChanged
        private void rdbNormalWeight_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(chkCompleteFile.Checked);
            LoadGridData();
        }
        private void rdbPublicWeight_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(chkCompleteFile.Checked);
            LoadGridData();
        }
        private void rdbMultiWeight_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(chkCompleteFile.Checked);
            LoadGridData();
        }
        private void chkCompleteFile_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(chkCompleteFile.Checked);
            LoadGridData();
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
        private void gridPendingFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 0 || e.RowIndex < 0)
            {
                return;
            }
            var senderGrid = (DataGridView)sender;
            var PrintID = this.gridPendingFile[gridPendingFile.Columns.IndexOf(gridPendingFile.Columns["ID"]), e.RowIndex].Value;
            if (PrintID != null)
            {
                if (rdbNormalWeight.Checked)
                {
                    var RepData = _dbObj.rptNormalTicket
                        .Where(x => x.ID == PrintID.ToString())
                        .Select(x => new {
                            ID = x.ID ?? "",
                            Truck = x.Truck ?? "",
                            Mode = x.Mode,
                            ProductCode = x.ProductCode ?? "",
                            Name = x.Name,
                            SupplierCode = x.SupplierCode,
                            SupplierName = x.SupplierName,
                            TransporterCode = x.TransporterCode ?? "",
                            TarnsPorterName = x.TarnsPorterName ?? "",
                            ChallanNumber = x.ChallanNumber ?? "",
                            Miscellaneous = x.Miscellaneous ?? "",
                            DeliveryNoteN = x.DeliveryNoteN ?? "",
                            ChallanWeight = x.ChallanWeight ?? "",
                            ChallanDate = x.ChallanDate ?? "",
                            DateIn = x.DateIn ?? "",
                            TimeIn = x.TimeIn ?? "",
                            DateOut = x.DateOut ?? "",
                            TimeOut = x.TimeOut ?? "",
                            TareWeight = x.TareWeight ?? "",
                            GrossWeight = x.GrossWeight ?? "",
                            NetWeight = x.NetWeight ?? "",
                            ProdInOut = x.ProdInOut

                });
                rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(), FrmName.NormalWeighing, enumProductInOut.Other);
                rptCmn.ShowDialog();
                }
            }
        }
        #endregion

        #region Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
