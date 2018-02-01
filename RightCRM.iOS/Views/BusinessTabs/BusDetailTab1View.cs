using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using RightCRM.Core.ViewModels.Home;
using RightCRM.Common;
using Cirrious.FluentLayouts.Touch;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation(TabIconName = "ic_paper", TabName = Constants.TitleBusinessDetailsPage)]
    public partial class BusDetailTab1View : BaseViewController<BusDetailTab1ViewModel>
    {
        public BusDetailTab1View (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem backbutton = new UIBarButtonItem(UIImage.FromBundle("ic_back"), UIBarButtonItemStyle.Done, null);

            this.NavigationItem.LeftBarButtonItem = backbutton;

            //  lblAccountName.RemoveConstraint(lblAccou);
            // lblAccountName.RemoveConstraint(constraint: constr);


            View.AddConstraints(
                lblAccountName.Width().EqualTo(View.Center.X).Minus(30),
                nameBusWeb.Width().EqualTo(View.Center.X).Minus(30)
            );

            var Set = this.CreateBindingSet<BusDetailTab1View, BusDetailTab1ViewModel>();

            Set.Bind(backbutton).To(vm => vm.GoToRootMenuCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}