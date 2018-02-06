// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NewBusResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NewBusResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.CreateNew
{
    public class Registration
    {
        public string msg { get; set; }

        public int status { get; set; }

    }


    public class NewBusResponseModel
    {
        public Registration registration;
    }
}
