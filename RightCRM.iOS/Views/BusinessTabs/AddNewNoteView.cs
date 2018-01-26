using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvxPlugins.Picker.iOS;
using RightCRM.Core.ViewModels.Home;
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

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                pickerQuery.ToLeftMargin(View),
                pickerQuery.Below(topHeading, 12),
                pickerQuery.Width().EqualTo(View.Center.X).Minus(30),
                pickerQuery.Height().EqualTo(24),

                pickerAnswer.ToLeftMargin(View),
                pickerAnswer.Below(pickerQuery, 12),
                pickerAnswer.Width().EqualTo(View.Center.X).Minus(30),
                pickerAnswer.Height().EqualTo(24),

                pickerClient.ToLeftMargin(View),
                pickerClient.Below(pickerAnswer, 12),
                pickerClient.Width().EqualTo(View.Center.X).Minus(30),
                pickerClient.Height().EqualTo(24),

                txtNoteComment.ToLeftMargin(View),
                txtNoteComment.Below(pickerClient, 12),
                txtNoteComment.Width().EqualTo(View.Center.X).Plus(30),

                btnAddComment.WithSameCenterX(View),
                btnAddComment.Below(txtNoteComment, 24),
                btnAddComment.Width().EqualTo(160));
            
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

            Set.Bind(btnAddComment).To(vm => vm.AddCommentCommand);
            Set.Apply();
        }
    }
}