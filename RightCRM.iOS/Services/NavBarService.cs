// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavBarService.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NavBarService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using RightCRM.Core.Services;
using UIKit;

namespace RightCRM.iOS.Services
{
    public class NavBarService : INavBarService
    {

        public NavBarService()
        {

        }

        public void TaggingModeEnabled(bool isTaggingMode)
        {
           // throw new NotImplementedException();

           var assignTagBtn = new UIBarButtonItem(UIImage.FromBundle("ic_compose"),
                         UIBarButtonItemStyle.Plain, null);

           // UIApplication.SharedApplication.InvokeOnMainThread(() =>
            //{
            //var window = UIApplication.SharedApplication.KeyWindow;
            //var vc = window.RootViewController;
            //while (vc.PresentedViewController != null)
            //    vc = vc.PresentedViewController;

            //var navController = vc as UINavigationController;
            //if (navController != null)

            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
            var presenter = Mvx.GetSingleton<IMvxIosViewPresenter>() as MvxSidebarPresenter;

            if (appDelegate.Window.RootViewController.PresentedViewController != null)
            {
            //    appDelegate.Window.RootViewController.DismissViewController(true, null);
            }
            else
            {
                //presenter.MasterNavigationController.PopToRootViewController(true);
            }

           // vc = vc.ChildViewControllers[0];

           // vc = vc.PresentedViewController;

            //presenter.ViewsContainer

                if (isTaggingMode)
                {
                    presenter.MasterNavigationController.NavigationItem.SetRightBarButtonItem(assignTagBtn, true);

                    presenter.MasterNavigationController.NavigationBar.BarTintColor = UIColor.LightGray;
                }
           // });

        }
    }
}
