using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeTofood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
{
    internal static void RegiterContainer(HttpConfiguration httpConfiguration)
    {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SqlIRestaurantData>().As<IRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance()
                .InstancePerRequest();
            builder.RegisterType<OdeToFoodDBContext>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
}
}