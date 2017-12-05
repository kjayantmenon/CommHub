using Autofac;
using Autofac.Integration.WebApi;
using NotificationManager.Contracts;
using NotificationsHub.WebApi.App_Start;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace NotificationsHub.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Bootstrapper.Run();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            SetupDI(config);
        }

        private static void SetupDI(HttpConfiguration configuration)
        {
            //var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            // Configure the container 



            string instrumentaionKey = "0c37906f-efe7-48c8-ae3f-3f93f0e1aa82";
            ILogger logger = new LoggerConfiguration()
                 .WriteTo.File(@"C:\home\code\notificationsvc\logs\logs.txt")
                 .WriteTo.ApplicationInsightsTraces(instrumentaionKey)
                 .CreateLogger();
            builder.RegisterInstance<ILogger>(logger);
            builder.RegisterInstance<INotificationManager>(new NotificationManager.NotificationManager(logger));
            builder.RegisterAssemblyTypes(
            Assembly.GetExecutingAssembly())
            .Where(t =>
            !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t))
            .InstancePerRequest();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}
