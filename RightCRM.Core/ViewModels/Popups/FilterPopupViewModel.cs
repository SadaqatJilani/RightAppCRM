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

namespace RightCRM.Core.ViewModels.Popups
{
    public class FilterPopupViewModel : BaseViewModel, IMvxViewModel<BusinessList, IEnumerable<FilterListViewModel>>
    {
        private BusinessList businessList;
        private readonly ICacheService cacheService;

        public FilterPopupViewModel(IMvxNavigationService navigationService, ICacheService cacheService)
        {
            this.cacheService = cacheService;
            this.navigationService = navigationService;

            CloseCommand = CloseCommand ?? new MvxAsyncCommand(CloseFilters);

            FilterChangedCommand = new MvxCommand<FilterItemViewModel>(FilterOptions);

            SearchBusinessesCommand = new MvxAsyncCommand(SearchParameters);
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

        }

        private async Task SearchParameters()
        {

            await cacheService.InsertObject<IEnumerable<FilterListViewModel>>(Constants.SelectedFilters, FilterList);
            await navigationService.Close(this, FilterList);
        }

        private async Task<List<FilterListViewModel>> ExtractFilterItems()
        {
            var cachedFilters = await cacheService.GetObject<IEnumerable<FilterListViewModel>>(Constants.SelectedFilters);

            if(cachedFilters != null)
            {
                return new List<FilterListViewModel>(cachedFilters);
            }

            var listAddress = new List<FilterItemViewModel>();

            foreach (var item in businessList.AddressArray ?? Enumerable.Empty<address>())
            {
                listAddress.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.AddressFilter,
                    FilterName = item.REGION,
                    Count = item.COUNT
                });
            }

            var listCompany = new List<FilterItemViewModel>();

            foreach (var item in businessList.CompanyArray ?? Enumerable.Empty<company_size>())
            {
                listCompany.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.CompanySizeFilter,
                    FilterName = item.COMPANY_SIZE,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }


            var listIndustry = new List<FilterItemViewModel>();

            foreach (var item in businessList.IndustryArray ?? Enumerable.Empty<industry>())
            {
                listIndustry.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.IndustryFilter,
                    FilterName = item.INDUSTRY,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listRevenue = new List<FilterItemViewModel>();

            foreach (var item in businessList.RevenueArray ?? Enumerable.Empty<revenue>())
            {
                listRevenue.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.RevenueFilter,
                    FilterName = item.ANNUAL_REVENUE,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listTags = new List<FilterItemViewModel>();

            foreach (var item in businessList.TagsArray ?? Enumerable.Empty<Tags>())
            {
                listTags.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.TagsFilter,
                    FilterName = item.CTAG,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listSalesWorkers = new List<FilterItemViewModel>();

            foreach (var item in businessList.SalesWorkersArray ?? Enumerable.Empty<SalesWorkers>())
            {
                listSalesWorkers.Add(new FilterItemViewModel()
                {
                    SectionName = Constants.SalesWorkFilter,
                    FilterName = item.NAME,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listStatus = new List<FilterItemViewModel>();

            foreach (var item in businessList.StatusArray ?? Enumerable.Empty<status>())
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

        public IMvxCommand<FilterItemViewModel> FilterChangedCommand { get; private set; }
        public IMvxCommand SearchBusinessesCommand { get; private set; }

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }
}
