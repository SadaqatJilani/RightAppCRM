// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailsRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailsRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class BusDetailsRequestModel
    {
        public string session_id { get; set; }
        public int? account_number { get; set; }
    }
}
