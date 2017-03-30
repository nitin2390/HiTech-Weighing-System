using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using static HitechTMS.HitechEnums;
using System;

namespace HitechTMS
{
    public partial class rptCommon : Form
    {
        public FrmName _frmName { get; set; }
        public rptCommon(IEnumerable dataSrc, FrmName enumfrmName)
        {
            InitializeComponent();
            this._frmName = enumfrmName;

            ReportDocument cryRpt = new ReportDocument();
            if (_frmName == FrmName.ProductDetail)
            {
                cryRpt.Load(Environment.CurrentDirectory + @"\Reports\Product.rpt");
                this.Text = "Product";
            }
            else if (_frmName == FrmName.Supplier || _frmName == FrmName.Transport)
            {
                cryRpt.Load(Environment.CurrentDirectory + @"\Reports\SupplierTransport.rpt");
                cryRpt.SummaryInfo.ReportTitle = _frmName == FrmName.Supplier ? "Supplier File" : "Transport File";
                this.Text = _frmName == FrmName.Supplier ? "Supplier File" : "Transport File";
            }
            else if (_frmName == FrmName.AddEditUser)
            {
                cryRpt.Load(Environment.CurrentDirectory + @"\Reports\User.rpt");
                cryRpt.SummaryInfo.ReportTitle = "Users";
                this.Text = "Users";
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
