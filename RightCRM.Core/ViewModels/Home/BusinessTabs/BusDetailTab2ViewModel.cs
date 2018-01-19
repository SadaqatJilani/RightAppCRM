// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusDetailTab2ViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusDetailTab2ViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.Core.ViewModels.Home
{
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using RightCRM.Common;

    /// <summary>
    /// Bus detail tab2 view model.
    /// </summary>
    public class BusDetailTab2ViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Core.ViewModels.Home.BusDetailTab2ViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public BusDetailTab2ViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.NewNoteCommand = new MvxAsyncCommand(async () => await navigationService.Navigate<AddNewNoteViewModel>());
        }

        /// <summary>
        /// Gets the new note command.
        /// </summary>
        /// <value>The new note command.</value>
        public IMvxCommand NewNoteCommand { get; private set; }

        /// <summary>
        /// Prepare this instance.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();

            this.Title = Constants.TitleBusinessNotesPage;
        }
    }
}
