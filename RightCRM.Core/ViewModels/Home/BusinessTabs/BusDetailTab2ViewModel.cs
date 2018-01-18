// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailTab2ViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailTab2ViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;

namespace RightCRM.Core.ViewModels.Home
{
    public class BusDetailTab2ViewModel : BaseViewModel
    {
        public BusDetailTab2ViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            NewNoteCommand = new MvxAsyncCommand(async () => await navigationService.Navigate<AddNewNoteViewModel>());
        
        }

        public IMvxCommand NewNoteCommand { get; private set; }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessNotesPage;
        }

    }
}
