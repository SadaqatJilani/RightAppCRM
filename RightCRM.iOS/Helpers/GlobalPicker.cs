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
using MvvmCross.iOS.Views;
using CoreGraphics;
using Foundation;

namespace RightCRM.iOS.Helpers
{
    public class GlobalPicker : Picker
    {
        public GlobalPicker()
        {
            this.DisplayPropertyName = nameof(PickerItem.DisplayName);
            this.Font = UIFont.SystemFontOfSize(UIFont.SmallSystemFontSize);
            this.Highlighted = true;

            this.TintColor = UIColor.LightGray;
            this.BackgroundColor = UIColor.FromRGB(246, 248, 250);

            this.Layer.BorderWidth = 1f;
            this.Layer.BorderColor = UIColor.LightGray.CGColor;

            this.AddButtonToToolbar(new UIBarButtonItem(UIBarButtonSystemItem.Cancel, OnPickerDeselect));
        }

        private void OnPickerDeselect(object sender, EventArgs e)
        {
            if (this.CanResignFirstResponder)
                this.ResignFirstResponder();
        }


        //public UIEdgeInsets() : base() { }
        //public UIEdgeableLabel(NSCoder coder) : base(coder) { }
        //public UIEdgeableLabel(CGRect frame) : base(frame) { }
        //protected UIEdgeableLabel(NSObjectFlag t) : base(t) { }

        private UIEdgeInsets _edgeInset = UIEdgeInsets.Zero;
        public UIEdgeInsets EdgeInsets
        {
            get { return _edgeInset; }
            set
            {
                _edgeInset = value;
                this.InvalidateIntrinsicContentSize();
            }
        }

        public override CGRect TextRect(CGRect forBounds)
        {
            var rect = base.TextRect(EdgeInsets.InsetRect(forBounds));
            return new CGRect(x: rect.X - EdgeInsets.Left,
                              y: rect.Y - EdgeInsets.Top,
                              width: rect.Width + EdgeInsets.Left + EdgeInsets.Right,
                              height: rect.Height + EdgeInsets.Top + EdgeInsets.Bottom);
        }

        public override void DrawText(CGRect rect)
        {
            base.DrawText(this.EdgeInsets.InsetRect(rect));
        }

    }
}
