// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsEditViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsEditViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Common.Models;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels.Home.BusinessTabs
{
    public class LeadsEditViewModel : BaseViewModel, IMvxViewModel<LeadsItemViewModel, bool>
    {
        readonly IBusinessFacade businessFacade;
        private LeadsItemViewModel leadItem;
        readonly IUserFacade userFacade;

        public LeadsEditViewModel(IMvxNavigationService navigationService,
                                  IBusinessFacade businessFacade,
                                  IUserDialogs userDialogs,
                                  IUserFacade userFacade)
        {
            this.userFacade = userFacade;
            this.userDialogs = userDialogs;
            this.businessFacade = businessFacade;
            this.navigationService = navigationService;

            DeleteLeadCommand = new MvxAsyncCommand(DeleteLead);
        }

        private PickerItem selectedTag;
        public PickerItem SelectedTag
        {
            get { return selectedTag; }
            set { SetProperty(ref selectedTag, value); }
        }

        private MvxObservableCollection<PickerItem> pickerLeadTag;
        public MvxObservableCollection<PickerItem> PickerLeadTag
        {
            get { return pickerLeadTag; }
            set { SetProperty(ref pickerLeadTag, value); }
        }

        private string leadTag;
        public string LeadTag
        {
            get { return leadTag; }
            set { SetProperty(ref leadTag, value); }
        }

        private string businessUser;
        public string BusinessUser
        {
            get { return businessUser; }
            set { SetProperty(ref businessUser, value); }
        }

        private string workUser;
        public string WorkUser
        {
            get { return workUser; }
            set { SetProperty(ref workUser, value); }
        }

        public IMvxCommand DeleteLeadCommand { get; private set; }

        private async Task DeleteLead()
        {
            var res = await businessFacade.DeleteLead(leadItem.WorkUserID, leadItem.RID, true);

            if (res != null)
            {
                await userDialogs.AlertAsync(res.lead?.msg ?? string.Empty);

                if (res.lead?.status == 0)
                {
                    await navigationService.Close<bool>(this, true);
                }
            }
            else
            {
                await userDialogs.AlertAsync(Constants.SomethingWrong);
            }
        }

		public override async Task Initialize()
		{
            await base.Initialize();

            PickerLeadTag = new MvxObservableCollection<PickerItem>(await GetTagsFromList());
            SelectedTag = PickerLeadTag.FirstOrDefault(x=> x.DisplayName == leadItem.CTag);
		}

		public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        async Task<IEnumerable<PickerItem>> GetTagsFromList()
        {
            var tagList = new List<PickerItem>
            {
                new PickerItem() { DisplayName = "Select Tag", Value = 0 }
            };

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
            var tagList = new List<PickerItem>
            {
                new PickerItem() { DisplayName = "Select User to Assign Tag", Value = 0 }
            };

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
                    Value = res.ElementAt(i).UserID.GetValueOrDefault()
                };

                tagList.Add(tagItem);
            }

            return tagList;
        }


        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessEditLeadsPage;
        }

		public void Prepare(LeadsItemViewModel parameter)
        {
            leadItem = parameter;

            LeadTag = leadItem.CTag;
            BusinessUser = leadItem.AssignedToUsername;
            WorkUser = leadItem.WorkUsername;
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }
}
