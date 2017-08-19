using System;
using DAL;
namespace HitechTMS.Classes
{
    public class ReadSerialPortData
    {
        private GetResourceCaption _dbGetResourceCaption;

        public ReadSerialPortData()
        {
            _dbGetResourceCaption = new GetResourceCaption();
        }
        public double ReadSerialPortCommunication()
        {
            double ReadSerialPortValue = 0.00;
            try
            {
                string str;
                /* Uncomment After developement complete       
                 */
                HyperTerminalAdapter ht = new HyperTerminalAdapter();
                ht.Connect();
                str = ht.ReadSerialPort().Replace("\u0002", "").Replace("\u0003", "").Replace("\r", "");

                //Random rnd = new Random();
                //str = rnd.Next(1, 150).ToString();

                if (double.TryParse(str, out ReadSerialPortValue))
                    return ReadSerialPortValue;
                return ReadSerialPortValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
