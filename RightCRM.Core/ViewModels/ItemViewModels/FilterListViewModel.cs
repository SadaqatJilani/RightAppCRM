// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FilterListViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   FilterListViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.ItemViewModels
{
    public class FilterListViewModel : List<FilterItemViewModel>
    {
        public FilterListViewModel(IEnumerable<FilterItemViewModel> collection) : base(collection)
        {
            this.Heading = collection.FirstOrDefault()?.SectionName;
        }

        public string Heading { get; set; }
    }
}
