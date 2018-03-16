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

namespace RightCRM.iOS.Views.BusinessTabs
{
    [Register ("LeadsEditView")]
    partial class LeadsEditView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDeleteLead { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSaveLead { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblBusinessUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblEditLead { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblWorkUser { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnDeleteLead != null) {
                btnDeleteLead.Dispose ();
                btnDeleteLead = null;
            }

            if (btnSaveLead != null) {
                btnSaveLead.Dispose ();
                btnSaveLead = null;
            }

            if (lblBusinessUser != null) {
                lblBusinessUser.Dispose ();
                lblBusinessUser = null;
            }

            if (lblEditLead != null) {
                lblEditLead.Dispose ();
                lblEditLead = null;
            }

            if (lblWorkUser != null) {
                lblWorkUser.Dispose ();
                lblWorkUser = null;
            }
        }
    }
}