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
        private ProcessingForm _processingForm;
        private bool _emailSendStatus = false;
        private void LoadGridData()
        {
            try
            {

                if (rdbNormalWeight.Checked == true)
                {
                    var QueryNormalWeight = _dbObj.viewNormalPendingFile.Where(x => x.IsPending == _chkCompleteFile).ToList();
                    gridPendingFile.DataSource = QueryNormalWeight;
                    lblRecordsCount.Text = QueryNormalWeight.Count().ToString();
                    HideColumns(FrmName.NormalWeighing);
                }
                else if(rdbPublicWeight.Checked == true)
                {
                    var QueryPublicWeight = _dbObj.transPublicWeight.Where(x => x.IsPending == _chkCompleteFile).ToList();
                    gridPendingFile.DataSource = QueryPublicWeight;
                    lblRecordsCount.Text = QueryPublicWeight.Count().ToString();
                }
                else if(rdbMultiWeight.Checked == true)
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
                    if (gridPendingFile.Columns.Contains("ID") == true)
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
            _emailSendStatus = false;
            if (bgWorkerProcessor.IsBusy != true)
            {
                // create a new instance of the Processing form
                _processingForm = new ProcessingForm();
                // event handler for the Cancel button in AlertForm
                //_processingForm.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                _processingForm.StartPosition = FormStartPosition.CenterParent;
                // Start the asynchronous operation.
                bgWorkerProcessor.RunWorkerAsync();
                _processingForm.ShowDialog();
            }
        }

        #region "Worker Processor"
        private void bgWorkerProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            Task<bool> _emailStatus;
            BackgroundWorker worker = sender as BackgroundWorker;
            FrmName _frmNameCombination = FrmName.NormalPendingFile;
            using (CreateExcelAndSendEmail obj = new CreateExcelAndSendEmail())
            {
                if (_chkCompleteFile == 0)
                {
                    if (rdbNormalWeight.Checked == true)
                    {
                        _frmNameCombination = FrmName.NormalPendingFile;
                    }
                    else if (rdbPublicWeight.Checked == true)
                    {
                        _frmNameCombination = FrmName.PublicPendingFile;
                    }
                    else if (rdbMultiWeight.Checked == true)
                    {
                        _frmNameCombination = FrmName.MultiPendingFile;
                    }
                }
                else
                {
                    if (rdbNormalWeight.Checked == true)
                    {
                        _frmNameCombination = FrmName.NormalCompleteFile;
                    }
                    else if (rdbPublicWeight.Checked == true)
                    {
                        _frmNameCombination = FrmName.PublicCompleteFile;
                    }
                    else if (rdbMultiWeight.Checked == true)
                    {
                        _frmNameCombination = FrmName.MultiCompleteFile;
                    }
                }
                _emailStatus = CallSendEmailAsync(obj, _frmNameCombination);

                for (int i = 1; i <= 100; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // Perform a time consuming operation and report progress.
                        worker.ReportProgress(i);

                        if (!_emailSendStatus)
                        {
                            System.Threading.Thread.Sleep(250);
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
                _emailSendStatus = _emailStatus.Result;

            }
        }

        private void bgWorkerProcessor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Show the progress in main form (GUI)
            //labelResult.Text = (e.ProgressPercentage.ToString() + "%");
            // Pass the progress to AlertForm label and progressbar
            _processingForm.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            _processingForm.ProgressValue = e.ProgressPercentage;
        }

        private void bgWorkerProcessor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Close the AlertForm
            _processingForm.Close();
            if (_emailSendStatus)
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("EMAIL_SENT"), _dbGetResourceCaption.GetStringValue("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("ERR_EMAIL_CHK_CONFIG"), _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> CallSendEmailAsync(CreateExcelAndSendEmail obj, FrmName _frmNameCombination)
        {
            var _result = await Task.Run(() => obj.CreateExcelAndSendEmailToList(_frmNameCombination));
            return _result;
        }

        #endregion
    }
}
