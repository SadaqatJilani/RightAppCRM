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

namespace RightCRM.Core.ViewModels.Home
{
    public class CreateNewBusViewModel : BaseViewModel, IMvxViewModel<string>
    {
        private BusinessDetails newBusinessDetails;

        public CreateNewBusViewModel()
        {
        }

        public BusinessDetails NewBusinessDetails{ get { return newBusinessDetails; } set{ SetProperty(ref newBusinessDetails, value);}}

        public void Prepare(string parameter)
        {
            Title = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            NewBusinessDetails = new BusinessDetails()
            {
                BusinessID = 101,
                AccountName = "hey",
                AccountType = "test",
                AnnualRevenue = 133,
                BusinessNTN = "93829391",
                BusinessWebsite = "www.helloworld.com",
                CampaignMedia = "bolwala",
                CampaignName = "hellomoto",
                CampaignSrc = "source",
                CompanySize = "1000",
                Industry = "Pharma"
            };
        }
    }
}
