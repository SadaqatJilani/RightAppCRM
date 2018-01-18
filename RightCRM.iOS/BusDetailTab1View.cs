using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using RightCRM.Core.ViewModels.Home;

namespace RightCRM.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation(WrapInNavigationController = true)]
    public partial class BusDetailTab1View : MvxViewController<BusDetailTab1ViewModel>
    {
        public BusDetailTab1View (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //var set = this.CreateBindingSet<BusDetailTab1View, Tab1ViewModel>();

            //set.Bind(btnModal).To(vm => vm.OpenModalCommand);
            //set.Bind(btnNavModal).To(vm => vm.OpenNavModalCommand);
            //set.Bind(btnChild).To(vm => vm.OpenChildCommand);

            //set.Apply();
        }
    }
}