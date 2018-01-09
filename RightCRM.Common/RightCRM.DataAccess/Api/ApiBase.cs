// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ApiBase.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   ApiBase
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Connectivity;
using RightCRM.DataAccess.Factories;

namespace RightCRM.DataAccess.Api
{
    public class ApiBase
    {
        /// <summary>
        /// The request factory.
        /// </summary>
        protected readonly IRequestFactory RequestFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.DataAccess.Api.ApiBase"/> class.
        /// </summary>
        /// <param name="requestFactory">Request factory.</param>
        public ApiBase(
            IRequestFactory requestFactory)
        {
            this.RequestFactory = requestFactory;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:GPK.DataAccess.Api.ApiBase"/> is internet connection.
        /// </summary>
        /// <value><c>true</c> if is internet connection; otherwise, <c>false</c>.</value>
        protected bool IsInternetConnection
        {
            get
            {
                if (!CrossConnectivity.IsSupported)
                {
                    return true;
                }

                return CrossConnectivity.Current.IsConnected;
            }
        }

        /// <summary>
        /// Gets the API result.
        /// </summary>
        /// <returns>The API result.</returns>
        /// <param name="url">The URL.</param>
        /// <param name="saveToCache">If set to <c>true</c> save to cache.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected virtual async Task<T> GetApiResult<T>(string url, bool saveToCache = false)
        {
            var request = this.RequestFactory.Create(url);
            var result = await request.GetAsync<T>();

            if (result.Status == Model.ResponseStatus.Success)
            {
                if (saveToCache)
                {
                    await this.SaveToCache(url, result.Content);
                }

                return result.Content;
            }

            var exception = new Exception($"Api Error: {result.Message}");
           // this.analyticsService.TrackException(exception);
            throw exception;
        }

        /// <summary>
        /// Saves to cache.
        /// </summary>
        /// <returns>The to cache.</returns>
        /// <param name="url">The URL.</param>
        /// <param name="result">The Result.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected virtual async Task SaveToCache<T>(string url, T result)
        {
            try
            {
              //  await this.CacheService.InsertObject(url, result);
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"Error saving cache object with key {url}");
#endif
               // this.analyticsService.TrackException(ex);
            }
        }
    }
}
