using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace _02Lists
{
    public class CustomSource : UITableViewSource
    {
        public const string CellId = "CellId";

        private readonly UIViewController controller;
        private readonly List<string> data;

        public CustomSource(UIViewController controller,List<string> data)
        {
            this.controller = controller;
            this.data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellId);
            cell.TextLabel.Text = data[indexPath.Row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var alert = UIAlertController.Create("Selection", $"{data[indexPath.Row]}", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            controller.ShowViewController(alert, controller);
        }
    }


    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            listview.RegisterClassForCellReuse(typeof(UITableViewCell), CustomSource.CellId);
            listview.Source = new CustomSource(this, new List<string> { "1", "2", "3" });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}