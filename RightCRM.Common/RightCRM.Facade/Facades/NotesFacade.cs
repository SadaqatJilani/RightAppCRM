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

namespace RightCRM.Facade.Facades
{
    public class NotesFacade : INotesFacade
    {
        private readonly INotesApi notesApi;

        public NotesFacade(INotesApi notesApi)
        {
            this.notesApi = notesApi;
        }

        public void AddNewNote(NotesModel newNote)
        {
            //throw new NotImplementedException();
        }

        public Task<IEnumerable<NotesModel>> GetAllNotes()
        {
            //  throw new NotImplementedException();

            return notesApi.GetAllNotes();
        }

        public NotesModel GetNoteByID(int noteID)
        {
            //  throw new NotImplementedException();

            return new NotesModel();
        }
    }
}
