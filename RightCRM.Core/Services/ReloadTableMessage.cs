// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ReloadTableMessage.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   ReloadTableMessage
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Plugins.Messenger;

namespace RightCRM.Core.Services
{
    public class ReloadTableMessage : MvxMessage
    {
        public ReloadTableMessage(object sender) : base(sender)
        {
        }
    }
}
