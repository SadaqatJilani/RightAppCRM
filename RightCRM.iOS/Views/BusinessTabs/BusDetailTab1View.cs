// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailTab1View.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailTab1View
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.iOS.Views
{
    using System;
    using Cirrious.FluentLayouts.Touch;
    using MvvmCross.Binding.BindingContext;
    using MvvmCross.iOS.Views;
    using MvvmCross.iOS.Views.Presenters.Attributes;
    using RightCRM.Common;
    using RightCRM.Core.ViewModels.Home;
    using UIKit;

    /// <summary>
    /// Bus detail tab1 view.
    /// </summary>
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation(TabIconName = "ic_paper", TabName = Constants.TitleBusinessDetailsPage)]
    public partial class BusDetailTab1View : BaseViewController<BusDetailTab1ViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.iOS.Views.BusDetailTab1View"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public BusDetailTab1View (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem backbutton = new UIBarButtonItem(UIImage.FromBundle("ic_back"), UIBarButtonItemStyle.Done, null);

            this.NavigationItem.LeftBarButtonItem = backbutton;

            View.AddConstraints(
                lblAccountName.Width().EqualTo(View.Center.X).Minus(30),
                nameBusWeb.Width().EqualTo(View.Center.X).Minus(30)
            );

            var Set = this.CreateBindingSet<BusDetailTab1View, BusDetailTab1ViewModel>();

            Set.Bind(backbutton).To(vm => vm.GoToRootMenuCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            Set.Bind(lblAccountName).To(vm => vm.ListBusinessDetails.AccountName).TwoWay();
            Set.Bind(lblAccountType).To(vm => vm.ListBusinessDetails.AccountType).TwoWay();
            Set.Bind(lblBusinessNTN).To(vm => vm.ListBusinessDetails.BusinessNTN).TwoWay();
            Set.Bind(lblBusWebsite).To(vm => vm.ListBusinessDetails.BusinessWebsite).TwoWay();
            Set.Bind(lblIndustry).To(vm => vm.ListBusinessDetails.Industry).TwoWay();
            Set.Bind(lblCompanySize).To(vm => vm.ListBusinessDetails.CompanySize).TwoWay();
            Set.Bind(lblAnnualRevenue).To(vm => vm.ListBusinessDetails.AnnualRevenue).TwoWay();
            Set.Bind(lblCampaignName).To(vm => vm.ListBusinessDetails.CampaignName).TwoWay();
            Set.Bind(lblCampaignSrc).To(vm => vm.ListBusinessDetails.CampaignSrc).TwoWay();
            Set.Bind(lblCampaignMedia).To(vm => vm.ListBusinessDetails.CampaignMedia).TwoWay();

            Set.Apply();
        }
    }
}