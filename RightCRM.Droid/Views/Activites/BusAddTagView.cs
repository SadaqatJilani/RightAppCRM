// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusAddTagView.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusAddTagView
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
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels.Popups;
using RightCRM.Common;

namespace RightCRM.Droid.Views.Activites
{
    [MvxActivityPresentation]
    [Activity(Label = "Assign Tag",
         Theme = "@style/AppTheme",
         ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class BusAddTagView : MvxAppCompatActivity<BusAddTagViewModel>
    {
        private Toolbar toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.business_assigntag);

            // Create your application here

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                this.SetSupportActionBar(toolbar);
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;

                default:
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}
