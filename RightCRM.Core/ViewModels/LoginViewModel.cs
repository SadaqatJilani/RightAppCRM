using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels
{
   
    public class LoginViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        
        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _loginResult;
        public string LoginResult
        {
            get { return _loginResult; }
            set { SetProperty(ref _loginResult, value); }
        }

        public IMvxCommand LoginCommand => new MvxCommand(Login);
        private void Login()
        {
            //if (UserName == "admin" && Password == "123"){
            //    LoginResult = "Login Successfully";
            //}
            //else{
            //LoginResult = "User Name or Password is Invalid";

            //}

            //ShowViewModel<AccountsViewModel>();
            _navigationService.Navigate<BusinessViewModel>();
        }
    }
}
