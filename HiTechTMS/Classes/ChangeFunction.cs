using DAL.Entity_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HitechTMS.HitechEnums;

namespace HitechTMS.Classes
{
    public class ChangeFunction
    {
        private HitechTruckMngtSystmDataBaseFileEntities dbObj;
        private GetResourceCaption dbGetResourceCaption;
        public void CommonChangeFunction(List<ModifyCaptions> commonlist)
        {
            dbGetResourceCaption = new GetResourceCaption();
            dbObj = new HitechTruckMngtSystmDataBaseFileEntities();
            foreach (var item in commonlist)
            {
                var result = dbObj.Captions.Where(x => x.Id == item.ID && x.FormType == item.frmID).First();
                result.ModifiedCaptioin = item.isModified ? item.ModifiedText : result.DefaultCaption ;
                result.IsCaptionModified = true;
                dbObj.SaveChanges();
                
            }
            
        }
    }
    }

    public class ModifyCaptions
    {
        public string ModifiedText { get; set; }
        
        public int ID { get; set; }

        public bool isModified { get; set; }
        public int frmID { get; set; }
}




