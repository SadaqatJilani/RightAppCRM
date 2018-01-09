using System;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Api;

namespace RightCRM.Facade.Facades
{
    public class UserFacade : IUserFacade
    {
        public Task<UserSetting> GetUserProfile(string username)
        {
            throw new NotImplementedException();
        }
    }
}
