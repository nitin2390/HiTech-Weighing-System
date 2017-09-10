using System;
using System.IO.Ports;
using System.Reflection;
using System.Threading;

namespace SerialPortListener.Serial
{

    /// <summary>
    /// Manager for serial port data
    /// </summary>
    public class SerialPortManager : IDisposable
    {
        public static int _calledfromWeighingforms { get; set; }
        public SerialPortManager(int calledfromWeighingforms = 0)
        {
            _calledfromWeighingforms = calledfromWeighingforms;
            // Finding installed serial ports on hardware
            _currentSerialSettings.PortNameCollection = SerialPort.GetPortNames();
            _currentSerialSettings.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_currentSerialSettings_PropertyChanged);

            // If serial ports is found, we select the first found
            if (_currentSerialSettings.PortNameCollection.Length > 0)
                _currentSerialSettings.PortName = _currentSerialSettings.PortNameCollection[0];
        }

        
        ~SerialPortManager()
        {
            Dispose(false);
        }


        #region Fields
        private SerialPort _serialPort;
        private SerialSettings _currentSerialSettings = new SerialSettings(_calledfromWeighingforms);
        private string _latestRecieved = String.Empty;
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved; 

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the current serial port settings
        /// </summary>
        public SerialSettings CurrentSerialSettings
        {
            get { return _currentSerialSettings; }
            set { _currentSerialSettings = value; }
        }

        #endregion

        #region Event handlers

        void _currentSerialSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // if serial port is changed, a new baud query is issued
            if (e.PropertyName.Equals("PortName"))
                UpdateBaudRateCollection();
        }

        
        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(10);
                string nbrDataRead = _serialPort.ReadLine();
                if (nbrDataRead.Length < 0)
                    return;

                // Send data to whom ever interested
                NewSerialDataRecieved?.Invoke(this, new SerialDataEventArgs(nbrDataRead));
            }
            catch (Exception)
            {

                //throw ex;
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public int StartListening()
        {
            try
            {
                // Closing serial port if it is open
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                // Setting serial port settings
                _serialPort = new SerialPort(
                    _currentSerialSettings.PortName,
                    _currentSerialSettings.BaudRate,
                    _currentSerialSettings.Parity,
                    _currentSerialSettings.DataBits,
                    _currentSerialSettings.StopBits);

                // Subscribe to event and open serial port for data
                _serialPort.Open();
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                
                return 0;
            }
            catch (Exception)
            {
                //Silently supress the error
                return -1;
            }

        }

        /// <summary>
        /// Closes the serial port
        /// </summary>
        public void StopListening()
        {
            _serialPort.Close();
        }


        /// <summary>
        /// Retrieves the current selected device's COMMPROP structure, and extracts the dwSettableBaud property
        /// </summary>
        private void UpdateBaudRateCollection()
        {
            _serialPort = new SerialPort(_currentSerialSettings.PortName);
            _serialPort.Open();
            object p = _serialPort.BaseStream.GetType().GetField("commProp", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_serialPort.BaseStream);
            Int32 dwSettableBaud = (Int32)p.GetType().GetField("dwSettableBaud", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);

            _serialPort.Close();
            _currentSerialSettings.UpdateBaudRateCollection(dwSettableBaud);
        }

        // Call to release serial port
        public void Dispose()
        {
            Dispose(true);
        }

        // Part of basic design pattern for implementing Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serialPort.DataReceived -= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            // Releasing serial port (and other unmanaged objects)
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.Dispose();
            }
        }


        #endregion

    }

    /// <summary>
    /// EventArgs used to send bytes recieved on serial port
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        public SerialDataEventArgs(string dataInByteArray)
        {
            Data = dataInByteArray;
        }

        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        public string Data;
    }
}
