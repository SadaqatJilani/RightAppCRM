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
            this.DisplayPropertyName = nameof(PickerItem.DisplayName);
            this.TintColor = UIColor.Blue;
            this.BackgroundColor = UIColor.FromRGB(246, 248, 250);

            this.Layer.BorderWidth = 0.5f;
            this.Layer.BorderColor = UIColor.Black.CGColor;


            this.AddButtonToToolbar(new UIBarButtonItem(UIBarButtonSystemItem.Cancel, OnPickerDeselect));
        }

        private void OnPickerDeselect(object sender, EventArgs e)
        {
            if (this.CanResignFirstResponder)
                this.ResignFirstResponder();
        }
    }
}
