﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MarketsViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   MarketsViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.Home
{
    public class MarketsViewModel : BaseViewModel, IMvxViewModel<string>
    {
        public MarketsViewModel()
        {
        }


        public void Prepare(string parameter)
        {
            // throw new NotImplementedException();

            Title = parameter;
        }
    }
}