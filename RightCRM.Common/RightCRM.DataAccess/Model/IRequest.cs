// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IRequest.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   IRequest
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RightCRM.DataAccess.Model
{
    public interface IRequest
    {
        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<ResponseData<T>> GetAsync<T>();

        /// <summary>
        /// Posts the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<ResponseData<T>> PostAsync<T>();

        /// <summary>
        /// Posts the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="postData">Post data.</param>
        Task<ResponseData<string>> PostAsync(IEnumerable<KeyValuePair<string, string>> postData);
    }
}
