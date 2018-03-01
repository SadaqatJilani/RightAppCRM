using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.Facade.Facades
{
    public interface IBusinessFacade
    {
        Task<GetBusinessResponseModel> GetBusiness(int pageNo);

        Task<GetBusinessResponseModel> FilterBusinesses(GetBusinessRequestModel filterRequestModel, int pageNo);

        Task<AddTagsResponseModel> AddTagToBusinesses(IEnumerable<int?> accountList, string tagText, int? workerUserID = null);

        Task<IEnumerable<TagData>> GetTagsFromList(string listName);

        Task<SaveSearchResponseModel> SaveSearchFilters(SaveSearchRequestModel selectedFilters);

        Task<GetSearchesResponseModel> GetSavedSearches();

    }
}
