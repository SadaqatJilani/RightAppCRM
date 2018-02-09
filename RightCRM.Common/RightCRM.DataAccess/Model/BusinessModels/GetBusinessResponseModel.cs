﻿// <auto-generated/>
// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetBusinessResponseModel.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   GetBusinessResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using RightCRM.Common.Models;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class status
    {
        public string STATUS;
        public int? COUNT;
    }
    public class industry
    {
        public string INDUSTRY;
        public int? COUNT;
    }
    public class company_size
    {
        public string COMPANY_SIZE;
        public int? COUNT;
    }
    public class revenue
    {
        public string ANNUAL_REVENUE;
        public int? COUNT;
    }
    public class address
    {
        public int? ID;
        public string REGION;
        public int COUNT;
        public city[] cities;
    }
    public class city
    {
        public int? ID;
        public string NAME;
        public int? COUNT;
    }

    public class Tags
    {
        public string CTAG;
        public int? COUNT;
    }

    public class SalesWorkers
    {
        public int? AUSRID;
        public string NAME;
        public int? COUNT;
    }

    public class BusinessList
    {
        public string msg { get; set; }
        // OverHead Code to handle string response
        public int status { get; set; }

        public string industry
        {
            set
            {
                IndustryArray = JsonConvert.DeserializeObject<industry[]>(value);
            }
        }
        public string company_size
        {
            set
            {

                CompanyArray = JsonConvert.DeserializeObject<company_size[]>(value);
            }
        }

        public string annual_revenue
        {
            set
            {
                RevenueArray = JsonConvert.DeserializeObject<revenue[]>(value);
            }
        }

        public string address
        {
            set
            {
                AddressArray = JsonConvert.DeserializeObject<address[]>(value);
            }
        }

        public string account_list
        {
            set
            {
                DataArray = JsonConvert.DeserializeObject<Business[]>(value);
            }
        }

        public string tags
        {
            set
            {
                TagsArray = JsonConvert.DeserializeObject<Tags[]>(value);
            }
        }

        public string sales_workers
        {
            set
            {
                SalesWorkersArray = JsonConvert.DeserializeObject<SalesWorkers[]>(value);
            }
        }

        //
        public status[] StatusArray { get; set; }
        public industry[] IndustryArray { get; set; }
        public company_size[] CompanyArray { get; set; }
        public revenue[] RevenueArray { get; set; }
        public address[] AddressArray { get; set; }
        public Business[] DataArray { get; set; }
        public Tags[] TagsArray { get; set; }
        public SalesWorkers[] SalesWorkersArray { get; set; }
    }


    public class GetBusinessResponseModel
    {
        public BusinessList business;
    }
}
