using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OD.Forms.Security;
using System.Security.Principal;

namespace TestSecureForms
{
	public partial class Form1 : SecureBaseForm
	{
		private IPrincipal _nextFormPrincipal;

		public Form1(IPrincipal userPrincipal) : base(new string[] {"UserRole1","UserRole3"}, userPrincipal)
		{
			_nextFormPrincipal = userPrincipal;
			InitializeComponent();
		}

		private void Form1_UserIsAllowed(object sender, EventArgs e)
		{
			button1.Enabled = this.ValidatedUserRoles.Contains("UserRole1");
			button2.Enabled = this.ValidatedUserRoles.Contains("UserRole3");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form2 nextForm = new Form2(_nextFormPrincipal);
			nextForm.Show();
		}
	}
}
