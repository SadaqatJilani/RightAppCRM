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
using RightCRM.Core.Models;
using RightCRM.Core.ViewModels.Home;

namespace RightCRM.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            //MenuItems = new List<MenuModel>
            MenuItems.Add(new MenuModel() { Title = "Home", ImageName = "ic_build_white", Navigate = NavigateHome });
            MenuItems.Add(new MenuModel() { Title = "Markets", ImageName = "ic_description_white", Navigate = NavigateToMarkets });
            MenuItems.Add(new MenuModel() { Title = "MvvmCross", ImageName = "ic_settings_white", Navigate = NavigateToMarkets });
            MenuItems.Add(new MenuModel() { Title = "Xamarin", ImageName = "ic_explore_white", Navigate = NavigateToMarkets });
            MenuItems.Add(new MenuModel() { Title = "Microsoft", ImageName = "ic_credit_card_white", Navigate = NavigateToMarkets });
            MenuItems.Add(new MenuModel() { Title = "Evolve", ImageName = "ic_device_hub_white", Navigate = NavigateToMarkets });
        }

        private IMvxCommand navigateHome;
        public IMvxCommand NavigateHome
        {
            get
            {
                navigateHome = navigateHome ?? new MvxAsyncCommand(NavigateToViewModel<BusinessViewModel>);
                return navigateHome;
            }
        }

        private IMvxCommand navigateToMarkets;
        public IMvxCommand NavigateToMarkets
        {
            get
            {
                navigateToMarkets = navigateToMarkets ?? new MvxAsyncCommand(NavigateToViewModel<MarketsViewModel>);
                return navigateToMarkets;
            }
        }


        private async Task NavigateToViewModel<T>() where T : MvxViewModel
        {
            await navigationService.Navigate<T>();
        }

    }
}
