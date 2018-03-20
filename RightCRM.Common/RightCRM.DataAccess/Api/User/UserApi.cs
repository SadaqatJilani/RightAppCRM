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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using RightCRM.Common;
    using RightCRM.Common.Models;
    using RightCRM.Common.Services;
    using RightCRM.DataAccess.Config;
    using RightCRM.DataAccess.Factories;
    using RightCRM.DataAccess.Model.RequestModels;
    using RightCRM.DataAccess.Model.ResponseModels;
    using RightCRM.DataAccess.Model.Users;

    /// <summary>
    /// User API.
    /// </summary>
    public class UserApi : IUserApi
    {
        /// <summary>
        /// The rest service.
        /// </summary>
        private readonly IRestService restService;
        private readonly ICacheService cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.DataAccess.Api.User.UserApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        public UserApi(IRestService restService, ICacheService cacheService)
        {
            this.cacheService = cacheService;
            this.restService = restService;
        }

        public async Task<IEnumerable<UserData>> GetSubUsers(GetSubUsersRequestModel userFilters)
        {
#if FAKE
            return await Task.FromResult(new GetSubUsersResponseModel());

#else
            try
            {
                string requestUrl = ApiConfig.GetSubUsers();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);

                userFilters.session_id = sessionId;
                userFilters.page_no = 1;

                var result = await this.restService.MakeOpenRequestAsync<GetSubUsersResponseModel>(
                                                                                            requestUrl,
                                                                                            HttpMethod.Post,
                                                                                            userFilters);
                return result?.Content?.user?.UserDataArray;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }


#endif
        }

        public async Task<IEnumerable<UserInfo>> GetUserList(GetUsersRequestModel userFilters)
        {
#if FAKE
            return await Task.FromResult(new List<UserInfo>(){
                new UserInfo(){ UserID = 23, UserName = "Alfred" },
                new UserInfo(){ UserID = 24, UserName = "Batman" },
                new UserInfo(){ UserID = 25, UserName = "Superman" },
                new UserInfo(){ UserID = 26, UserName = "Spongbob" },
            });

#else
            try
            {
                string requestUrl = ApiConfig.GetUsers();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);

                userFilters.sessionid = sessionId;

                var result = await this.restService.MakeOpenRequestAsync<GetUsersResponseModel>(
                                                                                            requestUrl,
                                                                                            HttpMethod.Post,
                                                                                            userFilters);
                return result?.Content?.individual?.DataArray;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }


#endif

        }

        /// <summary>
        /// Gets the user session identifier.
        /// </summary>
        /// <returns>The user session identifier.</returns>
        /// <param name="userLogin">User login.</param>
        public async Task<ResponseUserLogin> GetUserSessionId(RequestUserLogin userLogin)
        {

#if FAKE

            return await Task.FromResult(new ResponseUserLogin(){

                user = new User()
                {
                    sesid = "101", 
                    msg= Constants.LoginSuccessString,
                    status=0,
                    userid=userLogin.loginid,
                    username = userLogin.loginid, 
                    agreement_req = null
                }
            });
#else

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

#endif

        }
    }
}
