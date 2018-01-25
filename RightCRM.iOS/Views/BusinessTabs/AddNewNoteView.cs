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

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxChildPresentation()]
    public partial class AddNewNoteView : BaseViewController<AddNewNoteViewModel>
    {
        Picker pickerQuery;
        Picker pickerAnswer;
        Picker pickerClient;

        public AddNewNoteView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // this.TabBarController.hide = true;

            pickerQuery = new Picker()
            {
                DisplayPropertyName = nameof(PickerItem.DisplayName),
                TintColor = UIColor.Blue,
                BackgroundColor = UIColor.FromRGB(246, 248, 250)
            };
            pickerQuery.AddButtonToToolbar(new UIBarButtonItem(UIBarButtonSystemItem.Cancel, OnPickerDeselect));

            View.Add(pickerQuery);

            pickerAnswer = new Picker()
            {
                DisplayPropertyName = nameof(PickerItem.DisplayName),
                TintColor = UIColor.Blue,
                BackgroundColor = UIColor.FromRGB(246, 248, 250)
            };
            pickerAnswer.AddButtonToToolbar(new UIBarButtonItem(UIBarButtonSystemItem.Cancel, OnPickerDeselect));

            View.Add(pickerAnswer);

            pickerClient = new Picker()
            {
                DisplayPropertyName = nameof(PickerItem.DisplayName),
                TintColor = UIColor.Blue,
                BackgroundColor = UIColor.FromRGB(246,248,250)
            };
            pickerClient.AddButtonToToolbar(new UIBarButtonItem(UIBarButtonSystemItem.Cancel, OnPickerDeselect));

            View.Add(pickerClient);

            View.AddGestureRecognizer(new UITapGestureRecognizer((obj) => OnPickerDeselect(obj, EventArgs.Empty)));
            

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
                txtNoteComment.Width().EqualTo(View.Center.X).Plus(30)

               // selectedTextItem.AtLeftOf(View, 12),
              //  selectedTextItem.Below(_pickerText, 12),

              //  _pickerImage.AtLeftOf(View, 12),
              //  _pickerImage.Below(selectedTextItem, 12)
                );
        }

        private void OnPickerDeselect(object sender, EventArgs e)
        {
            if (pickerQuery.CanResignFirstResponder)
                pickerQuery.ResignFirstResponder();

            if (pickerAnswer.CanResignFirstResponder)
                pickerAnswer.ResignFirstResponder();

            if (pickerClient.CanResignFirstResponder)
                pickerClient.ResignFirstResponder();

            if (txtNoteComment.CanResignFirstResponder)
                txtNoteComment.ResignFirstResponder();
        }

        private void PickerViewModel_SelectedItemChanged(object sender, EventArgs e)
        {
         //   throw new NotImplementedException();
        }
    }
}