// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="UserFacade.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   UserFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.Facade.Facades
{
    using System;
    using System.Threading.Tasks;
    using RightCRM.Common.Models;
    using RightCRM.DataAccess.Api;
    using RightCRM.DataAccess.Model.RequestModels;
    using RightCRM.DataAccess.Model.ResponseModels;

    /// <summary>
    /// User facade.
    /// </summary>
    public class UserFacade : IUserFacade
    {
        /// <summary>
        /// The user API.
        /// </summary>
        private readonly IUserApi userApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Facade.Facades.UserFacade"/> class.
        /// </summary>
        /// <param name="userApi">User API.</param>
        public UserFacade(IUserApi userApi)
        {
            this.userApi = userApi;     
        }

        /// <summary>
        /// Gets the user session identifier.
        /// </summary>
        /// <returns>The user session identifier.</returns>
        /// <param name="userLogin">User login.</param>
        public async Task<ResponseUserLogin> GetUserSessionId(RequestUserLogin userLogin)
        {
            return await this.userApi.GetUserSessionId(userLogin);
        }
    }
}
