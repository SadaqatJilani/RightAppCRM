using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Api
{
    public interface IBusinessApi
    {
        IEnumerable<Business> GetBusinessList();
    }
}
