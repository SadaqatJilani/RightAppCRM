using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.Binding.BindingContext;
using RightCRM.iOS.Helpers;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public partial class CreateNewBusView : MvxViewController<CreateNewBusViewModel>
    {
        public CreateNewBusView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

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


            var Set = this.CreateBindingSet<CreateNewBusView, CreateNewBusViewModel>();

            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}