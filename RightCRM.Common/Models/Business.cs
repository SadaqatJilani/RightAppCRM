using System;
using Newtonsoft.Json;

namespace RightCRM.Common.Models
{
    public class Business
    {
        [JsonProperty("ACNUM")]
        public int BusinessID { get; set; }

        public string CompanyLogoURL { get; set; }

        [JsonProperty("ACNAME")]
        public string CompanyName { get; set; }

        [JsonProperty("ACTYPE")]
        public string BusinessType { get; set; }

        [JsonProperty("REVENUE")]
        public int AnnualRevenue { get; set; }

        [JsonProperty("SIZE")]
        public int CompanySize { get; set; }

        public string CompanyAddress { get; set; }

        [JsonProperty("INDUSTRY")]
        public string IndustryType { get; set; }
    }
}
