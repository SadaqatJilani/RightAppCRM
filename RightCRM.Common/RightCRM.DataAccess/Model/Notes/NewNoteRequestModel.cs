// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NewNoteRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NewNoteRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.Notes
{
    public class NewNoteRequestModel
    {
        public string ses { get; set; }
        public int? ACNUM { get; set; }
        public int? USRID { get; set; }
        public int? WHOCOMM { get; set; }
        public int? HOWCOMM { get; set; }
        public int? TELRESP { get; set; }
        public string Note { get; set; }
    }
}
