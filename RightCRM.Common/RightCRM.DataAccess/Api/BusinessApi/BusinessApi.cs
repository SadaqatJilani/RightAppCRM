﻿// // --------------------------------------------------------------------------------------------------------------------
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
    using RightCRM.DataAccess.Model.BusinessModels;

    public class BusinessApi : IBusinessApi
    {
        private readonly IRestService restService;
        private readonly ICacheService cacheService;

        public BusinessApi(IRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;

        }

        /// <summary>
        /// Gets the business list.
        /// </summary>
        /// <returns>The business list.</returns>
        public async Task<GetBusinessResponseModel> GetBusinessList(int pageNo)
        {

#if FAKE

            return await Task.FromResult(new GetBusinessResponseModel()
            {
                business = new BusinessList()
                {
                    DataArray = new Business[]

                    {
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"}
                    }
                }
            });

#else                  

            try
            {
                string requestUrl = ApiConfig.GetAllBusinesses();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);
                var result = await this.restService.MakeOpenRequestAsync<GetBusinessResponseModel>(
                                                                                            requestUrl,
                                                                                            HttpMethod.Post,
                                                                                            new GetBusinessRequestModel()
                                                                                            {
                                                                                                sessionid = sessionId,
                                                                                                only_saved = 0,
                                                                                                srch_pageno = pageNo,
                                                                                                srch_keywords = null,
                                                                                                srch_ctag = null,
                                                                                                srch_industry = null,
                                                                                                srch_address_id = null,
                                                                                                srch_company_size = null,
                                                                                                srch_annual_revenue = null
                                                                                            });
                return result.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }

#endif


        }


        public async Task<BusDetailsResponseModel> GetBusinessDetails(int? businessID)
        {
#if FAKE

            return await Task.FromResult(new BusDetailsResponseModel()
            {
                business = new BusInfo()
                {
                    Data = new BusinessDetails()
                    {
                        BusinessID = 101,
                        AccountName = "hey",
                        AccountType = "test",
                        AnnualRevenue = "133",
                        BusinessNTN = "93829391",
                        BusinessWebsite = "www.helloworld.com",
                        CampaignMedia = "bolwala",
                        CampaignName = "hellomoto",
                        CampaignSrc = "source",
                        CompanySize = "1000",
                        Industry = "Pharma"
                    }
                }

            });

#else
            try
            {
                string requestUrl = ApiConfig.GetBusinessDetails();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);
                var result = await this.restService.MakeOpenRequestAsync<BusDetailsResponseModel>(
                    requestUrl,
                    HttpMethod.Post,
                    new BusDetailsRequestModel()
                    {
                    session_id = sessionId, 
                    account_number= businessID
                    });

                return result.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }
#endif
        }


        public async Task<GetBusinessResponseModel> FilterBusinesses(GetBusinessRequestModel filterRequest)
        {

#if FAKE

            return await Task.FromResult(new GetBusinessResponseModel()
            {
                business = new BusinessList()
                {
                    DataArray = new Business[]

                    {
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"},
                        new Business(){ BusinessID = 101, Revenue = "1000", CompanySize="50", BusinessType="e-commerce", CompanyName = "Portal", IndustryType="Industrial"}
                    }
                }
            });

#else

            try
            {
                string requestUrl = ApiConfig.GetAllBusinesses();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);

                filterRequest.sessionid = sessionId;
                filterRequest.srch_pageno = 1;

                var result = await this.restService.MakeOpenRequestAsync<GetBusinessResponseModel>(
                                                                                            requestUrl,
                                                                                            HttpMethod.Post,
                                                                                            filterRequest);

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
