// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ModelUserLogin.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   ModelUserLogin
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.RequestModels
{
    public class RequestUserLogin
    {
        public string loginid { get; set; }
        public string token { get; set; }
        public string svsid { get; set; }

    }
}
