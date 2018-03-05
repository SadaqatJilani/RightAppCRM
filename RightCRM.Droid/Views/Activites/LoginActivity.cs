// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LoginActivity.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LoginActivity
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using RightCRM.Core.ViewModels;

namespace RightCRM.Droid.Views.Activites
{
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
