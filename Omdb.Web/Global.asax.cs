using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using Omdb.Api;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register Logger
            builder.RegisterInstance(LogManager.GetLogger("Logger")).As<ILog>();

            // Register IOMDbApi service
            builder.RegisterType<OMDbApi>().As<IOMDbApi>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            ILog logger = DependencyResolver.Current.GetService<ILog>();
            Exception exception = Server.GetLastError();
            logger.Error(exception);
        }
    }
}
