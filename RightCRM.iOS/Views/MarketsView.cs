using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.Binding.BindingContext;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public partial class MarketsView : MvxViewController<MarketsViewModel>
    {
        public MarketsView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var Set = this.CreateBindingSet<MarketsView, MarketsViewModel>();
            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}