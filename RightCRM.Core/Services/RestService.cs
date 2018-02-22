// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RestService.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   RestService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.Core.Services
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using RightCRM.DataAccess.Factories;
    using Acr.UserDialogs;
    using RightCRM.Common.Helpers;

    /// <summary>
    /// Rest service.
    /// </summary>
    public class RestService : IRestService
    {
        private readonly IUserDialogs userDialogs;

        public RestService(IUserDialogs userDialogs)
        {
            this.userDialogs = userDialogs;
        }

        /// <summary>
        /// The get error result.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ErrorResult> GetErrorResult(HttpResponseMessage result)
        {
            try
            {
                var responseString = await result.Content.ReadAsStringAsync();
                var errorMessage = JsonConvert.DeserializeObject<string>(responseString);

                var errorResponse = new ErrorResult()
                {
                    StatusCode = (int)result.StatusCode,
                    StatusDescription = errorMessage
                };

                return errorResponse;
            }
            catch (Exception e)
            {
                Debug.WriteLine("SimpleRestService PostAsync Exception: {0}", e.Message);
                return new ErrorResult() { StatusCode = 500, StatusDescription = "Internal error occurred" };
            }
        }

        /// <summary>
        /// The get status code.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetStatusCode(string response)
        {
            try
            {
                var errorResult = JsonConvert.DeserializeObject<ErrorResult>(response);
                return errorResult.StatusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine("SimpleRestService PostAsync Exception: {0}", e.Message);
                return 500;
            }
        }

        /// <summary>
        /// Makes the open request async.
        /// </summary>
        /// <returns>The open request async.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">Verb param.</param>
        /// <param name="requestBody">Request body.</param>
        /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<ApiResponse<T>> MakeOpenRequestAsync<T>(string requestUrl, HttpMethod verb, object requestBody, bool failSilent = false)
        {
            userDialogs.ShowLoading();

            var responseData = new ApiResponse<T>();
            HttpResponseMessage result = null;
            using (var client = new HttpClient(new HttpClientHandler()))
            {

                client.Timeout = TimeSpan.FromSeconds(20);

                try
                {
                    var request = new HttpRequestMessage { Method = verb };
                    request.RequestUri = new Uri(requestUrl);
                    request.Headers.Add("Accept", "application/json");
                    var jsonRequest = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                    if (verb == HttpMethod.Post)
                    {
                        result = await client.PostAsync(requestUrl, jsonRequest);
                    }
                    else if (verb == HttpMethod.Get)
                    {
                        result = await client.SendAsync(request).ConfigureAwait(false);
                    }

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        responseData.ContentStatus = ResponseContentStatus.OK;
                        var responseString = await result.Content.ReadAsStringAsync();
                        responseData.Content = JsonConvert.DeserializeObject<T>(responseString, new JsonSettings());
                    }
                    else
                    {
                        // TODO: Efficient Error Handling needs to be done, plus network connectivity checking also needs to be incorporated.
                        responseData.ContentStatus = ResponseContentStatus.Fail;
                        responseData.ErrorResponse = new ErrorResult() { StatusCode = (int)HttpStatusCode.NotFound, StatusDescription = "Something went wrong" };
                    }

                    return responseData;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("SimpleRestService PostAsync Exception: {0}", e.Message);
                    if (result != null)
                    {
                        responseData.ErrorResponse = await this.GetErrorResult(result);
                    }
                    else
                    {
                        responseData.ErrorResponse = new ErrorResult() { StatusCode = 500, StatusDescription = "Something went wrong, Please contact admin" };
                    }

                    responseData.ContentStatus = ResponseContentStatus.Fail;

                    userDialogs.HideLoading();
                    await userDialogs.AlertAsync(responseData.ErrorResponse.StatusDescription);

                    return responseData;
                }

                finally
                {
                    userDialogs.HideLoading();
                }
            }
        }
    }
}
