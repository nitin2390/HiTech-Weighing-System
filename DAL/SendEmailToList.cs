using DAL.Entity_Model;
using System;
using System.Linq;

namespace DAL
{
    public class SendEmailToList
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        //private SendEmail objSendEmail;
        public SendEmailToList()
        {
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
        }

        public bool sendEmail()
        {
            try
            {
                dbObj.SaveChanges();
                //var emailConfig = dbObj.EmailConfigs.Select(x =>
                //    new
                //    {
                //        x.EmailID,
                //        x.Password,
                //        x.EmailServerPort,
                //        x.EmailSmtpServer
                //    }).SingleOrDefault();
                //objSendEmail = new SendEmail()
                return true;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return false;
            }
        }

    }
}
