using DAL.Entity_Model;
using HitechTMS.Classes;
using System;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS
{
    public partial class frmDateFiltersForReports : HitechTMSSecurity.SecureBaseForm
    {
        public IPrincipal _iPrincipal { get; set; }
        public enumProductNormalPublicMulti _enumProductNormalPublicMulti { get; set; }
        public enumWeightMode _weightMode { get; set; }
        public enumProductInOut _enumProductInOut { get; set; }
        private GetResourceCaption _dbGetResourceCaption;
        public frmDateFiltersForReports(enumProductNormalPublicMulti EnumProductInOut, IPrincipal userPrincipal) : 
                            base(new string[] { AppRole.SuperAdmin.ToString(),
                                                    AppRole.Admin.ToString(),
                                                        AppRole.ApplicationUser.ToString(),
                                                            AppRole.Supervisor.ToString() }, userPrincipal)
        {
            InitializeComponent();
            _dbGetResourceCaption = new GetResourceCaption();
            _iPrincipal = userPrincipal;
            _enumProductNormalPublicMulti = EnumProductInOut;
            Text = _enumProductNormalPublicMulti.ToString() + " Weighing Report";
            MaximumSize = MinimumSize = Size;
            MinimizeBox = MaximizeBox = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(_enumProductNormalPublicMulti == enumProductNormalPublicMulti.Normal)
            {
                using (HitechTruckMngtSystmDataBaseFileEntities dbContext = new HitechTruckMngtSystmDataBaseFileEntities())
                {
                    var RepData = dbContext.V_rptNormalReport
                            .Where(x => x.DateIn >= dtPicketFromDate.Value.Date && x.DateIn <= dtPicketToDate.Value.Date && x.DateIn != null)
                            .Select(x => new
                            {
                                ID = x.ID ?? string.Empty,
                                Truck = x.Truck ?? string.Empty,
                                Mode = x.Mode,
                                ProductCode = x.ProductCode ?? string.Empty,
                                Name = x.Name,
                                SupplierCode = x.SupplierCode,
                                SupplierName = x.SupplierName,
                                TransporterCode = x.TransporterCode ?? string.Empty,
                                TarnsPorterName = x.TarnsPorterName ?? string.Empty,
                                ChallanNumber = x.ChallanNumber ?? string.Empty,
                                Miscellaneous = x.Miscellaneous ?? string.Empty,
                                DeliveryNoteN = x.DeliveryNoteN ?? string.Empty,
                                ChallanWeight = x.ChallanWeight ?? string.Empty,
                                ChallanDate = x.ChallanDate ?? DateTime.MinValue,
                                DateIn = x.DateIn ?? DateTime.MinValue,
                                TimeIn = x.TimeIn ?? string.Empty,
                                DateOut = x.DateOut ?? DateTime.MinValue,
                                TimeOut = x.TimeOut ?? string.Empty,
                                TareWeight = x.TareWeight ?? string.Empty,
                                GrossWeight = x.GrossWeight ?? string.Empty,
                                NetWeight = x.NetWeight ?? string.Empty,
                                ProdInOut = x.ProdInOut
                            });

                    if (RepData.Count() > 0)
                    {
                        rptCommon rptCmn = new rptCommon(RepData.ToList().AsEnumerable(),
                                                            FrmName.NormalWeighingReport,
                                                            enumProductInOut.Other);
                        rptCmn.ShowDialog();
                    }
                    else
                    {
                        string errorMessage = "No data to print";
                        MessageBox.Show(errorMessage
                                        , _dbGetResourceCaption.GetStringValue("ERROR")
                                        , MessageBoxButtons.OK
                                        , MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
