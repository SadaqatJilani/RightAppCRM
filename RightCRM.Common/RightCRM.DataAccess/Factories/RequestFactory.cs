// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RequestFactory.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   RequestFactory
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using RightCRM.DataAccess.Model;

namespace RightCRM.DataAccess.Factories
{
    /// <summary>
    /// Request factory.
    /// </summary>
    public class RequestFactory : IRequestFactory
    {
        /// <summary>
        /// Create the specified url.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="url">URL.</param>
        public IRequest Create(string url)
        {
            var result = new RightCrmRequest(url);

            return result;
        }
    }
}
