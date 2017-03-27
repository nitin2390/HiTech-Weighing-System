using DAL.Entity_Model;
using HitechTMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HitechTMS.File
{
    public partial class frmSupplierFile : Form
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        private GetResourceCaption dbGetResourceCaption;
        public frmSupplierFile()
        {
            InitializeComponent();
            dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            this.MinimizeBox = this.MaximizeBox = false;
            this.MaximumSize = this.MinimumSize = this.Size;
            BindGrid();
        }

        private void BindGrid()
        {
            try
            {
                var SupplierQuery = from Supplier in dbObj.mstSupplier
                                orderby Supplier.SupplierCode ascending
                                select Supplier;
                List<mstSupplier> SupplierList = SupplierQuery.ToList();
                gridSupplier.DataSource = SupplierList;

                if(gridSupplier.ColumnCount > 0)
                {
                    gridSupplier.Columns["Id"].Visible = false;

                }

                lblRecordsCount.Text = SupplierList.Count().ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierCode.Text != "")
                {

                    var existSupplierCode = (from Supplier in dbObj.mstSupplier
                                         where Supplier.SupplierCode == txtSupplierCode.Text
                                         select Supplier.SupplierCode).ToList();

                    if (existSupplierCode.Count == 0)
                    {
                        mstSupplier objSupplier = new mstSupplier();
                        objSupplier.SupplierCode = txtSupplierCode.Text;
                        objSupplier.SupplierName = txtSupplierName.Text;

                        objSupplier.Address1 = txtAddressLine1.Text;
                        objSupplier.Address2 = txtAddressLine2.Text;
                        objSupplier.Address3 = txtAddressLine3.Text;
                        objSupplier.Phone = txtPhone.Text;
                        objSupplier.Fax = txtFax.Text;
                        objSupplier.Email = txtEmail.Text;
                        dbObj.mstSupplier.Add(objSupplier);
                        if (dbObj.SaveChanges() == 1)
                        {
                            ResetCntrl();
                            BindGrid();
                            MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_SAVE"));
                        }
                    }
                    else
                    {
                        MessageBox.Show(dbGetResourceCaption.GetStringValue("DUPLICATE_DATA"), dbGetResourceCaption.GetStringValue("ALERT"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message.ToString());
            }
        }

        private void ResetCntrl()
        {
           
        }
    }
}
