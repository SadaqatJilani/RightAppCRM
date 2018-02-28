using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using RightCRM.Common;
using RightCRM.Common.Models;
using RightCRM.Common.Services;
using RightCRM.Core.Services;
using RightCRM.Core.ViewModels.Home;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.Core.ViewModels.Popups;
using RightCRM.DataAccess.Model.BusinessModels;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels
{
    public class BusinessViewModel : BaseViewModel, IMvxViewModel<string>
    {
        private BusinessList businessFilters;
        private int businessPageno = 1;

        private LongPressMessage longPressMessage;

        private MvxObservableCollection<BusinessItemViewModel> _allBusiness;
        public MvxObservableCollection<BusinessItemViewModel> AllBusiness
        {
            get { return _allBusiness; }
            set { SetProperty(ref _allBusiness, value, "AllBus"); }
        }

        readonly IBusinessFacade businessFacade;
        readonly INavBarService navBarService;
        readonly IMvxMessenger messenger;

        private List<FilterListViewModel> cachedFilters;
        readonly ICacheService cacheService;
        private bool moreItemsLoaded;

        private string searchKeyword;

        public BusinessViewModel(IBusinessFacade businessFacade,
                                 IMvxNavigationService navigationService,
                                 IUserDialogs userDialogs,
                                 INavBarService navBarService,
                                 IMvxMessenger messenger,
                                 ICacheService cacheService) : base(userDialogs)
        {
            this.cacheService = cacheService;
            this.messenger = messenger;
            this.navBarService = navBarService;
            this.navigationService = navigationService;
            this.businessFacade = businessFacade;
            this.userDialogs = userDialogs;

            BusinessDetailCommand = new MvxAsyncCommand<BusinessItemViewModel>(ShowBusinessDetails);
            BusLongPressedCommand = new MvxCommand<int>(SelectBusForTag);
            LoadMoreBusinessesCommand = new MvxAsyncCommand(LoadMoreBusinesses);
            AllBusiness = new MvxObservableCollection<BusinessItemViewModel>();

            cachedFilters = new List<FilterListViewModel>();
        }

        private async Task LoadMoreBusinesses()
        {
            if (moreItemsLoaded)
            {
                businessPageno++;

                var result = await this.businessFacade.FilterBusinesses(await ConvertToBusRequest(cachedFilters), businessPageno);

                if (result != null)
                {
                    PopulateBusinesses(result.business?.DataArray);
                }
            }
        }

        private void SelectBusForTag(int selectedBusinessRow)
        {
            if (IsLongPress == false)
            {
                IsLongPress = true;

                longPressMessage = new LongPressMessage(this, true);
                messenger.Publish(longPressMessage);

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

        private async Task ShowBusinessDetails(BusinessItemViewModel business)
        {
            // throw new NotImplementedException();
            if (business != null)
                await navigationService.Navigate<BusinessDetailTabViewModel, BusinessItemViewModel>(business);
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

        private bool isFilterOn;
        public bool IsFilterOn
        {
            get { return isFilterOn; }
            set{SetProperty(ref isFilterOn, value); }
        }

        private async Task AssignFilter()
        {

            //  AllBusiness.chang
            var selectedBusinesses = AllBusiness.Where(x => x.IsSelected == true);

            await navigationService.Navigate<BusAddTagViewModel, IEnumerable<BusinessItemViewModel>>(selectedBusinesses);
        }

        private bool CanFilter()
        {
            if (this.AllBusiness != null && this.AllBusiness.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task BusinessFilter()
        {
            var filterList = await navigationService.Navigate<FilterPopupViewModel, BusinessList, IEnumerable<FilterListViewModel>>(businessFilters);

            if (filterList != null)
            {
                cachedFilters = new List<FilterListViewModel>(filterList);

                AllBusiness.Clear();

                businessPageno = 1;
                var result = await this.businessFacade.FilterBusinesses(await ConvertToBusRequest(cachedFilters), businessPageno);

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
                moreItemsLoaded = false;
                return;
            }
            else
            {
                moreItemsLoaded = true;
            }

            foreach (var business in businesses)
            {
                var businessItem = new BusinessItemViewModel
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

        public IMvxCommand<BusinessItemViewModel> BusinessDetailCommand { get; private set; }
        public IMvxCommand<int> BusLongPressedCommand { get; private set; }
        public IMvxCommand LoadMoreBusinessesCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            businessPageno = 1;
            cachedFilters = new List<FilterListViewModel>(await cacheService.GetObjFromMem<IEnumerable<FilterListViewModel>>(Constants.SelectedFilters) ??
                                                          Enumerable.Empty<FilterListViewModel>());

            var result = await this.businessFacade.FilterBusinesses(await ConvertToBusRequest(cachedFilters), businessPageno);

            if (result != null)
            {
                businessFilters = result.business;
                await cacheService.InsertObject(Constants.AllSavedFilters, businessFilters);

                PopulateBusinesses(result.business?.DataArray);
            }

            ShowBusinessFilterCommand.RaiseCanExecuteChanged();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            IsLongPress = false;

            longPressMessage = new LongPressMessage(this, false);
            messenger.Publish(longPressMessage);
        }


       async Task<GetBusinessRequestModel> ConvertToBusRequest(IEnumerable<FilterListViewModel> filterList)
        {
            var savedKeyword = await cacheService.GetObjFromMem<string>(Constants.SavedKeyword);

            var filterRequest = new GetBusinessRequestModel
            {
                srch_address_id = JsonStringFromList(filterList, Constants.AddressFilter),

                srch_company_size = JsonStringFromList(filterList, Constants.CompanySizeFilter),

                srch_industry = JsonStringFromList(filterList, Constants.IndustryFilter),

                srch_annual_revenue = JsonStringFromList(filterList, Constants.RevenueFilter),

                srch_ctag = JsonStringFromList(filterList, Constants.TagsFilter),

                user_list = JsonStringFromList(filterList, Constants.SalesWorkFilter),

                user_status = JsonStringFromList(filterList, Constants.StatusFilter),

                srch_keywords = savedKeyword?.ToLower()
            };

            return filterRequest;
        }

    }
}
