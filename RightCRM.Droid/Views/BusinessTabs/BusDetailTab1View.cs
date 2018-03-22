// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailTab1View.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailTab1View
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
using RightCRM.Droid.Views.Fragments;
using RightCRM.Common;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;

namespace RightCRM.Droid.Views.BusinessTabs
{
    [MvxTabLayoutPresentation(TabLayoutResourceId = Resource.Id.tabs, ViewPagerResourceId = Resource.Id.viewpager, Title = Constants.TitleBusinessDetailsPage, ActivityHostViewModelType = typeof(BusinessDetailTabViewModel))]
    [Register(nameof(BusDetailTab1View))]
    public class BusDetailTab1View : MvxFragment<BusDetailTab1ViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.business_detailtab1, null);

            return view;
        }
    }
}
