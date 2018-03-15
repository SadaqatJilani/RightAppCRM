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

namespace RightCRM.iOS
{
    [Register ("LeadsEntCell")]
    partial class LeadsEntCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblBusinessUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTag { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblWorkUser { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblBusinessUser != null) {
                lblBusinessUser.Dispose ();
                lblBusinessUser = null;
            }

            if (lblTag != null) {
                lblTag.Dispose ();
                lblTag = null;
            }

            if (lblWorkUser != null) {
                lblWorkUser.Dispose ();
                lblWorkUser = null;
            }
        }
    }
}