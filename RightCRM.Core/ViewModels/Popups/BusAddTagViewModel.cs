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
using RightCRM.Facade.Facades;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using RightCRM.DataAccess.Model.BusinessModels;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.Common.Services;

namespace RightCRM.Core.ViewModels.Popups
{
    public class BusAddTagViewModel : BaseViewModel, IMvxViewModel<IEnumerable<BusinessItemViewModel>>
    {
        private MvxObservableCollection<PickerItem> pickerTagUser;
        private MvxObservableCollection<PickerItem> pickerSelectTag;
        private readonly IBusinessFacade businessFacade;
        private List<BusinessItemViewModel> accountList;
        private readonly IUserFacade userFacade;
        readonly IListsService listsService;

        public BusAddTagViewModel(IMvxNavigationService navigationService, 
                                  IBusinessFacade businessFacade, 
                                  IUserFacade userFacade,
                                  IUserDialogs userDialogs,
                                  IListsService listsService)
        {
            this.listsService = listsService;
            this.userDialogs = userDialogs;
            this.userFacade = userFacade;
            this.businessFacade = businessFacade;
            this.navigationService = navigationService;

            AddTagCommand = new MvxAsyncCommand(AddTagForBusiness);
        }

        private async Task AddTagForBusiness()
        {
            //  throw new NotImplementedException();
            var accNums = accountList.Select(x => x.BusinessID).ToList();

            var res = new AddTagsResponseModel();

            if (SelectedTag.Value == null)
            {
                await userDialogs.AlertAsync("Please select a tag first");
            }
            else
            {
                res = await businessFacade.AddTagToBusinesses(accNums, SelectedTag.DisplayName, selectedUser.Value);

                if (res?.lead?.status == 0)
                {
                    userDialogs.Toast(res?.lead?.msg ?? string.Empty);
                }

                else
                {
                    await userDialogs.AlertAsync(res?.lead?.msg ?? string.Empty);
                }
            }
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

        PickerItem selectedTag;
        public PickerItem SelectedTag { get { return selectedTag; } set{SetProperty(ref selectedTag, value);} }

        PickerItem selectedUser;
        public PickerItem SelectedUser { get { return selectedUser; } set{SetProperty(ref selectedUser, value);} }

        public MvxAsyncCommand AddTagCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            PickerSelectTag = new MvxObservableCollection<PickerItem>(await listsService.GetTagsFromList());
            SelectedTag = PickerSelectTag[0];

            PickerTagUser = new MvxObservableCollection<PickerItem>(await listsService.GetUsersFromList());
            SelectedUser = PickerTagUser[0];
        }

        public void Prepare(IEnumerable<BusinessItemViewModel> parameter)
        {
            accountList = new List<BusinessItemViewModel>(parameter);
        }
    }
}
