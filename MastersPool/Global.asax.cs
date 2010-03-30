using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Web.Mvc;
using System.Reflection;
using Ninject;
using MastersPool.Services.Interfaces;
using MastersPool.Services;
using MastersPool.Data.Interfaces;
using MastersPool.Data.SqlServer;
using MastersPool.Models;
using System.Web.Security;

namespace MastersPool
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            RegisterAllControllersIn(Assembly.GetExecutingAssembly());
        }

        protected override Ninject.IKernel CreateKernel()
        {
            return new StandardKernel(new ServiceModule());
        }
    }

    internal class ServiceModule : Ninject.Modules.Module
    {
        public override void Load()
        {
            // TODO refactor this to load all from assemblies if it gets painful.
            Bind<IConfigurationService>().To<ConfigurationService>();
            Bind<IGolferService>().To<GolferService>();

            // Authentication bindings
            Bind<IFormsAuthenticationService>().To<FormsAuthenticationService>();
            Bind<IMembershipService>().To<AccountMembershipService>();
            Bind<MembershipProvider>().ToMethod(ctx => Membership.Provider);

            // TODO mmm hardcoded candy goodness
            //Bind<ISessionRepository>().To<SqlSessionRepository>().WithConstructorArgument(
            //    "connection",
            //    "Data Source=tcp:s01.winhost.com;Initial Catalog=DB_2340_smellys;User ID=DB_2340_smellys_user;Password=1MirPan0;Integrated Security=False;"
            //    );

            Bind<ISessionRepository>().To<SqlSessionRepository>().WithConstructorArgument(
                "connection",
                @"server=Brett-dev01\SQLEXPRESS;Trusted_Connection=true;database=ThePoolmeister;"
                );
        }
    }
}