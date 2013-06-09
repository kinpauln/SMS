using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace SMS.UI.Mvc3.Filters
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        /*注意：  其中 filterContext对象是 从页面传过来的。
                        获取页面controller值的方法是  filterContext.RouteData.GetRequiredString("controller")
                        获取页面action值的方法是： filterContext.RouteData.GetRequiredString("action")
                        转到其他页面的方法是：  filterContext.HttpContext.Response.Redirect()I
                        ip: filterContext.HttpContext.Request.Url.Host  
                        端口：filterContext.HttpContext.Request.Url.Port.ToString()
         */
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            bool isLoginUser = SMS.UI.Mvc3.Helpers.SMSHelper.IsLoginUser();
            if (!isLoginUser) {
                //filterContext.Result(("http://" + filterContext.HttpContext.Request.Url.Host + ":" + filterContext.HttpContext.Request.Url.Port.ToString() + "/" + retUrl);
                filterContext.Result = new RedirectResult("/");
            }
            //if (filterContext.HttpContext.Request.QueryString["k"] == "go")
            //{
            //    string retUrl = filterContext.RouteData.GetRequiredString("controller") + "/" + filterContext.RouteData.GetRequiredString("action");
            //    filterContext.HttpContext.Response.Redirect("http://" + filterContext.HttpContext.Request.Url.Host + ":" + filterContext.HttpContext.Request.Url.Port.ToString() + "/" + retUrl);
            //}
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //Action执行之后
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            //返回Result之前
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            //filterContext.RouteData.Values["controller"]
            //filterContext.RouteData.Values["action"]
            //返回Result之后
        }
    }
}