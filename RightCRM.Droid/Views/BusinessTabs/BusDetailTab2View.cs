// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailTab2View.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailTab2View
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------


using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels.Home;
using RightCRM.Common;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;

namespace RightCRM.Droid.Views.BusinessTabs
{
    [MvxTabLayoutPresentation(TabLayoutResourceId = Resource.Id.tabs, 
                              ViewPagerResourceId = Resource.Id.viewpager, 
                              Title = Constants.TitleBusinessNotesPage, 
                              ActivityHostViewModelType = typeof(BusinessDetailTabViewModel))]
    [Register(nameof(BusDetailTab2View))]
    public class BusDetailTab2View : MvxFragment<BusDetailTab2ViewModel>
    {
        private MvxRecyclerView recyclerNotes;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.business_notestab2, null);


            recyclerNotes = view.FindViewById<MvxRecyclerView>(Resource.Id.notes_recycler);
            if (recyclerNotes != null)
            {
                recyclerNotes.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerNotes.SetLayoutManager(layoutManager);

                //add divider
                var dividerItemDecoration = new DividerItemDecoration(recyclerNotes.Context,
                                                                                        layoutManager.Orientation);
                recyclerNotes.AddItemDecoration(dividerItemDecoration);
            }

            return view;
        }
    }
}
