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

namespace RightCRM.Core.ViewModels.Popups
{
    public class BusAddTagViewModel : BaseViewModel, IMvxViewModel<IEnumerable<Business>>
    {
        private MvxObservableCollection<PickerItem> pickerTagUser;
        private MvxObservableCollection<PickerItem> pickerSelectTag;
        private readonly IBusinessFacade businessFacade;
        private List<Business> accountList;
        private readonly IUserFacade userFacade;

        public BusAddTagViewModel(IMvxNavigationService navigationService, 
                                  IBusinessFacade businessFacade, 
                                  IUserFacade userFacade,
                                  IUserDialogs userDialogs)
        {
            this.userDialogs = userDialogs;
            this.userFacade = userFacade;
            this.businessFacade = businessFacade;
            this.navigationService = navigationService;

            AddTagCommand = new MvxAsyncCommand(AddTagForBusiness);
        }

        private async Task AddTagForBusiness()
        {
            //  throw new NotImplementedException();
            var accNums = accountList.Select(x => x.BusinessID);

            var res = new AddTagsResponseModel();

            if (SelectedTag.Value == 0)
            {
                await userDialogs.AlertAsync("Please select a tag first");
            }
            else
            {
                res = await businessFacade.AddTagToBusinesses(accNums, SelectedTag.DisplayName);
                await userDialogs.AlertAsync(res?.lead?.msg ?? string.Empty);
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

            PickerSelectTag = new MvxObservableCollection<PickerItem>(await GetTagsFromList());
            SelectedTag = PickerSelectTag[0];

            PickerTagUser = new MvxObservableCollection<PickerItem>(await GetUsersFromList());
            SelectedUser = PickerTagUser[0];
        }

        async Task<IEnumerable<PickerItem>> GetTagsFromList()
        {
            var tagList = new List<PickerItem>();

            tagList.Add(new PickerItem() { DisplayName = "Select Tag", Value = 0 });

            var res = await businessFacade.GetTagsFromList("ctag");

            if (res == null || !res.Any())
                return tagList;


            for (int i = 0; i < res.Count(); i++)
            {
                var tagItem = new PickerItem
                {
                    DisplayName = res.ElementAt(i).list,
                    Value = i + 1
                };

                tagList.Add(tagItem);
            }

            return tagList;
        }

        async Task<IEnumerable<PickerItem>> GetUsersFromList()
        {
            var tagList = new List<PickerItem>();

            tagList.Add(new PickerItem() { DisplayName = "Select User to Assign Tag", Value = 0 });

            var res = await userFacade.GetAllUsers(new DataAccess.Model.Users.GetUsersRequestModel()
            {
                page_no = 1
            });

            if (res == null || !res.Any())
                return tagList;


            for (int i = 0; i < res.Count(); i++)
            {
                var tagItem = new PickerItem
                {
                    DisplayName = res.ElementAt(i).UserName,
                    Value = i + 1
                };

                tagList.Add(tagItem);
            }

            return tagList;
        }


        public void Prepare(IEnumerable<Business> parameter)
        {
            accountList = new List<Business>(parameter);
        }
    }
}
