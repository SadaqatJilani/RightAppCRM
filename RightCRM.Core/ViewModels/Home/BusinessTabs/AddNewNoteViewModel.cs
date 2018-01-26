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
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using RightCRM.Common;
using RightCRM.Common.Models;

namespace RightCRM.Core.ViewModels.Home
{
    public class AddNewNoteViewModel : BaseViewModel
    {
        private ObservableCollection<PickerItem> pickerQueryType;
        private ObservableCollection<PickerItem> pickerAnswerType;
        private ObservableCollection<PickerItem> pickerClientType;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Core.ViewModels.Home.AddNewNoteViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public AddNewNoteViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

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


            AddCommentCommand = new MvxAsyncCommand(async () => await AddCommentAndGoBack());
        }

        private async Task AddCommentAndGoBack()
        {
           // throw new NotImplementedException();
          await navigationService.Close(this);

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

        public IMvxCommand AddCommentCommand { get; set; }

        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleCreateNewNotePage;
        }
    }
}
