using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.Common;
using RightCRM.Core.ViewModels.Home.BusinessTabs;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RightCRM.Core.Services;

namespace RightCRM.iOS.Views.BusinessTabs
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation(WrapInNavigationController = true, TabIconName = "ic_notes", TabName = Constants.TitleBusinessAssociationsPage)]
    public partial class AssociatedTab3View : BaseViewController<AssociatedTab3ViewModel>
    {
        private readonly MvxSubscriptionToken token;

        public AssociatedTab3View (IntPtr handle) : base (handle)
        {
            token = Mvx.Resolve<IMvxMessenger>().Subscribe<ReloadTableMessage>(OnReloadMessage);
        }

        private void OnReloadMessage(ReloadTableMessage obj)
        {
            this.tblViewAssociatedEnt.ReloadData();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            txtUserName.ShouldReturn += TxtField_ShouldReturn;
            txtEmailAddress.ShouldReturn += TxtField_ShouldReturn;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.DismissKeyboardOnBackgroundTap();

            UIBarButtonItem backbutton = new UIBarButtonItem(UIImage.FromBundle("ic_back"), UIBarButtonItemStyle.Done, null);

            this.NavigationItem.LeftBarButtonItem = backbutton;

            var source = new AssociatedTVS(tblViewAssociatedEnt);

            var Set = this.CreateBindingSet<AssociatedTab3View, AssociatedTab3ViewModel>();

            Set.Bind(backbutton).To(vm => vm.GoToRootMenuCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            Set.Bind(source).For(x=> x.ItemsSource).To(vm => vm.AssociatedEntities);

            Set.Bind(txtUserName).For(x=>x.Text).To(vm => vm.AssociatedUsername);
            Set.Bind(txtEmailAddress).For(x => x.Text).To(vm => vm.AssociatedEmail);

            Set.Bind(btnSubmit).To(vm => vm.SubmitAssociationCommand);
            Set.Apply();

            this.tblViewAssociatedEnt.Source = source;
            this.tblViewAssociatedEnt.ReloadData();
        }


        public override void ViewDidDisappear(bool animated)
        {
            txtUserName.ShouldReturn -= TxtField_ShouldReturn;
            txtEmailAddress.ShouldReturn -= TxtField_ShouldReturn;

            base.ViewDidDisappear(animated);
        }
    }
}