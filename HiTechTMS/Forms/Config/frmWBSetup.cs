using DAL.Entity_Model;
using HitechTMS.Classes;
using HitechTMSSecurity;
using SharedLibrary;
using System;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
namespace HitechTMS.MasterForms
{
    public partial class frmWBSetup : SecureBaseForm
    {

        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption dbGetResourceCaption;

        public Guid ID { get; set; }
        EncryptionAndDecryption objEncryptionAndDecryption;
        mstWeighBridgeSetup WeighBridgeSetup = new mstWeighBridgeSetup();

        public frmWBSetup(FrmName _FrmName, IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.SuperAdmin.ToString() }, userPrincipal)
        {
            InitializeComponent();
            dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            cmbUnits.DataSource = Enum.GetValues(typeof(enumUnits));
            LoadData();

        }
        private void LoadData()
        {
            var WBSetupData= dbObj.mstWeighBridgeSetup.Select(
                x => new
                {
                    x.Id,
                    x.Unit,
                    x.WeighCapacity
                }).ToList();
           
            if (WBSetupData.Count>0)
            {
                ID = WBSetupData[0].Id == Guid.Empty ? Guid.NewGuid() : WBSetupData[0].Id;
                cmbUnits.SelectedIndex = cmbUnits.FindString(Enum.GetName(typeof(enumUnits),WBSetupData[0].Unit));
                if (cmbUnits.SelectedIndex==0)
                {
                    lblWt.Text = "Kg";
                }
                else
                {
                    lblWt.Text = "t";
                }
                txtWBCapacity.Text = WBSetupData[0].WeighCapacity.ToString();

            }
            else
            {
                ID = Guid.NewGuid();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtWBCapacity.Text))
            {

                errorWBSetup.SetError(txtWBCapacity, dbGetResourceCaption.GetStringValue("CANT_BE_BLANK"));
                txtWBCapacity.Focus();
                return;
            }
            else
            {
                errorWBSetup.Clear();
            }


            if ((txtWBCapacity.MaxLength < 6) || Convert.ToInt32(txtWBCapacity.Text) < 0)
            {

                // errorWBSetup.SetError(txtWBCapacity, dbGetResourceCaption.GetStringValue("CANT_BE_BLANK"));
                MessageBox.Show("Not correct");
                txtWBCapacity.Focus();
                return;
            }
            else
            {
                errorWBSetup.Clear();
            }


            WeighBridgeSetup.Id = ID;
            WeighBridgeSetup.Unit = cmbUnits.SelectedIndex;
            WeighBridgeSetup.WeighCapacity = Convert.ToInt32(txtWBCapacity.Text);
            dbObj.mstWeighBridgeSetup.AddOrUpdate(WeighBridgeSetup);
            try
            {
                if (dbObj.SaveChanges() == 1)
                {
                    MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_SAVE"));
                }
            }
            catch (DbEntityValidationException dbEx)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUnits.SelectedIndex == 0)
            {
                lblWt.Text = "Kg";
            }
            else
            {
                lblWt.Text = "t";
            }
        }

        private void txtWBCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
            if (e.KeyChar == (char)13)
            {
                btnOk_Click(sender , e);
            }
        }

    }
}
