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
    [Register ("LoginView")]
    partial class LoginView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        RightCRM.iOS.BtnUniversal LoginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordFeild { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UserNameFeild { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LoginButton != null) {
                LoginButton.Dispose ();
                LoginButton = null;
            }

            if (PasswordFeild != null) {
                PasswordFeild.Dispose ();
                PasswordFeild = null;
            }

            if (UserNameFeild != null) {
                UserNameFeild.Dispose ();
                UserNameFeild = null;
            }
        }
    }
}