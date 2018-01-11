using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Api;

namespace RightCRM.Facade.Facades
{
    public class BusinessFacade : IBusinessFacade
    {
        readonly IBusinessApi businessApi;
        public BusinessFacade(IBusinessApi businessApi)
        {
            this.businessApi = businessApi;
        }

        public IEnumerable<Business> GetBusiness()
        {
            return  this.businessApi.GetBusinessList();
        }

        public void AddBusiness(Business business)
        {
            this.businessApi.GetBusinessList();
        }

        public Business GetBusinessByID(int businessId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Business> SearchBusiness(string firstCriteria)
        {
            throw new NotImplementedException();
        }
    }
}
