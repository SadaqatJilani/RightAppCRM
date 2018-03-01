// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SavedSearchesTVS.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SavedSearchesTVS
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace RightCRM.iOS.Views.Search
{
    public class SavedSearchesTVS : MvxTableViewSource
    {
        
        public SavedSearchesTVS(UITableView tableView) : base(tableView)
        {

        }


        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return (SavedSearchCell)tableView.DequeueReusableCell(SavedSearchCell.Key, indexPath);
        }
    }
}
