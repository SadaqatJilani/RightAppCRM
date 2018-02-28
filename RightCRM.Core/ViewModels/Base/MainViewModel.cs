using MvvmCross.Core.Navigation;
using RightCRM.Core.ViewModels.Menu;

namespace RightCRM.Core.ViewModels
{
	public class MainViewModel : BaseViewModel
    {

        public MainViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void ShowMenu()
        {
            navigationService.Navigate<MenuViewModel>();
            //ShowViewModel<MenuViewModel>();            
        }

        public void ShowHome()
        {
            ShowViewModel<HomeViewModel>();
        }

        public void Init(object hint)
        {
            // Can perform Vm data retrival here based on any
            // data passed in the hint object

            // ShowViewModel<SomeViewModel>(new { derp: "herp", durr: "derrrrrr" });
            // public class SomeViewModel : MvxViewModel
            // {
            //     public void Init(string derp, string durr)
            //     {
            //     }
            // }
        }

        public override void Start()
        {
            //base.Start();
        }
    }
}