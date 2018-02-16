using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebar;
using RightCRM.Core.ViewModels.Popups;
using MvxPlugins.Picker.iOS;
using RightCRM.iOS.Helpers;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "AddBusinessTag")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PushPanel, true)]
    public partial class BusAddTagView : BaseViewController<BusAddTagViewModel>
    {
        Picker pickerSelectTag;
        Picker pickerSelectUserForTag;

        public BusAddTagView (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            pickerSelectTag = new GlobalPicker();
            pickerSelectUserForTag = new GlobalPicker();

            View.Add(pickerSelectTag);
            View.Add(pickerSelectUserForTag);

            DismissKeyboardOnBackgroundTap();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                pickerSelectTag.ToLeftMargin(View),
                pickerSelectTag.Below(lblAssignTag, 12),
                pickerSelectTag.ToRightMargin(View),
                pickerSelectTag.Height().EqualTo(24),

                pickerSelectUserForTag.ToLeftMargin(View),
                pickerSelectUserForTag.Below(pickerSelectTag, 12),
                pickerSelectUserForTag.ToRightMargin(View),
                pickerSelectUserForTag.Height().EqualTo(24),

                btnAssignTag.WithSameCenterX(View),
                btnAssignTag.Below(pickerSelectUserForTag, 24),
                btnAssignTag.Width().EqualTo(160));

            var Set = this.CreateBindingSet<BusAddTagView, BusAddTagViewModel>();

            //title
            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            //picker bindings
            Set.Bind(pickerSelectTag).For(v => v.ItemsSource).To(vm => vm.PickerSelectTag);
            Set.Bind(pickerSelectTag).For(v => v.SelectedItem).To(vm => vm.SelectedTag).TwoWay();

            Set.Bind(pickerSelectUserForTag).For(v => v.ItemsSource).To(vm => vm.PickerTagUser);
            Set.Bind(pickerSelectUserForTag).For(v => v.SelectedItem).To(vm => vm.SelectedUser).TwoWay();

            Set.Apply();


        }
    }
}