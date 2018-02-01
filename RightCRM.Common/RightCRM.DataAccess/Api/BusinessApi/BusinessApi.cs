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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using RightCRM.Common;
    using RightCRM.Common.Models;
    using RightCRM.Common.Services;
    using RightCRM.DataAccess.Config;
    using RightCRM.DataAccess.Factories;
    using RightCRM.DataAccess.Model.BusinessModel;

    public class BusinessApi : IBusinessApi
    {
        private readonly IRestService restService;
        private readonly ICacheService cacheService;

        public BusinessApi(IRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;

        }

        public async Task<GetBusinessResponseModel> GetBusinessList()
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
                var result = await this.restService.MakeOpenRequestAsync<GetBusinessResponseModel>(
                                                                                            requestUrl,
                                                                                            HttpMethod.Post,
                                                                                            JsonConvert.SerializeObject(new GetBusinessRequestModel()
                                                                                            {
                                                                                                sessionid = sessionId,
                                                                                                only_saved_accounts = false,
                                                                                                srch_pageno = 1,
                                                                                                srch_keywords = "",
                                                                                                srch_ctag = "",
                                                                                                srch_industry = "",
                                                                                                srch_address_id = null,
                                                                                                srch_company_size = "",
                                                                                                srch_annual_revenue = ""
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
