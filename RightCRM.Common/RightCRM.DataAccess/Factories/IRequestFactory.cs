// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IRequestFactory.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   IRequestFactory
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using RightCRM.DataAccess.Model;

namespace RightCRM.DataAccess.Factories
{
    public interface IRequestFactory
    {
        /// <summary>
        /// Create the specified url.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="url">The URL.</param>
        IRequest Create(string url);
    }
}
