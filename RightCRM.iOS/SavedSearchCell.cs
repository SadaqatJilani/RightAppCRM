using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;

namespace RightCRM.iOS
{
    public partial class SavedSearchCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("SavedSearchCell");

        private const string BindingText = "SearchLabel SearchName";

        public SavedSearchCell(IntPtr handle) : base(BindingText, handle)
        {
        }

        public string SearchLabel { get { return lblSavedSearch.Text; } set { lblSavedSearch.Text = value; } }
    }
}