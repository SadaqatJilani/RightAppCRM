using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using RightCRM.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxRootPresentation]
    public partial class LoginView : BaseViewController<LoginViewModel>
    {
        public LoginView (IntPtr handler) : base (handler)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.AddGestureRecognizer(new UITapGestureRecognizer(() => {
                this.UserNameFeild.ResignFirstResponder();
                this.PasswordFeild.ResignFirstResponder();
            }));



            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(UserNameFeild).To(vm => vm.UserName);
            set.Bind(PasswordFeild).To(vm => vm.Password);
            set.Bind(LoginButton).To(vm => vm.LoginCommand);
           // set.Bind(ResultLabel).To(vm => vm.LoginResult);
            set.Apply();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

          //  View.RemoveGestureRecognizer();
        }
    }
}