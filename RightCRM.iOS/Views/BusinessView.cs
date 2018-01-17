using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebar;

namespace RightCRM.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public partial class BusinessView : MvxTableViewController<BusinessViewModel>
    {
        public BusinessView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var filterBtn = new UIBarButtonItem(UIImage.FromBundle("filtericon"),
                                                UIBarButtonItemStyle.Plain, null);

            this.NavigationItem.RightBarButtonItem = filterBtn;

            var Set = this.CreateBindingSet<BusinessView, BusinessViewModel>();
            var source = new TableSource(this.TableView);
            Set.Bind(source).To(vm => vm.AllBusiness);
            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Bind(filterBtn).To(vm => vm.ShowBusinessFilterCommand);
            Set.Apply();

            this.TableView.Source = source;
            this.TableView.RowHeight = UITableView.AutomaticDimension;
            this.TableView.EstimatedRowHeight = 5f;
            this.TableView.ReloadData();

        }

        void HandleEventHandler(object sender, EventArgs e)
        {
            FilterPopup yourController = new FilterPopup
            {
                ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext,
                ModalTransitionStyle = UIModalTransitionStyle.CoverVertical
            };
            this.PresentViewController(yourController, true, null);

        }

        public class TableSource : MvxTableViewSource
        {
            public TableSource(UITableView tableView)
                : base(tableView)
            {
                tableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
            {
                return (UITableViewCell)TableView.DequeueReusableCell(BusinessViewCell.Key, indexPath);
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                base.RowSelected(tableView, indexPath);
            }
        }
    }
}