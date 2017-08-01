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
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace HitechTMS.MasterForms
{
    public partial class frmGeneralSetting : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        public Guid ID { get; set; }
        EncryptionAndDecryption objEncryptionAndDecryption;
        mstGeneralSettings GeneralSetting = new mstGeneralSettings();


        public frmGeneralSetting(FrmName _FrmName, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {

            InitializeComponent();
            _dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();

            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            cmbMode.DataSource = Enum.GetValues(typeof(enumWeightMode));
            cmbStoredTare.DataSource = Enum.GetValues(typeof(enumYesNo));
            cmbFirstWeightTicket.DataSource = Enum.GetValues(typeof(enumYesNo));
            cmbTicketFormat.DataSource = Enum.GetValues(typeof(enumTicket));
            cmbReportFormat.DataSource = Enum.GetValues(typeof(enumReportFormat));
            cmbTicketReportPrintingMode.DataSource = Enum.GetValues(typeof(enumReportPrinting));
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
                cmbMode.SelectedIndex = cmbMode.FindString(generalSettingData[0].Mode.ToString() == ((int)enumWeightMode.Manual).ToString() ? enumWeightMode.Manual.ToString() : enumWeightMode.Auto.ToString());
                txtMinimumNetWtLimit.Text = generalSettingData[0].MiniNetWeight.ToString();
                cmbStoredTare.SelectedIndex = cmbStoredTare.FindString(generalSettingData[0].StoreTare.ToString() == ((int)enumYesNo.No).ToString() ? enumYesNo.No.ToString() : enumYesNo.Yes.ToString());
                cmbFirstWeightTicket.SelectedIndex = cmbFirstWeightTicket.FindString(generalSettingData[0].FirstWeightTkt.ToString() == ((int)enumYesNo.No).ToString() ? enumYesNo.No.ToString() : enumYesNo.Yes.ToString());
                cmbTicketFormat.SelectedIndex = cmbTicketFormat.FindString(generalSettingData[0].TicketFormat.ToString() == ((int)enumYesNo.No).ToString() ? enumTicket.HalfTicket.ToString() : enumTicket.FullTicket.ToString());
                cmbReportFormat.SelectedIndex = cmbReportFormat.FindString(generalSettingData[0].ReportFormat.ToString() == ((int)enumYesNo.No).ToString() ? enumReportFormat.Compressed.ToString() : enumReportFormat.Details.ToString());
                cmbTicketReportPrintingMode.SelectedIndex = cmbTicketReportPrintingMode.FindString(generalSettingData[0].TktRepPrintingMode.ToString() == ((int)enumYesNo.No).ToString() ? enumReportPrinting.Draft.ToString() : enumReportPrinting.Graphical.ToString());
                txtHeaderBlankLine.Text = generalSettingData[0].HeaderBlankLine.ToString();
                txtFooterBlankLine.Text = generalSettingData[0].FooterBlankLine.ToString();

            }
            else
            {
                ID = Guid.NewGuid();
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtTransactionNo.Text))
            {
                errorProviderSetting.SetError(txtTransactionNo, _dbGetResourceCaption.GetStringValue("CANT_BE_BLANK"));
                txtTransactionNo.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            if (string.IsNullOrEmpty(txtMinimumNetWtLimit.Text))
            {

                errorProviderSetting.SetError(txtMinimumNetWtLimit, _dbGetResourceCaption.GetStringValue("CANT_BE_BLANK"));
                txtMinimumNetWtLimit.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            if (string.IsNullOrEmpty(txtHeaderBlankLine.Text))
            {

                errorProviderSetting.SetError(txtHeaderBlankLine, _dbGetResourceCaption.GetStringValue("CANT_BE_BLANK"));
                txtHeaderBlankLine.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            if (string.IsNullOrEmpty(txtFooterBlankLine.Text))
            {

                errorProviderSetting.SetError(txtFooterBlankLine, _dbGetResourceCaption.GetStringValue("CANT_BE_BLANK"));
                txtFooterBlankLine.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtTransactionNo.Text, "[^0-9]"))
            {
                // MessageBox.Show("Please enter only numbers in Min Net Weight");
                errorProviderSetting.SetError(txtTransactionNo, _dbGetResourceCaption.GetStringValue("INT_TRANSACTION"));
                txtTransactionNo.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtMinimumNetWtLimit.Text, "[^0-9]"))
            {
                // MessageBox.Show("Please enter only numbers in Min Net Weight");
                errorProviderSetting.SetError(txtMinimumNetWtLimit, _dbGetResourceCaption.GetStringValue("INT_MIN_NET_WEIGHT"));
                txtMinimumNetWtLimit.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtHeaderBlankLine.Text, "[^0-9]"))
            {
                // MessageBox.Show("Please enter only numbers in Header Blank Line");
                errorProviderSetting.SetError(txtHeaderBlankLine, _dbGetResourceCaption.GetStringValue("INT_HEADER_BLANK_LINE"));
                txtHeaderBlankLine.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtFooterBlankLine.Text, "[^0-9]"))
            {
                //  MessageBox.Show("Please enter only numbers in Footer Blank Line");
                errorProviderSetting.SetError(txtFooterBlankLine, _dbGetResourceCaption.GetStringValue("INT_FOOTER_BLANK_LINE"));
                txtFooterBlankLine.Focus();
                return;
            }
            else
            {
                errorProviderSetting.Clear();
            }

            GeneralSetting.Id = ID;
            GeneralSetting.TransactionNo = Convert.ToInt32(txtTransactionNo.Text);
            GeneralSetting.Mode = cmbMode.SelectedIndex.ToString();
            GeneralSetting.MiniNetWeight = Convert.ToDecimal(txtMinimumNetWtLimit.Text);
            GeneralSetting.StoreTare = cmbStoredTare.SelectedIndex.ToString();
            GeneralSetting.FirstWeightTkt = cmbFirstWeightTicket.SelectedIndex.ToString();
            GeneralSetting.TicketFormat = cmbTicketFormat.SelectedIndex.ToString();
            GeneralSetting.ReportFormat = cmbReportFormat.SelectedIndex.ToString();
            GeneralSetting.TktRepPrintingMode = cmbTicketReportPrintingMode.SelectedIndex.ToString();
            GeneralSetting.HeaderBlankLine = Convert.ToInt32(txtHeaderBlankLine.Text);
            GeneralSetting.FooterBlankLine = Convert.ToInt32(txtFooterBlankLine.Text);
            GeneralSetting.AddedDate = DateTime.Now;
            GeneralSetting.UpdatedDate = DateTime.Now;
            dbObj.mstGeneralSettings.AddOrUpdate(GeneralSetting);
            try
            {
                if (dbObj.SaveChanges() == 1)
                {
                    MessageBox.Show(_dbGetResourceCaption.GetStringValue("DATA_SAVE"));
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
