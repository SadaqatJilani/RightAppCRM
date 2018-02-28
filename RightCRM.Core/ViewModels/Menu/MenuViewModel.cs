// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MenuViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   MenuViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Core.Models;
using RightCRM.Core.ViewModels.Home;
using Acr.UserDialogs;

namespace RightCRM.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(IMvxNavigationService navigationService, IUserDialogs userDialogs)
        {
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            this.userDialogs = userDialogs;
        }

        public List<MenuModel> MenuItems
        {
            get;
            set;
        }

        private IMvxCommand navigateHome;
        public IMvxCommand NavigateHome
        {
            get
            {
                navigateHome = navigateHome ?? 
                    new MvxAsyncCommand(async () => await navigationService.Navigate<BusinessViewModel, string>(MenuItems[0].Title));
                return navigateHome;
            }
        }

        private IMvxCommand navigateToMarkets;
        public IMvxCommand NavigateToMarkets
        {
            get
            {
                navigateToMarkets = navigateToMarkets ?? 
                    new MvxAsyncCommand(async () => await navigationService.Navigate<MarketsViewModel, string>(MenuItems[1].Title));
                return navigateToMarkets;
            }
        }

        private IMvxCommand navigateToCreateNewB;
        public IMvxCommand NavigateToCreateNewB
        {
            get
            {
                navigateToCreateNewB = navigateToCreateNewB ??
                    new MvxAsyncCommand(async () => await navigationService.Navigate<CreateNewBusViewModel, string>(MenuItems[2].Title));
                return navigateToCreateNewB;
            }
        }

        private IMvxCommand logoutCommand;
        public IMvxCommand LogoutCommand         
        {
            get
            {
                logoutCommand = logoutCommand ??
                    new MvxAsyncCommand(async () => await LogoutFromApp());
                return logoutCommand;
            }
        }

        public void ShowViewModelAndroid(Type type)
        {
            throw new NotImplementedException();
        }

        private async Task LogoutFromApp()
        {

            if (await userDialogs.ConfirmAsync("Are you sure you want to logout ?", okText: "Logout", cancelText: "Cancel"))
            {
                await navigationService.Navigate<LoginViewModel>();
            }
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            MenuItems = new List<MenuModel>
            {
                new MenuModel() { Title = Constants.TitleBusinessPage, ImageName = "ic_build_white", Navigate = NavigateHome },
                new MenuModel() { Title = Constants.TitleMarketsPage, ImageName = "ic_description_white", Navigate = NavigateToMarkets },
                new MenuModel() { Title = Constants.TitleCreateNewPage, ImageName = "ic_settings_white", Navigate = NavigateToCreateNewB },
            };
        }
    }
}
