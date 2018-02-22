// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IUserFacade.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   IUserFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.Facade.Facades
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RightCRM.Common.Models;
    using RightCRM.DataAccess.Model.RequestModels;
    using RightCRM.DataAccess.Model.ResponseModels;
    using RightCRM.DataAccess.Model.Users;

    /// <summary>
    /// User facade.
    /// </summary>
    public interface IUserFacade
    {
        /// <summary>
        /// Gets the user session identifier.
        /// </summary>
        /// <returns>The user session identifier.</returns>
        /// <param name="userLogin">User login.</param>
        Task<ResponseUserLogin> GetUserSessionId(RequestUserLogin userLogin);

        Task<IEnumerable<UserInfo>> GetAllUsers(GetUsersRequestModel userFilters);
    }
}
