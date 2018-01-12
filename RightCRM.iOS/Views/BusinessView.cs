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
            var Set = this.CreateBindingSet<BusinessView, BusinessViewModel>();
            var source = new TableSource(this.TableView);
            Set.Bind(source).To(vm => vm.AllBusiness);
            Set.Apply();

            this.TableView.Source = source;
            this.TableView.RowHeight = UITableView.AutomaticDimension;
            this.TableView.EstimatedRowHeight = 5f;
            this.TableView.ReloadData();
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
        }
    }
}