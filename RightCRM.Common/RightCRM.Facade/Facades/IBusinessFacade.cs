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

        Business GetBusinessByID(int businessId);

        void AddBusiness(Common.Models.Business business);

        IEnumerable<Common.Models.Business> SearchBusiness(string firstCriteria);

        Task<GetBusinessResponseModel> FilterBusinesses(IEnumerable<FilterList> filterList);
    }
}
