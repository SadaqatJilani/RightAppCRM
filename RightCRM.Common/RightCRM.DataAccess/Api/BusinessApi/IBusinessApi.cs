using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.BusinessModel;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public interface IBusinessApi
    {
        Task<GetBusinessResponseModel> GetBusinessList();
    }
}
