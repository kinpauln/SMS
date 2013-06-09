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
using SMS.UI.Mvc3.Controllers;

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
            LogHelper.SetConfig();

            //Database.SetInitializer<SMSContext>(new SMSIntializer());
            //Database.SetInitializer(new DropCreateDatabaseAlways<UserDBContext>()); 
            //Database.SetInitializer<SMSContext>(new DropCreateDatabaseIfModelChanges<SMSContext>());
                        
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception objExp = HttpContext.Current.Server.GetLastError();
            //LogHelper.WriteLog("\r\nIP:" + Request.UserHostAddress + "\r\nError Page:" + Request.Url + "\r\nInner Message:" + Server.GetLastError().InnerException.Message + "\r\nMessage:" + Server.GetLastError().Message, objExp);
            if (objExp != null)
            {
                string errString = string.Join("\r\n",
                    new string[]{
                    "IP:"+Request.UserHostAddress,
                    "Error Page:" + Request.Url,
                    "Inner Message:" + (objExp.InnerException == null ? string.Empty : objExp.InnerException.Message),
                    "Message:" + (objExp == null ? string.Empty : objExp.Message)
                    }
                );
                LogHelper.WriteLog(errString, objExp);
            }

            Exception exception = Server.GetLastError();
            // Log the exception.

            Response.Clear();

            RouteData routeData = new RouteData();
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("controller", "Error");

            //HttpException httpException = exception as HttpException;


            //if (httpException == null)
            //{
            //    routeData.Values.Add("action", "Index");
            //}
            //else //It's an Http Exception, Let's handle it.
            //{
            //    switch (httpException.GetHttpCode())
            //    {
            //        case 404:
            //            // Page not found.
            //            routeData.Values.Add("action", "HttpError404");
            //            break;
            //        case 500:
            //            // Server error.
            //            routeData.Values.Add("action", "HttpError500");
            //            break;

            //        // Here you can handle Views to other error codes.
            //        // I choose a General error template  
            //        default:
            //            routeData.Values.Add("action", "General");
            //            break;
            //    }
            //}

            // Pass exception details to the target error View.
            routeData.Values.Add("error", exception);

            // Clear the error on server.
            Server.ClearError();

            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;

            // Call target Controller and pass the routeData.
            IController errorController = new ErrorController();
            errorController.Execute(new RequestContext(
                 new HttpContextWrapper(Context), routeData));
        } 
    }
}