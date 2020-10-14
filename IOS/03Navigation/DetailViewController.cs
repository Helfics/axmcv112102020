using Foundation;
using System;
using UIKit;

namespace _03Navigation
{
    public partial class DetailViewController : UIViewController
    {
        public long Id { get; set; }

        public Action<long> OnSuccess { get; set; }

        public DetailViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            detailLabel.Text = $"Detail id {Id}";

            cancelBtn.TouchUpInside += CancelBtn_TouchUpInside;

            okButton.TouchUpInside += OkButton_TouchUpInside;
        }

        private void OkButton_TouchUpInside(object sender, EventArgs e)
        {

            NavigationController.PopViewController(true);
            OnSuccess?.Invoke(Id);
        }

        private void CancelBtn_TouchUpInside(object sender, EventArgs e)
        {
            NavigationController.PopViewController(true);
        }
    }
}