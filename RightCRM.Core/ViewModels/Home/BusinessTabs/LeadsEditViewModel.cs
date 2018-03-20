// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsEditViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsEditViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Common.Models;
using RightCRM.Common.Services;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.DataAccess.Model.BusinessModels;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels.Home.BusinessTabs
{
    public class LeadsEditViewModel : BaseViewModel, IMvxViewModel<LeadsItemViewModel, bool>
    {
        readonly IBusinessFacade businessFacade;
        private LeadsItemViewModel leadItem;
        readonly IUserFacade userFacade;
        readonly IListsService listsService;

        public LeadsEditViewModel(IMvxNavigationService navigationService,
                                  IBusinessFacade businessFacade,
                                  IUserDialogs userDialogs,
                                  IUserFacade userFacade,
                                  IListsService listsService)
        {
            this.listsService = listsService;
            this.userFacade = userFacade;
            this.userDialogs = userDialogs;
            this.businessFacade = businessFacade;
            this.navigationService = navigationService;

            DeleteLeadCommand = new MvxAsyncCommand(DeleteLead);
            SaveLeadCommand = new MvxAsyncCommand(SaveLead);
        }

        private PickerItem selectedTag;
        public PickerItem SelectedTag
        {
            get { return selectedTag; }
            set { SetProperty(ref selectedTag, value); }
        }

        private PickerItem selectedBusUser;
        public PickerItem SelectedBusUser
        {
            get { return selectedBusUser; }
            set { SetProperty(ref selectedBusUser, value); }
        }

        private PickerItem selectedWorkUser;
        public PickerItem SelectedWorkUser
        {
            get { return selectedWorkUser; }
            set { SetProperty(ref selectedWorkUser, value); }
        }

        private MvxObservableCollection<PickerItem> pickerLeadTag;
        public MvxObservableCollection<PickerItem> PickerLeadTag
        {
            get { return pickerLeadTag; }
            set { SetProperty(ref pickerLeadTag, value); }
        }

        private MvxObservableCollection<PickerItem> pickerBusinessUser;
        public MvxObservableCollection<PickerItem> PickerBusinessUser
        {
            get { return pickerBusinessUser; }
            set { SetProperty(ref pickerBusinessUser, value); }
        }

        private MvxObservableCollection<PickerItem> pickerWorkUser;
        public MvxObservableCollection<PickerItem> PickerWorkUser
        {
            get { return pickerWorkUser; }
            set { SetProperty(ref pickerWorkUser, value); }
        }

        public IMvxCommand DeleteLeadCommand { get; private set; }
        public IMvxCommand SaveLeadCommand { get; private set; }

        private async Task SaveLead()
        {
            var res = await businessFacade.UpdateLead(new UpdateLeadRequestModel()
            {
                business_account_number = leadItem.AccountNumber,
                ctag = SelectedTag.DisplayName,
                lead_id = leadItem.RID,
                work_userid = SelectedWorkUser.Value,
                individual_userid = SelectedBusUser.Value
            });

            if (res != null)
            {
                await userDialogs.AlertAsync(res.lead?.msg ?? string.Empty);

                if (res.lead?.status == 0)
                {
                    await navigationService.Close(this, true);
                }
            }
            else
            {
                await userDialogs.AlertAsync(Constants.SomethingWrong);
            }
        }

        private async Task DeleteLead()
        {
            var res = await businessFacade.DeleteLead(leadItem.WorkUserID.GetValueOrDefault(), leadItem.RID, true);

            if (res != null)
            {
                await userDialogs.AlertAsync(res.lead?.msg ?? string.Empty);

                if (res.lead?.status == 0)
                {
                    await navigationService.Close(this, true);
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

            PickerLeadTag = new MvxObservableCollection<PickerItem>(await listsService.GetTagsFromList());
            SelectedTag = PickerLeadTag.FirstOrDefault(x => x.DisplayName == leadItem.CTag) ?? PickerLeadTag[0];

            PickerBusinessUser = new MvxObservableCollection<PickerItem>(await listsService.GetAssociationsFromList(leadItem.AccountNumber.GetValueOrDefault()));
            SelectedBusUser = PickerBusinessUser.FirstOrDefault(x => x.Value == leadItem.AssignedToUserID) ?? PickerBusinessUser[0];

            PickerWorkUser = new MvxObservableCollection<PickerItem>(await listsService.GetUsersFromList());
            SelectedWorkUser = PickerWorkUser.FirstOrDefault(x => x.Value == leadItem.WorkUserID) ?? PickerWorkUser[0];
		}

		public TaskCompletionSource<object> CloseCompletionSource { get; set; }

		public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessEditLeadsPage;
        }

		public void Prepare(LeadsItemViewModel parameter)
        {
            leadItem = parameter;
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }
}
