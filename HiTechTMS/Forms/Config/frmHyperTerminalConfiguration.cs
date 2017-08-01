using DAL.Entity_Model;
using HitechTMS.Classes;
using SerialPortListener.Serial;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using HitechTMSSecurity;
using static HitechTMS.HitechEnums;

namespace HitechTMS.Config
{
    public partial class frmHyperTerminalConfiguration : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        public Guid ID { get; set; }
        EncryptionAndDecryption objEncryptionAndDecryption;
        EmailConfig objEmailConfig;
        SerialPortManager _spManager;
        public frmHyperTerminalConfiguration(FrmName frmName, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Admin.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            objEmailConfig = new EmailConfig();
            UserInitialization();
            //LoadData();
            //btnExit.CausesValidation = false;
        }

        private void UserInitialization()
        {
            _spManager = new SerialPortManager();
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            serialSettingsBindingSource.DataSource = mySerialSettings;
            portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;
            dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));
            //_spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>();
            //this.FormClosing += new FormClosingEventHandler();
        }
    }
}
