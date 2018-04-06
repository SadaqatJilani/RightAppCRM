// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ActionBarCallBack.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   ActionBarCallBack
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Android.Content;
using Android.Support.V7.View;
using Android.Views;
using MvvmCross.Core.ViewModels;
using RightCRM.Core.ViewModels;

namespace RightCRM.Droid.Helpers
{
    public class ActionBarCallback : Java.Lang.Object, Android.Support.V7.View.ActionMode.ICallback
    {
        private readonly Context mContext;
        private readonly BusinessViewModel viewModel;

        public ActionBarCallback(Context context, BusinessViewModel mvxViewModel)
        {
            mContext = context;
            viewModel = mvxViewModel;
        }


        public bool OnActionItemClicked(Android.Support.V7.View.ActionMode mode, IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.assigntagmode:
                    // do whatever you want
                    viewModel?.AssignTagCommand?.Execute();
                    return true;
                default:
                    return false;
            }
        }

        public bool OnCreateActionMode(Android.Support.V7.View.ActionMode mode, IMenu menu)
        {
            mode?.MenuInflater?.Inflate(Resource.Menu.contextual_menu, menu);

            IconTinter.tintMenuIcon(menu.FindItem(Resource.Id.assigntagmode));

            return true;
        }

        public void OnDestroyActionMode(Android.Support.V7.View.ActionMode mode)
        {
          //  mode?.Dispose();
            viewModel?.DeselectAllRowsCommand?.Execute();
        }

        public bool OnPrepareActionMode(Android.Support.V7.View.ActionMode mode, IMenu menu)
        {
            return false;
        }
    }
}
