// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessApi.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   BusinessApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessApi.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   BusinessApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.DataAccess.Api.BusinessApi
{
    using System;
    using RightCRM.Common.Models;
    using System.Collections.Generic;
    using RightCRM.DataAccess.Factories;
    using RightCRM.DataAccess.Config;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using System.Net.Http;
    using RightCRM.DataAccess.Model.Business;
    using RightCRM.Common.Services;
    using RightCRM.Common;

    public class BusinessApi : IBusinessApi
    {
        private readonly IRestService restService;
        private readonly ICacheService cacheService;
        public BusinessApi(IRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
           
        }

        public async Task<IEnumerable<Business>> GetBusinessList()
        {

#if FAKE

            return await Task.FromResult(new List<Business>
            {
                new Business(){ BusinessID = 101, AnnualRevenue = 1000, CompanySize=50, BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                new Business(){ BusinessID = 101, AnnualRevenue = 1000, CompanySize=50, BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                new Business(){ BusinessID = 101, AnnualRevenue = 1000, CompanySize=50, BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                new Business(){ BusinessID = 101, AnnualRevenue = 1000, CompanySize=50, BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                new Business(){ BusinessID = 101, AnnualRevenue = 1000, CompanySize=50, BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                new Business(){ BusinessID = 101, AnnualRevenue = 1000, CompanySize=50, BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                new Business(){ BusinessID = 101, AnnualRevenue = 1000, CompanySize=50, BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"}
            });

#else                  

            try
            {
                string requestUrl = ApiConfig.GetAllBusinesses();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);
                var result = await this.restService.MakeOpenRequestAsync<IEnumerable<Business>>(
                                                                                            requestUrl,
                                                                                            HttpMethod.Post,
                    JsonConvert.SerializeObject(new GetBusinessRequestModel()
                    {
                        sessionid = sessionId

                    }));
                return result.Content;
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
