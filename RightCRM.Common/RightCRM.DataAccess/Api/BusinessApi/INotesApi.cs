// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INotesApi.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   INotesApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.Notes;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public interface INotesApi
    {
        Task<IEnumerable<NotesModel>> GetAllNotes(int accountNum);

        Task<NewNoteResponseModel> SaveNewNote(NewNoteRequestModel newNote);
    }
}
