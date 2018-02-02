// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessDetailsFacade.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessDetailsFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using RightCRM.DataAccess.Api.BusinessApi;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.Facade.Facades
{
    public class BusinessDetailsFacade : IBusinessDetailsFacade
    {
        private readonly IBusinessApi businessApi;

        public BusinessDetailsFacade(IBusinessApi businessApi)
        {
            this.businessApi = businessApi;
        }

        public Task<BusDetailsResponseModel> GetBusinessDetails(int? businessID)
        {
            // throw new NotImplementedException();

            return businessApi.GetBusinessDetails(businessID);
        }
    }
}
