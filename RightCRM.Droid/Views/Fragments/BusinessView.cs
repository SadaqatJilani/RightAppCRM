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
using Android.Support.V4.View;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V4.Graphics.Drawable;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using RightCRM.Core.Services;

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

        protected override int FragmentId => Resource.Layout.fragment_home;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.HasOptionsMenu = true;
        }

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

            return view;
        }

        private void OnLongPress(LongPressMessage message)
        {
            if (message.IsLongPress == true)
            {
                menuInstance.FindItem(Menu.First).SetVisible(false);
                menuInstance.FindItem(Menu.First + 1).SetVisible(true);
            }
            else
            {
                menuInstance.FindItem(Menu.First).SetVisible(true);
                menuInstance.FindItem(Menu.First + 1).SetVisible(false);
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

            tintMenuIcon(filterBtn);

            assignTagBtn = menu.Add(Menu.None,
                            Menu.First + 1,
                            Menu.None,
                            "Assign Tag");
            assignTagBtn.SetIcon(Resource.Drawable.ic_compose)
                     .SetShowAsAction(ShowAsAction.IfRoom);

            tintMenuIcon(assignTagBtn);

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
                    ViewModel.ShowBusinessFilterCommand.Execute();
                    break;

                default:
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }


        void tintMenuIcon(IMenuItem item)
        {
            Drawable normalDrawable = item.Icon;
            Drawable wrapDrawable = DrawableCompat.Wrap(normalDrawable);
            DrawableCompat.SetTint(wrapDrawable, Android.Graphics.Color.White);

            item.SetIcon(wrapDrawable);
        }
    }
}
