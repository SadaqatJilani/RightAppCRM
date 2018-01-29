// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ErrorResult.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   ErrorResult
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.DataAccess.Factories
{
    /// <summary>
    /// Error result.
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        ///     Gets or sets the status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        ///     Gets or sets the status description.
        /// </summary>
        public string StatusDescription { get; set; }
    }
}
