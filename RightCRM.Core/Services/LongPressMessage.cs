// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LongPressMessage.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LongPressMessage
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvvmCross.Plugins.Messenger;

namespace RightCRM.Core.Services
{
    public class LongPressMessage : MvxMessage
    {
        public LongPressMessage(object sender, bool isLongPress)
    : base(sender)
    {
            IsLongPress = isLongPress;

        }

        public bool IsLongPress
        {
            get;
            private set;
        }

    }
}
