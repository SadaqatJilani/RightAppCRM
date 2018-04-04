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
    using RightCRM.Facade.Facades;
    using System.Linq;
    using Acr.UserDialogs;
    using System;
    using RightCRM.Core.ViewModels.ItemViewModels;

    /// <summary>
    /// Bus detail tab2 view model.
    /// </summary>
    public class BusDetailTab2ViewModel : BaseViewModel, IMvxViewModel<int>
    {
        private readonly INotesFacade notesFacade;

        private int businessID;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Core.ViewModels.Home.BusDetailTab2ViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public BusDetailTab2ViewModel(IMvxNavigationService navigationService, 
                                      INotesFacade notesFacade,
                                      IUserDialogs userDialogs) : base(userDialogs)
        {
            this.navigationService = navigationService;
            this.notesFacade = notesFacade;
            this.userDialogs = userDialogs;

            this.NewNoteCommand = new MvxAsyncCommand(SaveNoteAndReturn);
            this.AllNotesList = new MvxObservableCollection<NotesItemViewModel>();
        }

        async Task SaveNoteAndReturn()
        {
            var res = await navigationService.Navigate<AddNewNoteViewModel, int, bool>(businessID);

            if (res == true)
            {
                await this.Initialize();
            }
                
        }

        /// <summary>
        /// Gets the new note command.
        /// </summary>
        /// <value>The new note command.</value>
        public IMvxCommand NewNoteCommand { get; private set; }

        private MvxObservableCollection<NotesItemViewModel> allNotesList;
        public MvxObservableCollection<NotesItemViewModel> AllNotesList { get { return allNotesList; } set { SetProperty(ref allNotesList, value); } }

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

            // this.AllNotesList = new MvxObservableCollection<NotesModel>(await this.notesFacade.GetAllNotes());

            this.AllNotesList.Clear();
                                    
            var result = await this.notesFacade.GetAllNotes(businessID);

            if (result == null || !result.Any())
            {
                // show no result screen
               // this.NoManualsFound = true;
                return;
            }

            foreach (var note in result)
            {
                var noteItem = new NotesItemViewModel
                {
                    NoteID = note.NoteID,
                    BusinessUserName = note.BusinessUserName,
                    BusinessUserID = note.BusinessUserID,
                    NoteString = note.NoteString,
                    AccountNumber = note.AccountNumber,
                    CreatedOnTimeStamp = note.CreatedOnTimeStamp,
                    WorkUserName = "Reported By: " + note.WorkUserName,
                    WorkUserID = note.WorkUserID,
                    CreatedByID = note.CreatedByID,

                    WhoComm = note.WhoComm,
                    HowComm = note.HowComm,
                    TelephoneResponse = note.TelephoneResponse,
                    Attachment = note.Attachment,
                    FollowUpTimeStamp = note.FollowUpTimeStamp
                };

                this.AllNotesList.Add(noteItem);
            }

        }

        public void Prepare(int parameter)
        {
            businessID = parameter;
        }
    }
}
