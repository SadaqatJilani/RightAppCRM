// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AddNewNoteViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   AddNewNoteViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Common.Models;
using RightCRM.Common.Services;
using RightCRM.Facade.Facades;

namespace RightCRM.Core.ViewModels.Home
{
    public class AddNewNoteViewModel : BaseViewModel, IMvxViewModel<int, bool>
    {
        private readonly INotesFacade notesFacade;

        private readonly ICacheService cacheService;

        private ObservableCollection<PickerItem> pickerQueryType;
        private ObservableCollection<PickerItem> pickerAnswerType;
        private ObservableCollection<PickerItem> pickerClientType;

        private int accountNum;

        private string commentText;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Core.ViewModels.Home.AddNewNoteViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public AddNewNoteViewModel(IMvxNavigationService navigationService,
                                   IUserDialogs userDialogs,
                                   INotesFacade notesFacade,
                                  ICacheService cacheService) : base (userDialogs)
        {
            this.cacheService = cacheService;
            this.notesFacade = notesFacade;
            this.navigationService = navigationService;
            this.userDialogs = userDialogs;

            AddCommentCommand = new MvxAsyncCommand(async () => await AddCommentAndGoBack());
        }

        private async Task AddCommentAndGoBack()
        {
            // throw new NotImplementedException();
          var res =  await notesFacade.SaveNewNote(new DataAccess.Model.Notes.NewNoteRequestModel()
            {
                ACNUM= accountNum,
                HOWCOMM = SelectedQueryType.Value,
                TELRESP = SelectedAnsType.Value,
                WHOCOMM = SelectedClientType.Value, 
                Note = CommentText, 
                USRID = Convert.ToInt32(await cacheService.RetrieveSettings<string>(Constants.UserID))
            });

            bool refreshList = false;

            if (res != null)
            {
                await userDialogs.AlertAsync(res.note?.msg);
                refreshList = true;
            }

            await navigationService.Close<bool>(this, refreshList);

        }

        /// <summary>
        /// Gets or sets the type of the picker query.
        /// </summary>
        /// <value>The type of the picker query.</value>
        public ObservableCollection<PickerItem> PickerQueryType
        {
            get { return pickerQueryType; }
            set { SetProperty(ref pickerQueryType, value); }
        }

        /// <summary>
        /// Gets or sets the type of the picker answer.
        /// </summary>
        /// <value>The type of the picker answer.</value>
        public ObservableCollection<PickerItem> PickerAnswerType
        {
            get { return pickerAnswerType; }
            set { SetProperty(ref pickerAnswerType, value); }
        }

        /// <summary>
        /// Gets or sets the type of the picker client.
        /// </summary>
        /// <value>The type of the picker client.</value>
        public ObservableCollection<PickerItem> PickerClientType
        {
            get { return pickerClientType; }
            set { SetProperty(ref pickerClientType, value); }
        }

        public PickerItem SelectedQueryType { get; set; }
        public PickerItem SelectedAnsType { get; set; }
        public PickerItem SelectedClientType { get; set; }

        public string CommentText
        {
            get { return commentText; }
            set { SetProperty(ref commentText, value); }
        }

        public IMvxCommand AddCommentCommand { get; set; }

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleCreateNewNotePage;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            PickerQueryType = new ObservableCollection<PickerItem>() {
            new PickerItem() {DisplayName = "Call", Value = 0},
            new PickerItem() {DisplayName = "Visit", Value = 1},
            new PickerItem() {DisplayName = "Email", Value = 2},
            new PickerItem() {DisplayName = "General", Value = 3}
        };
            SelectedQueryType = PickerQueryType[0];

            PickerAnswerType = new ObservableCollection<PickerItem>() {
            new PickerItem() {DisplayName = "Answer", Value = 0},
            new PickerItem() {DisplayName = "No Answer", Value = 1},
            new PickerItem() {DisplayName = "Callback", Value = 2}
        };
            SelectedAnsType = PickerAnswerType[0];

            PickerClientType = new ObservableCollection<PickerItem>() {
            new PickerItem() {DisplayName = "Customer", Value = 0},
            new PickerItem() {DisplayName = "Company Agent", Value = 1}
        };
            SelectedClientType = PickerClientType[0];
        }

        public void Prepare(int parameter)
        {
            accountNum = parameter;
        }
    }
}
