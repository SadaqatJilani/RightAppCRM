using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvxPlugins.Picker.iOS;
using MvvmCross.Binding.iOS.Views;
using Cirrious.FluentLayouts.Touch;
using RightCRM.Common.Models;
using RightCRM.iOS.Helpers;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxChildPresentation]
    public partial class AddNewNoteView : BaseViewController<AddNewNoteViewModel>
    {
        Picker pickerQuery;
        Picker pickerAnswer;
        Picker pickerClient;

        public AddNewNoteView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            pickerQuery = new GlobalPicker();
            pickerAnswer = new GlobalPicker();
            pickerClient = new GlobalPicker();

            View.Add(pickerQuery);
            View.Add(pickerAnswer);
            View.Add(pickerClient);

            DismissKeyboardOnBackgroundTap();

            var Set = this.CreateBindingSet<AddNewNoteView, AddNewNoteViewModel>();

            //title
            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            //picker bindings
            Set.Bind(pickerQuery).For(v => v.ItemsSource).To(vm => vm.PickerQueryType);
            Set.Bind(pickerQuery).For(v => v.SelectedItem).To(vm => vm.SelectedQueryType).TwoWay();

            Set.Bind(pickerAnswer).For(v => v.ItemsSource).To(vm => vm.PickerAnswerType);
            Set.Bind(pickerAnswer).For(v => v.SelectedItem).To(vm => vm.SelectedAnsType).TwoWay();

            Set.Bind(pickerClient).For(v => v.ItemsSource).To(vm => vm.PickerClientType);
            Set.Bind(pickerClient).For(v => v.SelectedItem).To(vm => vm.SelectedClientType).TwoWay();
            Set.Apply();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                pickerQuery.ToLeftMargin(View),
                pickerQuery.Below(topHeading, 12),

                pickerAnswer.ToLeftMargin(View),
                pickerAnswer.Below(pickerQuery, 12),

                pickerClient.ToLeftMargin(View),
                pickerClient.Below(pickerAnswer, 12),

                txtNoteComment.ToLeftMargin(View),
                txtNoteComment.Below(pickerClient, 30),
                txtNoteComment.Width().EqualTo(View.Center.X).Plus(30));
        }
    }
}