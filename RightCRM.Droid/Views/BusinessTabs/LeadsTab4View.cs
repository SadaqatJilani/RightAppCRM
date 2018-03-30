// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsTab4View.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsTab4View
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
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels.Home.BusinessTabs;
using RightCRM.Common;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.AppCompat.Widget;
using Android.Support.V7.Widget;

namespace RightCRM.Droid.Views.BusinessTabs
{
    [MvxTabLayoutPresentation(TabLayoutResourceId = Resource.Id.tabs, 
                              ViewPagerResourceId = Resource.Id.viewpager, 
                              Title = Constants.TitleBusinessLeadsPage, 
                              ActivityHostViewModelType = typeof(BusinessDetailTabViewModel))]
    [Register(nameof(LeadsTab4View))]
    public class LeadsTab4View : MvxFragment<LeadsTab4ViewModel>
    {
        private MvxRecyclerView recyclerLeads;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.business_leadstab4, null);

            recyclerLeads = view.FindViewById<MvxRecyclerView>(Resource.Id.business_Leads_rec);
            if (recyclerLeads != null)
            {
                recyclerLeads.HasFixedSize = true;
                var layoutManager = new MvxGuardedLinearLayoutManager(Activity);
                recyclerLeads.SetLayoutManager(layoutManager);

                //add divider
                var dividerItemDecoration = new DividerItemDecoration(recyclerLeads.Context,
                                                                                        layoutManager.Orientation);
                recyclerLeads.AddItemDecoration(dividerItemDecoration);
            }

            return view;
        }
    }
}
