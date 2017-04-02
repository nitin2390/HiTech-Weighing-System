using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharedLibrary
{
    public class Common
    {
        private Regex _validChar { get; set; }

        public Common()
        {
            _validChar = new Regex(@"[^a-zA-Z0-9\s]");
        }

        public KeyPressEventArgs RestirctTextBox(KeyPressEventArgs e)
        {
            if (_validChar.IsMatch(e.KeyChar.ToString()))
            {
                if (!(char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
            return e;
        }
    }
}
