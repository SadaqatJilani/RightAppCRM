using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using RightCRM.DataAccess.Api;
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
            Mvx.RegisterType<IBusinessApi, FakeBusinessApi>();
            Mvx.RegisterType<IBusinessFacade, BusinessFacade>();
            RegisterAppStart<ViewModels.LoginViewModel>();
        }


    }
}
