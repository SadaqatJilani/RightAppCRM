// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RightCrmRequest.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   RightCrmRequest
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;

namespace RightCRM.DataAccess.Model
{
    public class RightCrmRequest : IRequest
    {
        /// <summary>
        /// The URL.
        /// </summary>
        private readonly string url;

        public 
        RightCrmRequest(string url)
        {
            this.url = url;
        }

        public async Task<ResponseData<T>> GetAsync<T>()
        {
            var result = await this.MakeOpenBaseRequestAsync<T>(HttpMethod.Get);

            return result;
        }

        public async Task<ResponseData<T>> PostAsync<T>()
        {
            var result = await this.MakeOpenBaseRequestAsync<T>(HttpMethod.Post);

            return result;
        }

        public async Task<ResponseData<string>> PostAsync(IEnumerable<KeyValuePair<string, string>> postData)
        {
            var result = await this.PostOpenBaseRequestAsync(postData);

            return result;
        }

        /// <summary>
        /// Posts the open base request async.
        /// </summary>
        /// <returns>The open base request async.</returns>
        /// <param name="postData">Post data.</param>
        private async Task<ResponseData<string>> PostOpenBaseRequestAsync(IEnumerable<KeyValuePair<string, string>> postData)
        {
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
#if DEBUG
                Debug.WriteLine($"Perform Open HTTP POST async: {url}");
#endif
                var content = new FormUrlEncodedContent(postData);

                var responseData = new ResponseData<string>();
                HttpResponseMessage result = null;

                try
                {
                    result = await client.PostAsync(this.url, content).ConfigureAwait(false);
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        var responseString = await result.Content.ReadAsStringAsync();
                        responseData.Status = ResponseStatus.Success;
                        responseData.Content = responseString.Substring(1, responseString.Length - 2);
                    }
                    else
                    {
                        responseData.Status = ResponseStatus.Fail;
                        responseData.Message = await result.Content.ReadAsStringAsync();
                    }

#if DEBUG
                    Debug.WriteLine($"Finished Perform OPEN HTTP POST async: {url}");
#endif

                    return responseData;
                }
                catch (Exception exception)
                {
#if DEBUG
                    Debug.WriteLine("{0} PostAsync Exception: {1}", this.GetType().Name, exception.Message);
#endif
                    responseData.Message = exception.Message;
                    responseData.Status = ResponseStatus.Fail;

                    return responseData;
                }
            }
        }


        /// <summary>
        /// Makes the open base request async.
        /// </summary>
        /// <returns>The open base request async.</returns>
        /// <param name="verb">The Verb.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private async Task<ResponseData<T>> MakeOpenBaseRequestAsync<T>(HttpMethod verb)
        {
            var responseData = new ResponseData<T>();
            HttpResponseMessage result = null;

#if DEBUG
            Debug.WriteLine($"Perform open HTTP {verb.Method} request async: {this.url}");
#endif

            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                //if (this.isAuthenticated)
                //{
                //    this.AddAuthorizationHeader(client);
                //}

                var request = new HttpRequestMessage { Method = verb };

                request.RequestUri = new Uri(this.url);
                request.Headers.Add("accept", "application/json");

                try
                {
                    if (typeof(T) == typeof(byte[]))
                    {
                        var bytes = await client.GetByteArrayAsync(this.url);
                        if (bytes == null)
                        {
                            responseData.Status = ResponseStatus.Fail;
                        }
                        else
                        {
                            responseData.Status = ResponseStatus.Success;
                            T val = (T)Convert.ChangeType(bytes, typeof(T));
                            responseData.Content = val;
                        }

                        return responseData;
                    }

                    result = await client.SendAsync(request).ConfigureAwait(false);

#if DEBUG
                    Debug.WriteLine($"Finished open HTTP {verb.Method} request async: {this.url}");
#endif

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        var responseString = await result.Content.ReadAsStringAsync();
                        responseData.Status = ResponseStatus.Success;
                        responseData.Content = JsonConvert.DeserializeObject<T>(responseString);
                    }
                    else
                    {
                        responseData.Status = ResponseStatus.Fail;
                        var errorMsg = "Oops, something went wrong.";
                        if (result.StatusCode == HttpStatusCode.SwitchingProtocols || result.StatusCode == HttpStatusCode.Continue)
                        {
                            errorMsg = "Try to reconnect or refresh the page";
                        }
                        else if (result.StatusCode == HttpStatusCode.Moved || result.StatusCode == HttpStatusCode.NotModified)
                        {
                            errorMsg = "Try to reconnect or refresh the page";
                        }
                        else if (result.StatusCode == HttpStatusCode.InternalServerError || result.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            errorMsg = "Service Unavailable";
                        }

                        responseData.Message = errorMsg;
                    }

                    return responseData;
                }
                catch (Exception exception)
                {
#if DEBUG
                    Debug.WriteLine(
                        "{1} {2} MakeOpenBaseRequestAsync Exception: {0}",
                        exception.Message,
                        this.url,
                        this.GetType().Name);
#endif
                    responseData.Message = exception.Message;
                    responseData.Status = ResponseStatus.Fail;

                    return responseData;
                }
            }
        }
    }
}
