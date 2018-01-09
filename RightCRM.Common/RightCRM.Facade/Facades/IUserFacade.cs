using System;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.Facade.Facades
{
    public interface IUserFacade
    {
        Task<UserSetting> GetUserProfile(string username);
    }
}
