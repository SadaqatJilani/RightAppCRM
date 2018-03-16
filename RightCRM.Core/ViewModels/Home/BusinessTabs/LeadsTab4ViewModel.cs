// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsTab4ViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsTab4ViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.Facade.Facades;
using System.Threading.Tasks;
using System.Linq;
using RightCRM.Common.Models;

namespace RightCRM.Core.ViewModels.Home.BusinessTabs
{
    public class LeadsTab4ViewModel : BaseViewModel, IMvxViewModel<int>
    {
        private int businessID;
        readonly IBusinessFacade businessFacade;

        public LeadsTab4ViewModel(IMvxNavigationService navigationService, IBusinessFacade businessFacade)
        {
            this.navigationService = navigationService;
            this.businessFacade = businessFacade;

            LeadsList = new MvxObservableCollection<LeadsItemViewModel>();
            LeadSelectedCommand = new MvxAsyncCommand<LeadsItemViewModel>(OpenSelectedLead);
        }

        private async Task OpenSelectedLead(LeadsItemViewModel selectedLead)
        {
           var res = await navigationService.Navigate<LeadsEditViewModel, LeadsItemViewModel, bool>(selectedLead);

            if (res == true)
            {
                await this.Initialize();
            }
        }

        private MvxObservableCollection<LeadsItemViewModel> leadsList;
        public MvxObservableCollection<LeadsItemViewModel> LeadsList
        {
            get { return leadsList; }
            set { SetProperty(ref leadsList, value); }
        }

        public IMvxCommand<LeadsItemViewModel> LeadSelectedCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            LeadsList.Clear();

            var res = await businessFacade.GetLeads(businessID, true);

            if (res != null)
            {
                foreach(var item in res.lead?.LeadDataArray ?? Enumerable.Empty<LeadsModel>())
                {
                    LeadsList.Add(new LeadsItemViewModel(){
                        BusinessName = item.BUSINESS,
                        CTag = item.CTAG,
                        RID = item.RID,
                        AssignedToUsername = item.USRNAME,
                        WorkUserID = item.WORK_USRID.GetValueOrDefault(),
                        WorkUsername = item.WORK_USRNAME
                    });
                }
            }

        }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessLeadsPage;
        }

        public void Prepare(int parameter)
        {
            businessID = parameter;
        }
    }
}
