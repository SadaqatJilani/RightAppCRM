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
        public static readonly NSString Key = new NSString("SearchItemCell");
        private const string BindingText = "Name CompanyName";

        public SearchItemCell(IntPtr handle)  : base (BindingText, handle)
        {
            Debug.WriteLine("BusinessViewCell ctor");
        }

        //public string Name { get { return CompanyName.Text; } set { CompanyName.Text = value; } }
    }
}
