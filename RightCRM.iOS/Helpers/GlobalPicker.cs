// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="GlobalPicker.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   GlobalPicker
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using MvxPlugins.Picker.iOS;
using RightCRM.Common.Models;
using UIKit;

namespace RightCRM.iOS.Helpers
{
    public class GlobalPicker : Picker
    {
        public GlobalPicker()
        {
            DisplayPropertyName = nameof(PickerItem.DisplayName);
            TintColor = UIColor.Blue;
            BackgroundColor = UIColor.FromRGB(246, 248, 250);

            this.AddButtonToToolbar(new UIBarButtonItem(UIBarButtonSystemItem.Cancel, OnPickerDeselect));
        }

        private void OnPickerDeselect(object sender, EventArgs e)
        {
            if (this.CanResignFirstResponder)
                this.ResignFirstResponder();
        }
    }
}
