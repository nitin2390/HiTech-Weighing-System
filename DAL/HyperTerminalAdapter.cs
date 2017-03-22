using System;
using System.IO.Ports;

namespace DAL
{
    public class HyperTerminalAdapter
    {
        SerialPort oSerialPort = new SerialPort();

        // Allow the user to set the appropriate properties. 
        public int BaudRate = 2400;
        public int DataBits = 8;
        public int ReadTimeout = 2000;
        public int WriteTimeout = 2000;
        public string PortName = "COM4";
        public string Handshake = "";
        public string Name = "user";
        public string DataReceived = "";
        public string sParity = "none";
        public int iStopBits = 1;



        public HyperTerminalAdapter()
        {
            this.Configure();
        }

        public void Configure()
        {
            oSerialPort.PortName = this.PortName;
            oSerialPort.BaudRate = this.BaudRate;
            oSerialPort.DataBits = this.DataBits;
            oSerialPort.ReadTimeout = this.ReadTimeout;
            oSerialPort.WriteTimeout = this.WriteTimeout;

            oSerialPort.Handshake = System.IO.Ports.Handshake.None;

            if (this.sParity == "even")
            {
                oSerialPort.Parity = Parity.Even;
            }
            else if (this.sParity == "odd")
            {
                oSerialPort.Parity = Parity.Odd;
            }
            else if (this.sParity == "mark")
            {
                oSerialPort.Parity = Parity.Mark;
            }
            else if (this.sParity == "space")
            {
                oSerialPort.Parity = Parity.Space;
            }
            else
            {
                oSerialPort.Parity = Parity.None;
            }

            if (this.iStopBits == 0)
            {
                oSerialPort.StopBits = StopBits.None;
            }
            else if (this.iStopBits == 1.5)
            {
                oSerialPort.StopBits = StopBits.OnePointFive;
            }
            else if (this.iStopBits == 2)
            {
                oSerialPort.StopBits = StopBits.Two;
            }
            else
            {
                oSerialPort.StopBits = StopBits.One;
            }

        }

        public Boolean Connect()
        {
            bool connect = false;
            try
            {
                if (!oSerialPort.IsOpen)
                {
                    oSerialPort.Open();
                    connect = true;
                }
                return connect; 
            }
            catch (Exception e1)
            {
                string strErr = e1.Message;
                return connect;
            }
        }
        
        public void Disconnect()
        {
            try
            {
                if (oSerialPort.IsOpen)
                {
                    oSerialPort.Close();
                }
            }
            catch { }
        }

        //public void Write(string sData)
        //{
        //    if (oSerialPort.IsOpen)
        //    {
        //        try
        //        {
        //            oSerialPort.WriteLine(sData);
        //        }
        //        catch { }
        //    }
        //}

        public string ReadSerialPort()
        {
            try
            {
                this.DataReceived = oSerialPort.ReadLine().ToString();
                oSerialPort.Close();
                return (this.DataReceived);                
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

    }
}
