// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="CreateNewBusViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   CreateNewBusViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.ViewModels.Home
{
    public class CreateNewBusViewModel : BaseViewModel, IMvxViewModel<string>
    {
        public CreateNewBusViewModel()
        {
        }

        public void Prepare(string parameter)
        {
            Title = parameter;
        }
    }
}
