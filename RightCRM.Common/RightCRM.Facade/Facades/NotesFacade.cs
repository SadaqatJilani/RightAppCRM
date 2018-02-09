// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NotesFacade.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NotesFacade
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;
using RightCRM.DataAccess.Api.BusinessApi;
using RightCRM.DataAccess.Model.Notes;

namespace RightCRM.Facade.Facades
{
    public class NotesFacade : INotesFacade
    {
        private readonly INotesApi notesApi;

        public NotesFacade(INotesApi notesApi)
        {
            this.notesApi = notesApi;
        }

        public Task<IEnumerable<NotesModel>> GetAllNotes(int accountNum)
        {
            //  throw new NotImplementedException();

            return notesApi.GetAllNotes(accountNum);
        }

        public NotesModel GetNoteByID(int noteID)
        {
            //  throw new NotImplementedException();

            return new NotesModel();
        }

        public Task<NewNoteResponseModel> SaveNewNote(NewNoteRequestModel newNote)
        {
            return notesApi.SaveNewNote(newNote);
        }
    }
}
