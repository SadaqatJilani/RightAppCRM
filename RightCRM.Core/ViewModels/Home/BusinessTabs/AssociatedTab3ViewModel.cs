// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AssociatedTab3ViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AssociatedTab3ViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using RightCRM.Common;
using RightCRM.Common.Models;
using RightCRM.Core.Services;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels.Home.BusinessTabs
{
    public class AssociatedTab3ViewModel : BaseViewModel, IMvxViewModel<int>
    {
        private int entityID;
        readonly IBusinessFacade businessFacade;
        readonly INewBusFacade newBusFacade;
        readonly IMvxMessenger messenger;
        private ReloadTableMessage reloadTableMessage;

        public AssociatedTab3ViewModel(IMvxNavigationService navigationService,
                                       IBusinessFacade businessFacade,
                                       INewBusFacade newBusFacade,
                                       IUserDialogs userDialogs,
                                       IMvxMessenger messenger)
        {
            this.messenger = messenger;
            this.userDialogs = userDialogs;
            this.newBusFacade = newBusFacade;
            this.businessFacade = businessFacade;
            this.navigationService = navigationService;

            AssociatedEntities = new MvxObservableCollection<AssociationItemViewModel>();

            SubmitAssociationCommand = new MvxAsyncCommand(SubmitAssociation, CanSubmitNewAssoc);
            DeleteAssociationCommandInit = new MvxAsyncCommand<int>(this.DeleteAssociation);
        }

        public IMvxCommand<int> DeleteAssociationCommandInit { get; set; }

        private async Task DeleteAssociation(int index)
        {
          //  AssociatedEntities.Remove(associatedItem);

            var res = await this.businessFacade.DeleteAssociation(entityID, AssociatedEntities[index].UserID, true);

            if (res != null)
            {
                 await userDialogs.AlertAsync(res.business?.msg ?? string.Empty);

                 await LoadAssociations();

                //reloadTableMessage = new ReloadTableMessage(this);
                //messenger.Publish(reloadTableMessage);
            }
            else
            {
                await userDialogs.AlertAsync(Constants.SomethingWrong);
            }
        }

        private bool CanSubmitNewAssoc()
        {
            if (!string.IsNullOrWhiteSpace(AssociatedUsername) && !string.IsNullOrWhiteSpace(AssociatedEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task SubmitAssociation()
        {
            var res = await newBusFacade.SubmitNewBusiness(new DataAccess.Model.CreateNew.NewBusRequestModel
            {
                business_account_id = this.entityID,
                user_name = this.AssociatedUsername,
                user_email = this.AssociatedEmail,
                user_login_id = this.AssociatedEmail
            });

            if (res != null)
            {
                if (res.register?.status == 0)
                {
                    this.AssociatedUsername = string.Empty;
                    this.AssociatedEmail = string.Empty;

                    await userDialogs.AlertAsync(res.register?.msg ?? string.Empty);

                    await LoadAssociations();
                }

                else
                {
                    await userDialogs.AlertAsync(Constants.SomethingWrong);
                }
            }
        }

        private string associatedUsername;
        public string AssociatedUsername
        {
            get { return associatedUsername; }
            set { SetProperty(ref associatedUsername, value); if (value != null) { SubmitAssociationCommand.RaiseCanExecuteChanged(); } }
        }

        private string associatedEmail;
        public string AssociatedEmail
        {
            get { return associatedEmail; }
            set { SetProperty(ref associatedEmail, value); if (value != null) { SubmitAssociationCommand.RaiseCanExecuteChanged(); } }
        }

        private MvxObservableCollection<AssociationItemViewModel> associatedEntities;
        public MvxObservableCollection<AssociationItemViewModel> AssociatedEntities
        {
            get { return associatedEntities; }
            set { SetProperty(ref associatedEntities, value); }
        }

        public IMvxCommand SubmitAssociationCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            await LoadAssociations();
        }

        private async Task LoadAssociations()
        {
            Dispatcher.RequestMainThreadAction(() => { 

                AssociatedEntities.Clear();

            });

            var res = await businessFacade.GetAssociations(entityID, true);

            if (res != null)
            {
                if (res.business?.AssociationsArray == null || !res.business.AssociationsArray.Any())
                {
                    return;
                }

                foreach (var item in res.business?.AssociationsArray ?? Enumerable.Empty<AssociationModel>())
                {
                    var associationItem = new AssociationItemViewModel
                    {
                        AccountName = item.acname,
                        AccountNum = item.acnum,
                        UserID = item.usrid,
                        Username = item.usrname,
                        DeleteAssociationCommand = this.DeleteAssociationCommandInit
                    };

                    Dispatcher.RequestMainThreadAction(() => { 
                    AssociatedEntities.Add(associationItem);
                    });
                }
            }
        }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessAssociationsPage;
        }

        public void Prepare(int parameter)
        {
            entityID = parameter;
        }
    }
}
