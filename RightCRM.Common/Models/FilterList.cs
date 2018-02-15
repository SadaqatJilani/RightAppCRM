// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FilterList.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   FilterList
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace RightCRM.Common.Models
{
    public class FilterList : List<FilterModel>
    {
        public string Heading { get; set; }

        public FilterList(IEnumerable<FilterModel> collection) : base(collection)
        {
            this.Heading = collection.FirstOrDefault()?.SectionName;
        }
 
    }
}
