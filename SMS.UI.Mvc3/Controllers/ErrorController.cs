using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.OleDb;
using System.Net.Mail;
using System.Data;
using System.Web;

namespace SMS.UI.Mvc3.Controllers
{
    public class ErrorController : Controller
    {
        public virtual ActionResult Index()
        {
            Exception exception =  RouteData.Values["error"] as Exception;
            
            ViewData["exception"] = exception;
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}