// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsTVS.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsTVS
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace RightCRM.iOS.Views.BusinessTabs
{
    public class LeadsTVS : MvxTableViewSource
    {
        public LeadsTVS(UITableView leadsTableView) : base(leadsTableView)
        {
            
        }

    protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
    {
            return (LeadsEntCell)tableView.DequeueReusableCell(LeadsEntCell.Key);
    }

}
}
