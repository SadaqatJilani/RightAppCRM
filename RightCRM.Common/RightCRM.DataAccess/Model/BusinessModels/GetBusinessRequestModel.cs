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
        public bool only_saved_accounts { get; set; }
        public int srch_pageno { get; set; }
        public string srch_keywords { get; set; }
        public string srch_address_id { get; set; }
        public string srch_industry { get; set; }
        public string srch_company_size { get; set; }
        public string srch_annual_revenue { get; set; }
        public string srch_ctag { get; set; }
    }
}
