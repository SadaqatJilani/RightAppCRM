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
using RightCRM.Core.Models;

namespace RightCRM.Core.ViewModels.Popups
{
    public class FilterPopupViewModel : BaseViewModel, IMvxViewModel<BusinessList, IEnumerable<FilterList>>
    {
        private BusinessList businessList;

        public FilterPopupViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            CloseCommand = CloseCommand ?? new MvxAsyncCommand(CloseFilters);

            FilterChangedCommand = new MvxCommand<FilterModel>(FilterOptions);

            SearchBusinessesCommand = new MvxAsyncCommand(SearchParameters);
        }

        private void FilterOptions(FilterModel filterItem)
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

            Demolist = new MvxObservableCollection<FilterList>(await ExtractFilterItems());

        }

        private async Task SearchParameters()
        {
            await navigationService.Close(this, Demolist);
        }

        private Task<List<FilterList>> ExtractFilterItems()
        {
            var listAddress = new List<FilterModel>();

            foreach (var item in businessList.AddressArray)
            {
                listAddress.Add(new FilterModel()
                {
                    SectionName = "Address",
                    FilterName = item.REGION,
                    Count = item.COUNT
                });
            }

            var listCompany = new List<FilterModel>();

            foreach (var item in businessList.CompanyArray)
            {
                listCompany.Add(new FilterModel()
                {
                    SectionName = "Company Size",
                    FilterName = item.COMPANY_SIZE,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }


            var listIndustry = new List<FilterModel>();

            foreach (var item in businessList.IndustryArray)
            {
                listIndustry.Add(new FilterModel()
                {
                    SectionName = "Industry",
                    FilterName = item.INDUSTRY,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listRevenue = new List<FilterModel>();

            foreach (var item in businessList.RevenueArray)
            {
                listRevenue.Add(new FilterModel()
                {
                    SectionName = "Revenue",
                    FilterName = item.ANNUAL_REVENUE,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listTags = new List<FilterModel>();

            foreach (var item in businessList.TagsArray)
            {
                listTags.Add(new FilterModel()
                {
                    SectionName = "Tags",
                    FilterName = item.CTAG,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listSalesWorkers = new List<FilterModel>();

            foreach (var item in businessList.SalesWorkersArray)
            {
                listSalesWorkers.Add(new FilterModel()
                {
                    SectionName = "Sales Workers",
                    FilterName = item.NAME,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var listStatus = new List<FilterModel>();

            foreach (var item in businessList.StatusArray ?? Enumerable.Empty<status>())
            {
                listStatus.Add(new FilterModel()
                {
                    SectionName = "Status",
                    FilterName = item.STATUS,
                    Count = item.COUNT.GetValueOrDefault()
                });
            }

            var filterList = new List<FilterList>
            {
                new FilterList(listAddress),
                new FilterList(listCompany),
                new FilterList(listIndustry),
                new FilterList(listRevenue),
                new FilterList(listTags),
                new FilterList(listSalesWorkers),
                new FilterList(listStatus)
            };


            return Task.FromResult(filterList);
        }

        private MvxObservableCollection<FilterList> demolist;
        public MvxObservableCollection<FilterList> Demolist { get { return demolist; } set { SetProperty(ref demolist, value); } }

        private FilterModel selectedFilter;
        public FilterModel SelectedFilter
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

        public IMvxCommand<FilterModel> FilterChangedCommand { get; private set; }
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
