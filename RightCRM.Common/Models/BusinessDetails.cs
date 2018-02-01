// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessDetails.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessDetails
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Common.Models
{
    public class BusinessDetails
    {
        public int? BusinessID { get; set; }

        public string AccountName { get; set; }

        public string AccountType { get; set; }

        public string BusinessNTN { get; set; }

        public string BusinessWebsite { get; set; }

        public string Industry { get; set; }

        public int? AnnualRevenue { get; set; }

        public string CompanySize { get; set; }

        public string CampaignName { get; set; }

        public string CampaignSrc { get; set; }

        public string CampaignMedia { get; set; }
    }
}
