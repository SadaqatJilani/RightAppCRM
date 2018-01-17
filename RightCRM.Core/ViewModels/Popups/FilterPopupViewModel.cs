// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FilterPopupViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   FilterPopupViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.Popups
{
    public class FilterPopupViewModel : BaseViewModel
    {
        public FilterPopupViewModel(MvxNavigationService navigationService) : base (navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Prepare()
        {
            base.Prepare();
        }

        private IMvxCommand filterPopupCommand;
        public IMvxCommand FilterPopupCommand
        {
            get
            {
                filterPopupCommand = filterPopupCommand ?? new MvxAsyncCommand(NavigateToViewModel<FilterPopupViewModel>);
                return filterPopupCommand;
            }
        }

    }
}
