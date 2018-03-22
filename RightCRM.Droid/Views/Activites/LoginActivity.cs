// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LoginActivity.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LoginActivity
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels;

namespace RightCRM.Droid.Views.Activites
{
    [MvxActivityPresentation]
    [Activity(
        Label = "Login",
        Theme = "@style/AppTheme.Login",
        LaunchMode = LaunchMode.SingleTop,
        NoHistory = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        Name = "rightcrm.droid.views.activities.LoginActivity"
    )]          
    public class LoginActivity : MvxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            SetContentView(Resource.Layout.activity_login);
        }
    }
}
