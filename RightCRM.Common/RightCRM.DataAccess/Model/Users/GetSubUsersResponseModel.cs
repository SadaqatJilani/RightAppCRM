// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetSubUsersResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetSubUsersResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.DataAccess.Model.Users
{
    public class UserData
    {
        public string usrname { get; set; }
        public int? usrid { get; set; }
    }

   public class ResStatusData
    {
        public string status { get; set; }
        public int? count { get; set; }
    }

    public class ResSvsIdData
    {
        public string svsid { get; set; }
        public int? count { get; set; }
    }

    public class ResIsAdminData
    {
        public string admin { get; set; }
        public int? count { get; set; }
    }

    public class SubUserData
    {
        public string msg { get; set; }

        public int? status { get; set; }

        public string data
        {
            set
            {
                UserDataArray = JsonConvert.DeserializeObject<UserData[]>(value);
            }
        }

        public string res_status
        {
            set
            {
                ResStatusArray = JsonConvert.DeserializeObject<ResStatusData[]>(value);
            }
        }

        public string res_svsid
        {
            set
            {
                ResSvsIdArray = JsonConvert.DeserializeObject<ResSvsIdData[]>(value);
            }
        }

        public string res_isadmin
        {
            set
            {
                ResIsAdminArray = JsonConvert.DeserializeObject<ResIsAdminData[]>(value);
            }
        }

        public UserData[] UserDataArray { get; set; }
        public ResStatusData[] ResStatusArray { get; set; }
        public ResSvsIdData[] ResSvsIdArray { get; set; }
        public ResIsAdminData[] ResIsAdminArray { get; set; }
    }

    public class GetSubUsersResponseModel
    {
        public GetSubUsersResponseModel()
        {
        }
    }
}
