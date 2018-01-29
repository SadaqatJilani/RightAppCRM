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
    [Register ("NotesCell")]
    partial class NotesCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCall { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMessage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNoteComment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNoteUserName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCall != null) {
                btnCall.Dispose ();
                btnCall = null;
            }

            if (btnEmail != null) {
                btnEmail.Dispose ();
                btnEmail = null;
            }

            if (btnMessage != null) {
                btnMessage.Dispose ();
                btnMessage = null;
            }

            if (lblNoteComment != null) {
                lblNoteComment.Dispose ();
                lblNoteComment = null;
            }

            if (lblNoteUserName != null) {
                lblNoteUserName.Dispose ();
                lblNoteUserName = null;
            }
        }
    }
}