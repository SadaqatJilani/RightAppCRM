using System;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Api
{
    public class FakeUserApi : IUserApi
    {
        public FakeUserApi()
        {
        }

        public Task<UserSetting> GetUserProfile(string username)
        {
            throw new NotImplementedException();
        }
    }
}
