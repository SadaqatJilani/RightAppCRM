// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessDetailTabViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessDetailTabViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using RightCRM.Common;

namespace RightCRM.Core.ViewModels.Home
{
    public class BusinessDetailTabViewModel : BaseViewModel
    {
        public BusinessDetailTabViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            CloseBusinessDetailCommand = new MvxAsyncCommand(async () => await navigationService.Navigate<BusinessViewModel, string>(Constants.TitleBusinessPage));
            ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
        }

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }
        public IMvxCommand CloseBusinessDetailCommand { get; private set; }


        public override void Prepare()
        {
            base.Prepare();

            Title = Constants.TitleBusinessDetailsPage;
        }

        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>
            {
                navigationService.Navigate<BusDetailTab1ViewModel>(),
                navigationService.Navigate<BusDetailTab2ViewModel>()
            };
            await Task.WhenAll(tasks);
        }

        private int _itemIndex;

        public int ItemIndex
        {
            get { return _itemIndex; }
            set
            {
                if (_itemIndex == value) return;
                _itemIndex = value;
               // MvxTrace.Trace("Tab item changed to {0}", _itemIndex.ToString());
                RaisePropertyChanged(() => ItemIndex);
            }
        }
    }
}
