using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace MobileGrid
{
    public partial class MobileGridControl : UserControl
    {
        public MobileGridControl()
        {
            InitializeComponent();
        }

        public Panel RowsContainer { get { return MainPanel; } }
        
        public List<MobileGridRow> Rows { get {
                List<MobileGridRow> controls = new List<MobileGridRow>();
                foreach (Control c in MainPanel.Controls) controls.Add(c as MobileGridRow);
                return controls;
            } }

        object _dataSource = null;

        public Type GridRowType { get; set; }
        public string DateFormat { get; set; }

        public object DataSource
        {
            get { return _dataSource; }
            set
            {
                if (GridRowType == null) return;
                RowsContainer.Controls.Clear();



                if (value == null) return;
                if (value is DataTable)
                {
                    foreach (DataRow datarow in (value as DataTable).Rows) AddRow(datarow);
                }
                if (value is ICollection )
                {
                    foreach (object datarow in (value as ICollection)) AddRow(datarow);
                }

                if (Rows.Count > 0) SelectedRow = Rows[0];
            }

        }

        void AddRow(object rowData)
        {
            MobileGridRow mobileGridRow = (MobileGridRow)Activator.CreateInstance(GridRowType);
            var v = Rows.LastOrDefault();
            if (v != null)
            {
                int top = v.Top;
                top += v.Height;
                mobileGridRow.Top = top - 1;
                mobileGridRow.Index = v.Index + 1;
            }
            mobileGridRow.GridControl = this;
            mobileGridRow.Data = rowData;
            mobileGridRow.BackColor = DefaultRowColor;
            assignMouseEvents(mobileGridRow);
            //foreach (Control c in mobileGridRow.Controls) assignMouseEvents(c);
            mobileGridRow.ButtonClicked += MobileGridRow_ButtonClicked;
            RowsContainer.Controls.Add(mobileGridRow);

        }
        public event EventHandler<GridRowButtonClickedEventArgs> GridRowButtonClicked;

        private void MobileGridRow_ButtonClicked(object sender, GridRowButtonClickedEventArgs e)
        {
            GridRowButtonClicked?.Invoke(sender, e);
        }

        private void assignMouseEvents(Control control)
        {
            control.MouseDown += General_MouseDown;
            control.MouseMove += General_MouseMove;
            control.MouseUp += General_MouseUp;
        }
        public Color ActiveRowColor { get; set; } = Color.LightBlue;
        public Color DefaultRowColor { get; set; } = SystemColors.Control;

        private Point _StartPoint;

        public void General_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            _StartPoint = e.Location;
            RowsContainer.VerticalScroll.Enabled = true;
            RowsContainer.VerticalScroll.Visible = true;
            SelectedRow = sender as MobileGridRow;
        }
        public void General_MouseUp(object sender, MouseEventArgs e)
        {
            RowsContainer.VerticalScroll.Enabled = false;
            RowsContainer.VerticalScroll.Visible = false;
        }
        public void General_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                Point changePoint = new Point(e.Location.X - _StartPoint.X,
                                              e.Location.Y - _StartPoint.Y);
                RowsContainer.AutoScrollPosition = new Point(-RowsContainer.AutoScrollPosition.X,
                                                     -RowsContainer.AutoScrollPosition.Y - changePoint.Y);
            }
        }

        public event EventHandler SelectedRowChanged ;

        private MobileGridRow _SelectedRow = null;

        public MobileGridRow SelectedRow
        {
            get
            {
                return _SelectedRow;
            }
            set
            {
                if (value == null) return;

                bool fireRowChangedEvent = value != _SelectedRow;
                _SelectedRow = value;
                Rows.ForEach(x => x.BackColor = DefaultRowColor);
                _SelectedRow.BackColor = ActiveRowColor;
                if (fireRowChangedEvent)
                {
                    SelectedRowChanged?.Invoke(_SelectedRow, null);
                }
            }
        }

        public object SelectedRowData
        {
            get
            {
                if (SelectedRow == null) return null;
                return SelectedRow.Data;
            }
        }




    }
}
