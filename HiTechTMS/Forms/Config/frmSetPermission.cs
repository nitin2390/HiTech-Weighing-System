using DAL.Entity_Model;
using HitechTMS.Classes;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HitechTMSSecurity;
using static HitechTMS.HitechEnums;
using System.Security.Principal;

namespace HitechTMS.Forms.Config
{
    public partial class frmSetPermission : SecureBaseForm
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj { get; }
        //private GetResourceCaption _dbGetResourceCaption;
        //EncryptionAndDecryption objEncryptionAndDecryption;
        private FrmName _frmName { get; set; }
        public Boolean _saveClick { get; set; }
        public Guid _userRoleID { get; private set; }
        public frmSetPermission(IPrincipal userPrincipal) : base(new string[] { HitechEnums.AppRole.SuperAdmin.ToString() }, userPrincipal)
        {

        }
       
    }
}
