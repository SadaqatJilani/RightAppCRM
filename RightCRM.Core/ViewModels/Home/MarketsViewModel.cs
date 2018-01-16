// // --------------------------------------------------------------------------------------------------------------------
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
    public class MarketsViewModel : BaseViewModel
    {
        public MarketsViewModel()
        {
        }

        public override void Prepare()
        {
            base.Prepare();

            Title = "Markets";
        }
    }
}
