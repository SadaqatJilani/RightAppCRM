// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="FilterPopupView.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   FilterPopupView
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
using RightCRM.Common;
using RightCRM.Core.ViewModels.Popups;

namespace RightCRM.Droid.Views.Search
{
    [MvxActivityPresentation]
    [Activity(Label = "Filter Businesses",
          Theme = "@style/AppTheme",
          ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class FilterPopupView : MvxAppCompatActivity<FilterPopupViewModel>
    {
        private Toolbar toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.business_filterview);

            // Create your application here

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                this.SetSupportActionBar(toolbar);
                this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add(Menu.None,
                     Menu.First,
                     Menu.None,
                     "SAVE").SetShowAsAction(ShowAsAction.Always);

            menu.Add(Menu.None,
                     Menu.First + 1,
                     Menu.None,
                     "RESET").SetShowAsAction(ShowAsAction.Always);;

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;

                case Menu.First:
                    ViewModel?.SaveSearchCommand?.Execute();
                    break;

                case Menu.First + 1:
                    ViewModel?.ResetFiltersCommand?.Execute();
                    break;

                default:
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}
