// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NewBusRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NewBusRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.CreateNew
{
    public class NewBusRequestModel
    {
        public string sessionid { get; set; }

        public int? user_id { get; set; }
        public string user_email { get; set; }
        public string user_login_id { get; set; }
        public string user_name { get; set; }
        public int? business_account_id { get; set; }
        public string business_account_name { get; set; }
        public string business_account_type { get; set; }
        public string business_account_industry { get; set; }
        public string business_account_company_size { get; set; }
        public string business_account_annual_revenue { get; set; }
        public string campaign_nam { get; set; }
        public string campaign_med { get; set; }
        public string campaign_src { get; set; }


        //"user_id":(params.user_id == undefined? null:params.user_id),
        //"user_email":(params.email == undefined? null:params.email), 
        //"user_login_id":(params.email == undefined? null:params.email), 
        //"user_name":(params.username == undefined? null:params.username),
        //"business_account_id":(params.business_id == undefined? null:params.business_id),
        //"business_account_name":(params.acname == undefined? null:params.acname),
        //"business_account_type":(params.actype == undefined? null:params.actype),
        //"business_account_industry":(params.industry == undefined? null:params.industry),
        //"business_account_company_size":(params.company_size == undefined? null:params.company_size),
        //"business_account_annual_revenue":(params.revenue == undefined? null:params.revenue),
        //"campaign_nam":(params.campaign_name == undefined? null:params.campaign_name), 
        //"campaign_med":(params.campaign_med == undefined? null:params.campaign_med),
        //"campaign_src":(params.campaign_src == undefined? null:params.campaign_src)
    }
}
