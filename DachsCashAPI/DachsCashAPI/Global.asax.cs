using System.Web;
using System.Web.Http;
using DachsCashAPI.Services;
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

            _container.Register<IBudgetService, BudgetService>(Lifestyle.Transient);
            _container.Verify();

            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);
        }
    }
}
