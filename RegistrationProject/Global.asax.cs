using DataLibrary.Orchestrators;
using DataLibrary.Repositories;
using Ninject;
using Ninject.Web.Common.WebHost;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RegistrationProject
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRegistrationOrchestrator>().To<RegistrationOrchestrator>().InSingletonScope();
            kernel.Bind<IReportingOrchestrator>().To<ReportingOrchestrator>().InSingletonScope();
            kernel.Bind<IRegistrationRepository>().To<RegistrationRepository>().InSingletonScope();
            kernel.Bind<IReportingRepository>().To<ReportingRepository>().InSingletonScope();
        }

    }
}
