using Foundation;
using System;
using UIKit;

namespace _01Layouts
{
    public partial class HistoryViewController : UIViewController
    {
        public HistoryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            historytableview.RegisterClassForCellReuse(typeof(UITableViewCell),StringsSource.Key);
            historytableview.Source = new StringsSource(ViewController.dataResults);
        }
    }
}