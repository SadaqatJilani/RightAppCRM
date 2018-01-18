using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.Binding.BindingContext;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxRootPresentation]
    //[MvxModalPresentation(ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen, ModalTransitionStyle = UIModalTransitionStyle.CoverVertical)]
    public partial class BusinessDetailTabView : MvxTabBarViewController<BusinessDetailTabViewModel>
    {
        private bool isPresentedFirstTime = true;

        public BusinessDetailTabView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (ViewModel != null && isPresentedFirstTime)
            {
                isPresentedFirstTime = false;
                ViewModel.ShowInitialViewModelsCommand.ExecuteAsync(null);
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem backbutton = new UIBarButtonItem(UIImage.FromBundle("ic_back"), UIBarButtonItemStyle.Done, null);

            this.NavigationItem.LeftBarButtonItem = backbutton;

            var Set = this.CreateBindingSet<BusinessDetailTabView, BusinessDetailTabViewModel>();

            Set.Bind(backbutton).To(vm => vm.GoToRootMenuCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}