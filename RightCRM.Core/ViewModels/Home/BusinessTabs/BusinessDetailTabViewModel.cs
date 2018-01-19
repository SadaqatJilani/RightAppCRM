// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BusinessDetailTabViewModel.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   BusinessDetailTabViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace RightCRM.Core.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MvvmCross.Core.Navigation;
    using MvvmCross.Core.ViewModels;
    using RightCRM.Common;

    /// <summary>
    /// Business detail tab view model.
    /// </summary>
    public class BusinessDetailTabViewModel : BaseViewModel
    {
        /// <summary>
        /// The index of the item.
        /// </summary>
        private int itemIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RightCRM.Core.ViewModels.Home.BusinessDetailTabViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public BusinessDetailTabViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.ShowInitialViewModelsCommand = new MvxAsyncCommand(this.ShowInitialViewModels);
        }

        /// <summary>
        /// Gets the show initial view models command.
        /// </summary>
        /// <value>The show initial view models command.</value>
        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }

        /// <summary>
        /// Gets or sets the index of the item.
        /// </summary>
        /// <value>The index of the item.</value>
        public int ItemIndex
        {
            get
            {
                return this.itemIndex;
            }

            set
            {
                if (this.itemIndex == value)
                {
                    return;
                }

                this.itemIndex = value;
                //// MvxTrace.Trace("Tab item changed to {0}", _itemIndex.ToString());
                this.RaisePropertyChanged(() => this.ItemIndex);
            }
        }

        /// <summary>
        /// Prepare this instance.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();

            this.Title = Constants.TitleBusinessDetailsPage;
        }

        /// <summary>
        /// Shows the initial view models.
        /// </summary>
        /// <returns>The initial view models.</returns>
        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>
            {
                navigationService.Navigate<BusDetailTab1ViewModel>(),
                navigationService.Navigate<BusDetailTab2ViewModel>()
            };
            await Task.WhenAll(tasks);
        }
    }
}
