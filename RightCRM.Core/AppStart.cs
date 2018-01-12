// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AppStart.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AppStart
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Core.ViewModels;

namespace RightCRM.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;

        public AppStart(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        }

        /// <summary>
        /// Start is called on startup of the app
        /// Hint contains information in case the app is started with extra parameters
        /// </summary>
        public void Start(object hint = null)
        {
            _navigationService.Navigate<LoginViewModel>();
        }
    }
}
