// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FilterItemViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   FilterItemViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace RightCRM.Core.ViewModels.ItemViewModels
{
    public class FilterItemViewModel : BaseViewModel
    {
        public FilterItemViewModel()
        {
        }

        int filterID;
        public int FilterID
        {
            get { return filterID; }
            set { SetProperty(ref filterID, value); }
        }

        string sectionName;
        public string SectionName
        {
            get{ return sectionName; }
            set{SetProperty(ref sectionName, value);}
        }

        string filterName;
        public string FilterName
        {
            get { return filterName; }
            set{SetProperty(ref filterName, value);}
        }

        int count;
        public int Count
        {
            get { return count; }
            set { SetProperty(ref count, value); }
        }

        bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set {SetProperty(ref isSelected, value);}
        }
    }
}
