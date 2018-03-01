// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetBusinessRequestModel.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   GetBusinessRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using RightCRM.Common;
using RightCRM.Common.Services;

namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class GetBusinessRequestModel
    {
        public string sessionid{ get; set; }
        public int? srch_pageno { get; set; }
        public string srch_keywords { get; set; }
        public int? only_saved { get; set; }
        public string srch_address_id { get; set; }
        public int? user_login_id { get; set; }
        public string user_status{ get; set; }
        public string campaign_name { get; set; }
        public string campaign_source { get; set; }
        public string campaign_media { get; set; }
        public string srch_industry { get; set; }
        public string srch_company_size { get; set; }
        public string srch_annual_revenue { get; set; }
        public string srch_ctag { get; set; } 
        public string user_list { get; set; } 
        public string saved_search_id { get; set; } 

        //{ sessionid:saved_search_id: null } 'hmoyssyuhijydamxrdwgnwqpjxisugfa', 
            //srch_pageno: 1, 
            //srch_keywords: null, 
            //only_saved: 0, 
            //srch_address_id: null,
            //user_login_id: null,
            //user_status: null,
            //campaign_name: null, 
            //campaign_source: null, 
            //campaign_media: null, 
            //srch_industry: '["services"]',
            //srch_company_size: '["11-50"]', 
            //srch_annual_revenue: null,
            //srch_ctag: null, 
            //user_list: null,
            //saved_search_id: null }

        //{ "sessionid" : "mryszyfeonmublchotvghjvhajloocxi", 
            //"srch_pageno" : 1, 
            //"only_saved_accounts":0,
            //"srch_keywords" : null, 
            //"srch_address_id" : null,
            //"srch_industry" : null, 
            //"srch_company_size" : null,
            //"srch_annual_revenue" : null, 
            //"srch_ctag" : null,
            //"business_status" : null, 
            //"assign_user_list" : null,
            //"campaign_nam" : null,
            //"campaign_src" : null, 
            //"campaign_med" : null }







        /////BACKUP
 //public string sessionid{ get; set; }
        //public int only_saved_accounts { get; set; }
        //public int srch_pageno { get; set; }
        //public string srch_keywords { get; set; }
        //public string srch_address_id { get; set; }
        //public string srch_industry { get; set; }
        //public string srch_company_size { get; set; }
        //public string srch_annual_revenue { get; set; }
        //public string srch_ctag { get; set; }
        //public string business_status { get; set; }
        //public string assign_user_list { get; set; }
        //public string campaign_nam { get; set; }
        //public string campaign_src { get; set; }
        //public string campaign_med { get; set; }
    }
}
