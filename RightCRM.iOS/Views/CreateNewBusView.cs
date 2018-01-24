using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.Binding.BindingContext;
using RightCRM.iOS.Helpers;
using Cirrious.FluentLayouts.Touch;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public partial class CreateNewBusView : BaseViewController<CreateNewBusViewModel>
    {



        public CreateNewBusView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.InitKeyboardHandling();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

         //   contentView.AtLeftOf(View);
         //   contentView.WithSameWidth(View);
         //   contentView.Bottom().EqualTo().BottomOf(this.btnCreateBusiness).Plus(1000);
         //  this.scrollView.ContentSize = new CoreGraphics.CGSize(View.Frame.Width, this.btnCreateBusiness.ConvertRectToView(this.btnCreateBusiness.Bounds, View).Bottom + 100);

            //Source:
            //https://www.spaceotechnologies.com/ease-ios-keyboard-handling-xamarin-app-development/
            txtAccountName.InputAccessoryView = new NextPreviousToolBar(txtAccountName, null, txtAccountType);
            txtAccountType.InputAccessoryView = new NextPreviousToolBar(txtAccountType, txtAccountName, txtBusinessNTN);
            txtBusinessNTN.InputAccessoryView = new NextPreviousToolBar(txtBusinessNTN, txtAccountType, txtBusinessWebsite);
            txtBusinessWebsite.InputAccessoryView = new NextPreviousToolBar(txtBusinessWebsite, txtBusinessNTN, txtIndustry);
            txtIndustry.InputAccessoryView = new NextPreviousToolBar(txtIndustry, txtBusinessWebsite, txtCompanySize);
            txtCompanySize.InputAccessoryView = new NextPreviousToolBar(txtCompanySize, txtIndustry, txtAnnualRevenue);
            txtAnnualRevenue.InputAccessoryView = new NextPreviousToolBar(txtAnnualRevenue, txtCompanySize, txtCampaignName);
            txtCampaignName.InputAccessoryView = new NextPreviousToolBar(txtCampaignName, txtAnnualRevenue, txtCampaignSrc);
            txtCampaignSrc.InputAccessoryView = new NextPreviousToolBar(txtCampaignSrc, txtCampaignName, txtCampaignMedia);
            txtCampaignMedia.InputAccessoryView = new NextPreviousToolBar(txtCampaignMedia, txtCampaignSrc, null); 


            var lastOffset = this.scrollView.ContentOffset;

            var Set = this.CreateBindingSet<CreateNewBusView, CreateNewBusViewModel>();

            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }

        public override bool HandlesKeyboardNotifications()
        {
            return true;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            this.UnregisterForKeyboardNotifications();
        }

    }
}