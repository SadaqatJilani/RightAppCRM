// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AddTagsResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AddTagsResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{

    public class TagResponse
    {
        public string msg { get; set; }

        public int? status { get; set; }

        public string sql_error { get; set; }
    }

    public class AddTagsResponseModel
    {
        public TagResponse lead;
    }
}
