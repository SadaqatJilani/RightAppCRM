using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.Binding.BindingContext;
using RightCRM.Common;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation(WrapInNavigationController = true, TabIconName = "ic_notes", TabName = Constants.TitleBusinessNotesPage)]
    public partial class BusDetailTab2View : MvxViewController<BusDetailTab2ViewModel>
    {
        public BusDetailTab2View (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem backbutton = new UIBarButtonItem(UIImage.FromBundle("ic_back"), UIBarButtonItemStyle.Done, null);

            this.NavigationItem.LeftBarButtonItem = backbutton;

            var Set = this.CreateBindingSet<BusDetailTab2View, BusDetailTab2ViewModel>();

            Set.Bind(backbutton).To(vm => vm.GoToRootMenuCommand);
            Set.Bind(btnAddNewNote).To(vm => vm.NewNoteCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}