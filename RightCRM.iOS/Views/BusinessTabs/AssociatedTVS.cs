// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AssociatedTVS.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AssociatedTVS
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.Core;
using RightCRM.Core.ViewModels.ItemViewModels;
using UIKit;

namespace RightCRM.iOS.Views.BusinessTabs
{
    public class AssociatedTVS : MvxTableViewSource
    {

        private List<AssociationItemViewModel> associationList = new List<AssociationItemViewModel>();

        public AssociatedTVS(UITableView associationTableView) : base(associationTableView)
        {
            
        }


        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (AssociatedEntCell)tableView.DequeueReusableCell(AssociatedEntCell.Key);

            if (cell != null)
            {
                cell.Index = indexPath.Row;
            }

            return cell;
        }

	}
}
