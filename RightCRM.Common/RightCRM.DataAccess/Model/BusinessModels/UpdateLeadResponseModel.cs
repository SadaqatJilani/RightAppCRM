// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="UpdateLeadResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   UpdateLeadResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class UpdateLeadInfo
    {
        public int? status { get; set; }

        public string msg { get; set; }

        public string sql_error { get; set; }
    }
    
    public class UpdateLeadResponseModel
    {
        public UpdateLeadInfo lead;
    }
}
