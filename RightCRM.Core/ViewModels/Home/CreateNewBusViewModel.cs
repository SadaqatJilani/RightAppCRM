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
using RightCRM.Facade.Facades;
using RightCRM.DataAccess.Model.CreateNew;
using RightCRM.Common;

namespace RightCRM.Core.ViewModels.Home
{
    public class CreateNewBusViewModel : BaseViewModel, IMvxViewModel<string>
    {
        /// <summary>
        /// The new bus facade.
        /// </summary>
        private readonly INewBusFacade newBusFacade;

        /// <summary>
        /// The new business details.
        /// </summary>
        private BusinessDetails newBusinessDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Core.ViewModels.Home.CreateNewBusViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="userDialogs">User dialogs.</param>
        /// <param name="newBusFacade">New bus facade.</param>
        public CreateNewBusViewModel(IMvxNavigationService navigationService,
                                     IUserDialogs userDialogs,
                                     INewBusFacade newBusFacade) : base (userDialogs)
        {
            this.newBusFacade = newBusFacade;
            this.navigationService = navigationService;
            this.userDialogs = userDialogs;

            SubmitBusinessCommand = new MvxAsyncCommand(SubmitBusinessAsync);
        }

        private async Task SubmitBusinessAsync()
        {
            await Task.Delay(1000);

            var busRequestModel = new NewBusRequestModel
            { 
                acname = newBusinessDetails.AccountName,
                actype = newBusinessDetails.AccountType
            };

           var res =  await newBusFacade.SubmitNewBusiness(busRequestModel);

            if (res != null)
                userDialogs.Alert(res.registration?.msg);

            else
                userDialogs.Alert(Constants.SomethingWrong);
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
