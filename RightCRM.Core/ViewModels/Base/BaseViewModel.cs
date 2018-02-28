using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Akavache;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using RightCRM.Common;
using RightCRM.Core.ViewModels.ItemViewModels;
using RightCRM.Core.ViewModels.Menu;

namespace RightCRM.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected IMvxNavigationService navigationService;
        protected IUserDialogs userDialogs;

        public BaseViewModel()
        {
        }

        public BaseViewModel(IUserDialogs userDialogs)
        {
            this.userDialogs = userDialogs;

            this.PropertyChanged += Monitor_InitializeTask;
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

        private IMvxCommand goToRootMenuCommand;
        public IMvxCommand GoToRootMenuCommand
        {
            get
            {
                goToRootMenuCommand = goToRootMenuCommand ??
                    new MvxAsyncCommand(async () => await navigationService.Navigate<BusinessViewModel, string>(Constants.TitleBusinessPage));

                return goToRootMenuCommand;
            }
        }


        void Monitor_InitializeTask(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.InitializeTask) && this.InitializeTask != null)
            {
                this.InitializeTask.PropertyChanged += InitializeTask_PropertyChanged;
            }

        }

        void InitializeTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(InitializeTask.Status))
            {
                    //userDialogs.ShowLoading();
            }

            else if (e.PropertyName == nameof(InitializeTask.IsCompleted))
            {
                    userDialogs.HideLoading();
            }
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

                if (userDialogs != null && InitializeTask != null && this.InitializeTask.IsNotCompleted)
                    userDialogs.ShowLoading();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();

            this.InitializeTask.PropertyChanged -= InitializeTask_PropertyChanged;
            this.PropertyChanged -= Monitor_InitializeTask;
        }

        protected async Task NavigateToViewModel<T, U>(U hello) where T : MvxViewModel<U>
            where U : class
        {
            await navigationService.Navigate<T, U>(hello);
        }


        protected string JsonStringFromList(IEnumerable<FilterListViewModel> filterList, string filterField, bool intList = false)
        {
            if (intList)
            {
                var filterInt = filterList.FirstOrDefault(x => x.Heading == filterField)?
                                          .Where(x => x.IsSelected == true)?
                                          .Select(x => x.FilterID)?
                                          .ToList();

                if (filterInt == null || !filterInt.Any())
                    return null;

                else
                    return JsonConvert.SerializeObject(filterInt);
                
            }

            else
            {
                var filterString = filterList.FirstOrDefault(x => x.Heading == filterField)?
                                             .Where(x => x.IsSelected == true)?
                                             .Select(x => x.FilterName)?
                                             .ToList();

                if (filterString == null || !filterString.Any())
                    return null;

                else
                    return JsonConvert.SerializeObject(filterString);
            }
        }
    }
}
