// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="UserApi.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   UserApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using RightCRM.DataAccess.Model.RequestModels;
using RightCRM.DataAccess.Model.ResponseModels;

namespace RightCRM.DataAccess.Api.User
{
    public class UserApi : IUserApi
    {
        public UserApi()
        {
        }

        public Task<ResponseUserLogin> GetUserSessionId(RequestUserLogin userLogin)
        {
            throw new NotImplementedException();
        }
    }
}
