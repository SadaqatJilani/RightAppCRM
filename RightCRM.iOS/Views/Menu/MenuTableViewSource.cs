// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MenuTableViewSource.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   MenuTableViewSource
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using RightCRM.Core.Models;

namespace RightCRM.iOS.Views
{
    public class MenuTableViewSource : UITableViewSource
    {
        List<MenuModel> TableItems;
        string CellIdentifier = "MenuTableViewCell";

        public MenuTableViewSource(List<MenuModel> menuItems)
        {
            TableItems = menuItems;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            MenuTableViewCell cell = tableView.DequeueReusableCell(CellIdentifier) as MenuTableViewCell;
            MenuModel item = TableItems[indexPath.Row];

            if (cell == null)
                cell = MenuTableViewCell.Create();

            cell.BackgroundColor = UIColor.Clear;

            //seperator line full width
            cell.SeparatorInset = UIEdgeInsets.Zero;
            cell.LayoutMargins = UIEdgeInsets.Zero;

            cell.MenuItemTextLabel.Text = item.Title;
            cell.MenuItemTextLabel.TextColor = UIColor.White;//;UIColor.FromRGB (230, 230, 230);
            cell.MenuItemTextLabel.HighlightedTextColor = UIColor.Black;

            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            var image = UIImage.FromBundle(item.ImageName);
            if (image != null)
            {
                cell.MenuImage.Image = image;
                var templatedImage = cell.MenuImage.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                cell.MenuImage.Image = templatedImage;
                cell.MenuImage.TintColor = UIColor.FromRGB(230, 230, 230);
            }

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            MenuModel item = TableItems[indexPath.Row];
            item.Navigate.Execute();
            //Mvx.Resolve<IMvxSideMenu>().Close();
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 40f;
        }
    }
}
