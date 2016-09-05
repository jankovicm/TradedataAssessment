using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using TradedataAssessment.Init.Modules;

namespace TradedataAssessment.Init
{
    public class DependencyInitializer
    {
        public static void InitializeTradedata(Assembly projectAssembly, ContainerBuilder builder = null)
        {
            if (builder == null)
                builder = new ContainerBuilder();

            //builder.RegisterApiControllers(projectAssembly).PropertiesAutowired();

            builder.RegisterModule(new EntityFrameworkModule());
            builder.RegisterModule(new ServiceModule());
            
            //builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();
            //var resolver = new AutofacDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}