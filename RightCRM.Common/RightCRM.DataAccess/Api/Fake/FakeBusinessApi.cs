using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Api
{
    public class FakeBusinessApi : IBusinessApi
    {
        public FakeBusinessApi()
        {
        }

        public IEnumerable<Business> GetBusinessList()
        {
            return new List<Business>()
            {
                new Business(){CompanyName="Company Name",BusinessType="Business Type",AnnualRevenue=10000,CompanySize=500},
                new Business(){CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){CompanyName="Zepto Systems Ltd",BusinessType="Local Software",AnnualRevenue=10000,CompanySize=500},
            };
        }
    }
}
