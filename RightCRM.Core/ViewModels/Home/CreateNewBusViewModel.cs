// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="CreateNewBusViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   CreateNewBusViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using Acr.UserDialogs;

namespace RightCRM.Core.ViewModels.Home
{
    public class CreateNewBusViewModel : BaseViewModel, IMvxViewModel<string>
    {
        private BusinessDetails newBusinessDetails;

        public CreateNewBusViewModel(IMvxNavigationService navigationService,
                                     IUserDialogs userDialogs) : base (userDialogs)
        {
            this.navigationService = navigationService;
            this.userDialogs = userDialogs;

            SubmitBusinessCommand = new MvxAsyncCommand(SubmitBusinessAsync);
        }

        private async Task SubmitBusinessAsync()
        {
            await Task.Delay(1000);

            userDialogs.Alert("Business submitted successfully");
        }

        public BusinessDetails NewBusinessDetails{ get { return newBusinessDetails; } set{ SetProperty(ref newBusinessDetails, value);}}


        public IMvxCommand SubmitBusinessCommand { get; private set; }

        public void Prepare(string parameter)
        {
            Title = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            NewBusinessDetails = new BusinessDetails();
        }
    }
}
