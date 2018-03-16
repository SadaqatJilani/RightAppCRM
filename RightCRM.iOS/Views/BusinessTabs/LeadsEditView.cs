// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LeadsEditView.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   LeadsEditView
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using RightCRM.Core.ViewModels.Home.BusinessTabs;
using RightCRM.iOS.Helpers;
using UIKit;

namespace RightCRM.iOS.Views.BusinessTabs
{
    [MvxFromStoryboard("Main")]
    [MvxChildPresentation]
    public partial class LeadsEditView : BaseViewController<LeadsEditViewModel>
    {
        private GlobalPicker pickerTag;

        public LeadsEditView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            pickerTag = new GlobalPicker();

            View.Add(pickerTag);

            DismissKeyboardOnBackgroundTap();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(

                pickerTag.ToLeftMargin(View),
                pickerTag.Below(lblEditLead, 12),
                pickerTag.Width().EqualTo(View.Center.X).Minus(30),
                pickerTag.Height().EqualTo(24),

                lblBusinessUser.Below(pickerTag, 12));
            
            var Set = this.CreateBindingSet<LeadsEditView, LeadsEditViewModel>();

            //title
            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            Set.Bind(lblBusinessUser).For(x => x.Text).To(vm => vm.BusinessUser);
            Set.Bind(lblWorkUser).For(x => x.Text).To(vm => vm.WorkUser);

            Set.Bind(btnDeleteLead).To(vm => vm.DeleteLeadCommand);

            //pickers
            Set.Bind(pickerTag).For(v => v.ItemsSource).To(vm => vm.PickerLeadTag);
            Set.Bind(pickerTag).For(v => v.SelectedItem).To(vm => vm.SelectedTag).TwoWay();

            Set.Apply();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

