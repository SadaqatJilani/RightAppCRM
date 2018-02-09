// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NoteListResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NoteListResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Model.Notes
{

    public class NotesList
    {
        public string msg { get; set; }

        public string data
        {
            set
            {
                DataArray = JsonConvert.DeserializeObject<NotesModel[]>(value);
            }
        }

        public NotesModel[] DataArray { get; private set; }
    }

    public class NoteListResponseModel
    {
        public NotesList note;
    }
}
