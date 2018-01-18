using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.Core.ViewModels.Home;

namespace RightCRM.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation]
    public partial class BusDetailTab2View : MvxViewController<BusDetailTab2ViewModel>
    {
        public BusDetailTab2View (IntPtr handle) : base (handle)
        {
        }
    }
}