using DAL.Entity_Model;
using HitechTMS.Classes;
using OD.Forms.Security;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.File
{
    public partial class frmStoredTareFile : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption dbGetResourceCaption;
        public Guid ID { get; set; }
        private EncryptionAndDecryption objEncryptionAndDecryption;
        private EmailConfig objEmailConfig;
        public FrmName _frmName { get; set; }
        public frmStoredTareFile(FrmName intfrmtype,IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.ApplicationUser.ToString() }, userPrincipal)
        {
            InitializeComponent();
            dbGetResourceCaption = new GetResourceCaption();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            this._frmName = intfrmtype;
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            objEmailConfig = new EmailConfig();
            BindTransportCode();
        }

        private void BindTransportCode()
        {
            try
            {
                var listTrasnportCode = dbObj.mstSupplierTransporter
                    .Where(x => x.IsSuplier == ((int)FrmName.Transport).ToString())
                    .Select(x => x).ToList();
                listTrasnportCode.Insert(0, new mstSupplierTransporter()  {  SupplierCode ="Select", SupplierName = "" });
                cmbTransportCode.DataSource = listTrasnportCode;
                cmbTransportCode.DisplayMember = "SupplierCode";
                cmbTransportCode.ValueMember = "SupplierCode";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void cmbTransportCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtTransportName.Text = ((DAL.Entity_Model.mstSupplierTransporter)cmbTransportCode.SelectedItem).SupplierName;

        }

        private void txtTareWeight_TextChanged(object sender, EventArgs e)
        {
            if(txtTareWeight.Text.Trim() != "")
            {
                txtDateIn.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");   
                txtTimeIn.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                txtDateIn.Text = "";
                txtTimeIn.Text = "";
            }
        }

        private void txtTareWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > 0))
            {
                e.Handled = true;
            }
        }
    }
}
