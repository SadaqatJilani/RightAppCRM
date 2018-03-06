// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AssociatedTVS.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AssociatedTVS
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace RightCRM.iOS.Views.BusinessTabs
{
    public class AssociatedTVS : MvxTableViewSource
    {
        public AssociatedTVS(UITableView notesTableView) : base(notesTableView)
        {

        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return (AssociatedEntCell)tableView.DequeueReusableCell(AssociatedEntCell.Key);
        }
    }
}
