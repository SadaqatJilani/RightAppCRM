// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Common.Models
{
    public class LeadsModel
    {
        public string RID { get; set; }
        public int? WORK_USRID { get; set; }
        public string WORK_USRNAME { get; set; }
        public int? ACNUM { get; set; }
        public string BUSINESS { get; set; }
        public int? USRID { get; set; }
        public string USRNAME { get; set; }
        public string CTAG { get; set; }
    }
}
