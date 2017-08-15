using System;
using System.Text;
using System.Windows.Forms;
using SerialPortListener.Serial;
using DAL.Entity_Model;
using HitechTMS.Classes;
using System.IO.Ports;
using System.Linq;
using System.Data.Entity.Migrations;

namespace SerialPortListener
{
    public partial class frmSerialPortSetting : Form
    {
        SerialPortManager _spManager;
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        public frmSerialPortSetting()
        {
            _dbGetResourceCaption = new GetResourceCaption();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();

            InitializeComponent();
            UserInitialization();
        }

      
        private void UserInitialization()
        {
            _spManager = new SerialPortManager(0);
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            serialSettingsBindingSource.DataSource = mySerialSettings;
            portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;
            dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));
            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            //this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _spManager.Dispose();   
        }


        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            int maxTextLength = 1000; // maximum text length in text box
            if (tbData.TextLength > maxTextLength)
                tbData.Text = tbData.Text.Remove(0, tbData.TextLength - maxTextLength);

            // This application is connected to a GPS sending ASCCI characters, so data is converted to text
            //string str = Encoding.ASCII.GetString(e.Data);
            tbData.AppendText(e.Data + Environment.NewLine);
            tbData.ScrollToCaret();
        }

        // Handles the "Start Listening"-buttom click event
        public void btnStart_Click(object sender, EventArgs e)
        {
            if (_spManager.StartListening() == -1)
            {
                MessageBox.Show("Error in settings");
            }
        }

        // Handles the "Stop Listening"-buttom click event
        public void btnStop_Click(object sender, EventArgs e)
        {
            if (_spManager.StartListening() != -1)
            {
                _spManager.StopListening();
            }
            else
            {
                MessageBox.Show("Port is not openned!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mstHyperTerminalData objmstHyperTerminalData = new mstHyperTerminalData();

            var OldResult = _dbObj.mstHyperTerminalData.ToList();
            if(OldResult.Count() > 0)
            {
                objmstHyperTerminalData.Id = OldResult[0].Id;
            }else
            {
                objmstHyperTerminalData.Id = Guid.NewGuid();
            }
            if (_spManager.StartListening() != -1)
            {
                objmstHyperTerminalData.PortName = portNameComboBox.SelectedItem.ToString();
                objmstHyperTerminalData.BaudRate = Convert.ToInt32(baudRateComboBox.SelectedItem);
                objmstHyperTerminalData.DataBits = Convert.ToInt32(dataBitsComboBox.SelectedItem);
                objmstHyperTerminalData.sParity = parityComboBox.SelectedItem.ToString();
                objmstHyperTerminalData.iStopBits = Convert.ToDecimal((StopBits)Enum.Parse(typeof(StopBits), stopBitsComboBox.SelectedItem.ToString()));
                _dbObj.mstHyperTerminalData.AddOrUpdate(objmstHyperTerminalData);
                _dbObj.SaveChanges();
                _spManager.StopListening();
            }
            else
            {
                MessageBox.Show("Error in settings");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if(_spManager.CurrentSerialSettings.PortName.Length > 0)
                {
                    _spManager.StartListening();
                    _spManager.StopListening();
                    _spManager.Dispose();
                }
                Close();
            }
            catch (Exception)
            {
                //throw ex;
            }
        }
    }
}
