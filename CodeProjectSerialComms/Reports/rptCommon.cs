using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;

namespace HitechTMS
{
    public partial class rptCommon : Form
    {

        public rptCommon(IEnumerable dataSrc)
        {
            InitializeComponent();

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"..\..\Reports\Product.rpt");
            cryRpt.SetDataSource(dataSrc);
            cryRepViewCommon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            cryRepViewCommon.ReportSource = cryRpt;
            cryRepViewCommon.Refresh();

        }
    }
}
