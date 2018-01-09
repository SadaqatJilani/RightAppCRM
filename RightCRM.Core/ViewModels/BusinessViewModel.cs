using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common.Models;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels
{
    public class BusinessViewModel : MvxViewModel
    {
        private MvxObservableCollection<Business> _allBusiness;
        public MvxObservableCollection<Business> AllBusiness{
            get { return _allBusiness; }
            set{SetProperty(ref _allBusiness,value);}
        }

        readonly IBusinessFacade businessFacade;   
        public BusinessViewModel(IBusinessFacade businessFacade)
        {
            this.businessFacade = businessFacade;
            AllBusiness = new MvxObservableCollection<Business>(this.businessFacade.GetBusiness());
        }
    }
}
