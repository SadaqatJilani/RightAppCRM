// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="HomeFragment.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   HomeFragment
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Android.Runtime;
using MvvmCross.Droid.Views.Attributes;
using RightCRM.Core.ViewModels;

namespace RightCRM.Droid.Views.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("rightcrm.droid.views.fragments.HomeFragment")]
    public class HomeFragment : BaseFragment<BusinessViewModel>
    {

        protected override int FragmentId => Resource.Layout.fragment_home;

    }
}
