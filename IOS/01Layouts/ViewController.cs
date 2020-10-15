using Foundation;
using System;
using UIKit;
using System.Linq;
using System.Collections.Generic;

namespace _01Layouts
{

    // L'equivalent de l'adapteur Android
    public class StringsSource : UITableViewSource
    {
        public const string Key = "CellId";

        private readonly List<string> data;

        public StringsSource(List<string> data)
        {
            this.data = data;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(Key);
            cell.TextLabel.Text = data[indexPath.Row];

            //var cell = tableView.DequeueReusableCell("historycell") as HistoryCell;

            //cell.Total = data[indexPath.Row];

            //var cell = tableView.DequeueReusableCell("subtitlecell");

            //cell.TextLabel.Text = data[indexPath.Row];
            //cell.DetailTextLabel.Text = "Un sous texte";

            return cell;
        }
    }

    public partial class ViewController : UIViewController
    {
        public static List<string> dataResults = new List<string>();

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            current.Text = string.Empty;
            result.Text = string.Empty;

            btn1.TouchUpInside += Btn_TouchUpInside;
            btn2.TouchUpInside += Btn_TouchUpInside;
            btn3.TouchUpInside += Btn_TouchUpInside;
            btn4.TouchUpInside += Btn_TouchUpInside;
            btn5.TouchUpInside += Btn_TouchUpInside;
            btn6.TouchUpInside += Btn_TouchUpInside;
            btn7.TouchUpInside += Btn_TouchUpInside;
            btn8.TouchUpInside += Btn_TouchUpInside;
            btn9.TouchUpInside += Btn_TouchUpInside;
            btn0.TouchUpInside += Btn_TouchUpInside;
            btnPlus.TouchUpInside += Btn_TouchUpInside;

            btnEquals.TouchUpInside += BtnEquals_TouchUpInside;

         
        }

        private void Btn_TouchUpInside(object sender, EventArgs e)
        {
            current.Text += ((UIButton)sender).CurrentTitle;
        }

        private void BtnEquals_TouchUpInside(object sender, EventArgs e)
        {
            var operations = current
                                                 .Text
                                                 ?.Split('+')
                                                 .Where(x => !string.IsNullOrEmpty(x))
                                                 .ToList();

            if (!operations.Any())
            {
                var alert = UIAlertController.Create("Oups", "La saisie est vide", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                ShowViewController(alert, this);
            }
            else
            {
                var sum = operations
                                              .Select(int.Parse)
                                              .Sum()
                                              .ToString();

                result.Text = sum;

                dataResults.Insert(0, sum);

                current.Text = string.Empty;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}