using eWallet.BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Mvc;

namespace eWallet
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule serviceModule = new ServiceModule("DefaultLocalConnection");
            NinjectModule clientModule = new ClientModule();

            var kernel = new StandardKernel(serviceModule, clientModule);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
