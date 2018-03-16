// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AssociationItemViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AssociationItemViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.ItemViewModels
{
    public class AssociationItemViewModel : BaseViewModel
    {
        private int accountNum;
        public int AccountNum { get { return accountNum; } set{SetProperty(ref accountNum, value);}}

        private string accountName;
        public string AccountName { get { return accountName; } set { SetProperty(ref accountName, value); } }

        private int userID;
        public int UserID { get { return userID; } set { SetProperty(ref userID, value); } }

        private string username;
        public string Username { get { return username; } set { SetProperty(ref username, value); } }

        public IMvxCommand<AssociationItemViewModel> DeleteAssociationCommand { get; set; }
    }
}
