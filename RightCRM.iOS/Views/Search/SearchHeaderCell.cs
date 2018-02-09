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
using UIKit;

namespace RightCRM.iOS.Views.Search
{
    public partial class SearchHeaderCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("SearchHeaderCell");
        private const string BindingText = "Name CompanyName";

        public SearchHeaderCell(IntPtr handle)  : base (BindingText, handle)
        {
            Debug.WriteLine("BusinessViewCell ctor");
        }

        //public string Name { get { return CompanyName.Text; } set { CompanyName.Text = value; } }

    }
}
