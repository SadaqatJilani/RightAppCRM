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

namespace RightCRM.DataAccess.Api.BusinessApi
{
    public interface INotesApi
    {
        Task<IEnumerable<NotesModel>> GetAllNotes();
    }
}
