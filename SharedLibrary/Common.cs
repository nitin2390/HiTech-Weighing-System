using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharedLibrary
{
    public class Common
    {
        private Regex _validChar { get; set; }
        private Regex _onlyNumeric { get; set; }
        public Common()
        {
            _validChar = new Regex(@"[^a-zA-Z0-9\s]");
            _onlyNumeric = new Regex("[^0-9]");
        }

        public KeyPressEventArgs RestirctTextBoxAndUpperCase(KeyPressEventArgs e)
        {
            e = RestirctTextBox(e);
            e.KeyChar = Char.ToUpper(e.KeyChar);
            return e;
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
            return e;
        }

        public KeyPressEventArgs OnlyNumericValue(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            return e;
        }

    }
}
