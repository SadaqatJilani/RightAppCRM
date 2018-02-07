// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NotesModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NotesModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RightCRM.Common.Models
{
    public class NotesModel
    {
        [JsonProperty("RID")]
        public int NoteID { get; set; }

        [JsonProperty("ACNUM")]
        public int AccountNumber { get; set; }

        [JsonProperty("BUSINESS_USRID")]
        public int BusinessUserID { get; set; }

        [JsonProperty("BUSINESS_USRNAME")]
        public string BusinessUserName { get; set; }

        [JsonProperty("WORK_USRID")]
        public int WorkUserID { get; set; }

        [JsonProperty("WORK_USRNAME")]
        public string WorkUserName { get; set; }

        [JsonProperty("WHOCOMM")]
        public int WhoComm { get; set; }

        [JsonProperty("HOWCOMM")]
        public int HowComm { get; set; }

        [JsonProperty("TELRESP")]
        public int TelephoneResponse { get; set; }

        [JsonProperty("FOLLOWUP_TS")]
        public string FollowUpTimeStamp { get; set; }

        [JsonProperty("NOTE")]
        public string NoteString { get; set; }

        [JsonProperty("ATTACHMENT")]
        public string Attachment { get; set; }

        [JsonProperty("CREATED_USRID")]
        public int CreatedByID { get; set; }

        [JsonProperty("CREATED_TS")]
        public int CreatedOnTimeStamp { get; set; }


        //public string NoteComment { get; set; }

        //public string TimeStamp { get; set; }

        //public string QueryType { get; set; }

        //public string AnsType { get; set; }

        //public string ClientType { get; set; }
    }
}
