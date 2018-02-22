// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SearchTVS.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SearchTVS
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.Views;
using RightCRM.Core.Models;
using UIKit;

namespace RightCRM.iOS.Views.Search
{
    public class SearchTVS : MvxExpandableTableViewSource
    {
        public SearchTVS(UITableView tableView) : base(tableView)
        {
            //string nibName = "SearchItemCell";
            //_cellIdentifier = new NSString(nibName);
            //tableView.RegisterNibForCellReuse(UINib.FromName(nibName, NSBundle.MainBundle), CellIdentifier);

            //string nibName2 = "SearchHeaderCell";
            //_headerCellIdentifier = new NSString(nibName2);
            //tableView.RegisterNibForCellReuse(UINib.FromName(nibName2, NSBundle.MainBundle), HeaderCellIdentifier);

        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return (SearchItemCell)tableView.DequeueReusableCell(SearchItemCell.Key, indexPath);

           // return tableView.DequeueReusableCell(CellIdentifier);
        }


        protected override UITableViewCell GetOrCreateHeaderCellFor(UITableView tableView, nint section)
        {
            return (SearchHeaderCell)tableView.DequeueReusableCell(SearchHeaderCell.Key);

           // return tableView.DequeueReusableCell(HeaderCellIdentifier);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
           // tableView.CellAt(indexPath).Accessory = UITableViewCellAccessory.Checkmark;

            var item = GetItemAt(indexPath);

           if (this.SelectionChangedCommand != null)
                this.SelectionChangedCommand.Execute(item);
        }


        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
           // tableView.CellAt(indexPath).Accessory = UITableViewCellAccessory.None;

            var item = GetItemAt(indexPath);

            if (this.SelectionChangedCommand != null)
                this.SelectionChangedCommand.Execute(item);
        }

        //public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        //{
        //    return 30f;
        //}

        //private readonly NSString _cellIdentifier;
        //protected virtual NSString CellIdentifier => _cellIdentifier;

        //private readonly NSString _headerCellIdentifier;
        //protected virtual NSString HeaderCellIdentifier => _headerCellIdentifier;

    }
}
