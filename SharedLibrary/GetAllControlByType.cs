using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SharedLibrary
{
    public class GetAllControlByType
    {
        public IEnumerable<Control> GetAllControllType(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControllType(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type
                                      ).OrderBy( c => c.TabIndex);
        }
    }
}
