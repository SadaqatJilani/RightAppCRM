// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NewBusFacade.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NewBusFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using RightCRM.DataAccess.Api.BusinessApi;
using RightCRM.DataAccess.Model.CreateNew;

namespace RightCRM.Facade.Facades
{
    public class NewBusFacade : INewBusFacade
    {
        private readonly INewBusApi newBusApi;

        public NewBusFacade(INewBusApi newBusApi)
        {
            this.newBusApi = newBusApi;
        }

        public Task<NewBusResponseModel> SubmitNewBusiness(NewBusRequestModel newBusDetails)
        {
            return newBusApi.CreateNewBusiness(newBusDetails);
        }
    }
}
