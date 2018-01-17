using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels.Popups;
using MvvmCross.iOS.Support;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace RightCRM.iOS
{
    [MvxFromStoryboard(StoryboardName = "FilterPopup")]
    [MvxModalPresentation(ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext, ModalTransitionStyle = UIModalTransitionStyle.CoverVertical)]
    public partial class FilterPopup : MvxViewController<FilterPopupViewModel>
    {
        public FilterPopup (IntPtr handle) : base (handle)
        {
        }
        public FilterPopup()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0.5f);
        }
    }
}