using SharedLibrary;
using System.Data;
using System.Linq;
using System.Net.Mail;
using DAL.Entity_Model;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using ProcessingWindow;

namespace HitechTMS.Classes
{

    public class CreateExcelAndSendEmail : Form, IDisposable
    {
        public HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        private ProcessingForm _processingForm;
        bool disposed = false;
        private System.ComponentModel.BackgroundWorker bgWorkerProcessor;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public string FileName { get; set; }
        public string WorkSheetName { get; set; }
        private bool _emailSendStatus = false;

        public CreateExcelAndSendEmail()
        {
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _dbGetResourceCaption = new GetResourceCaption();
            InitializeComponent();
        }
        public bool CreateExcelAndSendEmailToList(HitechEnums.FrmName objEnums)
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
                bgWorkerProcessor.RunWorkerAsync(objEnums);
                _processingForm.ShowDialog();
            }

            return _emailSendStatus;
        }

        private bool SendCurrentEmail(HitechEnums.FrmName objEnums)
        {
            try
            {
                ExcelUtlity obj = new ExcelUtlity();
                DataTable dt = new DataTable();

                if (objEnums == HitechEnums.FrmName.ProductDetail)
                {
                    var query = _dbObj.Products.Select(x => new { x.Code, x.Name });
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\ProductDetails.xls";
                    this.WorkSheetName = "Details";
                }
                else if (objEnums == HitechEnums.FrmName.NormalPendingFile)
                {
                    var query = _dbObj.viewNormalPendingFile.Where(x => x.IsPending == 0).ToList();
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\Normal Pending Weight.xls";
                    this.WorkSheetName = "Details";
                }
                else if (objEnums == HitechEnums.FrmName.PublicPendingFile)
                {
                    //var query = dbObj.viewNormalPendingFile.Where(x => x.IsPending == 0).ToList();
                    //dt = obj.ConvertToDataTable(query.ToList());
                    //this.FileName = @"\Normal Pending Weight.xls";
                    //this.WorkSheetName = "Details";
                }
                else if (objEnums == HitechEnums.FrmName.MultiPendingFile)
                {

                }
                else if (objEnums == HitechEnums.FrmName.NormalCompleteFile)
                {
                    var query = _dbObj.viewNormalPendingFile.Where(x => x.IsPending == 1).ToList();
                    dt = obj.ConvertToDataTable(query.ToList());
                    dt.Columns.Remove("ID");
                    this.FileName = @"\Normal Complete Weight.xls";
                    this.WorkSheetName = "Details";
                }
                else if (objEnums == HitechEnums.FrmName.PublicCompleteFile)
                {

                }
                else if (objEnums == HitechEnums.FrmName.MultiCompleteFile)
                {

                }



                else if (objEnums == HitechEnums.FrmName.Supplier)
                {
                    var query = _dbObj.mstSupplierTransporter
                        .Where(x => x.IsSuplier == ((int)HitechEnums.FrmName.Supplier).ToString())
                        .Select(x => new { x.SupplierCode, x.SupplierName, x.Address1, x.Address2, x.Address3, x.Phone, x.Fax, x.Email, x.IsSuplier });

                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\SupplierFile.xls";
                    this.WorkSheetName = "Details";
                }

                else if (objEnums == HitechEnums.FrmName.Transport)
                {
                    var query = _dbObj.mstSupplierTransporter
                        .Where(x => x.IsSuplier == ((int)HitechEnums.FrmName.Transport).ToString())
                        .Select(x => new { x.SupplierCode, x.SupplierName, x.Address1, x.Address2, x.Address3, x.Phone, x.Fax, x.Email });
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\TransportFile.xls";
                    this.WorkSheetName = "Details";
                }

                else if (objEnums == HitechEnums.FrmName.AddEditUser)
                {
                    var query = _dbObj.UserRoleTypes
                        .Join(_dbObj.UserRole, x => x.Id, s => s.UserRoleType, (x, s) => new { s.Name, x.RoleName })
                        .Where(x => x.RoleName != HitechEnums.AppRole.SuperAdmin.ToString())
                        .Select(x => x);
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\User.xls";
                    this.WorkSheetName = "Details";
                }

                else if (objEnums == HitechEnums.FrmName.StoredTareFile)
                {
                    var query = from StoredTareRecords in _dbObj.mstStoredTareRecords.AsEnumerable()
                                join s in _dbObj.mstSupplierTransporter.AsEnumerable() on StoredTareRecords.mstSupplierTransporterID equals s.Id into joinedmm
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
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\Stored Tare File.xls";
                    this.WorkSheetName = "Details";
                }

                EncryptionAndDecryption objEncryptionAndDecryption = new EncryptionAndDecryption();
                var objEmailConfig = _dbObj.EmailConfigs.Select(x => new {
                    x.EmailID,
                    x.EmailServerPort,
                    x.EmailSmtpServer,
                    x.Password,
                    x.EmailBody,
                    x.EmailSubject,
                    x.EmailRecipient,
                    x.IsActive
                }).Where(x => x.IsActive == "1").ToList();
                MailAddress mytoAddress = new MailAddress(objEmailConfig[0].EmailRecipient.ToString(), "HiTech Weighing");
                SendEmail objSendEmail = new SendEmail(dt, objEmailConfig[0].EmailID.ToString(), mytoAddress, objEncryptionAndDecryption.Decrypt(objEmailConfig[0].Password).ToString(), objEmailConfig[0].EmailSubject.ToString(), objEmailConfig[0].EmailBody.ToString(), 587, objEmailConfig[0].EmailSmtpServer.ToString(), this.FileName, this.WorkSheetName);
                if (objSendEmail.SendEmailTo() )
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }

        private void InitializeComponent()
        {
            this.bgWorkerProcessor = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bgWorkerProcessor
            // 
            this.bgWorkerProcessor.WorkerReportsProgress = true;
            this.bgWorkerProcessor.WorkerSupportsCancellation = true;
            this.bgWorkerProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerProcessor_DoWork);
            this.bgWorkerProcessor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerProcessor_ProgressChanged);
            this.bgWorkerProcessor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerProcessor_RunWorkerCompleted);
            // 
            // CreateExcelAndSendEmail
            // 
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Name = "CreateExcelAndSendEmail";
            this.ResumeLayout(false);

        }

        private async Task<bool> SendCurrentEmailAsync(HitechEnums.FrmName objEnums)
        {
            var _result = await Task.Run(() => SendCurrentEmail(objEnums));
            return _result;
        }

        private void bgWorkerProcessor_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Task<bool> _emailStatus;
            BackgroundWorker worker = sender as BackgroundWorker;
            _emailStatus = SendCurrentEmailAsync((HitechEnums.FrmName)Enum.Parse(typeof(HitechEnums.FrmName),e.Argument.ToString()));

            for (int i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending )
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

        private void bgWorkerProcessor_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Show the progress in main form (GUI)
            //labelResult.Text = (e.ProgressPercentage.ToString() + "%");
            // Pass the progress to AlertForm label and progressbar
            _processingForm.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            _processingForm.ProgressValue = e.ProgressPercentage;
        }

        private void bgWorkerProcessor_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
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

    }
}
