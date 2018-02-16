// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusAddTagViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusAddTagViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using System.Threading.Tasks;

namespace RightCRM.Core.ViewModels.Popups
{
    public class BusAddTagViewModel : BaseViewModel
    {
        private MvxObservableCollection<PickerItem> pickerTagUser;
        private MvxObservableCollection<PickerItem> pickerSelectTag;

        public BusAddTagViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            PickerSelectTag = new MvxObservableCollection<PickerItem>();
            PickerTagUser = new MvxObservableCollection<PickerItem>();
        }


        public MvxObservableCollection<PickerItem> PickerSelectTag
        {
            get { return pickerSelectTag; }
            set { SetProperty(ref pickerSelectTag, value); }
        }

        public MvxObservableCollection<PickerItem> PickerTagUser
        {
            get { return pickerTagUser; }
            set { SetProperty(ref pickerTagUser, value); }
        }

        public PickerItem SelectedTag { get; set; }
        public PickerItem SelectedUser { get; set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            PickerSelectTag.Add(new PickerItem() { DisplayName = "Select Tag", Value = 0 });
            SelectedTag = PickerSelectTag[0];

            PickerTagUser.Add(new PickerItem() { DisplayName = "Select User to Assign Tag", Value = 0 });
            SelectedUser = PickerTagUser[0];
        }

    }
}
