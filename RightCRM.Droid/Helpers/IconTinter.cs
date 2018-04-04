// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IconTinter.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   IconTinter
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Android.Graphics.Drawables;
using Android.Support.V4.Graphics.Drawable;
using Android.Views;

namespace RightCRM.Droid.Helpers
{
    public static class IconTinter
    {
        public static void tintMenuIcon(IMenuItem item)
        {
            Drawable normalDrawable = item.Icon;
            Drawable wrapDrawable = DrawableCompat.Wrap(normalDrawable);
            DrawableCompat.SetTint(wrapDrawable, Android.Graphics.Color.White);

            item.SetIcon(wrapDrawable);
        }
    }
}
