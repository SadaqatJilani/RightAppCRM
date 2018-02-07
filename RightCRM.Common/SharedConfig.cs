// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SharedConfig.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SharedConfig
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Common
{
    public static class SharedConfig
    {

        /// <summary>
        /// Gets the right crm API root.
        /// </summary>
        /// <value>The right crm API root.</value>
        //public static string RightCrmApiRoot { get => "http://18.221.200.133:8083/api/"; }

        public static string RightCrmApiRoot { get => "http://dev.rightcrm.zepto.work:8083/api/"; }

        /// <summary>
        /// Gets the right API authentication root.
        /// </summary>
        /// <value>The right API authentication root.</value>
        //public static string RightApiAuthenticationRoot{ get => "http://18.216.31.46:8081/api/"; }

        public static string RightApiAuthenticationRoot { get => "http://dev.rightaccount.zepto.work:8081/api/"; }
    }
}
