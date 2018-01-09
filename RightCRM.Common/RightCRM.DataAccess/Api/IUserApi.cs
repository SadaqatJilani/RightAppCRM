using System;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Api
{
    public interface IUserApi
    {
        Task<UserSetting> GetUserProfile(string username);
    }
}
