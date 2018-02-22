// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetTagsResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetTagsResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.DataAccess.Model.BusinessModels
{

    public class TagData
    {
        public string list { get; set; }
        public string parent { get; set; }
    }

    public class TagList
    {
        public int? status { get; set; }
        public string msg { get; set; }

        public string data
        {
            set
            {
                TagDataArray = JsonConvert.DeserializeObject<TagData[]>(value);
            }
        }

        public TagData[] TagDataArray { get; set; }
    }

    public class GetTagsResponseModel
    {
        public TagList list;
    }
}
