// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailTab1ViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailTab1ViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;

namespace RightCRM.Core.ViewModels.Home
{
    public class BusDetailTab1ViewModel : BaseViewModel
    {
        public BusDetailTab1ViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

       // public MvxAsyncCommand CloseBusinessDetailCommand { get; private set; }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessDetailsPage;
        }

    }
}
