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
        private GlobalPicker pickerBusUser;
        private GlobalPicker pickerWorkUser;

        public LeadsEditView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            pickerTag = new GlobalPicker();
            pickerBusUser = new GlobalPicker();
            pickerWorkUser = new GlobalPicker();

            View.Add(pickerTag);
            View.Add(pickerBusUser);
            View.Add(pickerWorkUser);

            DismissKeyboardOnBackgroundTap();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(

                pickerTag.ToLeftMargin(View),
                pickerTag.Below(lblEditLead, 12),
                pickerTag.Width().EqualTo(View.Center.X).Minus(30),
                pickerTag.Height().EqualTo(24),

                pickerBusUser.ToLeftMargin(View),
                pickerBusUser.Below(pickerTag, 12),
                pickerBusUser.Width().EqualTo(View.Center.X).Minus(30),
                pickerBusUser.Height().EqualTo(24),

                pickerWorkUser.ToLeftMargin(View),
                pickerWorkUser.Below(pickerBusUser, 12),
                pickerWorkUser.Width().EqualTo(View.Center.X).Minus(30),
                pickerWorkUser.Height().EqualTo(24),

                btnSaveLead.Below(pickerWorkUser, 40),
                btnSaveLead.Width().EqualTo(90),
                btnSaveLead.Height().EqualTo(30),
                btnSaveLead.WithSameCenterX(View).Minus(60),

                btnDeleteLead.Below(pickerWorkUser, 40),
                btnDeleteLead.Width().EqualTo(90),
                btnDeleteLead.Height().EqualTo(30),
                btnDeleteLead.WithSameCenterX(View).Plus(60));
            
            var Set = this.CreateBindingSet<LeadsEditView, LeadsEditViewModel>();

            //title
            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            //Set.Bind(lblBusinessUser).For(x => x.Text).To(vm => vm.BusinessUser);
            //Set.Bind(lblWorkUser).For(x => x.Text).To(vm => vm.WorkUser);

            Set.Bind(btnSaveLead).To(vm => vm.SaveLeadCommand);
            Set.Bind(btnDeleteLead).To(vm => vm.DeleteLeadCommand);

            //pickers
            Set.Bind(pickerTag).For(v => v.ItemsSource).To(vm => vm.PickerLeadTag);
            Set.Bind(pickerTag).For(v => v.SelectedItem).To(vm => vm.SelectedTag).TwoWay();

            Set.Bind(pickerBusUser).For(v => v.ItemsSource).To(vm => vm.PickerBusinessUser);
            Set.Bind(pickerBusUser).For(v => v.SelectedItem).To(vm => vm.SelectedBusUser).TwoWay();

            Set.Bind(pickerWorkUser).For(v => v.ItemsSource).To(vm => vm.PickerWorkUser);
            Set.Bind(pickerWorkUser).For(v => v.SelectedItem).To(vm => vm.SelectedWorkUser).TwoWay();

            Set.Apply();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

