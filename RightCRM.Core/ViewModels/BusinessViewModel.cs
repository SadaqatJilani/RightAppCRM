using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using RightCRM.Core.Models;
using RightCRM.Core.ViewModels.Popups;
using RightCRM.Core.ViewModels.Home;
using RightCRM.Facade.Facades;
using System.Threading.Tasks;

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
            AllBusiness = new MvxObservableCollection<Business>(this.businessFacade.GetBusiness().Result);

            BusinessDetailCommand = new MvxAsyncCommand<Business>(ShowBusinessDetails);
        }

        private async Task ShowBusinessDetails(Business business)
        {
            // throw new NotImplementedException();

            await navigationService.Navigate<BusinessDetailTabViewModel, Business>(business);
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

        public IMvxCommand<Business> BusinessDetailCommand { get; private set; }
    }
}
