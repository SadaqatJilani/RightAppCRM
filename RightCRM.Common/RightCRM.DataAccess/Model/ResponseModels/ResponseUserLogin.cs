// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ResponseUserLogin.cs" company="(c) Arif Imran">
// //   (c) Arif Imran
// // </copyright>
// // <summary>
// //   ResponseUserLogin
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.ResponseModels
{
    public class User
    {
        public int status { get; set; }
        public string msg { get; set; }
        public string sesid { get; set; }
        public string userid { get; set; }
        public object username { get; set; }
        public int agreement_req { get; set; }
    }
    public class ResponseUserLogin
    {
        public User user { get; set; }
    }
}
