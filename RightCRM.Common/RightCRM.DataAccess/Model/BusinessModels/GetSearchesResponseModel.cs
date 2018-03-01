// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetSearchesResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetSearchesResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class SearchData
    {
        public string rid { get; set; }
        public string name { get; set; }
    }

    public class BusSearch
    {
        public string msg { get; set; }

        public int? status { get; set; }

        public string search_data
        {
            set
            {
                SearchDataArray = JsonConvert.DeserializeObject<SearchData[]>(value);
            }
        }



        public SearchData[] SearchDataArray { get; set; }
    }

    public class GetSearchesResponseModel
    {
        public BusSearch business;
    }
}
