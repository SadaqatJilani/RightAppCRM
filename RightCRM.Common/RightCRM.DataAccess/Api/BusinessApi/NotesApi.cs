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
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using RightCRM.Common;
using RightCRM.Common.Models;
using RightCRM.Common.Services;
using RightCRM.DataAccess.Config;
using RightCRM.DataAccess.Factories;
using RightCRM.DataAccess.Model.Notes;

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public class NotesApi : INotesApi
    {
        private readonly ICacheService cacheService;
        private readonly IRestService restService;

        public NotesApi(ICacheService cacheService, IRestService restService)
        {
            this.cacheService = cacheService;
            this.restService = restService;
        }


        public async Task<IEnumerable<NotesModel>> GetAllNotes(int AccountNum)
        {
            
#if FAKE
            return await Task.FromResult(new List<NotesModel>
            {
                new NotesModel { BusinessUserName = "ExhibitA", NoteString="Heelloo this is a test" },
                new NotesModel { BusinessUserName= "ExhibitB", NoteString="Heelloo this is a test"}
            });

#else
            try
            {
                string requestUrl = ApiConfig.GetAllNotes();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);
                var result = await this.restService.MakeOpenRequestAsync<NoteListResponseModel>(
                    requestUrl,
                    HttpMethod.Post,
                    new NoteListRequestModel()
                    {
                        sessionid = sessionId,
                        acnum = AccountNum
                    });

                return result.Content.note.DataArray;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }

#endif


        }

        public async Task<NewNoteResponseModel> SaveNewNote(NewNoteRequestModel newNote)
        {
#if FAKE
            return await Task.FromResult(new NewNoteResponseModel()
            {
                note = new NewNote()
                {
                    msg = "success"

                }
            });

#else
            try
            {
                string requestUrl = ApiConfig.SaveNewNote();
                string sessionId = await this.cacheService.RetrieveSettings<string>(Constants.SessionID);
                newNote.ses = sessionId;

                var result = await this.restService.MakeOpenRequestAsync<NewNoteResponseModel>(
                    requestUrl,
                    HttpMethod.Post,
                    newNote);

                return result.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }

#endif
        }
    }
}
