using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Api;
using RightCRM.DataAccess.Api.BusinessApi;
using RightCRM.DataAccess.Model.BusinessModels;
using Newtonsoft.Json;
using System.Linq;
using RightCRM.Common;
using RightCRM.Facade.Helpers;

namespace RightCRM.Facade.Facades
{
    public class BusinessFacade : IBusinessFacade
    {
        readonly IBusinessApi businessApi;
        public BusinessFacade(IBusinessApi businessApi)
        {
            this.businessApi = businessApi;
        }

        public Task<GetBusinessResponseModel> GetBusiness(int pageNo)

        {
            return this.businessApi.GetBusinessList(pageNo);
        }

        public Task<AddTagsResponseModel> AddTagToBusinesses(IEnumerable<int?> accountList, string lead)
        {
            var tagRequest = new AddTagsRequestModel();

            if (accountList != null && accountList.Any())
            {
                tagRequest.account_list = JsonConvert.SerializeObject(accountList);
            }

            tagRequest.tag = lead;

            return this.businessApi.AddTagToBusiness(tagRequest);
        }


        public Task<GetBusinessResponseModel> FilterBusinesses(IEnumerable<FilterList> filterList)
        {
            var filterRequest = new GetBusinessRequestModel
            {
                srch_address_id = JsonStringFromList(filterList, Constants.AddressFilter),

                srch_company_size = JsonStringFromList(filterList, Constants.CompanySizeFilter),

                srch_industry = JsonStringFromList(filterList, Constants.IndustryFilter),

                srch_annual_revenue = JsonStringFromList(filterList, Constants.RevenueFilter),

                srch_ctag = JsonStringFromList(filterList, Constants.TagsFilter),

                user_list = JsonStringFromList(filterList, Constants.SalesWorkFilter),

                user_status = JsonStringFromList(filterList, Constants.StatusFilter)
            };

            return this.businessApi.FilterBusinesses(filterRequest);
        }


        string JsonStringFromList(IEnumerable<FilterList> filterList, string filterField)
        {
            var filterString = filterList.FirstOrDefault(x => x.Heading == filterField)?
                                         .Where(x => x.IsSelected == true)?
                                         .Select(x => x.FilterName)?
                                         .ToList();

            if (filterString == null || !filterString.Any())
                return null;

            else
                return JsonConvert.SerializeObject(filterString);
        }

        public Task<IEnumerable<TagData>> GetTagsFromList(string listName)
        {
            return businessApi.GetTagsFromList(listName);
        }
    }
}