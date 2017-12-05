using Autofac;
using Autofac.Integration.WebApi;
using NotificationManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace NotificationsHub.WebApi.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacWebAPI();
        }
        public static void SetAutofacWebAPI()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            // Configure the container 
            
            
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterInstance<INotificationManager>(new NotificationManager.NotificationManager());
            
              builder.RegisterAssemblyTypes(
              Assembly.GetExecutingAssembly())
              .Where(t =>
              !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t))
              .InstancePerApiRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }
    }
}