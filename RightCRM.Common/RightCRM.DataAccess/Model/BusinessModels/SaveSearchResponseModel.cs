// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SaveSearchResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SaveSearchResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class SavedSearchModel
    {
        public string msg { get; set; }

        public int? status { get; set; }
    }

    public class SaveSearchResponseModel
    {
        public SavedSearchModel business;
    }
}
