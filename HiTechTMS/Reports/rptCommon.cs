using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using static HitechTMS.HitechEnums;
using System;
using Microsoft.Reporting.WinForms;

namespace HitechTMS
{
    public partial class rptCommon : Form
    {
        public FrmName _frmName { get; set; }
        public rptCommon(IEnumerable dataSrc, FrmName enumfrmName, enumProductInOut _enumProductInOut)
        {
            InitializeComponent();
            this._frmName = enumfrmName;

            ReportDocument cryRpt = new ReportDocument();
            if (_frmName == FrmName.ProductDetail)
            {
                cryRpt.Load(Environment.CurrentDirectory + @"\Reports\Product.rpt");
                cryRpt.SummaryInfo.ReportTitle = FrmName.ProductDetail.ToString();
                this.Text = FrmName.ProductDetail.ToString();
                
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

            else if (_frmName == FrmName.StoredTareFile)
            {
                cryRpt.Load(Environment.CurrentDirectory + @"\Reports\StoredTareFile.rpt");
                cryRpt.SummaryInfo.ReportTitle = "Stored Tare File";
                this.Text = "Stored Tare File";
            }

            else if (_frmName == FrmName.NormalWeighingTicket)
            {
                cryRpt.Load(Environment.CurrentDirectory + @"\Reports\normalTicket.rpt");
                cryRpt.SummaryInfo.ReportTitle = "Normal Weighing";
                this.Text = "Normal Weighing";
            }

            else if (_frmName == FrmName.NormalWeighingReport)
            {
                cryRpt.Load(Environment.CurrentDirectory + @"\Reports\NormalWeightComplete.rpt");
                cryRpt.SummaryInfo.ReportTitle = "Normal Weighing";
                this.Text = "Normal Weighing";
                SetHeaderForNormalWeighingReport(cryRpt);
            }

            cryRepViewCommon.Refresh();
            cryRpt.SetDataSource(dataSrc);
            cryRepViewCommon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            //cryRpt.SetParameterValue(0, "HiTech Weighing System");
            cryRepViewCommon.ReportSource = cryRpt;

        }

        private void SetHeaderForNormalWeighingReport(ReportDocument cryRpt)
        {
            try
            {

                cryRpt.DataDefinition.FormulaFields["H1"].Text = "'HiTech Weighing System'";
                cryRpt.DataDefinition.FormulaFields["H2"].Text = "'Normal Weight Report'";
                cryRpt.DataDefinition.FormulaFields["DateCaption"].Text = "'Date Time :'";
                cryRpt.DataDefinition.FormulaFields["SupplierCodeCaption"].Text = "'Supplier Code'";
                cryRpt.DataDefinition.FormulaFields["SupplierNameCaption"].Text = "'Supplier Name'";
                cryRpt.DataDefinition.FormulaFields["TruckCaption"].Text = "'Truck'";
                cryRpt.DataDefinition.FormulaFields["TransportNameCaption"].Text = "'Transport Name'";
                cryRpt.DataDefinition.FormulaFields["TransportCodeCaption"].Text = "'Transport Code'";
                cryRpt.DataDefinition.FormulaFields["TransportCodeCaption"].Text = "'Transport Code'";

                cryRpt.DataDefinition.FormulaFields["ProductCodeCaption"].Text = "'Product Code'";
                cryRpt.DataDefinition.FormulaFields["ProductNameCaption"].Text = "'Product Name'";
                cryRpt.DataDefinition.FormulaFields["ChallanNumberCaption"].Text = "'Challan Number'";
                cryRpt.DataDefinition.FormulaFields["ChallanDateCaption"].Text = "'Challan Date'";

                cryRpt.DataDefinition.FormulaFields["DateInCaption"].Text = "'Date In'";
                cryRpt.DataDefinition.FormulaFields["DateOutCaption"].Text = "'Date Out'";
                cryRpt.DataDefinition.FormulaFields["FirstWeightCaption"].Text = "'Tare Weight'";
                cryRpt.DataDefinition.FormulaFields["SecondWeightCaption"].Text = "'Gorss Weight'";
                cryRpt.DataDefinition.FormulaFields["NetWeightCaption"].Text = "'Net Weight'";



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rptCommon_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void rptCommon_Load(object sender, EventArgs e)
        {
            //this.rptViewer.RefreshReport();
            //rptViewer.Size = MaximumSize = MinimumSize = Size;
        }

        
    }
}
