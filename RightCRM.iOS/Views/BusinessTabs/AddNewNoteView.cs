using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvxPlugins.Picker.iOS;

namespace RightCRM.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxChildPresentation()]
    public partial class AddNewNoteView : BaseViewController<AddNewNoteViewModel>
    {
        public AddNewNoteView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           // this.TabBarController.hide = true;

            var picker = new Picker()
            {
                DisplayPropertyName = "hellloooo"
            };
            Add(picker);

            var Set = this.CreateBindingSet<AddNewNoteView, AddNewNoteViewModel>();

            Set.Bind().For(v => v.Title).To(vm => vm.Title);

            Set.Bind(picker).For(v => v.ItemsSource).To(vm => vm.PickerItems);
            Set.Bind(picker).For(v => v.SelectedItem).To(vm => vm.SelectedItem).TwoWay();
            Set.Apply();
        }
    }
}