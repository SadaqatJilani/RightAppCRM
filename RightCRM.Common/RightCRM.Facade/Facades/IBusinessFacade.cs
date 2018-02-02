using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.Facade.Facades
{
    public interface IBusinessFacade
    {
        Task<GetBusinessResponseModel> GetBusiness();

        Business GetBusinessByID(int businessId);

        void AddBusiness(Business business);

        IEnumerable<Business> SearchBusiness(string firstCriteria);
    }
}
