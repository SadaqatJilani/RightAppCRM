using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Config;
using RightCRM.DataAccess.Factories;

namespace RightCRM.DataAccess.Api
{
    public class FakeUserApi : ApiBase, IUserApi
    {
        public FakeUserApi(
            IRequestFactory requestFactory)
            : base(requestFactory)
        {
        }

        public async Task<UserSetting> GetUserProfile(string username)
        {
            UserSetting result = null;
            var url = ApiConfig.GetAllBusinesses();


#if FAKE
            result = new UserSetting() { UserName = "test", Password = "test" };

#else

            result = await this.GetApiResult<UserSetting>(url, true);

#endif


            return result;
        }
    }
}
