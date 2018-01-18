using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.Binding.BindingContext;

namespace RightCRM.iOS
{
    [MvxFromStoryboard("Main")]
    [MvxModalPresentation(ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen, ModalTransitionStyle = UIModalTransitionStyle.CoverVertical)]
    public partial class BusinessDetailTabView : MvxTabBarViewController<BusinessDetailTabViewModel>
    {
        public BusinessDetailTabView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem backbutton = new UIBarButtonItem("back", UIBarButtonItemStyle.Done, null);
        //backbutton.Clicked += (o, e) => {
        //        NavigationController.PopViewController(true);
        //};

            this.NavigationItem.LeftBarButtonItem = backbutton;

            var Set = this.CreateBindingSet<BusinessDetailTabView, BusinessDetailTabViewModel>();

            Set.Bind(backbutton).To(vm => vm.CloseBusinessDetailCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}