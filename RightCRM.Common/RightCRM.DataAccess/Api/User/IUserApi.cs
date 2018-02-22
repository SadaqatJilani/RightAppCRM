// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IUserApi.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   IUserApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.DataAccess.Api
{
    using System;
    using System.Threading.Tasks;
    using RightCRM.Common.Models;
    using RightCRM.DataAccess.Model.RequestModels;
    using RightCRM.DataAccess.Model.ResponseModels;
    using RightCRM.DataAccess.Model.Users;
    using System.Collections.Generic;

    /// <summary>
    /// User API.
    /// </summary>
    public interface IUserApi
    {
        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        /// <param name="userLogin">User login.</param>
        Task<ResponseUserLogin> GetUserSessionId(RequestUserLogin userLogin);

        Task<IEnumerable<UserInfo>> GetUserList(GetUsersRequestModel userFilters);
    }
}
