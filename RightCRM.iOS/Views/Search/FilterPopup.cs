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
    [MvxModalPresentation(ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext, ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    public partial class FilterPopup : BaseViewController<FilterPopupViewModel>
    {
        SearchTVS source;

        public FilterPopup (IntPtr handle) : base (handle)
        {
        }
        public FilterPopup()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           // View.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0.5f);

            DismissKeyboardOnBackgroundTap();

            var Set = this.CreateBindingSet<FilterPopup, FilterPopupViewModel>();

            source = new SearchTVS(this.tblViewSearch)
            {
                UseAnimations = true,
                AddAnimation = UITableViewRowAnimation.Left,
                RemoveAnimation = UITableViewRowAnimation.Right,
                IsAccordionExpandCollapseEnabled = true
            };

            txtKeywordSearch.SearchButtonClicked += TxtKeywordSearch_SearchButtonClicked;
            source.SelectedItemChanged += TxtKeywordSearch_SearchButtonClicked;

            Set.Bind(btnClose).To(vm => vm.CloseCommand);
            Set.Bind(source).For(x=>x.ItemsSource).To(vm=>vm.FilterList);
            Set.Bind(source).For(x => x.SelectionChangedCommand).To(vm => vm.FilterChangedCommand);

            Set.Bind(txtKeywordSearch).For(x => x.Text).To(vm => vm.SearchKeyword);

            Set.Bind(btnSearch).To(vm => vm.SearchBusinessesCommand);
            Set.Bind(btnReset).To(vm => vm.ResetFiltersCommand);

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


        public override void ViewDidDisappear(bool animated)
        {
            txtKeywordSearch.SearchButtonClicked -= TxtKeywordSearch_SearchButtonClicked;
            source.SelectedItemChanged -= TxtKeywordSearch_SearchButtonClicked;
                  
            base.ViewDidDisappear(animated);
        }

        void TxtKeywordSearch_SearchButtonClicked(object sender, EventArgs e)
        {
            if (txtKeywordSearch.CanResignFirstResponder)
            {
                txtKeywordSearch.ResignFirstResponder();
            }
        }
    }
}