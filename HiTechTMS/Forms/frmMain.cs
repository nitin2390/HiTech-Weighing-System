#region frmMain
#region NameSpace
using System;
using System.Windows.Forms;
using DAL;
using DAL.Entity_Model;
using System.Security.Principal;
using HitechTMSSecurity;
using HitechTMS.MasterForms;
using HitechTMS.Classes;
using HitechTMS.File;
using HitechTMS.Weighing;
using static HitechTMS.HitechEnums;
using HitechTMS.Config;
using System.Collections.Generic;
using System.Linq;
using MsgBox;
using SharedLibrary;
using SerialPortListener;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
#endregion
namespace HitechTMS
{
    public partial class frmMain : SecureBaseForm
    {
        #region Private Variable
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private IPrincipal _nextFormPrincipal;
        private GetResourceCaption _dbGetResourceCaption;
        private enumProductNormalPublicMulti _enumProductNormalPublicMulti { get; set; }
        private EncryptionAndDecryption objEncryptionAndDecryption;
        private string _role { get; set; }
        HyperTerminalAdapter ht = new HyperTerminalAdapter();
        enumWeightMode _mode;
        private string _usrName { get; set; }
        #endregion
        #region Delete Queries
        private string TransportFileDeleteQuery
                        = "Delete from mstSupplierTransporter where IsSuplier = "
                                + ((int)FrmName.Transport).ToString();
        private string SupplierFileDeleteQuery
                        = "Delete from mstSupplierTransporter where IsSuplier = "
                                + ((int)FrmName.Supplier).ToString();
        private string ProductFileDeleteQuery
                        = "Delete from Product";
        private string StoredTareFileDeleteQuery
                        = "Delete from mstStoredTareRecords";
        private string PendingFileDeleteQuery
                        = "select * from transNormalWeight where IsPending = 1";
        #endregion
        #region Cons
        public frmMain(string usrName, IPrincipal userPrincipal, string role) : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Supervisor.ToString(), HitechEnums.AppRole.ApplicationUser.ToString() }, userPrincipal)
        {

            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            _dbGetResourceCaption = new GetResourceCaption();
            objEncryptionAndDecryption = new EncryptionAndDecryption();
            _nextFormPrincipal = userPrincipal;
            KeyPreview = true;
            InitializeComponent();
            _role = role;
            LoadGlobalValues();
            _mode = GetGeneralSettingValues.Mode != null ?
                        (enumWeightMode)Enum.Parse(typeof(enumWeightMode), GetGeneralSettingValues.Mode)
                        : enumWeightMode.Auto;// (enumWeightMode)Enum.ToObject(typeof(enumWeightMode), GetGeneralSettingValues.Mode);

            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            pnlBottom.Location = new System.Drawing.Point(Bounds.X, Bounds.Height - pnlBottom.Height);
            pnlBottom.Width = Bounds.Width;
            MinimizeBox = MaximizeBox = false;
            HideMenuOnBasisOfRole();
            _usrName = usrName;

            lblCompanyName.Text = "Devloped && Maintained by : HiTech Weighing Enginners | ";
            lblCopyright.Text = "Copyright ©1990-2017. All right reserved";
            lblCompanyName.Location = new System.Drawing.Point(Bounds.X + 5, 0);
            lblCopyright.Location = new System.Drawing.Point(Bounds.Width - (lblCopyright.Width + (Bounds.Width / 3)), 0);
            lblDateAndTime.Location = new System.Drawing.Point(Bounds.Width - (lblDateAndTime.Width + (Bounds.Width / 5)), 0);
            chartNormalPendingWeight.Location = new System.Drawing.Point(50, 60);
            chartNormalCompleteWeight.Location = new System.Drawing.Point(500, 60);
            tmrDateAndTime.Interval = 1000;
            tmrDateAndTime.Start();

            var abc = Task.Run(() => GetModifiedFormsCaption());
        }
        #endregion
        #region LoadGlobalValues
        private void LoadGlobalValues()
        {
            try
            {
                if (dbObj.V_mstGeneralSettings.FirstOrDefault() != null)
                {
                    V_mstGeneralSettings GeneralSettings = dbObj.V_mstGeneralSettings.First();
                    GetGeneralSettingValues.Transaction_No = GeneralSettings.TransactionNo;
                    GetGeneralSettingValues.Mode = GeneralSettings.Mode;
                    GetGeneralSettingValues.Minimun_Net_Weight = GeneralSettings.MiniNetWeight;
                    GetGeneralSettingValues.Stored_Tare = GeneralSettings.StoreTare;
                    GetGeneralSettingValues.First_Weight_Ticket = GeneralSettings.FirstWeightTkt;
                    GetGeneralSettingValues.Ticket_Format = GeneralSettings.TicketFormat;
                    GetGeneralSettingValues.Report_Format = GeneralSettings.ReportFormat;
                    GetGeneralSettingValues.Ticket_Report_Printing_Mode = GeneralSettings.ReportFormat;
                    GetGeneralSettingValues.Header_Blank_Line = GeneralSettings.HeaderBlankLine;
                    GetGeneralSettingValues.Fotter_Blank_Line = GeneralSettings.FooterBlankLine;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    _dbGetResourceCaption.GetStringValue("ERROR"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion
        #region MenuSecurity
        private void HideMenuOnBasisOfRole()
        {
            try
            {
                foreach (ToolStripMenuItem mainMenu in menuStrip1.Items)
                {
                    // Level 1 menu
                    if (mainMenu.Text == "Configuration" && _role != HitechEnums.AppRole.SuperAdmin.ToString())
                    {
                        mainMenu.Visible = false;
                    }

                    // Level 2 menu
                    if (!mainMenu.Visible)
                    {
                        SetToolStripItems(mainMenu.DropDownItems);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    _dbGetResourceCaption.GetStringValue("ERROR"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        // if we have a MenuStrip named ts.

        private void SetToolStripItems(ToolStripItemCollection dropDownItems)
        {
            try
            {
                foreach (object obj in dropDownItems)
                {
                    if (obj.GetType().Equals(typeof(ToolStripMenuItem)))
                    {
                        //Level 2 menu
                        ToolStripMenuItem subMenu = (ToolStripMenuItem)obj;
                        if (subMenu.Text != null)
                        {
                            if (subMenu.Text == "Transaction / Pending File" && _role != HitechEnums.AppRole.SuperAdmin.ToString())
                            {
                                subMenu.Visible = false;
                            }
                        }
                        if (subMenu.HasDropDownItems)
                        {
                            SetToolStripItems(subMenu.DropDownItems);
                        }
                        else // Do the desired operations here.
                        {
                            //Level 3 menu
                            if (subMenu.Text != null)
                            {
                                if (subMenu.Text == "Transaction / Pending File" && _role != HitechEnums.AppRole.SuperAdmin.ToString())
                                {
                                    subMenu.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                _dbGetResourceCaption.GetStringValue("ERROR"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Form Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                // For each of the top menu items, get all sub items recursively
                allItems.AddRange(GetItems(item));
            }

            LoadDashBoard();

        }

        private IEnumerable<ToolStripMenuItem> GetItems(ToolStripMenuItem item)
        {
            foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
            {
                if (dropDownItem.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem subItem in GetItems(dropDownItem))
                        yield return subItem;
                }
                yield return dropDownItem;
            }
        }
        #endregion
        #region Closing Form Validation
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseFormValidation();
            }
        }
        private void CloseFormValidation()
        {
            if (MessageBox.Show(_dbGetResourceCaption.GetStringValue("CLOSE_APPLICATION"),
                _dbGetResourceCaption.GetStringValue("CONFIRMATION"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {

                InputBox.SetLanguage(InputBox.Language.English);
                DialogResult res = InputBox.ShowDialog(_dbGetResourceCaption.GetStringValue("ENTER_PASS"),
                                    _dbGetResourceCaption.GetStringValue("CONFIRMATION"),
                    InputBox.Icon.Nothing,
                    InputBox.Buttons.OkCancel,
                    InputBox.Type.TextBox,
                    null,
                    true,
                    new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold));
                if (res == DialogResult.OK || res == DialogResult.Yes)
                {
                    var password = objEncryptionAndDecryption.Encrypt(InputBox.ResultValue);
                    var result = dbObj.UserRole.Where(x => x.Password == password && x.Name == _usrName).Count();
                    if (result > 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(_dbGetResourceCaption.GetStringValue("USER_NAME_PASSWORD_MISTMATCH"),
                                            _dbGetResourceCaption.GetStringValue("ERROR"),
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
        #region DashBoard
        private void LoadDashBoard()
        {
            LoadNormalPendingWeight();
            LoadNormalCompleteWeight();
        }

        private void LoadNormalPendingWeight()
        {
            try
            {
                using (HitechTruckMngtSystmDataBaseFileEntities _dbobject = new HitechTruckMngtSystmDataBaseFileEntities())
                {
                    if (chartNormalPendingWeight.Titles.Any())
                    {
                        chartNormalPendingWeight.Titles.RemoveAt(0);
                    }
                    var resultSingleWeight = _dbobject.V_NormalPendingWeightDashBoard.ToList();
                    chartNormalPendingWeight.DataSource = resultSingleWeight;
                    chartNormalPendingWeight.Series[0].YValueMembers = "TruckCount";
                    chartNormalPendingWeight.Series[0].XValueMember = "DateIn";
                    chartNormalPendingWeight.Series[0].ChartType = SeriesChartType.Pie;
                    chartNormalPendingWeight.Series[0].IsValueShownAsLabel = true;
                    Title title = new Title();
                    title.Text = _dbGetResourceCaption.GetStringValue("NORMAL_CHART_PENDING");
                    title.Font = new Font("Arial", 14, FontStyle.Bold);
                    title.ForeColor = Color.FromArgb(0, 0, 205);
                    chartNormalPendingWeight.Titles.Add(title);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LoadNormalCompleteWeight()
        {
            try
            {
                using (HitechTruckMngtSystmDataBaseFileEntities _dbobject = new HitechTruckMngtSystmDataBaseFileEntities())
                {
                    if (chartNormalCompleteWeight.Titles.Any())
                    {
                        chartNormalCompleteWeight.Titles.RemoveAt(0);
                    }
                    var resultSingleWeight = _dbobject.V_NormalCompleteWeightDashBoard.ToList();
                    chartNormalCompleteWeight.DataSource = resultSingleWeight;
                    chartNormalCompleteWeight.Series[0].YValueMembers = "TruckCount";
                    chartNormalCompleteWeight.Series[0].XValueMember = "DateIn";
                    chartNormalCompleteWeight.Series[0].ChartType = SeriesChartType.Pie;
                    chartNormalCompleteWeight.Series[0].IsValueShownAsLabel = true;
                    Title title = new Title();
                    title.Text = _dbGetResourceCaption.GetStringValue("NORMAL_CHART_COMPLETE");
                    title.Font = new Font("Arial", 14, FontStyle.Bold);
                    title.ForeColor = Color.FromArgb(0, 0, 205);
                    chartNormalCompleteWeight.Titles.Add(title);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        #region File
        #region Open
        private void supplierFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierTransportFile objfrmSupplierFile = new frmSupplierTransportFile(FrmName.Supplier, _nextFormPrincipal);
            objfrmSupplierFile.Text = "Supplier File";
            objfrmSupplierFile.StartPosition = FormStartPosition.CenterParent;
            objfrmSupplierFile.ShowDialog();
        }
        private void productFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct productForm = new frmProduct(FrmName.ProductDetail, _nextFormPrincipal);
            productForm.StartPosition = FormStartPosition.CenterParent;
            productForm.ShowDialog();
        }
        private void transporterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierTransportFile objfrmTransportFile = new frmSupplierTransportFile(FrmName.Transport, _nextFormPrincipal);
            objfrmTransportFile.Text = "Transport File";
            objfrmTransportFile.StartPosition = FormStartPosition.CenterParent;
            objfrmTransportFile.ShowDialog();
        }
        private void storedTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmStoredTareFile objfrmTransportFile = new frmStoredTareFile(FrmName.StoredTareFile, _nextFormPrincipal, _mode);

            if (objfrmTransportFile.UserCanOpenForm == false)
            {
                MessageBox.Show(_dbGetResourceCaption.GetStringValue("DENIED"),
                    _dbGetResourceCaption.GetStringValue("INFORMATION"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                objfrmTransportFile.Text = @"Stored Tare File";
                objfrmTransportFile.StartPosition = FormStartPosition.CenterParent;
                objfrmTransportFile.ShowDialog();
            }

        }
        private void transactionPendingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactionForm objfrmSupplierFile = new frmTransactionForm(FrmName.Supplier, _nextFormPrincipal);
            objfrmSupplierFile.Text = "Transaction Files";
            objfrmSupplierFile.StartPosition = FormStartPosition.CenterParent;
            objfrmSupplierFile.ShowDialog();
        }
        #endregion
        #region Initialize Files
        private void productFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearData(ProductFileDeleteQuery);
        }
        private void transactionFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ClearData();
        }
        private void supplierFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearData(SupplierFileDeleteQuery);
        }

        private void transporterFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearData(TransportFileDeleteQuery);
        }

        private void storedTareFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData(StoredTareFileDeleteQuery);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ClearData(PendingFileDeleteQuery);
        }

        private void ClearData(string sqlCommand)
        {
            var result = MessageBox.Show(
                            _dbGetResourceCaption.GetStringValue("CONFIRMATION_DELETE"),
                            _dbGetResourceCaption.GetStringValue("CONFIRMATION"),
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ClearTableData(sqlCommand))
                {
                    MessageBox.Show(
                           _dbGetResourceCaption.GetStringValue("DATA_DELETED"),
                           _dbGetResourceCaption.GetStringValue("CONFIRMATION"),
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        _dbGetResourceCaption.GetStringValue("DATA_DELETED"),
                        _dbGetResourceCaption.GetStringValue("ERROR_DELETE"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        private bool ClearTableData(string sqlCommand)
        {
            bool IsDataDeleted = false;
            using (HitechTruckMngtSystmDataBaseFileEntities dbContext = new HitechTruckMngtSystmDataBaseFileEntities())
            {
                dbContext.Database.ExecuteSqlCommand(sqlCommand);
                IsDataDeleted = true;
            }
            return IsDataDeleted;
        }
        #endregion
        #region Switch user
        private void switchUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin objfrmLogin = new frmLogin();
            objfrmLogin.StartPosition = FormStartPosition.CenterParent;
            objfrmLogin.ShowDialog();
            this.Close();
        }

        #endregion
        #region Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }
        #endregion
        #endregion
        #region Weighing Forms

        private void publicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _enumProductNormalPublicMulti = enumProductNormalPublicMulti.Public;
            frmProductInOut objfrmProductInOut = new frmProductInOut(_enumProductNormalPublicMulti, _mode, _nextFormPrincipal);
            objfrmProductInOut.StartPosition = FormStartPosition.CenterParent;
            objfrmProductInOut.ShowDialog();
            if (objfrmProductInOut.DialogResult == DialogResult.Cancel)
            {
                LoadDashBoard();
            }
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _enumProductNormalPublicMulti = enumProductNormalPublicMulti.Normal;
            frmProductInOut objfrmProductInOut = new frmProductInOut(_enumProductNormalPublicMulti, _mode, _nextFormPrincipal);
            objfrmProductInOut.StartPosition = FormStartPosition.CenterParent;
            objfrmProductInOut.ShowDialog();
            if (objfrmProductInOut.DialogResult == DialogResult.Cancel)
            {
                LoadDashBoard();
            }

        }

        private void multiWeighingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _enumProductNormalPublicMulti = enumProductNormalPublicMulti.Multi;
            frmProductInOut objfrmProductInOut = new frmProductInOut(_enumProductNormalPublicMulti, _mode, _nextFormPrincipal);
            objfrmProductInOut.StartPosition = FormStartPosition.CenterParent;
            objfrmProductInOut.ShowDialog();
        }

        #endregion
        #region Configuration
            #region Email
            private void emailConfigToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmEmailConfig objEmailConfig = new frmEmailConfig(_nextFormPrincipal);
                if (objEmailConfig.UserCanOpenForm == false)
                {
                    MessageBox.Show(_dbGetResourceCaption.GetStringValue("DENIED"),
                        _dbGetResourceCaption.GetStringValue("INFORMATION"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    objEmailConfig.StartPosition = FormStartPosition.CenterParent;
                    objEmailConfig.ShowDialog();
                }

            }
        #endregion
            #region Shift Allocation
            private void toolStripMenuItem2_Click(object sender, EventArgs e)
            {
                frmShiftAllocation objfrmShiftAllocation = new frmShiftAllocation(FrmName.ShiftAllocation, _nextFormPrincipal);// _enumProductNormalPublicMulti, _mode, _nextFormPrincipal);
                objfrmShiftAllocation.StartPosition = FormStartPosition.CenterParent;
                objfrmShiftAllocation.ShowDialog();
            }
        #endregion
            #region Serial port
            private void toolStripMenuItem5_Click(object sender, EventArgs e)
            {
                frmSerialPortSetting objfrmSerialPortSetting = new frmSerialPortSetting();
                objfrmSerialPortSetting.StartPosition = FormStartPosition.CenterParent;
                objfrmSerialPortSetting.ShowDialog();
            }
        #endregion
            #region Weighing bridge setup
            private void weighingbridgeSetupToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmWBSetup objfrmWBSetup = new frmWBSetup(FrmName.WeighBridgeSetup, _nextFormPrincipal);
                objfrmWBSetup.StartPosition = FormStartPosition.CenterParent;
                objfrmWBSetup.ShowDialog();
            }
        #endregion
            #region User Management
            private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmAddUser objfrmTransportFile = new frmAddUser(FrmName.AddEditUser, _nextFormPrincipal);
                if (objfrmTransportFile.UserCanOpenForm == false)
                {
                    MessageBox.Show(_dbGetResourceCaption.GetStringValue("DENIED"),
                        _dbGetResourceCaption.GetStringValue("INFORMATION"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    objfrmTransportFile.Text = @"Add\Edit user";
                    objfrmTransportFile.StartPosition = FormStartPosition.CenterParent;
                    objfrmTransportFile.ShowDialog();
                }
            }
            #endregion
            #region Change Caption Generic Form
            private void productFileFieldsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmGenericChangeField objfrmGenericChangeField = new frmGenericChangeField(FrmName.ProductField, _nextFormPrincipal);
                objfrmGenericChangeField.StartPosition = FormStartPosition.CenterParent;
                objfrmGenericChangeField.ShowDialog();
            }
            private void supplierFileFieldsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmGenericChangeField objfrmGenericChangeField = new frmGenericChangeField(FrmName.SupplierField, _nextFormPrincipal);
                objfrmGenericChangeField.StartPosition = FormStartPosition.CenterParent;
                objfrmGenericChangeField.ShowDialog();
            }
            private void transporterFileFieldsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmGenericChangeField objfrmGenericChangeField = new frmGenericChangeField(FrmName.TranspoterField, _nextFormPrincipal);
                objfrmGenericChangeField.StartPosition = FormStartPosition.CenterParent;
                objfrmGenericChangeField.ShowDialog();
            }
            private void weighingFormFieldsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmGenericChangeField objfrmGenericChangeField = new frmGenericChangeField(FrmName.WeighingField, _nextFormPrincipal);
                objfrmGenericChangeField.StartPosition = FormStartPosition.CenterParent;
                objfrmGenericChangeField.ShowDialog();
            }
        #endregion
            #region General Setting
            private void genealSettingsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmGeneralSetting objfrmGeneralSetting = new frmGeneralSetting(FrmName.GenralSetting, _nextFormPrincipal);
                objfrmGeneralSetting.StartPosition = FormStartPosition.CenterParent;
                objfrmGeneralSetting.ShowDialog();
            }
            #endregion
        #endregion
        #region Report
        private void normalWeighingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void publicWeighingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void multiWeighingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region BackUp
        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseBackup objDatabaseBackup = new frmDatabaseBackup(_nextFormPrincipal);
            objDatabaseBackup.StartPosition = FormStartPosition.CenterParent;
            objDatabaseBackup.ShowDialog();
        }
        #endregion
        #region Watch
        private void tmrDateAndTime_Tick(object sender, EventArgs e)
        {

            lblDateAndTime.Text = " | " + DateTime.Now.ToString("F"); //F: Sunday, June 15, 2008 9:15:07 PM
        }
        #endregion
        #region Unimplemented
        private void pendingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmTransactionForm objfrmSupplierFile = new frmTransactionForm(FrmName.Supplier, _nextFormPrincipal);
            //objfrmSupplierFile.Text = "Pending File";
            //objfrmSupplierFile.StartPosition = FormStartPosition.CenterParent;
            //objfrmSupplierFile.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {



        }
        private void frmMain_UserIsAllowed(object sender, EventArgs e)
        {

        }
        private void grpDashBoard_Enter(object sender, EventArgs e)
        {

        }
        private void GetModifiedFormsCaption()
        {
            // var frmNormalPendingFormCaption = 
            //   dbObj.V_Captions.Where(x => x.IsCaptionModified).ToList();

            //FormNormalPendingCaptions.Truck
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion
    }
}
#endregion