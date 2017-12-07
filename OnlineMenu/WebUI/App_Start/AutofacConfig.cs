using Autofac;
using Autofac.Integration.Mvc;
using BusinessLogic.Contracts;
using BusinessLogic.DataBaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.AutofacModule;

namespace WebUI.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //enavle action parameters invoke
            builder.RegisterType<ExtensibleActionInvoker>()
                   .As<IActionInvoker>()
                   .WithParameter("injectActionMethodParameters", true);

            //register modules
            builder.RegisterModule<BusinessLogicRegistrationModule>();
            builder.RegisterModule<WebUIRegistrationModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}