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
	public partial class Form2 : SecureBaseForm
	{
		public Form2(IPrincipal userPrincipal) : base(new string[] {"UnknownRole"}, userPrincipal)
		{
			InitializeComponent();
		}

		private void Form2_UserIsDenied(object sender, EventArgs e)
		{
			this.BackColor = Color.Red;
		}

		private void Form2_UserIsAllowed(object sender, EventArgs e)
		{
			this.BackColor = Color.Green;
		}
	}
}
