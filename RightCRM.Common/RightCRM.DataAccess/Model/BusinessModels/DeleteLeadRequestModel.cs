// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DeleteLeadRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   DeleteLeadRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class DeleteLeadRequestModel
    {
        public string sessionid { get; set; }
        public int? user_id { get; set; }
        public string tag_id { get; set; }
    }
}
