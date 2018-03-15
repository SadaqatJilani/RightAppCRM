// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DeleteAssociationRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   DeleteAssociationRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class DeleteAssociationRequestModel
    {
        public string sessionid { get; set; }
        public int? business_account_number { get; set; }
        public int? user_account_id { get; set; }
    }
}
