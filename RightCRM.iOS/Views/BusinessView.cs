using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS;

namespace RightCRM.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
   // [MvxRootPresentation(WrapInNavigationController = true)]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public partial class BusinessView : MvxTableViewController<BusinessViewModel>
    {
        UILongPressGestureRecognizer longPressGesture;
        TableSource source;
        bool isLongPress;
        UIBarButtonItem filterBtn;
        UIBarButtonItem assignTagBtn;

        public BusinessView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            filterBtn = new UIBarButtonItem(UIImage.FromBundle("filtericon"),
                                                UIBarButtonItemStyle.Plain, null);

            assignTagBtn = new UIBarButtonItem(UIImage.FromBundle("ic_compose"),
                         UIBarButtonItemStyle.Plain, null);

            var rightBarItems = new UIBarButtonItem[] { filterBtn, assignTagBtn};

            this.NavigationItem.SetRightBarButtonItem(filterBtn, true);

            //this.NavigationItem.RightBarButtonItems[0].CustomView.Hidden = true;


            var Set = this.CreateBindingSet<BusinessView, BusinessViewModel>();

            source = new TableSource(this.TableView);
            Set.Bind(source).To(vm => vm.AllBusiness);
            Set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.BusinessDetailCommand);

            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            Set.Bind(filterBtn).To(vm => vm.ShowBusinessFilterCommand);
            Set.Bind(assignTagBtn).To(vm => vm.AssignTagCommand);
            Set.Apply();

            this.TableView.Source = source;
            this.TableView.RowHeight = UITableView.AutomaticDimension;
            this.TableView.EstimatedRowHeight = 5f;
            this.TableView.ReloadData();

            longPressGesture = new UILongPressGestureRecognizer(LongPressBusiness)
            {
                MinimumPressDuration = 1
            };
            // longPressGesture.CancelsTouchesInView = false;

            this.TableView.AddGestureRecognizer(longPressGesture);

        }

        private void LongPressBusiness(UILongPressGestureRecognizer gestureRecognizer)
        {
            var point = gestureRecognizer.LocationInView(this.TableView);

            var indexPath = this.TableView.IndexPathForRowAtPoint(point);

            var selectedCell = TableView.CellAt(indexPath);

            if (indexPath == null)
            {
                System.Console.WriteLine("Long press on table view, not row.");
            }

            else if (gestureRecognizer.State == UIGestureRecognizerState.Began)
            {
                System.Console.WriteLine($"Long press on row, at {indexPath.Row}");

                if (isLongPress == false)
                {
                    isLongPress = true;

                    this.NavigationItem.SetRightBarButtonItem(assignTagBtn, true);

                    this.NavigationController.NavigationBar.BarTintColor = UIColor.LightGray;
                }

                // TableView.SelectRow(indexPath, true, UITableViewScrollPosition.None);

                if (selectedCell.Selected == false)
                {
                    TableView.SelectRow(indexPath, true, UITableViewScrollPosition.None);
                    TableView.Delegate?.RowSelected(TableView, indexPath);
                }
                else
                {
                    TableView.DeselectRow(indexPath, true);
                    TableView.Delegate?.RowDeselected(TableView, indexPath);
                }
            }
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            this.TableView.RemoveGestureRecognizer(longPressGesture);
        }

        public class TableSource : MvxTableViewSource
        {
            private readonly bool isScrolling;
            private int lastViewedPosition = 0;

            public TableSource(UITableView tableView)
                : base(tableView)
            {
                tableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

                lastViewedPosition = 0;
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
            {
                int position = indexPath.Row;

                if ((position > lastViewedPosition) && (position == (ItemsSource.Count() - 1)))
                {
                    lastViewedPosition = position;
                    // LoadMoreItems();

                }

                return (BusinessViewCell)TableView.DequeueReusableCell(BusinessViewCell.Key, indexPath);
            }

        }




    }
}