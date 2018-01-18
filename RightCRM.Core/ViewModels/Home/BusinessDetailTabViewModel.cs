// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessDetailTabViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessDetailTabViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.Home
{
    public class BusinessDetailTabViewModel : BaseViewModel
    {
        public BusinessDetailTabViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            CloseBusinessDetailCommand = new MvxAsyncCommand(async () => await navigationService.Close(this));
        }

        public override void Prepare()
        {
            base.Prepare();

            Title = "Business Details";
        }

        public IMvxCommand CloseBusinessDetailCommand { get; private set; }
    }
}
