using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.Facade.Facades
{
    public interface IBusinessFacade
    {
        IEnumerable<Business> GetBusiness();
    }
}
