using System;
using System.Windows.Forms;
using HitechTMSActivation;
using HitechTMS.keys;

namespace HitechTMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Secure scr = new Secure();
            ProductKeys objProductKeys = new ProductKeys();
            string strProtection = @"Software\Microsoft\Windows\CurrentVersion\HomeGroup\{996F503E-A3E2-4DB4-8BC6-6FE72EDB5465}";
            //bool logic = scr.Algorithm("3F469A42-4F69-4F33-BEFA-80ECA1C5737B", strProtection);
            bool logic = scr.Algorithm( objProductKeys.ListProductkeys(), strProtection);
            if (logic)
                Application.Run(new frmLogin());
        }
    }
}
