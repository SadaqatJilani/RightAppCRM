// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SearchItemViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   SearchItemViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Core.ViewModels.ItemViewModels
{
    public class SearchItemViewModel : BaseViewModel
    {
        string rID;
        public string RID
        {
            get { return rID; }
            set { SetProperty(ref rID, value); }
        }

        string searchName;
        public string SearchName
        {
            get { return searchName; }
            set { SetProperty(ref searchName, value); }
        }

    }
}
