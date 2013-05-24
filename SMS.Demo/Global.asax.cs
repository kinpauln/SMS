using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using SMS.Domain;
using SMS.UI.Mvc3.Demo.Models;
using SMS.UI.ControllerFactory;
using SMS.UI.Mvc3.Demo.Helpers;
using SMS.Entities;

namespace SMS.UI.Mvc3.Demo
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

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SMSContext>());
            //using (SMSContext db = new SMSContext())
            //{
            //    SMSContext context = new SMSContext();
            //    var books = new List<Book> { 
            //     new Book {  Name = "钢铁是怎样炼成的",  
            //                 PublishDate=DateTime.Parse("2001-01-11"), 
            //                 Author="奥斯特洛夫斯基", 
            //                 Price=17.00,
            //                 Sales=100,
            //                 MarketArea=new Area(){
            //                     Nation="中国",
            //                     Province="山东",
            //                     City="青岛"
            //                 }
            //               },  

            //     new Book {  Name = "巴黎圣母院", 
            //                 PublishDate=DateTime.Parse("1980-02-23"), 
            //                 Author="雨果", 
            //                 Price=19.98,
            //                 Sales=200,
            //                 MarketArea=new Area(){
            //                     Nation="中国",
            //                     Province="广东",
            //                     City="深圳"
            //                 }
            //               }

            // };
            //    books.ForEach(d => context.Books.Add(d));
            //    context.SaveChanges();

            //    var users = new List<User> { 
            //     new User {  UserName = "Kinpauln",  
            //          Password="123456",
            //           Email="kinpauln@126.com"
            //               }
            // };
            //    users.ForEach(d => context.Users.Add(d));
            //    context.SaveChanges();
            //}

            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}