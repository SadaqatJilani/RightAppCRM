// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NewNoteResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NewNoteResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.Notes
{
    public class NewNote
    {
        public string msg { get; set; }
    }

    public class NewNoteResponseModel
    {
        public NewNote note;
    }
}
