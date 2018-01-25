// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AddNewNoteViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AddNewNoteViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RightCRM.Common;

namespace RightCRM.Core.ViewModels.Home
{
    public class AddNewNoteViewModel : BaseViewModel
    {
        ObservableCollection<string> pickerItems = new ObservableCollection<string>() { "item1", "item2", "item3" };

        public AddNewNoteViewModel()
        {
        }

        public ObservableCollection<string> PickerItems
        {
            get
            {
                return pickerItems;
            }
            set
            {
                SetProperty(ref pickerItems, value);
            }
        }

        public string SelectedItem { get; set; }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleCreateNewNotePage;
        }
    }
}
