using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.Binding.BindingContext;

namespace RightCRM.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation(WrapInNavigationController = true, TabIconName = "ic_notes", TabName = "Notes")]
    public partial class BusDetailTab2View : MvxViewController<BusDetailTab2ViewModel>
    {
        public BusDetailTab2View (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var Set = this.CreateBindingSet<BusDetailTab2View, BusDetailTab2ViewModel>();

            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}