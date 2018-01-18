using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using RightCRM.Core.Models;
using RightCRM.Core.ViewModels.Popups;
using RightCRM.Core.ViewModels.Home;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels
{
    public class BusinessViewModel : BaseViewModel, IMvxViewModel<string>
    {
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

            BusinessDetailCommand = new MvxAsyncCommand(async () => await navigationService.Navigate<BusinessDetailTabViewModel>());
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

        public void Prepare(string parameter)
        {
            Title = parameter;
        }

        public IMvxCommand BusinessDetailCommand { get; private set; }
    }
}
