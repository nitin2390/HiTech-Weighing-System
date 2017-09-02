using SharedLibrary;
using System.Data;
using System.Linq;
using System.Net.Mail;
using DAL.Entity_Model;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Windows.Forms;

namespace HitechTMS.Classes
{
    public class CreateExcelAndSendEmail : Form, IDisposable
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        bool disposed = false;
        private System.ComponentModel.BackgroundWorker bgWorkerProcessor;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public string FileName { get; set; }
        public string WorkSheetName { get; set; }

        public CreateExcelAndSendEmail()
        {
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
        }
        public bool CreateExcelAndSendEmailToList(HitechEnums.FrmName objEnums)
        {
            try
            {
                ExcelUtlity obj = new ExcelUtlity();
                DataTable dt = new DataTable();

                if (objEnums == HitechEnums.FrmName.ProductDetail)
                {
                    var query = dbObj.Products.Select(x => new { x.Code, x.Name });
                    dt = obj.ConvertToDataTable(query.ToList());
                    dt.Columns.Remove("ID");
                    this.FileName = @"\ProductDetails.xls";
                    this.WorkSheetName = "Details";
                }
                else if(objEnums == HitechEnums.FrmName.NormalPendingFile)
                {
                    var query = dbObj.viewNormalPendingFile.Where(x => x.IsPending == 0).ToList();
                    dt = obj.ConvertToDataTable(query.ToList());
                    dt.Columns.Remove("ID");
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
                    var query = dbObj.viewNormalPendingFile.Where(x => x.IsPending == 1).ToList();
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
                    var query = dbObj.mstSupplierTransporter
                        .Where(x => x.IsSuplier == ((int)HitechEnums.FrmName.Supplier).ToString())
                        .Select(x => new { x.SupplierCode, x.SupplierName, x.Address1, x.Address2, x.Address3, x.Phone, x.Fax, x.Email, x.IsSuplier });
                        
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\SupplierFile.xls";
                    this.WorkSheetName = "Details";
                }

                else if (objEnums == HitechEnums.FrmName.Transport)
                {
                    var query = dbObj.mstSupplierTransporter
                        .Where(x => x.IsSuplier == ((int)HitechEnums.FrmName.Transport).ToString())
                        .Select(x => new { x.SupplierCode, x.SupplierName, x.Address1, x.Address2, x.Address3, x.Phone, x.Fax, x.Email });
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\TransportFile.xls";
                    this.WorkSheetName = "Details";
                }

                else if (objEnums == HitechEnums.FrmName.AddEditUser)
                {
                    var query = dbObj.UserRoleTypes
                        .Join(dbObj.UserRole, x => x.Id, s => s.UserRoleType, (x, s) => new { s.Name, x.RoleName })
                        .Where(x => x.RoleName != HitechEnums.AppRole.SuperAdmin.ToString())
                        .Select(x => x);
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\User.xls";
                    this.WorkSheetName = "Details";
                }

                else if (objEnums == HitechEnums.FrmName.StoredTareFile)
                {
                    var query = from StoredTareRecords in dbObj.mstStoredTareRecords.AsEnumerable()
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
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = @"\Stored Tare File.xls";
                    this.WorkSheetName = "Details";
                }

                EncryptionAndDecryption objEncryptionAndDecryption = new EncryptionAndDecryption();
                var objEmailConfig = dbObj.EmailConfigs.Select(x => new { x.EmailID,
                                        x.EmailServerPort, x.EmailSmtpServer, x.Password,x.EmailBody,
                                        x.EmailSubject,x.EmailRecipient,x.IsActive }).Where(x => x.IsActive == "1").ToList();
                MailAddress mytoAddress = new MailAddress(objEmailConfig[0].EmailRecipient.ToString(),"HiTech Weighing");
                SendEmail objSendEmail = new SendEmail(dt, objEmailConfig[0].EmailID.ToString(), mytoAddress, objEncryptionAndDecryption.Decrypt(objEmailConfig[0].Password).ToString(), objEmailConfig[0].EmailSubject.ToString(), objEmailConfig[0].EmailBody.ToString(), 587, objEmailConfig[0].EmailSmtpServer.ToString(), this.FileName, this.WorkSheetName);
                if(objSendEmail.SendEmailTo()==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (System.Exception)
            {

                return false;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
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
            // 
            // CreateExcelAndSendEmail
            // 
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Name = "CreateExcelAndSendEmail";
            this.ResumeLayout(false);

        }
    }
}
