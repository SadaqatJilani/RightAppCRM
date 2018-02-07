using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;

namespace RightCRM.iOS.Views
{
    public partial class NotesCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("NotesCell_id");

        private const string BindingText = "NoteOwner BusinessUserName; NoteComment NoteString";

        public NotesCell (IntPtr handle) : base(BindingText, handle)
        {
        }

        public string NoteOwner { get { return lblNoteUserName.Text; } set { lblNoteUserName.Text = value; } }

        public string NoteComment { get { return lblNoteComment.Text; } set { lblNoteComment.Text = value; } }
    }
}