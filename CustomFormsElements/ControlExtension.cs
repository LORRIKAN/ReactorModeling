using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomFormsElements
{
    public static class ControlExtension
    {
        public static IEnumerable<T> GetChildControlsOfType<T>(this Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl is T t)
                    yield return t;

                if (childControl.Controls.Count > 0)
                    foreach (T cntrl in GetChildControlsOfType<T>(childControl))
                        yield return cntrl;
            }
        }
    }
}