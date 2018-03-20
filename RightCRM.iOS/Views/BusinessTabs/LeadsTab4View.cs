using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.iOS.Views;
using RightCRM.Core.ViewModels.Home.BusinessTabs;
using RightCRM.Common;
using MvvmCross.Binding.BindingContext;
using RightCRM.iOS.Views.BusinessTabs;

namespace RightCRM.iOS.Views.BusinessTabs
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxTabPresentation(WrapInNavigationController = true, TabIconName = "ic_notes", TabName = Constants.TitleBusinessLeadsPage)]
    public partial class LeadsTab4View : BaseViewController<LeadsTab4ViewModel>
    {
        public LeadsTab4View (IntPtr handle) : base (handle)
        {
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);

            var selectedRow = tblViewLeads.IndexPathForSelectedRow;

            if (selectedRow != null)
            {
                tblViewLeads.DeselectRow(selectedRow, true);
            }
		}

		public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem backbutton = new UIBarButtonItem(UIImage.FromBundle("ic_back"), UIBarButtonItemStyle.Done, null);

            this.NavigationItem.LeftBarButtonItem = backbutton;

            var source = new LeadsTVS(tblViewLeads);

            var Set = this.CreateBindingSet<LeadsTab4View, LeadsTab4ViewModel>();

            Set.Bind(backbutton).To(vm => vm.GoToRootMenuCommand);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            Set.Bind(source).For(x=>x.ItemsSource).To(vm => vm.LeadsList);
            Set.Bind(source).For(x => x.SelectionChangedCommand).To(vm => vm.LeadSelectedCommand);

            Set.Apply();

            this.tblViewLeads.Source = source;
            this.tblViewLeads.ReloadData();
        }
    }
}