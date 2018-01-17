using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using RightCRM.Core.Models;
using RightCRM.Core.ViewModels.Popups;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels
{
    public class BusinessViewModel : BaseViewModel
    {
        public override void Prepare()
        {
            base.Prepare();

            Title = "Business";
        }

        private MvxObservableCollection<Business> _allBusiness;
        public MvxObservableCollection<Business> AllBusiness{
            get { return _allBusiness; }
            set{SetProperty(ref _allBusiness,value);}
        }

        readonly IBusinessFacade businessFacade;   
        public BusinessViewModel(IBusinessFacade businessFacade, IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.businessFacade = businessFacade;
            AllBusiness = new MvxObservableCollection<Business>(this.businessFacade.GetBusiness());
        }

        public IMvxCommand ShowBusinessFilterCommand
        {
            get
            {
                return new MvxCommand(BusinessFilter);
            }
        }

        private void BusinessFilter()
        {
            navigationService.Navigate<FilterPopupViewModel>();
        }
    }
}
