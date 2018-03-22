// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="HomeFragment.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   HomeFragment
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Platform.WeakSubscription;
using RightCRM.Core.ViewModels;

namespace RightCRM.Droid.Views.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("rightcrm.droid.views.fragments.HomeFragment")]
    public class BusinessView : BaseFragment<BusinessViewModel>
    {
        private IDisposable itemSelectedToken;

        protected override int FragmentId => Resource.Layout.fragment_home;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var recyclerBusiness = view.FindViewById<MvxRecyclerView>(Resource.Id.business_recycler_view);
            if (recyclerBusiness != null)
            {
                recyclerBusiness.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerBusiness.SetLayoutManager(layoutManager);

                //add divider
                var dividerItemDecoration = new DividerItemDecoration(recyclerBusiness.Context,
                                                                                        layoutManager.Orientation);
                recyclerBusiness.AddItemDecoration(dividerItemDecoration);
            }

            //itemSelectedToken = ViewModel.WeakSubscribe(() => ViewModel.SelectedItem,
                //(sender, args) => {
                //    if (ViewModel.SelectedItem != null)
                //        Toast.MakeText(Activity,
                //            $"Selected: {ViewModel.SelectedItem.Title}",
                //            ToastLength.Short).Show();
                //});

            //var swipeToRefresh = view.FindViewById<MvxSwipeRefreshLayout>(Resource.Id.refresher);
            //var appBar = Activity.FindViewById<AppBarLayout>(Resource.Id.appbar);
            //if (appBar != null)
                //appBar.OffsetChanged += (sender, args) => swipeToRefresh.Enabled = args.VerticalOffset == 0;

            return view;
		}

	}
}
