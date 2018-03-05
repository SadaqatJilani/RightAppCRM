// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SearchHeaderCell.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SearchHeaderCell
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.Views.Expandable;
using UIKit;

namespace RightCRM.iOS.Views.Search
{
    public partial class SearchHeaderCell : MvxTableViewCell, IExpandableHeaderCell
    {
        public static readonly NSString Key = new NSString(nameof(SearchHeaderCell));
        private const string BindingText = "SearchHeader Heading";

        public SearchHeaderCell(IntPtr handle)  : base (BindingText, handle)
        {
            Debug.WriteLine("SearchHeaderCell ctor");
        }

        public string SearchHeader { get { return lblSrchHeader.Text; } set { lblSrchHeader.Text = value; } }

        public void OnExpanded()
        {
            ContentView.BackgroundColor = UIColor.FromRGB(135, 206, 250);
        }

        public void OnCollapsed()
        {
            ContentView.BackgroundColor = UIColor.White;

            ContentView.Layer.BorderWidth = 1f;
            ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
        }
    }
}
