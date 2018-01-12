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
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Core.Models;
using RightCRM.Core.ViewModels.Home;

namespace RightCRM.Core.ViewModels.Menu
{
    public class MenuViewModel : MvxViewModel
    {
        
        private readonly IMvxNavigationService navigationService;

        public List<MenuModel> MenuItems
        {
            get;
        }

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            MenuItems = new List<MenuModel>
            {
                new MenuModel() { Title = "Home", ImageName = "ic_build_white", Navigate = NavigateHome },
                new MenuModel() { Title = "About", ImageName = "ic_description_white", Navigate = NavigateOtherViewModel },
                new MenuModel() { Title = "MvvmCross", ImageName = "ic_settings_white", Navigate = NavigateOtherViewModel },
                new MenuModel() { Title = "Xamarin", ImageName = "ic_explore_white", Navigate = NavigateOtherViewModel },
                new MenuModel() { Title = "Microsoft", ImageName = "ic_credit_card_white", Navigate = NavigateOtherViewModel },
                new MenuModel() { Title = "Evolve", ImageName = "ic_device_hub_white", Navigate = NavigateOtherViewModel }
            };
        }

        private MvxCommand resetCommand;
        public MvxCommand NavigateHome
        {
            get
            {
                resetCommand = resetCommand ?? new MvxCommand(() => navigationService.Navigate<BusinessViewModel>());
                return resetCommand;
            }
        }

        private MvxCommand navigateOtherViewModel;
        public MvxCommand NavigateOtherViewModel
        {
            get
            {
                navigateOtherViewModel = navigateOtherViewModel ?? new MvxCommand(() => navigationService.Navigate<MarketsViewModel>());
                return navigateOtherViewModel;
            }
        }
    }
}
