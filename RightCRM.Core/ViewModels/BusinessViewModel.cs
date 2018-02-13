using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using RightCRM.Core.Models;
using RightCRM.Core.ViewModels.Popups;
using RightCRM.Core.ViewModels.Home;
using RightCRM.Facade.Facades;
using System.Threading.Tasks;
using Acr.UserDialogs;
using System.Collections.Generic;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.Core.ViewModels
{
    public class BusinessViewModel : BaseViewModel, IMvxViewModel<string>
    {
        private BusinessList businessFilters;


        private MvxObservableCollection<Business> _allBusiness;
        public MvxObservableCollection<Business> AllBusiness{
            get { return _allBusiness; }
            set{SetProperty(ref _allBusiness,value);}
        }

        readonly IBusinessFacade businessFacade;   
        public BusinessViewModel(IBusinessFacade businessFacade, IMvxNavigationService navigationService, IUserDialogs userDialogs) : base (userDialogs)
        {
            this.navigationService = navigationService;
            this.businessFacade = businessFacade;
            this.userDialogs = userDialogs;

            BusinessDetailCommand = new MvxAsyncCommand<Business>(ShowBusinessDetails);
        }

        private async Task ShowBusinessDetails(Business business)
        {
            // throw new NotImplementedException();

            await navigationService.Navigate<BusinessDetailTabViewModel, Business>(business);
        }

        IMvxCommand showBusinessFilterCommand;
        public IMvxCommand ShowBusinessFilterCommand
        {
            get
            {
                showBusinessFilterCommand = showBusinessFilterCommand ?? new MvxAsyncCommand(BusinessFilter);
                return showBusinessFilterCommand;
            }
        }

        private async Task BusinessFilter()
        {
          var filterList =  await navigationService.Navigate<FilterPopupViewModel, BusinessList, IEnumerable<FilterList>>(businessFilters);

            if (filterList != null)
            {
                AllBusiness.Clear();

                var result = await this.businessFacade.FilterBusinesses(filterList);
                await Initialize();
            }
        }

        public void Prepare(string parameter)
        {
            Title = parameter;
        }

        public IMvxCommand<Business> BusinessDetailCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();
            var result = await this.businessFacade.GetBusiness();

            if (result != null)
            {
                businessFilters = result.business;

                AllBusiness = new MvxObservableCollection<Business>(result.business?.DataArray);
            }

            else 
            {
              //  ShowBusinessFilterCommand.
            }
        }
    }
}
