using Autofac;
using Autofac.Integration.WebApi;
using NotificationManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace NotificationHub.Api
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<NotificationManager.NotificationManager>()
                   .As<INotificationManager>()
                   .InstancePerRequest();

            

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}