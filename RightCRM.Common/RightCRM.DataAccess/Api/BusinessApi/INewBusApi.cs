// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INewBusApi.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   INewBusApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using RightCRM.DataAccess.Model.CreateNew;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public interface INewBusApi
    {
        Task<NewBusResponseModel> CreateNewBusiness(NewBusRequestModel busDetails);
    }
}
