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
using RightCRM.Common.Models;

namespace RightCRM.Core.ViewModels.Home
{
    public class BusDetailTab1ViewModel : BaseViewModel, IMvxViewModel<Business>
    {
        private Business businessItem;

        public BusDetailTab1ViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessDetailsPage;
        }

        public void Prepare(Business parameter)
        {
            businessItem = parameter;
        }
    }
}
