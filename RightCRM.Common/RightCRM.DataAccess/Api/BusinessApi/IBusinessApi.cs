﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public interface IBusinessApi
    {
        Task<GetBusinessResponseModel> GetBusinessList(int pageNo);

        Task<BusDetailsResponseModel> GetBusinessDetails(int? businessID);

        Task<GetBusinessResponseModel> FilterBusinesses(GetBusinessRequestModel filterRequest);
    }
}
