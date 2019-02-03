using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileGrid
{
    public class GridRowButtonClickedEventArgs : EventArgs
    {
        public object RowData { get; internal set; }
        public int RowIndex { get; internal set; }
        public string ButtonTag { get; internal set; }
    }
}
