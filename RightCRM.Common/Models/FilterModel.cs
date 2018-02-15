// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FilterModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   FilterModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Common.Models
{
    public class FilterModel
    {
        public string SectionName
        {
            get;
            set;
        }
        public string FilterName
        {
            get;
            set;
        }
        public int Count
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }
    }
}
