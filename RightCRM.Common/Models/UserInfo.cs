// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="UserInfo.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   UserInfo
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.Common.Models
{
    public class UserInfo
    {
        [JsonProperty("USRID")]
        public int? UserID { get; set; }

        [JsonProperty("USRNAME")]
        public string UserName { get; set; }

        [JsonProperty("EMAIL")]
        public string EmailAddress { get; set; }

        [JsonProperty("EMAIL_STATUS")]
        public string EmailStatus { get; set; }

        [JsonProperty("STATUS")]
        public string UserStatus { get; set; }

        public bool IsSelected { get; set; }
    }
}
