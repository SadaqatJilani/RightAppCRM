﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MenuFragment.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   MenuFragment
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Droid.Support.V4;
using RightCRM.Core.ViewModels.Menu;
using RightCRM.Droid.Views.Activites;
using RightCRM.Core.ViewModels;

namespace RightCRM.Droid.Views.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("rightcrm.droid.views.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView navigationView;
        private IMenuItem previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_navigation, null);

            navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            navigationView.SetNavigationItemSelectedListener(this);
            navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            item.SetCheckable(true);
            item.SetChecked(true);
            previousMenuItem?.SetChecked(false);
            previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((MainActivity)Activity).DrawerLayout.CloseDrawers();
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemId)
            {
                case Resource.Id.nav_home:
                    //ViewModel.ShowViewModelAndroid(typeof(BusinessViewModel));
                    ViewModel.NavigateHome.Execute();
                    break;
                case Resource.Id.nav_markets:
                    //ViewModel.ShowViewModelAndroid(typeof(SecondHostViewModel));
                    break;
                case Resource.Id.nav_createnew:
                    //ViewModel.ShowViewModelAndroid(typeof(ExampleViewPagerViewModel));
                    break;
                case Resource.Id.nav_settings:
                    //ViewModel.ShowViewModelAndroid(typeof(SettingsViewModel));
                    break;
                case Resource.Id.nav_helpfeedback:
                    //ViewModel.ShowViewModelAndroid(typeof(SettingsViewModel));
                    break;
            }
        }
    }
}
