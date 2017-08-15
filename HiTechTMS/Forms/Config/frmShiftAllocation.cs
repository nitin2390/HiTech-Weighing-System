using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HitechTMS.Classes;
using HitechTMSSecurity;
using static HitechTMS.HitechEnums;
using System.Security.Principal;
using DAL.Entity_Model;

namespace HitechTMS.MasterForms

{
    public partial class frmShiftAllocation : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities _dbObj { get; }
        private GetResourceCaption _dbGetResourceCaption;
        
        public frmShiftAllocation(FrmName _FrmName, IPrincipal userPrincipal) 
            : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.SuperAdmin.ToString(), HitechEnums.AppRole.Supervisor.ToString() }, userPrincipal)
        {
            _dbGetResourceCaption = new GetResourceCaption();
            _dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            InitializeComponent();
            this.MinimizeBox = this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = this.Size;
            LoadShifts();
        }

        

        private void LoadShifts()
        {
            try
            {
                LoadShiftsData();
                LoadFormPreFilledData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Show/Hide shift rows
        /// </summary>
        /// <param name="number">How much rows will be visible depends upon parameter passed</param>
        private void RowVisible(int number = 1)
        {
            lblB.Visible = true;
            dtpStartB.Visible = true;
            dtpEndB.Visible = true;
            lblC.Visible = true;
            dtpStartC.Visible = true;
            dtpEndC.Visible = true;

            switch (number)
            {
                case 1:
                    lblB.Visible = false;
                    dtpStartB.Visible = false;
                    dtpEndB.Visible = false;
                    goto case 2;
                case 2:
                    lblC.Visible = false;
                    dtpStartC.Visible = false;
                    dtpEndC.Visible = false;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Load the Form Values
        /// </summary>
        private void LoadFormPreFilledData()
        {
            try
            {
                List<V_T_mstShiftAllocationInfo> getResults = _dbObj.V_T_mstShiftAllocationInfo.ToList();
                int RowCount = getResults.Count();
                if (RowCount > 0)
                {
                    cmbShift.SelectedIndex = cmbShift.FindString(Enum.GetName(typeof(enumShiftAllocation), RowCount));

                    dtpStartA.Value = ConvertTimeStampIntoDate(getResults.Where(x => x.mstShiftsValue == (int)enumShiftAllocation.One).FirstOrDefault().StartTime);
                    dtpEndA.Value = ConvertTimeStampIntoDate(getResults.Where(x => x.mstShiftsValue == (int)enumShiftAllocation.One).FirstOrDefault().EndTime);
                    RowVisible(RowCount);
                    switch (RowCount)
                    {
                        case 3:
                            dtpStartC.Value = ConvertTimeStampIntoDate(getResults.Where(x => x.mstShiftsValue == (int)enumShiftAllocation.Three).FirstOrDefault().StartTime);
                            dtpEndC.Value = ConvertTimeStampIntoDate(getResults.Where(x => x.mstShiftsValue == (int)enumShiftAllocation.Three).FirstOrDefault().EndTime);
                            goto case 2;
                        case 2:
                            dtpStartB.Value = ConvertTimeStampIntoDate(getResults.Where(x => x.mstShiftsValue == (int)enumShiftAllocation.Two).FirstOrDefault().StartTime);
                            dtpEndB.Value = ConvertTimeStampIntoDate(getResults.Where(x => x.mstShiftsValue == (int)enumShiftAllocation.Two).FirstOrDefault().EndTime);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime ConvertTimeStampIntoDate(TimeSpan t)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(t.TotalMilliseconds);
            return dtDateTime;
        }

        /// <summary>
        /// Fill the Dropdown of Load Shift
        /// </summary>
        private void LoadShiftsData()
        {
            try
            {
                var getResults = _dbObj.V_T_MSTShifts.OrderBy(x=> x.ShiftValue).ToList();
                if(getResults !=null && getResults.Count > 0)
                {
                    cmbShift.DataSource = getResults;
                    cmbShift.DisplayMember = "ShiftName";
                    cmbShift.ValueMember = "ShiftValue";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _dbGetResourceCaption.GetStringValue("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// btn Save Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        { 
            var entity = _dbObj.mstShiftAllocationInfo;
            List<mstShiftAllocationInfo> mstShiftList = new List<mstShiftAllocationInfo>();
            mstShiftAllocationInfo mstShift = new mstShiftAllocationInfo();
            int RowCount = entity.Count();

            if (RowCount > 0)
            {
                _dbObj.Database.ExecuteSqlCommand("TRUNCATE TABLE [mstShiftAllocationInfo]");
                _dbObj.SaveChanges();
            }

            int number = (int)cmbShift.SelectedValue;
            mstShift.Id = Guid.NewGuid();
            mstShift.mstShiftsValue = (int)enumShiftAllocation.One;
            mstShift.StartTime = dtpStartA.Value.TimeOfDay;
            mstShift.EndTime = dtpEndA.Value.TimeOfDay;
            mstShiftList.Add(mstShift);

            switch (number)
            {
                case 3:
                    mstShift = new mstShiftAllocationInfo();
                    mstShift.Id = Guid.NewGuid();
                    mstShift.mstShiftsValue = (int)enumShiftAllocation.Three;
                    mstShift.StartTime = dtpStartC.Value.TimeOfDay;
                    mstShift.EndTime = dtpEndC.Value.TimeOfDay;
                    mstShiftList.Add(mstShift);
                    goto case 2;
                case 2:
                    mstShift = new mstShiftAllocationInfo();
                    mstShift.Id = Guid.NewGuid();
                    mstShift.mstShiftsValue = (int)enumShiftAllocation.Two;
                    mstShift.StartTime = dtpStartB.Value.TimeOfDay;
                    mstShift.EndTime = dtpEndB.Value.TimeOfDay;
                    mstShiftList.Add(mstShift);
                    break;
                default:
                    break;
            }

            entity.AddRange(mstShiftList);
            _dbObj.SaveChanges();

        }

        private void frmShiftAllocation_Load(object sender, EventArgs e)
        {

        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            RowVisible(Convert.ToInt32(((System.Windows.Forms.ListControl)sender).SelectedValue));
        }
        /// <summary>
        /// Form exit 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
