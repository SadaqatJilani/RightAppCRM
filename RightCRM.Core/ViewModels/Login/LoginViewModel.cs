using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Common.Services;
using RightCRM.DataAccess.Model.RequestModels;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels
{
    /// <summary>
    /// Login view model.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// The user facade.
        /// </summary>
        private readonly IUserFacade userFacade;

        /// <summary>
        /// The cache service.
        /// </summary>
        private readonly ICacheService cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Core.ViewModels.LoginViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public LoginViewModel(IMvxNavigationService navigationService,
                              IUserFacade userFacade)
                             // ICacheService cacheService)
        {
            this.navigationService = navigationService;
            this.userFacade = userFacade;
           // this.cacheService = cacheService;
        }
        private string _userName = "khurram123_admin@zeptowork.com";
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password = "test123";
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

        public IMvxCommand LoginCommand => new MvxAsyncCommand(Login);
        private async Task Login()
        {
            //if (UserName == "admin" && Password == "123"){
            //    LoginResult = "Login Successfully";
            //}
            //else{
            //LoginResult = "User Name or Password is Invalid";

            //}

            //ShowViewModel<AccountsViewModel>();

            var result = await this.userFacade.GetUserSessionId(new RequestUserLogin()
            {
                loginid = UserName,
                token = Password,
                svsid = "work"
            });
            Debug.WriteLine("Session Id : " + result.user.sesid);


            this.GoToRootMenuCommand.Execute();
        }
    }
}
