// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NewBusApi.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NewBusApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using RightCRM.Common;
using RightCRM.Common.Services;
using RightCRM.DataAccess.Config;
using RightCRM.DataAccess.Factories;
using RightCRM.DataAccess.Model.CreateNew;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public class NewBusApi : INewBusApi
    {
        private readonly IRestService restService;
        private readonly ICacheService cacheService;

        public NewBusApi(IRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
        }

        public async Task<NewBusResponseModel> CreateNewBusiness(NewBusRequestModel busDetails)
        {

#if FAKE
            return await Task.FromResult( new NewBusResponseModel(){

                register = new Registration()
                {
                    msg = "Business Submitted Successfully",
                    status = 0
                }

            });

#else
            try
            {
                string requestUrl = ApiConfig.RegisterNewBusiness();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);
                busDetails.sessionid = sessionId;

                var result = await this.restService.MakeOpenRequestAsync<NewBusResponseModel>(
                    requestUrl,
                    HttpMethod.Post,
                    busDetails);

                return result?.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }


#endif
        }
    }
}
