// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MenuView.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   MenuView
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebar;
using Foundation;
using CoreGraphics;
using MvvmCross.iOS.Support.XamarinSidebar.Views;
using RightCRM.Core.ViewModels.Menu;

namespace RightCRM.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public partial class MenuView : MvxViewController<MenuViewModel>, IMvxSidebarMenu
    {
        private CGColor borderColor = new CGColor(45, 177, 128);
        private UIColor TextColor = UIColor.White, BackgroundColor = UIColor.FromRGB(14, 76, 116);

        public virtual UIImage MenuButtonImage => UIImage.FromBundle("threelines");

        public virtual bool AnimateMenu => true;
        public virtual float DarkOverlayAlpha => 0.5f;
        public virtual bool HasDarkOverlay => true;
        public virtual bool HasShadowing => false;
        public virtual float ShadowOpacity => 0.5f;
        public virtual float ShadowRadius => 4.0f;
        public virtual UIColor ShadowColor => UIColor.Black;
        public virtual bool DisablePanGesture => false;
        public virtual bool ReopenOnRotate => true;

        private int MaxMenuWidth = 300;
        private int MinSpaceRightOfTheMenu = 55;

        public int MenuWidth => UserInterfaceIdiomIsPhone ?
        int.Parse(UIScreen.MainScreen.Bounds.Width.ToString()) - MinSpaceRightOfTheMenu : MaxMenuWidth;

        private bool UserInterfaceIdiomIsPhone
        {
            get
            {
                return (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) &&
                    (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait);
            }
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            View.BackgroundColor = BackgroundColor;
            // This is the default value of edgesForExtendedLayout
            EdgesForExtendedLayout = UIRectEdge.None;

            MenuTableView.BackgroundColor = UIColor.Clear;
            MenuTableView.AlwaysBounceVertical = false;

            //Corner radius and color
            ProfileImage.Layer.CornerRadius = (ProfileImage.Frame.Width / 2);
            ProfileImage.Layer.BorderWidth = 1.5f;
            ProfileImage.Layer.BorderColor = borderColor;
            ProfileImage.Layer.MasksToBounds = true;

            //Label colors
            BigLabel.TextColor = TextColor;
            SmallLabel.TextColor = TextColor;

            MenuTableView.Source = new MenuTableViewSource(ViewModel.MenuItems);
            MenuTableView.SeparatorColor = UIColor.FromRGBA(187, 187, 187, 0.1f);

            MenuTableView.TableFooterView = new UIView(CGRect.Empty) { BackgroundColor = BackgroundColor };


            MenuTableView.SelectRow(NSIndexPath.FromRowSection(0, 0), false, UITableViewScrollPosition.None);
            //MenuTableView.TableFooterView.Hidden = false;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public virtual void MenuWillOpen()
        {
        }

        public virtual void MenuDidOpen()
        {
        }

        public virtual void MenuWillClose()
        {
        }

        public virtual void MenuDidClose()
        {
        }
    }
}

