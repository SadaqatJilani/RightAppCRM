using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Core.Models;

namespace RightCRM.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected IMvxNavigationService navigationService;

        public BaseViewModel()
        {
        }

        public string Title
        {
            get;
            set;
        }

        public bool IsBusy
        {
            get;
            set;
        }

        protected async Task NavigateToViewModel<T>() where T : MvxViewModel
        {
            await navigationService.Navigate<T>();
        }
    }
}
