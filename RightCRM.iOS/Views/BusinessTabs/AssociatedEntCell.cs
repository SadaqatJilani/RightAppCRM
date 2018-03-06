using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;

namespace RightCRM.iOS.Views.BusinessTabs
{
    public partial class AssociatedEntCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString(nameof(AssociatedEntCell));

        private const string BindingText = "AssociatedEnt Username";

        public AssociatedEntCell(IntPtr handle) : base(BindingText, handle)
        {
        }

        public string AssociatedEnt { get { return lblAssociatedName.Text; } set { lblAssociatedName.Text = value; } }

    }
}