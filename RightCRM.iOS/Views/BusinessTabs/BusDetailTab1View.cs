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
    [MvxTabPresentation(TabIconName = "ic_paper", TabName = "Business Details")]
    public partial class BusDetailTab1View : MvxViewController<BusDetailTab1ViewModel>
    {
        public BusDetailTab1View (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var Set = this.CreateBindingSet<BusDetailTab1View, BusDetailTab1ViewModel>();

            //Set.Bind(backbutton).To(vm => vm.CloseBusinessDetailCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}