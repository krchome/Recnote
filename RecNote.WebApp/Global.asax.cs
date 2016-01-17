using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RecNote.WebApp.Models;

namespace RecNote.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           /// BundleMobileConfig.RegisterBundles(BundleTable.Bundles);
        //    System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<ServiceContext>());

        }
    }
}
