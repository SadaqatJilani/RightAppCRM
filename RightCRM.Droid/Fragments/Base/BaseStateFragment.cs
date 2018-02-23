// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BaseStateFragment.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BaseStateFragment
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using Android.Content.Res;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using RightCRM.Droid.Activities;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;

namespace RightCRM.Droid.Fragments.Base
{
    public abstract class BaseStateFragment : MvxFragment
    {
        private Toolbar toolbar;
        private MvxActionBarDrawerToggle drawerToggle;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                ((MainActivity)Activity).SetSupportActionBar(toolbar);
                ((MainActivity)Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                drawerToggle = new MvxActionBarDrawerToggle(
                    Activity,                               // host Activity
                    ((MainActivity)Activity).DrawerLayout,  // DrawerLayout object
                    toolbar,                               // nav drawer icon to replace 'Up' caret
                    Resource.String.drawer_open,            // "open drawer" description
                    Resource.String.drawer_close            // "close drawer" description
                );

                ((MainActivity)Activity).DrawerLayout.AddDrawerListener(drawerToggle);
            }

            return view;
        }

        protected abstract int FragmentId { get; }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (toolbar != null)
                drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (toolbar != null)
                drawerToggle.SyncState();
        }
    }

    public abstract class BaseStateFragment<TViewModel> : BaseStateFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }

}
