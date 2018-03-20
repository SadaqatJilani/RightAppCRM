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

        public Task<AddTagsResponseModel> AddTagToBusinesses(IEnumerable<int?> accountList, string tagText, int? workerID = null)
        {
            var tagRequest = new AddTagsRequestModel();

            if (accountList != null && accountList.Any())
            {
                tagRequest.business_list = JsonConvert.SerializeObject(accountList);
            }

            tagRequest.tag = tagText;
            tagRequest.worker_userid = workerID;

            return this.businessApi.AddTagToBusiness(tagRequest);
        }


        public Task<GetBusinessResponseModel> FilterBusinesses(GetBusinessRequestModel filterRequestModel, int pageNo)
        {
            return this.businessApi.FilterBusinesses(filterRequestModel, pageNo);
        }

        public Task<IEnumerable<TagData>> GetTagsFromList(string listName)
        {
            return businessApi.GetTagsFromList(listName);
        }

        public Task<SaveSearchResponseModel> SaveSearchFilters(SaveSearchRequestModel selectedFilters)
        {
            return businessApi.SaveSearchFilters(selectedFilters);
        }

        public Task<GetSearchesResponseModel> GetSavedSearches()
        {
            return businessApi.GetSavedSearches(new GetSearchesRequestModel());
        }

        public Task<GetAssociationsResponseModel> GetAssociations(int entityID, bool isBusiness)
        {
            if (isBusiness)
            {
                return businessApi.GetAssociations(new GetAssociationsRequestModel()
                {
                    business_account_number = entityID
                });
            }
            else
            {
                return businessApi.GetAssociations(new GetAssociationsRequestModel()
                {
                    user_account_id = entityID
                });
            }
        }

        public Task<GetLeadsResponseModel> GetLeads(int entityID, bool isBusiness)
        {
            if (isBusiness)
            {
                return businessApi.GetLeads(new GetLeadsRequestModel
                {
                    business_account_number = entityID
                });
            }
            else
            {
                return businessApi.GetLeads(new GetLeadsRequestModel
                {
                    user_id = entityID
                });
            }
        }

        public Task<DeleteAssociationResponseModel> DeleteAssociation(int entityID, int? associationID, bool isBusiness)
        {
            if (isBusiness)
            {
                return businessApi.DeleteAssociation(new DeleteAssociationRequestModel
                {
                    business_account_number = entityID,
                    user_account_id = associationID
                });
            }
            else
            {
                return businessApi.DeleteAssociation(new DeleteAssociationRequestModel
                {
                    business_account_number = entityID,
                    user_account_id = associationID
                });
            }
        }

        public Task<DeleteLeadResponseModel> DeleteLead(int userID, string tagID, bool isBusiness)
        {
            return businessApi.DeleteLead(new DeleteLeadRequestModel
            {
                user_id = userID,
                tag_id = tagID
            });
        }

        public Task<UpdateLeadResponseModel> UpdateLead(UpdateLeadRequestModel updateLeadRequestModel)
        {
            return businessApi.UpdateLead(updateLeadRequestModel);
        }
    }
}