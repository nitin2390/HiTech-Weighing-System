using System;
using System.Windows.Forms;

namespace CodeProjectSerialComms
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
            Application.Run(new frmLogin());
            //Application.Run(new HiTechWeighingSystem());
           // Application.Run(new frmProduct());
        }
    }
}
