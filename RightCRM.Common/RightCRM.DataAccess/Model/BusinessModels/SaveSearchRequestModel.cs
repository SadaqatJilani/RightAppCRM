// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SaveSearchRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SaveSearchRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class SaveSearchRequestModel
    {
        public string sessionid{ get; set; }
        public int? srch_pageno { get; set; }
        public int? only_saved_accounts { get; set; }
        public string srch_keywords { get; set; }
        public string srch_address_id { get; set; }
        public string srch_industry { get; set; }
        public string srch_company_size { get; set; }
        public string srch_annual_revenue { get; set; }
        public string srch_ctag { get; set; }
        public string business_status { get; set; }
        public string assign_user_list { get; set; }
        public string campaign_nam { get; set; }
        public string campaign_src { get; set; }
        public string campaign_med { get; set; }
        public string seved_search_name { get; set; }
    }
}
