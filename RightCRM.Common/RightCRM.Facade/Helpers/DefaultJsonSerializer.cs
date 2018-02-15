// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DefaultJsonSerializer.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   DefaultJsonSerializer
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.Facade.Helpers
{
    public class DefaultJsonSerializer : JsonSerializerSettings
    {
        public DefaultJsonSerializer()
        {
            NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
