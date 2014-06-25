using System;
using System.Drawing;
using System.Windows.Forms;

namespace OefeningenLogo.UI.Extensions
{
    public static class FormExtensions
    {
        public static void RaiseEvent(this Form obj, Action @event)
        {
            if (@event != null)
                @event();
        }

        public static void SetValidState(this Control control, bool valid)
        {
            control.BackColor = valid ? Color.Green : Color.Red;
            control.ForeColor = Color.White;
        }
    }
}