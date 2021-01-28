using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using System;
using System.Web.Mvc;
using TrueCrimeRepo.Contracts;
using TrueCrimeRepo.Services;

[assembly: OwinStartupAttribute(typeof(TrueCrimeRepo.WebMVC.Startup))]
namespace TrueCrimeRepo.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //// OPTIONAL: Register web abstractions like HttpContextBase.

            //builder.RegisterModule<AutofacWebTypesModule>();
            //builder.RegisterType<CrimeService>().As<ICrimeService>();

            //// Set the dependency resolver to be Autofac.
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ConfigureAuth(app);
    
        }

    }

}
