// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GetAssociationsResponseModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GetAssociationsResponseModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using RightCRM.Common.Models;

namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class Associations
    {
        public string msg { get; set; }
        public string sqlerr { get; set; }
        public int? status { get; set; }

        public string data
        {
            set { AssociationsArray = JsonConvert.DeserializeObject<AssociationModel[]>(value); }
        }

        public AssociationModel[] AssociationsArray { get; set; }
    }


    public class GetAssociationsResponseModel
    {
        public Associations business;
    }
}
