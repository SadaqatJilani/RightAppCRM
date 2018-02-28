// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FilterPopupViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   FilterPopupViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using System.Linq;
using RightCRM.DataAccess.Model.BusinessModels;
using RightCRM.Common;
using RightCRM.Common.Services;
using RightCRM.Core.ViewModels.ItemViewModels;
using Acr.UserDialogs;

namespace RightCRM.Core.ViewModels.Popups
{
    public class FilterPopupViewModel : BaseViewModel, IMvxViewModel<BusinessList, IEnumerable<FilterListViewModel>>
    {
        private BusinessList businessList;
        private readonly ICacheService cacheService;

        public FilterPopupViewModel(IMvxNavigationService navigationService, 
                                    ICacheService cacheService,
                                    IUserDialogs userDialogs)
        {
            this.userDialogs = userDialogs;
            this.cacheService = cacheService;
            this.navigationService = navigationService;

            CloseCommand = CloseCommand ?? new MvxAsyncCommand(CloseFilters);

            FilterChangedCommand = new MvxCommand<FilterItemViewModel>(FilterOptions);

            SearchBusinessesCommand = new MvxAsyncCommand(CloseAndSearch);

            ResetFiltersCommand = new MvxAsyncCommand(ClearFilters);
        }

        private async Task ClearFilters()
        {
           var confirmDialog = await userDialogs.ConfirmAsync("Are you sure you want to reset the current filters?", "Confirmation", "YES", "NO");

            if (confirmDialog)
            {
                foreach (var filterItem in FilterList)
                {
                    foreach (var item in filterItem)
                    {
                        item.IsSelected = false;
                    }
                }

                SearchKeyword = string.Empty;

                await CloseAndSearch();
            }
        }

        private void FilterOptions(FilterItemViewModel filterItem)
        {
            if (filterItem.IsSelected == false)
            {
                filterItem.IsSelected = true;
            }

            else
            {
                filterItem.IsSelected = false;
            }
        }

        public override void Prepare()
        {
            base.Prepare();
        }

        public IMvxAsyncCommand CloseCommand { get; private set; }

        async Task CloseFilters()
        {
            await navigationService.Close(this);
            CloseCompletionSource?.TrySetCanceled();
        }

        public void Prepare(BusinessList parameter)
        {
            businessList = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            FilterList = new MvxObservableCollection<FilterListViewModel>(await ExtractFilterItems());

            SearchKeyword = await cacheService.GetObjFromMem<string>(Constants.SavedKeyword);
        }

        private async Task CloseAndSearch()
        {
            await cacheService.InsertObjInMem<IEnumerable<FilterListViewModel>>(Constants.SelectedFilters, FilterList);
            await cacheService.InsertObjInMem<string>(Constants.SavedKeyword, SearchKeyword);

            await navigationService.Close(this, FilterList);
        }

        private async Task<List<FilterListViewModel>> ExtractFilterItems()
        {
            var cachedFilters = await cacheService.GetObjFromMem<IEnumerable<FilterListViewModel>>(Constants.SelectedFilters);

            if(cachedFilters != null && cachedFilters.Any())
            {
                return new List<FilterListViewModel>(cachedFilters);
            }

            var listAddress = new List<FilterItemViewModel>();

            foreach (var item in businessList?.AddressArray ?? Enumerable.Empty<address>())
            {
                listAddress.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.AddressFilter,
                    FilterName = item.REGION_NAME,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listCompany = new List<FilterItemViewModel>();

            foreach (var item in businessList?.CompanyArray ?? Enumerable.Empty<company_size>())
            {
                listCompany.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.CompanySizeFilter,
                    FilterName = item.COMPANY_SIZE,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }


            var listIndustry = new List<FilterItemViewModel>();

            foreach (var item in businessList?.IndustryArray ?? Enumerable.Empty<industry>())
            {
                listIndustry.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.IndustryFilter,
                    FilterName = item.INDUSTRY,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listRevenue = new List<FilterItemViewModel>();

            foreach (var item in businessList?.RevenueArray ?? Enumerable.Empty<revenue>())
            {
                listRevenue.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.RevenueFilter,
                    FilterName = item.ANNUAL_REVENUE,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listTags = new List<FilterItemViewModel>();

            foreach (var item in businessList?.TagsArray ?? Enumerable.Empty<Tags>())
            {
                listTags.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.TagsFilter,
                    FilterName = item.CTAG,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listSalesWorkers = new List<FilterItemViewModel>();

            foreach (var item in businessList?.SalesWorkersArray ?? Enumerable.Empty<SalesWorkers>())
            {
                listSalesWorkers.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.SalesWorkFilter,
                    FilterName = item.NAME,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listStatus = new List<FilterItemViewModel>();

            foreach (var item in businessList?.StatusArray ?? Enumerable.Empty<status>())
            {
                listStatus.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.StatusFilter,
                    FilterName = item.STATUS,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var filteredList = new List<FilterListViewModel>
            {
                new FilterListViewModel(listAddress),
                new FilterListViewModel(listCompany),
                new FilterListViewModel(listIndustry),
                new FilterListViewModel(listRevenue),
                new FilterListViewModel(listTags),
                new FilterListViewModel(listSalesWorkers),
                new FilterListViewModel(listStatus)
            };


            return filteredList;
        }

        private MvxObservableCollection<FilterListViewModel> filterList;
        public MvxObservableCollection<FilterListViewModel> FilterList { get { return filterList; } set { SetProperty(ref filterList, value); } }

        private FilterItemViewModel selectedFilter;
        public FilterItemViewModel SelectedFilter
        {
            get
            {
                return selectedFilter;
            }
            set
            {
                SetProperty(ref selectedFilter, value);
                if (selectedFilter != null)
                {
                    selectedFilter.IsSelected = true;
                }
            }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set { SetProperty(ref searchKeyword, value); }
        }

        public IMvxCommand<FilterItemViewModel> FilterChangedCommand { get; private set; }
        public IMvxCommand SearchBusinessesCommand { get; private set; }

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }
        public IMvxCommand ResetFiltersCommand { get; private set; }

        private SaveSearchRequestModel ConvertToSaveSearchRequest(IEnumerable<FilterListViewModel> list)
        {

            var filterRequest = new SaveSearchRequestModel
            {
                srch_address_id = JsonStringFromList(list, Constants.AddressFilter, true),

                srch_company_size = JsonStringFromList(list, Constants.CompanySizeFilter),

                srch_industry = JsonStringFromList(list, Constants.IndustryFilter),

                srch_annual_revenue = JsonStringFromList(list, Constants.RevenueFilter),

                srch_ctag = JsonStringFromList(list, Constants.TagsFilter),

                assign_user_list = JsonStringFromList(list, Constants.SalesWorkFilter),

                business_status = JsonStringFromList(list, Constants.StatusFilter),

                srch_keywords = SearchKeyword
            };

            return filterRequest;
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }
}
