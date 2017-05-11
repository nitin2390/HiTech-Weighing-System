using DAL.Entity_Model;
using HitechTMS.Classes;
using HitechTMSSecurity;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.MasterForms
{
    public partial class frmGeneralSetting : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption dbGetResourceCaption;
        public Guid ID { get; set; }
        EncryptionAndDecryption objEncryptionAndDecryption;
        EmailConfig objEmailConfig;
        public frmGeneralSetting(FrmName _FrmName, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString() , HitechEnums.AppRole.SuperAdmin.ToString() }, userPrincipal)
        {

            InitializeComponent();
            dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            objEmailConfig = new EmailConfig();
            LoadData();
          //  btnExit.CausesValidation = false;
        }

        private void LoadData()
        {
            var generalSettingData = dbObj.mstGeneralSettings.Select(
                x => new
                {
                    x.Id,
                    x.TransactionNo,
                    x.Mode,
                    x.MiniNetWeight,
                    x.StoreTare,
                    x.FirstWeightTkt,
                    x.TicketFormat,
                    x.ReportFormat,
                    x.TktRepPrintingMode,
                    x.HeaderBlankLine,
                    x.FooterBlankLine,
                    x.AddedDate,
                    x.UpdatedDate
                }).ToList();

            if (generalSettingData.Count > 0)
            {
                ID = generalSettingData[0].Id == Guid.Empty ? Guid.NewGuid() : generalSettingData[0].Id;
                txtTransactionNo.Text = generalSettingData[0].TransactionNo.ToString();
                cmbMode.SelectedIndex = cmbMode.FindString(generalSettingData[0].Mode.ToString()=="0"? enumWeightMode.Manual.ToString():enumWeightMode.Auto.ToString());
                txtMinimumNetWtLimit.Text = generalSettingData[0].MiniNetWeight.ToString();
                cmbStoredTare.SelectedIndex = cmbStoredTare.FindString(generalSettingData[0].MiniNetWeight.ToString() == "0" ? enumYesNo.No.ToString() : enumYesNo.Yes.ToString());
                cmbFirstWeightTicket.SelectedIndex= cmbFirstWeightTicket.FindString(generalSettingData[0].FirstWeightTkt.ToString() == "0" ? enumYesNo.No.ToString() : enumYesNo.Yes.ToString());
                cmbTicketFormat.SelectedIndex= cmbTicketFormat.FindString(generalSettingData[0].TicketFormat.ToString() == "0" ? enumTicket.HalfTicket.ToString() : enumTicket.FullTicket.ToString());


            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
