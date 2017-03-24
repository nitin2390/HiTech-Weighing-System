using SharedLibrary;
using System.Data;
using System.Linq;
using System.Net.Mail;
using DAL.Entity_Model;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace HitechTMS.Classes
{
    public class CreateExcelAndSendEmail : IDisposable
    {
        public HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public string FileName { get; set; }
        public string WorkSheetName { get; set; }

        //public string EmailSubject { get; set; }
        //public string EmailBody { get; set; }
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
                    this.FileName = "ProductDetails.xls";
                    this.WorkSheetName = "Details";
                }
                else if (objEnums == HitechEnums.FrmName.ProductDetail)
                {
                    var query = dbObj.Products.Select(x => new { x.Code, x.Name });
                    dt = obj.ConvertToDataTable(query.ToList());
                    this.FileName = "ProductDetails.xls";
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
    }
}
