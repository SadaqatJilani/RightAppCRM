// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="UserApi.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   UserApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.DataAccess.Api.User
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using RightCRM.DataAccess.Config;
    using RightCRM.DataAccess.Factories;
    using RightCRM.DataAccess.Model.RequestModels;
    using RightCRM.DataAccess.Model.ResponseModels;

    /// <summary>
    /// User API.
    /// </summary>
    public class UserApi : IUserApi
    {
        /// <summary>
        /// The rest service.
        /// </summary>
        private readonly IRestService restService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.DataAccess.Api.User.UserApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        public UserApi(IRestService restService)
        {
            this.restService = restService;
        }

        /// <summary>
        /// Gets the user session identifier.
        /// </summary>
        /// <returns>The user session identifier.</returns>
        /// <param name="userLogin">User login.</param>
        public async Task<ResponseUserLogin> GetUserSessionId(RequestUserLogin userLogin)
        {
            try
            {
                string requestUrl = ApiConfig.GetUserSessionId();
                var result = await this.restService.MakeOpenRequestAsync<ResponseUserLogin>(
                                                                                            requestUrl,
                                                                                            HttpMethod.Post,
                                                                                            userLogin);
                return result.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }
        }
    }
}
