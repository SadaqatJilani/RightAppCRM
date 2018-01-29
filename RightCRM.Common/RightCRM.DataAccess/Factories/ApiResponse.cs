// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ApiResponse.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   ApiResponse
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Factories
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public T Content { get; set; }

        /// <summary>
        /// Gets or sets the content status.
        /// </summary>
        /// <value>The content status.</value>
        public ResponseContentStatus ContentStatus { get; set; }

        /// <summary>
        /// Gets or sets the error response.
        /// </summary>
        /// <value>The error response.</value>
        public ErrorResult ErrorResponse { get; set; }
    }
}
