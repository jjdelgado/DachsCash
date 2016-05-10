using System.Linq;
using System.Web;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace DachsCashAPI
{
     public class WebApiApplication : HttpApplication
    {
        private static Container _container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureIoc(GlobalConfiguration.Configuration);
        }

        private static void ConfigureIoc(HttpConfiguration configuration)
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            RegisterComponents(_container);
            _container.Verify();

            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);
        }

        private static void RegisterComponents(Container container)
        {
            var repositoryAssembly = typeof(WebApiApplication).Assembly;

            var registrations = from type in repositoryAssembly.GetExportedTypes()
                                where type.Namespace == "DachsCashAPI.Services" || type.Namespace == "DachsCashAPI.Utils" || type.Namespace == "DachsCashAPI.Database"
                                where type.GetInterfaces().Any()
                                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var registration in registrations)
            {
                container.Register(registration.Service, registration.Implementation, Lifestyle.Scoped);
            }
        }
    }
}
