// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ResponseData.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   ResponseData
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model
{
    public class ResponseData<T>
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public T Content { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public ResponseStatus Status { get; set; }
    }
}
