// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RightCRM.iOS.Views.Search
{
    [Register ("SearchHeaderCell")]
    partial class SearchHeaderCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSrchHeader { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblSrchHeader != null) {
                lblSrchHeader.Dispose ();
                lblSrchHeader = null;
            }
        }
    }
}