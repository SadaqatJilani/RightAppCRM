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

namespace RightCRM.iOS.Views
{
    [Register ("MenuView")]
    partial class MenuView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BigLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView MenuTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProfileImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SmallLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BigLabel != null) {
                BigLabel.Dispose ();
                BigLabel = null;
            }

            if (btnLogout != null) {
                btnLogout.Dispose ();
                btnLogout = null;
            }

            if (MenuTableView != null) {
                MenuTableView.Dispose ();
                MenuTableView = null;
            }

            if (ProfileImage != null) {
                ProfileImage.Dispose ();
                ProfileImage = null;
            }

            if (SmallLabel != null) {
                SmallLabel.Dispose ();
                SmallLabel = null;
            }
        }
    }
}