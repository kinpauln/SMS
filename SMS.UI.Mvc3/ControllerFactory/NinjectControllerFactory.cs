using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using Ninject;
using Ninject.Modules;
using SMS.Domain.Repositories;
using SMS.Domain.Interfaces;

namespace SMS.UI.ControllerFactory
{
    public class NinjectControllerFactory : DefaultControllerFactory {
        // A Ninject "kernel" is the thing that can supply object instances
        private IKernel kernel = new StandardKernel(new SportsStoreServices());

        // ASP.NET MVC calls this to get the controller for each request
        protected override IController GetControllerInstance(RequestContext context, Type controllerType) {
            if (controllerType == null)
                return base.GetControllerInstance(context, controllerType);
            return (IController)kernel.Get(controllerType);
        }

        // Configures how abstract service types are mapped to concrete implementations
        private class SportsStoreServices : NinjectModule
        {
            public override void Load()
            {
                Bind<IBookRepository>()
                    .To<BookRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["DbConnString"].ConnectionString);
            }
        }
    }
}