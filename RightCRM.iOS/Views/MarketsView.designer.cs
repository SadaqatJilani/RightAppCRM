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
    [Register ("MarketsView")]
    partial class MarketsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMarket { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblMarket != null) {
                lblMarket.Dispose ();
                lblMarket = null;
            }
        }
    }
}