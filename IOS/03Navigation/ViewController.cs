using Foundation;
using System;
using UIKit;

namespace _03Navigation
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            navigateCodeButton.TouchUpInside += NavigateCodeButton_TouchUpInside;
        }

        private void NavigateCodeButton_TouchUpInside(object sender, EventArgs e)
        {
            var dvc = Storyboard.InstantiateViewController(nameof(DetailViewController)) as DetailViewController;

            dvc.Id = 1;
            dvc.OnSuccess += (id) => {

                var alert = UIAlertController.Create("", $"Result ok id {id}", UIAlertControllerStyle.Alert);

                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

                this.NavigationController.PresentModalViewController(alert, true);
            };

            this.NavigationController.PushViewController(dvc, true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            switch (segue.DestinationViewController)
            {
                case DetailViewController dvc:
                    dvc.Id = 1;
                    dvc.OnSuccess += (id) => {

                        var alert = UIAlertController.Create("", $"Result ok id {id}", UIAlertControllerStyle.Alert);

                        alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

                        this.NavigationController.PresentModalViewController(alert,true);
                    };
                    break;
                default: break;
            }
            

            base.PrepareForSegue(segue, sender);
        }
    }
}