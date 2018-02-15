// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailsResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailsResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class BusInfo
    {
        public string msg { get; set; }

        public string sql_error { get; set; }
        // OverHead Code to handle string response
        public string status { get; set;  }

        public string account_data
        {
            set
            {
                Data = JsonConvert.DeserializeObject<BusinessDetails>(value);
            }
        }
        //

        public BusinessDetails Data { get; set; }
    }


    public class BusDetailsResponseModel
    {
        public BusInfo business;
    }
}
