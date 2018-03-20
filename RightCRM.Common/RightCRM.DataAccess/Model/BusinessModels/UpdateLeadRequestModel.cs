// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="UpdateLeadRequestModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   UpdateLeadRequestModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.DataAccess.Model.BusinessModels
{
    public class UpdateLeadRequestModel
    {
        public string session_id { get; set; }
        public string lead_id { get; set; }
        public string ctag { get; set; }
        public int? business_account_number { get; set; }
        public int? work_userid { get; set; }
        public int? individual_userid { get; set; }
    //"lead_id": "rid",
    //"ctag": "ctag",
    //"business_account_number": "acnum",
    //"work_userid": "workUserID",
    //"individual_userid": "usrID"
    }
}
