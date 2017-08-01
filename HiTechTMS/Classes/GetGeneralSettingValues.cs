using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitechTMS.Classes
{
    public static class GetGeneralSettingValues
    {
        public static int Transaction_No { get; set; }
        public static string Mode { get; set; }
        public static decimal Minimun_Net_Weight { get; set; }
        public static string Stored_Tare { get; set; }
        public static string First_Weight_Ticket { get; set; }
        public static string Ticket_Format { get; set; }
        public static string Report_Format { get; set; }
        public static string Ticket_Report_Printing_Mode { get; set; }
        public static int Header_Blank_Line { get; set; }
        public static int Fotter_Blank_Line { get; set; }
    }
}
