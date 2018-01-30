using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Core.Models;

namespace RightCRM.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected IMvxNavigationService navigationService;

        public BaseViewModel()
        {
            GoToRootMenuCommand = new MvxAsyncCommand(async () => await navigationService.Navigate<BusinessViewModel, string>(Constants.TitleBusinessPage));
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

        public IMvxCommand GoToRootMenuCommand { get; private set; }

        protected async Task NavigateToViewModel<T, U>(U hello) where T : MvxViewModel<U>
            where U : class
        {
            await navigationService.Navigate<T, U>(hello);
        }
    }
}
