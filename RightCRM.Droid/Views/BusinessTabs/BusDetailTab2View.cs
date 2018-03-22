// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailTab2View.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailTab2View
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
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels.Home;
using RightCRM.Common;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;

namespace RightCRM.Droid.Views.BusinessTabs
{
    [MvxTabLayoutPresentation(TabLayoutResourceId = Resource.Id.tabs, ViewPagerResourceId = Resource.Id.viewpager, Title = Constants.TitleBusinessNotesPage, ActivityHostViewModelType = typeof(BusinessDetailTabViewModel))]
    [Register(nameof(BusDetailTab2View))]
    public class BusDetailTab2View : MvxFragment<BusDetailTab2ViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.business_notestab2, null);


            //var recyclerBusiness = view.FindViewById<MvxRecyclerView>(Resource.Id.notes_recycler);
            //if (recyclerBusiness != null)
            //{
            //    recyclerBusiness.HasFixedSize = true;
            //    var layoutManager = new LinearLayoutManager(Activity);
            //    recyclerBusiness.SetLayoutManager(layoutManager);

            //    //add divider
            //    var dividerItemDecoration = new DividerItemDecoration(recyclerBusiness.Context,
            //                                                                            layoutManager.Orientation);
            //    recyclerBusiness.AddItemDecoration(dividerItemDecoration);
            //}

            return view;
        }
    }
}
