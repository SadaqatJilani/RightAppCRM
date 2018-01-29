// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NotesModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NotesModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Common.Models
{
    public class NotesModel
    {
        public NotesModel()
        {
        }

        public int NoteUserID { get; set; }

        public string NoteUserName { get; set; }

        public string NoteComment { get; set; }

        public string TimeStamp { get; set; }

        public string QueryType { get; set; }

        public string AnsType { get; set; }

        public string ClientType { get; set; }
    }
}
