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
using System.Threading.Tasks;
using Acr.UserDialogs;
using RightCRM.Facade.Facades;
using RightCRM.Core.ViewModels.ItemViewModels;

namespace RightCRM.Core.ViewModels.Home
{
    public class BusDetailTab1ViewModel : BaseViewModel, IMvxViewModel<int>
    {
        private int businessID;

        private BusinessDetails listBusinessDetails;

        private readonly IBusinessDetailsFacade businessDetailsFacade;

        public BusDetailTab1ViewModel(IMvxNavigationService navigationService,
                                      IUserDialogs userDialogs,
                                     IBusinessDetailsFacade businessDetailsFacade) : base (userDialogs)
        {
            this.navigationService = navigationService;
            this.userDialogs = userDialogs;
            this.businessDetailsFacade = businessDetailsFacade;
        }

        public BusinessDetails ListBusinessDetails{ get { return listBusinessDetails; } set{ SetProperty(ref listBusinessDetails, value);}}

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessDetailsPage;
        }

        public void Prepare(int parameter)
        {
            businessID = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            var res = await businessDetailsFacade.GetBusinessDetails(businessID);

            if (res != null)
                ListBusinessDetails = res.business?.Data ?? new BusinessDetails();

            //ListBusinessDetails = new BusinessDetails() { 
                //BusinessID = 101, 
                //AccountName = "hey", 
                //AccountType = "test", 
                //AnnualRevenue = 133, 
                //BusinessNTN = "93829391", 
                //BusinessWebsite = "www.helloworld.com", 
                //CampaignMedia="bolwala", 
                //CampaignName="hellomoto", 
                //CampaignSrc="source", 
                //CompanySize="1000", 
                //Industry="Pharma"};

        }
    }
}
