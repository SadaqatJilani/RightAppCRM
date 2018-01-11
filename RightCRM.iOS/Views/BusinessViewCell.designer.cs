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
    [Register ("BusinessViewCell")]
    partial class BusinessViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CompanyName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CompanySize { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RevenueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SizeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CompanyName != null) {
                CompanyName.Dispose ();
                CompanyName = null;
            }

            if (CompanySize != null) {
                CompanySize.Dispose ();
                CompanySize = null;
            }

            if (RevenueLabel != null) {
                RevenueLabel.Dispose ();
                RevenueLabel = null;
            }

            if (SizeLabel != null) {
                SizeLabel.Dispose ();
                SizeLabel = null;
            }
        }
    }
}