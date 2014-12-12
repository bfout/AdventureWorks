using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace AdventureWorks.WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.DependencyResolver = AutofacDependencyResolver();
        }

        private static IDependencyResolver AutofacDependencyResolver()
        {
            var builder = new ContainerBuilder();

            var businessLogicAssembly = Assembly.Load("AdventureWorks.BusinessLogic");
            var dataAccessAssembly = Assembly.Load("AdventureWorks.DataAccess");
            var webApiAssembly = Assembly.Load("AdventureWorks.WebApi");

            builder.RegisterAssemblyTypes(businessLogicAssembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAccessAssembly).AsImplementedInterfaces();
            builder.RegisterApiControllers(webApiAssembly);

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);

            return resolver;
        }
    }
}
