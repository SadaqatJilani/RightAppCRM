// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetUsersResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetUsersResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.DataAccess.Model.Users
{
    public class EmailStatus
    {
        public string EMAIL_STATUS { get; set; }
        public int? COUNT { get; set; }
    }



    public class UserList
    {
        public string msg { get; set; }
        // OverHead Code to handle string response
        public int status { get; set; }

        public string sql_error { get; set; }

        public string industries
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

        public string adddresses
        {
            set
            {
                AddressArray = JsonConvert.DeserializeObject<address[]>(value);
            }
        }

        public string data
        {
            set
            {
                DataArray = JsonConvert.DeserializeObject<UserInfo[]>(value);
            }
        }

        public string ctag
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

        public string user_status
        {
            set
            {
                StatusArray = JsonConvert.DeserializeObject<status[]>(value);
            }
        }

        public string email_status
        {
            set
            {
                EmailStatusArray = JsonConvert.DeserializeObject<EmailStatus[]>(value);
            }
        }

        //
        public status[] StatusArray { get; set; }
        public industry[] IndustryArray { get; set; }
        public company_size[] CompanyArray { get; set; }
        public revenue[] RevenueArray { get; set; }
        public address[] AddressArray { get; set; }
        public UserInfo[] DataArray { get; set; }
        public Tags[] TagsArray { get; set; }
        public SalesWorkers[] SalesWorkersArray { get; set; }
        public EmailStatus[] EmailStatusArray { get; set; }
    }

    public class GetUsersResponseModel
    {
        public UserList individual;
    }
}
