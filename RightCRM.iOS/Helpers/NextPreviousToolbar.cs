﻿using System;
using UIKit;

namespace RightCRM.iOS.Helpers
{
    /// <summary>
    /// Next previous tool bar.
    /// Source:
    /// https://www.spaceotechnologies.com/ease-ios-keyboard-handling-xamarin-app-development/
    /// </summary>
    public class NextPreviousToolBar : UIToolbar
    {
        public UITextField prevTextField { get; set; }
        public UITextField currentTextField { get; set; }
        public UITextField nextTextField { get; set; }

        public NextPreviousToolBar() : base() { }

        public NextPreviousToolBar(UITextField curr, UITextField prev,
                                   UITextField next)
        {
            this.currentTextField = curr;
            this.prevTextField = prev;
            this.nextTextField = next;
            AddButtonsToToolBar();

            currentTextField.ShouldReturn += CurrentTextField_ShouldReturn;
        }

        void AddButtonsToToolBar()
        {
            Frame = new CoreGraphics.CGRect(0.0f, 0.0f, 320, 44.0f);
            TintColor = UIColor.DarkGray;
            Translucent = false;
            Items = new UIBarButtonItem[]
            {
                new UIBarButtonItem("Prev",
                                    UIBarButtonItemStyle.Plain, delegate
                {
                prevTextField.BecomeFirstResponder();
                }) { Enabled = prevTextField != null },
                new UIBarButtonItem("Next",
                                    UIBarButtonItemStyle.Plain, delegate
                {
                nextTextField.BecomeFirstResponder();
                }) { Enabled = nextTextField != null },
                new
                UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
                {
                currentTextField.ResignFirstResponder();
                })
                            };
        }

        bool CurrentTextField_ShouldReturn(UITextField textField)
        {
            textField.ResignFirstResponder();
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            currentTextField.ShouldReturn -= CurrentTextField_ShouldReturn;

            base.Dispose(disposing);
        }
    }
}
