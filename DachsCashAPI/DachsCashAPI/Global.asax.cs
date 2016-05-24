using System.Linq;
using System.Web;
using System.Web.Http;
using DachsCashAPI.App_Start;
using DachsCashAPI.Database;
using DachsCashAPI.Services;
using DachsCashAPI.Utils;
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
            LogConfig.Register();

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
            // utils
            container.Register<ILogger, Logger>(Lifestyle.Scoped);
            container.Register<IDbSession, DbSession>(Lifestyle.Scoped);
            
            // services
            container.Register<IBudgetService, BudgetService>(Lifestyle.Scoped);
        }

         public static T GetComponent<T>() where T : class
         {
             return (T) _container.GetInstance<T>();
         }
    }
}
