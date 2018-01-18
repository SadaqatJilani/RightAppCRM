// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AddNewNoteViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AddNewNoteViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using RightCRM.Common;

namespace RightCRM.Core.ViewModels.Home
{
    public class AddNewNoteViewModel : BaseViewModel
    {
        public AddNewNoteViewModel()
        {
        }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleCreateNewNotePage;
        }
    }
}
