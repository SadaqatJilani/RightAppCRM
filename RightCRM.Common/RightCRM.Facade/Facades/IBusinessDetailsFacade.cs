// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IBusinessDetailsFacade.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   IBusinessDetailsFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using RightCRM.DataAccess.Model.BusinessModels;

namespace RightCRM.Facade.Facades
{
    public interface IBusinessDetailsFacade
    {
        Task<BusDetailsResponseModel> GetBusinessDetails(int? businessID);
    }
}
