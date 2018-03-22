// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessDetailTabView.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessDetailTabView
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels.Home;

namespace RightCRM.Droid.Views.BusinessTabs
{
    [MvxActivityPresentation()]
    [Activity(Theme = "@style/AppTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class BusinessDetailTabView : MvxAppCompatActivity<BusinessDetailTabViewModel>
    {
        private Toolbar toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.business_rootview);

            // Create your application here

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                this.SetSupportActionBar(toolbar);
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }

            if (bundle == null)
            {
                ViewModel.ShowInitialViewModelsCommand.Execute();
            }
        }
    }
}
