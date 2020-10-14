// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace _03Navigation
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cancelBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel detailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton okButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cancelBtn != null) {
                cancelBtn.Dispose ();
                cancelBtn = null;
            }

            if (detailLabel != null) {
                detailLabel.Dispose ();
                detailLabel = null;
            }

            if (okButton != null) {
                okButton.Dispose ();
                okButton = null;
            }
        }
    }
}