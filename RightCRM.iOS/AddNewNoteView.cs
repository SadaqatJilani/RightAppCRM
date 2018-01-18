using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using RightCRM.Core.ViewModels.Home;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace RightCRM.iOS
{
    [MvxFromStoryboard("Main")]
    [MvxChildPresentation()]
    public partial class AddNewNoteView : MvxViewController<AddNewNoteViewModel>
    {
        public AddNewNoteView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var Set = this.CreateBindingSet<AddNewNoteView, AddNewNoteViewModel>();

            Set.Bind().For(v => v.Title).To(vm => vm.Title);
            Set.Apply();
        }
    }
}