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

namespace RightCRM.Facade.Facades
{
    public class NotesFacade : INotesFacade
    {
        public NotesFacade()
        {
        }

        public void AddNewNote(NotesModel newNote)
        {
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<NotesModel>> GetAllNotes()
        {
          //  throw new NotImplementedException();

            return await Task.FromResult( new List<NotesModel>
            {
                new NotesModel { NoteUserName = "ExhibitA", NoteComment="Heelloo this is a test" },
                new NotesModel { NoteUserName="ExhibitB", NoteComment="Heelloo this is a test"}
            });
        }

        public NotesModel GetNoteByID(int noteID)
        {
            //  throw new NotImplementedException();

            return new NotesModel();
        }
    }
}
