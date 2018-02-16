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
    [Register ("BusAddTagView")]
    partial class BusAddTagView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAssignTag { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAssignTag { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAssignTag != null) {
                btnAssignTag.Dispose ();
                btnAssignTag = null;
            }

            if (lblAssignTag != null) {
                lblAssignTag.Dispose ();
                lblAssignTag = null;
            }
        }
    }
}