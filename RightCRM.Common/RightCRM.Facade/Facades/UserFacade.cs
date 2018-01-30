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
    using RightCRM.Common;
    using RightCRM.Common.Models;
    using RightCRM.Common.Services;
    using RightCRM.DataAccess.Api;
    using RightCRM.DataAccess.Model.RequestModels;
    using RightCRM.DataAccess.Model.ResponseModels;

    /// <summary>
    /// User facade.
    /// </summary>
    public class UserFacade : IUserFacade
    {
        /// <summary>
        /// The cache service.
        /// </summary>
        private readonly ICacheService cacheService;

        /// <summary>
        /// The user API.
        /// </summary>
        private readonly IUserApi userApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Facade.Facades.UserFacade"/> class.
        /// </summary>
        /// <param name="userApi">User API.</param>
        public UserFacade(IUserApi userApi, ICacheService cacheService)
        {
            this.userApi = userApi;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Gets the user session identifier.
        /// </summary>
        /// <returns>The user session identifier.</returns>
        /// <param name="userLogin">User login.</param>
        public async Task<ResponseUserLogin> GetUserSessionId(RequestUserLogin userLogin)
        {
            var res = await this.userApi.GetUserSessionId(userLogin);

            if (res != null)
                await cacheService.SaveSettings<string>(Constants.SessionID, res.user?.sesid);

            return res;
        }
    }
}
