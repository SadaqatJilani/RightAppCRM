using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using RightCRM.Common.Services;
using RightCRM.Core.Services;
using RightCRM.DataAccess.Api;
using RightCRM.DataAccess.Api.BusinessApi;
using RightCRM.DataAccess.Api.User;
using RightCRM.DataAccess.Factories;
using RightCRM.Facade.Facades;

namespace RightCRM.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
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

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            var appStart = Mvx.Resolve<IMvxAppStart>();

            // register the appstart object
            RegisterAppStart(appStart);
        }


    }
}
