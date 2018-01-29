// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IRestService.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   IRestService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.DataAccess.Factories
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Rest service.
    /// </summary>
    public interface IRestService
    {
       /// <summary>
       /// Makes the open request async.
       /// </summary>
       /// <returns>The open request async.</returns>
       /// <param name="requestUrl">Request URL.</param>
       /// <param name="verb">Verb param.</param>
       /// <param name="requestbody">Request body.</param>
       /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
       /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<ApiResponse<T>> MakeOpenRequestAsync<T>(string requestUrl, HttpMethod verb, string requestbody = "", bool failSilent = false);
    }
}
