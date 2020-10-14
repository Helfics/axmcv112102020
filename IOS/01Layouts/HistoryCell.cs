using Foundation;
using System;
using UIKit;

namespace _01Layouts
{
    public partial class HistoryCell : UITableViewCell
    {
        public HistoryCell (IntPtr handle) : base (handle)
        {
        }

        public string Total
        {
            get { return totalLabel.Text; }
            set { totalLabel.Text = value; }
        }
    }
}