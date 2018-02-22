// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AddTagsRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AddTagsRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class AddTagsRequestModel
    {
        public string session_id { get; set; }
        public string business_list { get; set; }
        public string individual_list { get; set; }
        public string tag { get; set; }
        public int? worker_userid { get; set; }
    }
}
