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
    using RightCRM.Common.Models;
    using System.Threading.Tasks;

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

        MvxObservableCollection<NotesModel> allNotesList;
        public MvxObservableCollection<NotesModel> AllNotesList { get { return allNotesList; } set { SetProperty(ref allNotesList, value); } }

        /// <summary>
        /// Prepare this instance.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();

            this.Title = Constants.TitleBusinessNotesPage;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            AllNotesList = new MvxObservableCollection<NotesModel>
            {
                new NotesModel { NoteUserName = "ExhibitA", NoteComment="Heelloo this is a test" },
                new NotesModel { NoteUserName="ExhibitB", NoteComment="Heelloo this is a test"}
            };

        }
    }
}
