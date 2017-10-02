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
using System.Security.Principal;
using static HitechTMS.HitechEnums;
using DAL.Entity_Model;

namespace HitechTMS.MasterForms
{
    public partial class frmGenericChangeField : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj;
        private GetResourceCaption dbGetResourceCaption;
        int FromNameId;
        int count;



        public frmGenericChangeField(FrmName _FrmName, IPrincipal userPrincipal ) 
            : base(new string[] { HitechEnums.AppRole.Admin.ToString(), HitechEnums.AppRole.SuperAdmin.ToString() }, userPrincipal)
        {
            dbGetResourceCaption = new GetResourceCaption();
            FromNameId = (int)_FrmName;
            
            Captions objcaptions = new Captions();
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MinimizeBox = this.MaximizeBox = false;
            this.Text = Enum.ToObject(typeof(FrmName), _FrmName).ToString(); //Enum.GetName(typeof(FrmName), _FrmName);
        }
        
        private void EnableFormField (int count, bool state)
        {
            switch (count)
            {
                case 7:
                    lblGen7.Visible = state;
                    txtGen7.Visible=state ;
                    goto case 6;
                case 6:
                    lblGen6.Visible=state;
                    txtGen6.Visible=state;
                    goto case 5;
                case 5:
                    lblGen5.Visible=state;
                    txtGen5.Visible=state;
                    goto case 4;

                case 4:
                    lblGen4.Visible=state;
                    txtGen4.Visible = state;
                    goto case 3;

                case 3:
                    lblGen1.Visible = state;
                    lblGen2.Visible = state;
                    lblGen3.Visible = state;
                    txtGen1.Visible = state;
                    txtGen2.Visible = state;
                    txtGen3.Visible = state;
                    break;
            }

        }
       
        private void loadDefault()
        {
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();

            var result = dbObj.Captions.Where(x => x.FormType == FromNameId).OrderBy(x=> x.Id).ToList();

            count = result.Count;
            EnableFormField(count,true);
            switch (count)
            {
                case 7:
                    lblGen7.Text = result[6].DefaultCaption;
                    txtGen7.Text = result[6].ModifiedCaptioin;
                    goto case 6;
                case 6:
                    lblGen6.Text = result[5].DefaultCaption;
                    txtGen6.Text = result[5].ModifiedCaptioin;
                    goto case 5;
                case 5:
                    lblGen5.Text = result[4].DefaultCaption;
                    txtGen5.Text = result[4].ModifiedCaptioin;
                    goto case 4;
                case 4:
                    lblGen4.Text = result[3].DefaultCaption;
                    txtGen4.Text = result[3].ModifiedCaptioin;
                    goto case 3;
                case 3:

                    lblGen1.Text = result[0].DefaultCaption;
                    lblGen2.Text = result[1].DefaultCaption;
                    lblGen3.Text = result[2].DefaultCaption;

                    txtGen1.Text = result[0].ModifiedCaptioin;
                    txtGen2.Text = result[1].ModifiedCaptioin;
                    txtGen3.Text = result[2].ModifiedCaptioin;
                    break;
                default:
                    break;
            }
            
        }

        private void frmGenericChangeField_Load(object sender, EventArgs e)
        {
            loadDefault();
        }

