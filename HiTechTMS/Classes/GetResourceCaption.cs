using System.Globalization;
using System.Reflection;
using System.Resources;

namespace HitechTMS.Classes
{
    class GetResourceCaption
    {
        ResourceManager res_man;
        CultureInfo cul;
        public GetResourceCaption()
        {
            res_man = new ResourceManager("HitechTMS.Resource.Resource", Assembly.GetExecutingAssembly());
            cul = CultureInfo.CreateSpecificCulture("en");
        }

        public string GetStringValue(string strID)
        {
            return res_man.GetString(strID, cul);
        }
    }
}
