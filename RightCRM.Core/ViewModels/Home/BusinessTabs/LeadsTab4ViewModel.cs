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
