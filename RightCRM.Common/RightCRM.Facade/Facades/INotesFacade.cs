// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INotesFacade.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   INotesFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Model.Notes;

namespace RightCRM.Facade.Facades
{
    public interface INotesFacade
    {
        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>The all notes.</returns>
        Task<IEnumerable<NotesModel>> GetAllNotes(int accountNum);

        /// <summary>
        /// Gets the note by identifier.
        /// </summary>
        /// <returns>The note by identifier.</returns>
        /// <param name="noteID">Note identifier.</param>
        NotesModel GetNoteByID(int noteID);

        /// <summary>
        /// Adds the new note.
        /// </summary>
        /// <param name="newNote">New note.</param>
        Task<NewNoteResponseModel> SaveNewNote(NewNoteRequestModel newNote);
    }
}
