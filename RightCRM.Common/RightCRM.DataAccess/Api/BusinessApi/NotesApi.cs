// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NotesApi.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NotesApi
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public class NotesApi : INotesApi
    {
        public NotesApi()
        {
        }

        public async Task<IEnumerable<NotesModel>> GetAllNotes()
        {
            
#if FAKE
            return await Task.FromResult(new List<NotesModel>
            {
                new NotesModel { NoteUserName = "ExhibitA", NoteComment="Heelloo this is a test" },
                new NotesModel { NoteUserName="ExhibitB", NoteComment="Heelloo this is a test"}
            });

#else




#endif


        }
    }
}
