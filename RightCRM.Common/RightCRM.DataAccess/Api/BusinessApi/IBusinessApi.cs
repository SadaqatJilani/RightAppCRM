using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public interface IBusinessApi
    {
        Task<GetBusinessResponseModel> GetBusinessList(int pageNo);

        Task<BusDetailsResponseModel> GetBusinessDetails(int? businessID);

        Task<GetBusinessResponseModel> FilterBusinesses(GetBusinessRequestModel filterRequest, int pageNo);

        Task<AddTagsResponseModel> AddTagToBusiness(AddTagsRequestModel requestedTags);

        Task<IEnumerable<TagData>> GetTagsFromList(string listName);

        Task<SaveSearchResponseModel> SaveSearchFilters(SaveSearchRequestModel selectedFilters);

        Task<GetSearchesResponseModel> GetSavedSearches(GetSearchesRequestModel saveSearchParams);

        Task<GetAssociationsResponseModel> GetAssociations(GetAssociationsRequestModel accountRequest);

        Task<GetLeadsResponseModel> GetLeads(GetLeadsRequestModel accountRequest);

        Task<DeleteAssociationResponseModel> DeleteAssociation(DeleteAssociationRequestModel associationToBeDeleted);

		Task<DeleteLeadResponseModel> DeleteLead(DeleteLeadRequestModel deleteLeadRequestModel);

        Task<UpdateLeadResponseModel> UpdateLead(UpdateLeadRequestModel updateLeadRequestModel);
	}
}
