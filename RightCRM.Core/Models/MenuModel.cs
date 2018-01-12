// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MenuModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   MenuModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Core.ViewModels;

namespace RightCRM.Core.Models
{
    public class MenuModel
    {
        public string Title
        {
            get;
            set;
        }

        public string ImageName
        {
            get;
            set;
        }

        public IMvxCommand Navigate
        {
            get;
            set;
        }

        public MenuModel() { }
    }
}
