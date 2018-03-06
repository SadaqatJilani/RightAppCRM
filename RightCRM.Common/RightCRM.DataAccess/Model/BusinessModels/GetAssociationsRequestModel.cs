// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetAssociationsRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetAssociationsRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class GetAssociationsRequestModel
    {
        public string sessionid { get; set; }
        public int? business_account_number { get; set; }
        public int? user_account_id { get; set; }
    }
}
