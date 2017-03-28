using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using static HitechTMS.HitechEnums;

namespace HitechTMS
{
    public partial class rptCommon : Form
    {
        public FrmName _frmName { get; set; }
        public rptCommon(IEnumerable dataSrc,FrmName enumfrmName)
        {
            InitializeComponent();
            this._frmName = enumfrmName;

                ReportDocument cryRpt = new ReportDocument();
                if (_frmName == FrmName.ProductDetail)
                {
                    cryRpt.Load(@"..\..\Reports\Product.rpt");
                }
                else if (_frmName == FrmName.Supplier || _frmName == FrmName.Transport)
                {
                    cryRpt.Load(@"..\..\Reports\SupplierTransport.rpt");
                cryRpt.SummaryInfo.ReportTitle = _frmName == FrmName.Supplier ? "Supplier File" : "Transport File";
                }

                cryRpt.SetDataSource(dataSrc);
                cryRepViewCommon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                cryRepViewCommon.ReportSource = cryRpt;
                cryRepViewCommon.Refresh();
            
        }

        private void rptCommon_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
