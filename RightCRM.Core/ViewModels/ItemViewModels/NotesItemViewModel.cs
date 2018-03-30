// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NotesItemViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   NotesItemViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.ItemViewModels
{
    public class NotesItemViewModel : MvxViewModel
    {
        string noteID;
        public string NoteID { get { return noteID; } set { SetProperty(ref noteID, value); } }

        private int? accountNumber;
        public int? AccountNumber { get { return accountNumber; } set { SetProperty(ref accountNumber, value); } }

        private int? businessUserID;
        public int? BusinessUserID { get { return businessUserID; } set { SetProperty(ref businessUserID, value); } }

        private string businessUserName;
        public string BusinessUserName { get { return businessUserName; } set { SetProperty(ref businessUserName, value); } }

        private int? workUserID;
        public int? WorkUserID { get { return workUserID; } set { SetProperty(ref workUserID, value); } }

        private string workUserName;
        public string WorkUserName { get { return workUserName; } set { SetProperty(ref workUserName, value); } }

        private int? whoComm;
        public int? WhoComm { get { return whoComm; } set { SetProperty(ref whoComm, value); } }

        private int? howComm;
        public int? HowComm { get { return howComm; } set { SetProperty(ref howComm, value); } }

        private int? telephoneResponse;
        public int? TelephoneResponse { get { return telephoneResponse; } set { SetProperty(ref telephoneResponse, value); } }

        private DateTime? followUpTimeStamp;
        public DateTime? FollowUpTimeStamp { get { return followUpTimeStamp; } set { SetProperty(ref followUpTimeStamp, value); } }

        private string noteString;
        public string NoteString { get { return noteString; } set { SetProperty(ref noteString, value); } }

        private string attachment;
        public string Attachment { get { return attachment; } set { SetProperty(ref attachment, value); } }

        private int? createdByID;
        public int? CreatedByID { get { return createdByID; } set { SetProperty(ref createdByID, value); } }

        private DateTime? createdOnTimeStamp;
        public DateTime? CreatedOnTimeStamp { get { return createdOnTimeStamp; } set { SetProperty(ref createdOnTimeStamp, value); } }
    }
}
