using System.Threading.Tasks;
using Acr.UserDialogs;
using Akavache;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
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
    }
}
