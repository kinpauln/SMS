using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using SMS.Domain;
using SMS.UI.Mvc3.Models;
using SMS.UI.ControllerFactory;
using SMS.UI.Mvc3.Helpers;
using SMS.Entities;

namespace SMS.UI.Mvc3
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Register();
            //routes.MapRoute(
            //    "Default", // 路由名称
            //    "{controller}/{action}/{id}", // 带有参数的 URL
            //    new { controller = "Books", action = "Add", id = UrlParameter.Optional } // 参数默认值
            //);
        }

        protected void Application_Start()
        {
            //Database.SetInitializer<SMSContext>(new SMSIntializer());
            //Database.SetInitializer(new DropCreateDatabaseAlways<UserDBContext>()); 
            //Database.SetInitializer<SMSContext>(new DropCreateDatabaseIfModelChanges<SMSContext>());
                        
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}