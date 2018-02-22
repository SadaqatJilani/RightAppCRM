// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="JsonSettings.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   JsonSettings
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.Common.Helpers
{
    public class JsonSettings : JsonSerializerSettings
    {
        public JsonSettings()
        {
            NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
