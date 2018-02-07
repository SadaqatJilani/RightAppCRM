// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessDetails.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessDetails
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.Common.Models
{
    public class BusinessDetails
    {
        public int? BusinessID { get; set; }

        [JsonProperty("ACNAME")]
        public string AccountName { get; set; }


        public string AccountType { get; set; }

        [JsonProperty("NTN")]
        public string BusinessNTN { get; set; }

        [JsonProperty("WEBSITE")]
        public string BusinessWebsite { get; set; }

        [JsonProperty("INDUSTRY")]
        public string Industry { get; set; }

        [JsonProperty("ANNUAL_REVENUE")]
        public string AnnualRevenue { get; set; }

        [JsonProperty("COMPANY_SIZE")]
        public string CompanySize { get; set; }

        public string CampaignName { get; set; }

        public string CampaignSrc { get; set; }

        public string CampaignMedia { get; set; }
    }
}
