using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Messenger;
using RightCRM.Common.Services;
using RightCRM.Core.Services;
using RightCRM.DataAccess.Api;
using RightCRM.DataAccess.Api.BusinessApi;
using RightCRM.DataAccess.Api.User;
using RightCRM.DataAccess.Factories;
using RightCRM.Facade.Facades;

namespace RightCRM.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IBusinessApi, BusinessApi>();
            Mvx.RegisterType<IBusinessFacade, BusinessFacade>();
            Mvx.RegisterType<IRestService, RestService>();
            Mvx.RegisterType<IUserApi, UserApi>();
            Mvx.RegisterType<IUserFacade, UserFacade>();
            Mvx.RegisterType<INotesFacade, NotesFacade>();
            Mvx.RegisterType<INotesApi, NotesApi>();
            Mvx.RegisterType<IBusinessDetailsFacade, BusinessDetailsFacade>();
            Mvx.RegisterType<INewBusFacade, NewBusFacade>();
            Mvx.RegisterType<INewBusApi, NewBusApi>();

            Mvx.RegisterType<ICacheService, CacheService>();
            Mvx.RegisterType<IListsService, ListsService>();

            Mvx.LazyConstructAndRegisterSingleton<IMvxMessenger, MvxMessengerHub>();

            Mvx.RegisterSingleton(() => UserDialogs.Instance);

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            var appStart = Mvx.Resolve<IMvxAppStart>();

            // register the appstart object
            RegisterAppStart(appStart);
        }


    }
}
