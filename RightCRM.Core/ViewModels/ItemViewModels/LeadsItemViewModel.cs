// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsItemViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsItemViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.ItemViewModels
{
    public class LeadsItemViewModel : MvxViewModel
    {
        private string rID;
        public string RID
        {
            get { return rID; }
            set { SetProperty(ref rID, value); }
        }

        private int? workUserID;
        public int? WorkUserID
        {
            get { return workUserID; }
            set { SetProperty(ref workUserID, value); }
        }

        private string workUsername;
        public string WorkUsername
        {
            get { return workUsername; }
            set { SetProperty(ref workUsername, value); }
        }

        private string businessName;
        public string BusinessName
        {
            get { return businessName; }
            set { SetProperty(ref businessName, value); }
        }

        private string assignedToUsername;
        public string AssignedToUsername
        {
            get { return assignedToUsername; }
            set { SetProperty(ref assignedToUsername, value); }
        }

        private string cTag;
        public string CTag
        {
            get { return cTag; }
            set { SetProperty(ref cTag, value); }
        }
    }
}