        private void btnChange_Click(object sender, EventArgs e )
        {
            bool isModified =
                       ((System.Windows.Forms.Control)sender).Name == "btnChange" ? true : false;

            List<ModifyCaptions> ModifiedCaptionsList = new List<ModifyCaptions>();
            ModifyCaptions modifiedcaptions;

            switch (count)
            {
                case 7:
                    modifiedcaptions = new ModifyCaptions();
                    modifiedcaptions.ModifiedText = txtGen7.Text;
                    if (!LengthCheck(txtGen7, modifiedcaptions.ModifiedText, isModified))
                    {
                        return;
                    }
                    modifiedcaptions.ID = 7;
                    modifiedcaptions.isModified = isModified;
                    modifiedcaptions.frmID = FromNameId;
                    ModifiedCaptionsList.Add(modifiedcaptions);
                    goto case 6;
                case 6:
                    modifiedcaptions = new ModifyCaptions();
                    modifiedcaptions.ModifiedText = txtGen6.Text;
                    if (!LengthCheck(txtGen6, modifiedcaptions.ModifiedText, isModified))
                    {
                        return;
                    }
                    modifiedcaptions.ID = 6;
                    modifiedcaptions.isModified = isModified;
                    modifiedcaptions.frmID = FromNameId;
                    ModifiedCaptionsList.Add(modifiedcaptions);
                    goto case 5;
                case 5:
                    modifiedcaptions = new ModifyCaptions();
                    modifiedcaptions.ModifiedText = txtGen5.Text;
                    if (!LengthCheck(txtGen5, modifiedcaptions.ModifiedText, isModified))
                    {
                        return;
                    }
                    modifiedcaptions.ID = 5;
                    modifiedcaptions.frmID = FromNameId;
                    modifiedcaptions.isModified = isModified;
                    ModifiedCaptionsList.Add(modifiedcaptions);
                    goto case 4;
                case 4:
                    modifiedcaptions = new ModifyCaptions();
                    modifiedcaptions.ModifiedText = txtGen4.Text;
                    if (!LengthCheck(txtGen4, modifiedcaptions.ModifiedText, isModified))
                    {
                        return;
                    }
                    modifiedcaptions.ID = 4;
                    modifiedcaptions.isModified = isModified;
                    modifiedcaptions.frmID = FromNameId;
                    ModifiedCaptionsList.Add(modifiedcaptions);
                    goto case 3;
                case 3:
                    modifiedcaptions = new ModifyCaptions();
                    modifiedcaptions.ModifiedText = txtGen1.Text;
                    if (!LengthCheck(txtGen1, modifiedcaptions.ModifiedText, isModified))
                    {
                        return;
                    }
                    modifiedcaptions.ID = 1;
                    modifiedcaptions.isModified = isModified;
                    modifiedcaptions.frmID = FromNameId;
                    ModifiedCaptionsList.Add(modifiedcaptions);
         
                    modifiedcaptions = new ModifyCaptions();
                    modifiedcaptions.ModifiedText = txtGen2.Text;
                    if (!LengthCheck(txtGen2, modifiedcaptions.ModifiedText, isModified))
                    {
                        return;
                    }
                    modifiedcaptions.ID = 2;
                    modifiedcaptions.isModified = isModified;
                    modifiedcaptions.frmID = FromNameId;
                    ModifiedCaptionsList.Add(modifiedcaptions);

                    modifiedcaptions = new ModifyCaptions();
                    modifiedcaptions.ModifiedText = txtGen3.Text;
                    if(!LengthCheck(txtGen3, modifiedcaptions.ModifiedText , isModified))
                    {
                        return;
                    }
                    modifiedcaptions.ID = 3;
                    modifiedcaptions.isModified = isModified;
                    modifiedcaptions.frmID = FromNameId;
                    ModifiedCaptionsList.Add(modifiedcaptions);

                    break;
            }
            ChangeFunction obj = new ChangeFunction();
            obj.CommonChangeFunction(ModifiedCaptionsList);
            
            if (!isModified)
            {
                loadDefault();
            }
            if (isModified==true)
            {
                MessageBox.Show(dbGetResourceCaption.GetStringValue("DATA_SAVE"));
            }
                       

        }

        private bool LengthCheck (TextBox textbox ,string modifiedtext , bool isModified)
        {
            if (modifiedtext.Length == 0 && isModified==true)
            {
                errorChangeField.SetError(textbox, dbGetResourceCaption.GetStringValue("CANT_BE_BLANK"));
                textbox.Focus();
                return false ;

            
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
