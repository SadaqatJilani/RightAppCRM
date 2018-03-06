// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AssociatedTab3ViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AssociatedTab3ViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using System.Threading.Tasks;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.Facade.Facades;
using System.Linq;
using RightCRM.DataAccess.Model.BusinessModels;
using MvvmCross.Core.Navigation;
using RightCRM.Common.Models;

namespace RightCRM.Core.ViewModels.Home.BusinessTabs
{
    public class AssociatedTab3ViewModel : BaseViewModel, IMvxViewModel<int>
    {
        private int businessID;
        readonly IBusinessFacade businessFacade;

        public AssociatedTab3ViewModel(IMvxNavigationService navigationService, IBusinessFacade businessFacade)
        {
            this.businessFacade = businessFacade;
            this.navigationService = navigationService;

            AssociatedEntities = new MvxObservableCollection<AssociationItemViewModel>();
        }

        private string associatedUsername;
        public string AssociatedUsername
        {
            get { return associatedUsername; }
            set { SetProperty(ref associatedUsername, value); }
        }

        private string associatedEmail;
        public string AssociatedEmail
        {
            get { return associatedEmail; }
            set { SetProperty(ref associatedEmail, value); }
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

            var res = await businessFacade.GetAssociations(businessID, true);

            if (res != null)
            {
                foreach(var item in res.business?.AssociationsArray ?? Enumerable.Empty<AssociationModel>())
                {
                    AssociatedEntities.Add(new AssociationItemViewModel
                    {
                        AccountName = item.acname,
                        AccountNum = item.acnum,
                        UserID = item.usrid,
                        Username = item.usrname
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
            businessID = parameter;
        }
    }
}
