// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetLeadsRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetLeadsRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class GetLeadsRequestModel
    {
        public string sessionid { get; set; }
        public int? user_id { get; set; }
        public int? business_account_number { get; set; }
    }
}
