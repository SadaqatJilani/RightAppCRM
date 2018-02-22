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
using System.Linq;
using RightCRM.Core.Services;
using MvvmCross.Plugins.Messenger;

namespace RightCRM.Core.ViewModels
{
    public class BusinessViewModel : BaseViewModel, IMvxViewModel<string>
    {
        private BusinessList businessFilters;
        private int businessPageno = 1;

        private LongPressMessage message;


        private MvxObservableCollection<Business> _allBusiness;
        public MvxObservableCollection<Business> AllBusiness{
            get { return _allBusiness; }
            set{SetProperty(ref _allBusiness,value, "AllBus");}
        }

        readonly IBusinessFacade businessFacade;
        readonly INavBarService navBarService;
        readonly IMvxMessenger messenger;

        public BusinessViewModel(IBusinessFacade businessFacade, 
                                 IMvxNavigationService navigationService, 
                                 IUserDialogs userDialogs, 
                                 INavBarService navBarService,
                                 IMvxMessenger messenger) : base (userDialogs)
        {
            this.messenger = messenger;
            this.navBarService = navBarService;
            this.navigationService = navigationService;
            this.businessFacade = businessFacade;
            this.userDialogs = userDialogs;

            BusinessDetailCommand = new MvxAsyncCommand<Business>(ShowBusinessDetails);
            BusLongPressedCommand = new MvxAsyncCommand<int>(SelectBusForTag);
            LoadMoreBusinessesCommand = new MvxAsyncCommand(LoadMoreBusinesses);
            AllBusiness = new MvxObservableCollection<Business>();
        }

        private async Task LoadMoreBusinesses()
        {
            businessPageno++;

            var result = await this.businessFacade.GetBusiness(businessPageno);

            if (result != null)
            {
                businessFilters = result.business;

                PopulateBusinesses(result.business?.DataArray);

            }
        }

        private async Task SelectBusForTag(int selectedBusinessRow)
        {
            if (IsLongPress == false)
            {
                IsLongPress = true;

                message = new LongPressMessage(this, true);
                messenger.Publish(message);

                //navBarService.TaggingModeEnabled(true);
            }

            if (AllBusiness[selectedBusinessRow].IsSelected == false)
            {
                AllBusiness[selectedBusinessRow].IsSelected = true;
            }
            else
            {
                AllBusiness[selectedBusinessRow].IsSelected = false;
            }

        }

        private async Task ShowBusinessDetails(Business business)
        {
            // throw new NotImplementedException();
            if (business != null)
            await navigationService.Navigate<BusinessDetailTabViewModel, Business>(business);
        }

        IMvxCommand showBusinessFilterCommand;
        public IMvxCommand ShowBusinessFilterCommand
        {
            get
            {
                showBusinessFilterCommand = showBusinessFilterCommand ?? new MvxAsyncCommand(BusinessFilter, CanFilter);
                return showBusinessFilterCommand;
            }
        }

        IMvxCommand assignTagCommand;
        public IMvxCommand AssignTagCommand
        {
            get
            {
                assignTagCommand = assignTagCommand ?? new MvxAsyncCommand(AssignFilter);
                return assignTagCommand;
            }
        }

        private bool isLongPress = false;
        public bool IsLongPress
        {
            get { return isLongPress; }
            set
            {
                isLongPress = value;
                RaisePropertyChanged(() => IsLongPress);
            }
        }

        private async Task AssignFilter()
        {

            //  AllBusiness.chang
            var selectedBusinesses =  AllBusiness.Where(x => x.IsSelected == true);

            await navigationService.Navigate<BusAddTagViewModel, IEnumerable<Business>>(selectedBusinesses);
        }

        private bool CanFilter()
        {
            if (AllBusiness.Count == 0)
            {
                return false;
            }
            return true;
        }

        private async Task BusinessFilter()
        {
          var filterList =  await navigationService.Navigate<FilterPopupViewModel, BusinessList, IEnumerable<FilterList>>(businessFilters);

            if (filterList != null)
            {
                AllBusiness.Clear();

                var result = await this.businessFacade.FilterBusinesses(filterList);

                if (result != null)
                {
                    PopulateBusinesses(result.business?.DataArray);
                }
            }
        }

        private void PopulateBusinesses(Business[] businesses)
        {
            if (businesses == null || !businesses.Any())
            {
                return;
            }

            foreach (var business in businesses)
            {
                var businessItem = new Business
                {
                    BusinessID = business.BusinessID,
                    BusinessType = business.BusinessType,
                    CompanyName = business.CompanyName,
                    CompanySize = business.CompanySize,
                    IndustryType = business.IndustryType,
                    Revenue = business.Revenue,
                    ADD_ID = business.ADD_ID
                };

                this.AllBusiness.Add(businessItem);
            }
        }

        public void Prepare(string parameter)
        {
            Title = parameter;
        }

        public IMvxCommand<Business> BusinessDetailCommand { get; private set; }
        public IMvxCommand<int> BusLongPressedCommand { get; private set; }
        public IMvxCommand LoadMoreBusinessesCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();
            var result = await this.businessFacade.GetBusiness(businessPageno);

            if (result != null)
            {
                businessFilters = result.business;

                PopulateBusinesses(result.business?.DataArray);

            }

            ShowBusinessFilterCommand.RaiseCanExecuteChanged();
        }
    }
}
