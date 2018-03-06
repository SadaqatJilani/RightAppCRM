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
    [Register ("LeadsTab4View")]
    partial class LeadsTab4View
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLeadsHeading { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblViewLeads { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblLeadsHeading != null) {
                lblLeadsHeading.Dispose ();
                lblLeadsHeading = null;
            }

            if (tblViewLeads != null) {
                tblViewLeads.Dispose ();
                tblViewLeads = null;
            }
        }
    }
}