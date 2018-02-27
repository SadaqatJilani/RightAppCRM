// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessItemViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessItemViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Core.ViewModels.ItemViewModels
{
    public class BusinessItemViewModel : BaseViewModel
    {
        private int? businessID;
        public int? BusinessID { get { return businessID; } set { SetProperty(ref businessID, value); } }

        private string companyName;
        public string CompanyName { get { return companyName; } set { SetProperty(ref companyName, value); } }

        private string businessType;
        public string BusinessType { get { return businessType; } set { SetProperty(ref businessType, value); } }

        private string industryType;
        public string IndustryType { get { return industryType; } set { SetProperty(ref industryType, value); } }

        private string companySize;
        public string CompanySize { get { return companySize; } set { SetProperty(ref companySize, value); } }

        private string revenue;
        public string Revenue { get { return revenue; } set { SetProperty(ref revenue, value); } }

        private int? aDD_ID;
        public int? ADD_ID { get { return aDD_ID; } set { SetProperty(ref aDD_ID, value); } }

        private bool isSelected;
        public bool IsSelected { get { return isSelected; } set { SetProperty(ref isSelected, value); } }
    }
}
