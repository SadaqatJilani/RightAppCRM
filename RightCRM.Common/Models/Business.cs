using System;
namespace RightCRM.Common.Models
{
    public class Business
    {
        public int BusinessID { get; set; }

        public string CompanyLogoURL { get; set; }

        public string CompanyName { get; set; }

        public string BusinessType { get; set; }

        public int AnnualRevenue { get; set; }

        public int CompanySize { get; set; }

        public string CompanyAddress { get; set; }

        public string IndustryType { get; set; }
    }
}
