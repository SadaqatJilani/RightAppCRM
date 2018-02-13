using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels.Popups;
using MvvmCross.iOS.Support;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using CoreGraphics;
using System.Collections.Generic;
using System.Linq;

namespace RightCRM.iOS.Views.Search
{
    [MvxFromStoryboard(StoryboardName = "FilterPopup")]
    [MvxModalPresentation(ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext, ModalTransitionStyle = UIModalTransitionStyle.CoverVertical)]
    public partial class FilterPopup : BaseViewController<FilterPopupViewModel>
    {
        public FilterPopup (IntPtr handle) : base (handle)
        {
        }
        public FilterPopup()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0.5f);

            var Set = this.CreateBindingSet<FilterPopup, FilterPopupViewModel>();

            var source = new SearchTVS(this.tblViewSearch)
            {
                UseAnimations = true,
                AddAnimation = UITableViewRowAnimation.Left,
                RemoveAnimation = UITableViewRowAnimation.Right,
                IsAccordionExpandCollapseEnabled = true
            };

            Set.Bind(btnClose).To(vm => vm.CloseCommand);
            Set.Bind(source).For(x=>x.ItemsSource).To(vm=>vm.Demolist);
           // Set.Bind(source).For(x => x.SelectedItem).To(vm => vm.SelectedFilter);
            Set.Bind(source).For(x => x.SelectionChangedCommand).To(vm => vm.FilterChangedCommand);

            Set.Bind(btnSearch).To(vm => vm.SearchBusinessesCommand);

            Set.Apply();


            //this.AddBindings(new Dictionary<object, string>
            //{
            //    { source, "ItemsSource BusinessFilters.AddressArray" }
            //});

            this.tblViewSearch.Source = source;
            //this.tblViewSearch.RowHeight = UITableView.AutomaticDimension;
            //this.tblViewSearch.EstimatedRowHeight = 120f;
            this.tblViewSearch.ReloadData();

        }
    }
}