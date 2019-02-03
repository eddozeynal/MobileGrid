using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileGrid
{
    public static class Helpers
    {
        public static  IEnumerable<Control> GetAllControls(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public static IEnumerable<Control> GetAllControls(this Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl))
                                      .Concat(controls);
        }

        public static IEnumerable<Control> GetAllControls(this UserControl control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public static IEnumerable<Control> GetAllControls(this UserControl control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl))
                                      .Concat(controls);
        }
        public static void ScrollDown(this Panel p, int pos)
        {
            //pos passed in should be positive
            using (Control c = new Control() { Parent = p, Height = 1, Top = p.ClientSize.Height + pos })
            {
                p.ScrollControlIntoView(c);
            }
        }
        public static void ScrollUp(this Panel p, int pos)
        {
            //pos passed in should be negative
            using (Control c = new Control() { Parent = p, Height = 1, Top = pos })
            {
                p.ScrollControlIntoView(c);
            }
        }
        public static Dictionary<string, object> ToDictionary(this DataRow dataRow)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                keyValues[column.ColumnName] = dataRow[column];
            }
            return keyValues;
        }
    }
}
