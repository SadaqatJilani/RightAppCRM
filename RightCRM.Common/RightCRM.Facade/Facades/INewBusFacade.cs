// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INewBusFacade.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   INewBusFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using RightCRM.DataAccess.Model.CreateNew;

namespace RightCRM.Facade.Facades
{
    public interface INewBusFacade
    {
        Task<NewBusResponseModel> SubmitNewBusiness(NewBusRequestModel newBusDetails);
    }
}
