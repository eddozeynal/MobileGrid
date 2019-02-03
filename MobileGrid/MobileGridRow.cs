using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileGrid
{
    public partial class MobileGridRow : UserControl
    {
        public MobileGridRow()
        {
            InitializeComponent();
        }
        object _data = null;

        public object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                if (_data == null) return;
                Dictionary<string, object> dataValues = new Dictionary<string, object>();
                if (_data is DataRow)
                {
                    dataValues = (_data as DataRow).ToDictionary();
                }
                else
                {
                    Type type = _data.GetType();
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);
                    DataTable table = new DataTable();
                    foreach (PropertyDescriptor prop in properties)
                        dataValues[prop.Name] = prop.GetValue(_data) ?? DBNull.Value;

                }
                IEnumerable<Control> taggedControls = this.GetAllControls().Where(x => x.Tag != null);
                foreach (string fieldName in dataValues.Keys.ToList())
                {
                    if (taggedControls.Select(x => x.Tag.ToString()).Contains(fieldName))
                    {
                        Control control = taggedControls.Where(x => x.Tag.ToString() == fieldName).First();
                        object dataValue = dataValues[fieldName];
                        string strValue = string.Empty;
                        strValue = dataValues[fieldName].ToString();
                        if (dataValue is DateTime)
                        {
                            strValue = Convert.ToDateTime(dataValue).ToString(GridControl.DateFormat);
                        }

                      //  string strValue = strValue ;dataValues[fieldName].ToString();
                        control.Text = strValue;

                    }
                }
                IEnumerable<Control> controls = this.GetAllControls();
                foreach (Control control in controls)
                {
                    control.MouseDown += RedirectMouseDown;
                    control.MouseMove += RedirectMouseMove;
                    control.MouseUp += RedirectMouseUp;
                    if (control is Button) control.Click += Button_Clicked;
                }
            }
        }

        public event EventHandler<GridRowButtonClickedEventArgs> ButtonClicked;

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            GridRowButtonClickedEventArgs args = new GridRowButtonClickedEventArgs();
            args.ButtonTag = (button.Tag ?? string.Empty).ToString();
            args.RowData = Data;
            args.RowIndex = Index;
            ButtonClicked?.Invoke(button, args);
        }

        public MobileGridControl GridControl { get; set; }
        public int Index { get; internal set; }

        private void MobileGridRow_Load(object sender, EventArgs e)
        {

        }
        private void RedirectMouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
            Point formPoint = PointToClient(screenPoint);
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
                formPoint.X, formPoint.Y, e.Delta);
            OnMouseDown(args);
        }
        private void RedirectMouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
            Point formPoint = PointToClient(screenPoint);
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
                formPoint.X, formPoint.Y, e.Delta);
            OnMouseMove(args);
        }
        private void RedirectMouseUp(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            Point screenPoint = control.PointToScreen(new Point(e.X, e.Y));
            Point formPoint = PointToClient(screenPoint);
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks,
                formPoint.X, formPoint.Y, e.Delta);
            OnMouseUp(args);
        }
    }
}
