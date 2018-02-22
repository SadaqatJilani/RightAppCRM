// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SearchItemCell.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SearchItemCell
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace RightCRM.iOS.Views.Search
{
    public partial class SearchItemCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString(nameof(SearchItemCell));
        private const string BindingText = "SearchItem FilterName; FilterItemSelected IsSelected";

        public SearchItemCell(IntPtr handle) : base(BindingText, handle)
        {
            Debug.WriteLine("SearchItemCell ctor");

            Accessory = UITableViewCellAccessory.Checkmark;
        }


        public static float GetCellHeight()
        {
            return 120f;
        }

        public string SearchItem { get { return lblSrchItem.Text; } set { lblSrchItem.Text = value; } }

        public bool FilterItemSelected
        {
            get
            {
                return Accessory == UITableViewCellAccessory.Checkmark;
            }
            set
            {
                Accessory = value ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
            }
        }
    }
}
