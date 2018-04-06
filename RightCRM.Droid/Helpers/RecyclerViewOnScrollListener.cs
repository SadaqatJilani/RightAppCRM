﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="RecyclerViewOnScrollListener.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   RecyclerViewOnScrollListener
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace RightCRM.Droid.Helpers
{
    public class RecyclerViewOnScrollListener : RecyclerView.OnScrollListener
    {
        public delegate void LoadMoreEventHandler(object sender, EventArgs e);
        public event LoadMoreEventHandler LoadMoreEvent;

        private readonly LinearLayoutManager layoutManager;

        public RecyclerViewOnScrollListener(LinearLayoutManager layoutManager)
        {
            this.layoutManager = layoutManager;
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);

            if (layoutManager == null || recyclerView.GetAdapter() == null)
            {
                return;
            }

            var visibleItemCount = recyclerView.ChildCount;
            var totalItemCount = recyclerView.GetAdapter().ItemCount;
            var pastVisiblesItems = layoutManager.FindFirstVisibleItemPosition();

            if (recyclerView.ComputeVerticalScrollRange() > recyclerView.Height &&
                layoutManager.FindLastCompletelyVisibleItemPosition() == recyclerView.GetAdapter().ItemCount - 1)
            {
                LoadMoreEvent(this, null);
            }
        }

    }
}