using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Principal;

namespace TestSecureForms
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
			
			// Initialize a test Principal 
			IPrincipal userPrincipal = new GenericPrincipal(WindowsIdentity.GetCurrent(), 
				new string[] {"UserRole1", "UserRole2" });

			Form1 mainForm = new Form1(userPrincipal);

			// Set form to be main window in order to Exit the application.
			mainForm.IsMainWindow = true;
			mainForm.Show();

			if (mainForm.Created)
				Application.Run();


			//
			//	Let's disable the old fashioned way ;-)
			//
			// Application.Run(new Form1());
		}
	}
}
