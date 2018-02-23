// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INavigationActivity.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   INavigationActivity
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Android.Support.V4.Widget;

namespace RightCRM.Droid.Activities
{
    public interface INavigationActivity
    {
        DrawerLayout DrawerLayout { get; set; }
    }
}
