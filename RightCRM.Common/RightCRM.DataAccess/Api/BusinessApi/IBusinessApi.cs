using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public interface IBusinessApi
    {
        Task<IEnumerable<Business>> GetBusinessList();
    }
}
