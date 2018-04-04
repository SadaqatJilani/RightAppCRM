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
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels;
using Android.Graphics.Drawables;
using Android.Support.V4.Graphics.Drawable;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RightCRM.Core.Services;
using MvvmCross.Droid.Support.V7.AppCompat;
using RightCRM.Droid.Helpers;

namespace RightCRM.Droid.Views.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register(nameof(BusinessView))]
    public class BusinessView : BaseFragment<BusinessViewModel>
    {
        private IDisposable itemSelectedToken;

        private IMenuItem filterBtn;
        private IMenuItem assignTagBtn;
        private IMenu menuInstance;
        private MvxSubscriptionToken token;
        private MvxAppCompatActivity appInstance;

        private ActionBarCallback actionBarCallback;

        private Android.Support.V7.View.ActionMode actionMode;

        private MvxRecyclerView recyclerBusiness;

        private RecyclerViewOnScrollListener onScrollListener;

        protected override int FragmentId => Resource.Layout.fragment_home;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.HasOptionsMenu = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            recyclerBusiness = view.FindViewById<MvxRecyclerView>(Resource.Id.business_recycler_view);

            if (recyclerBusiness != null)
            {
                recyclerBusiness.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);

                onScrollListener = new RecyclerViewOnScrollListener(layoutManager);

                //onScrollListener.LoadMoreEvent += OnScrollListener_LoadMoreEvent;
                //recyclerBusiness.AddOnScrollListener(onScrollListener);

                recyclerBusiness.SetLayoutManager(layoutManager);

                var dividerItemDecoration = new DividerItemDecoration(recyclerBusiness.Context,
                                                                                        layoutManager.Orientation);
                recyclerBusiness.AddItemDecoration(dividerItemDecoration);
            }

            return view;
        }

        void OnScrollListener_LoadMoreEvent(object sender, EventArgs e)
        {
            ViewModel?.LoadMoreBusinessesCommand?.Execute();
        }


		public override void OnResume()
		{
            onScrollListener.LoadMoreEvent += OnScrollListener_LoadMoreEvent;
            recyclerBusiness.AddOnScrollListener(onScrollListener);

            base.OnResume();
		}

		public override void OnPause()
		{
            onScrollListener.LoadMoreEvent -= OnScrollListener_LoadMoreEvent;
            recyclerBusiness.RemoveOnScrollListener(onScrollListener);

            base.OnPause();
        }

        private void OnLongPress(LongPressMessage message)
        {

            if (appInstance == null)
            {
                appInstance = (MvxAppCompatActivity)this.Activity;
            }

            if (actionBarCallback == null)
            {
                actionBarCallback = new ActionBarCallback(this.Activity, ViewModel);
            }

            if (message.IsLongPress == true)
            {
                actionMode = appInstance?.StartSupportActionMode(actionBarCallback);
            }

            else
            {
                actionMode?.Finish();
            }
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            filterBtn = menu.Add(Menu.None,
                                        Menu.First,
                                        Menu.None,
                                        "Search");
            filterBtn.SetIcon(Resource.Drawable.filtericon)
                     .SetShowAsAction(ShowAsAction.IfRoom);

            IconTinter.tintMenuIcon(filterBtn);

            menuInstance = menu;

            base.OnCreateOptionsMenu(menu, inflater);

            token = Mvx.Resolve<IMvxMessenger>().Subscribe<LongPressMessage>(OnLongPress);
            OnLongPress(new LongPressMessage(this, false));
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Menu.First:
                    ViewModel?.ShowBusinessFilterCommand?.Execute();
                    break;

                default:
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}
