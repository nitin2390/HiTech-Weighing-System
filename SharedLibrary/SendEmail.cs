using System;
using System.IO;
using System.Net.Mail;
using System.Data.Entity;
using System.Data;
using System.Collections.Generic;
using System.Collections;

namespace SharedLibrary
{
    public class SendEmail
    {
        public string EmailFrom { get; set; }
        public MailAddress EmailTo { get; set; }
        public string EmailFromPassword { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public int EmailServerPort { get; set; }
        public string EmailSmtpServer { get; set; }

        public string FileName { get; set; }
        public string WorkSheetName { get; set; }
        public DataTable dt { get; set; }

        public SendEmail(DataTable datatable,string emailFrom, MailAddress emailTo,
                            string emailFromPassword, string emailSubject,
                            string emailBody, int emailServerPort,
                            string emailSmtpServer,string fileName,string workSheetName
                        )
        {
            this.EmailFrom = emailFrom;
            this.EmailTo = emailTo;
            this.EmailFromPassword = emailFromPassword;
            this.EmailSubject = emailSubject;
            this.EmailBody = emailBody;
            this.EmailServerPort = emailServerPort;
            this.EmailSmtpServer = emailSmtpServer;
            this.dt = datatable;
            this.FileName = fileName;
            this.WorkSheetName = workSheetName;

        }
        public bool SendEmailTo()
        {
            try

            {
                if (CreateExlFile(dt,FileName,WorkSheetName) )
                {
                    Attachment attachment;
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(EmailSmtpServer);
                    attachment = new Attachment(Environment.CurrentDirectory + FileName);
                    mail.From = new MailAddress(EmailFrom);
                    mail.To.Add(EmailTo);
                    mail.Subject = EmailSubject;
                    mail.Body = EmailBody;
                    mail.Attachments.Add(attachment);
                    SmtpServer.Port = EmailServerPort;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom, EmailFromPassword);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);

                    mail.Attachments.Dispose();
                    releaseObject(SmtpServer);
                    releaseObject(mail);
                    releaseObject(attachment);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return false;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public bool CreateExlFile(DataTable dt,string FileName, string WorkSheetName)
        {
            ExcelUtlity obj = new ExcelUtlity();
            try
            {
                string ExcelFolderPath = Environment.CurrentDirectory + FileName;
                    if (File.Exists(ExcelFolderPath))
                    {
                        File.Delete(ExcelFolderPath);
                    }
                    obj.WriteDataTableToExcel(dt, "Product Details", ExcelFolderPath);
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                obj = null;
            }

        }
    }
}
