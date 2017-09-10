using DAL.Entity_Model;
using HitechTMS.Classes;
using ProcessingWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.File
{
    public partial class frmPendingFile : HitechTMSSecurity.SecureBaseForm
    {
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
        }

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
                                                x.Truck,
                                                x.ProductName,
                                                x.SupplierName,
                                                x.TransporterName,
                                                x.ChallanNumber,
                                                x.ChallanDate,
                                                x.ChallanWeight,
                                                x.ChallanWeightUnit,
                                                x.GrossWeight,
                                                x.TareWeight,
                                                x.ProdInOut
                                            })
                                            .OrderBy(x=> x.ProdInOut).ThenBy(x=>x.Truck)
                                            .ToList();

                    gridPendingFile.DataSource = QueryNormalWeight;
                    lblRecordsCount.Text = QueryNormalWeight.Count().ToString();

                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.Truck].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ProductName].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.SupplierName].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.TransporterName].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanNumber].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanDate].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanWeight].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanWeightUnit].Width = 50;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.GrossWeight].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.TareWeight].Width = 150;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ProdInOut].Width = 150;

                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.Truck].HeaderText = FormNormalPendingCaptions.Truck;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ProductName].HeaderText = FormNormalPendingCaptions.ProductName;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.SupplierName].HeaderText = FormNormalPendingCaptions.SupplierName;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.TransporterName].HeaderText = FormNormalPendingCaptions.TransporterName;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanNumber].HeaderText = FormNormalPendingCaptions.ChallanNumber;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanDate].HeaderText = FormNormalPendingCaptions.ChallanDate;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanWeight].HeaderText = FormNormalPendingCaptions.ChallanWeight;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ChallanWeightUnit].HeaderText = FormNormalPendingCaptions.ChallanWeightUnit;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.GrossWeight].HeaderText = FormNormalPendingCaptions.GrossWeight;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.TareWeight].HeaderText = FormNormalPendingCaptions.TareWeight;
                    gridPendingFile.Columns[(int)enumfrmNormalPendingHeader.ProdInOut].HeaderText = FormNormalPendingCaptions.ProdInOut;


                    //gridPendingFile.Columns[1].HeaderText = "Truck Name";

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

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void chkCompleteFile_CheckedChanged(object sender, EventArgs e)
        {
            _chkCompleteFile = Convert.ToInt16(chkCompleteFile.Checked);
            LoadGridData();
        }

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

        private void frmPendingFile_Load(object sender, EventArgs e)
        {

            
        }
    }
}
