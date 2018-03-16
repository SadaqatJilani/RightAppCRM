// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DeleteLeadResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   DeleteLeadResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{

    public class LeadStatus
    {
        public string msg { get; set; }

        public int? status { get; set; }
        
    }
    public class DeleteLeadResponseModel
    {
        public LeadStatus lead;
    }
}
