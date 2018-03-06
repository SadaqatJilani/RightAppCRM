// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetLeadsResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetLeadsResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Model.BusinessModels
{

    public class LeadInfo
    {
        public int? status { get; set; }
        public string msg { get; set; }

        public string data
        {
            set { LeadDataArray = JsonConvert.DeserializeObject<LeadsModel[]>(value); }
        }

        public LeadsModel[] LeadDataArray { get; set; }
    }


    public class GetLeadsResponseModel
    {
        public LeadInfo lead;
    }
}
