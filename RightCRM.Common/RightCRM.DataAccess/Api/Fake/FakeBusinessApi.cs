using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Api.BusinessApi;

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
                new Business(){BusinessID=101, CompanyName="Company Name",BusinessType="Business Type",AnnualRevenue=10000,CompanySize=500},
                new Business(){BusinessID=102, CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){BusinessID=103, CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){BusinessID=104, CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){BusinessID=105, CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){BusinessID=106, CompanyName="Zepto Systems Ltd",BusinessType="OffShore Software",AnnualRevenue=10000,CompanySize=500},
                new Business(){BusinessID=107, CompanyName="Zepto Systems Ltd",BusinessType="Local Software",AnnualRevenue=10000,CompanySize=500},
            };
        }
    }
}
