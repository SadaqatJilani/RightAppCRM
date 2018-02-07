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
                new NotesModel { BusinessUserName = "ExhibitA", NoteString="Heelloo this is a test" },
                new NotesModel { BusinessUserName="ExhibitB", NoteString="Heelloo this is a test"}
            });

#else
            return await Task.FromResult(new List<NotesModel>
            {
                new NotesModel { BusinessUserName = "ExhibitA", NoteString="Heelloo this is a test" },
                new NotesModel { BusinessUserName="ExhibitB", NoteString="Heelloo this is a test"}
            });

#endif


        }
    }
}
