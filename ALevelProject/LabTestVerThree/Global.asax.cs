using DataLayer;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace LabTestVerThree
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
           // Database.SetInitializer(new LabDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();

            Log.Info("Start MvcApplication");
        }

        protected void Application_End(Object sender, EventArgs e)
        {
            Log.Info("Stop MvcApplication");
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Log.Info("Session_End;");
        }
    }
}
