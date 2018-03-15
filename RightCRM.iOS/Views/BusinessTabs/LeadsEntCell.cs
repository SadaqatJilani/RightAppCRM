using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;

namespace RightCRM.iOS
{
    public partial class LeadsEntCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString(nameof(LeadsEntCell));

        private const string BindingText = "LeadTag CTag; LeadBusUser AssignedToUsername; LeadWorkUser WorkUsername";

        public LeadsEntCell(IntPtr handle) : base(BindingText, handle)
        {
        }

        public string LeadTag { get { return lblTag.Text; } set { lblTag.Text = value; } }

        public string LeadBusUser { get { return lblBusinessUser.Text; } set { lblBusinessUser.Text = value; } }

        public string LeadWorkUser { get { return lblWorkUser.Text; } set { lblWorkUser.Text = value; } }
    }
}