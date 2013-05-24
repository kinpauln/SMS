using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Domain;
using SMS.Domain.Repositories;
using SMS.Entities;
using SMS.UI.Mvc3.Helpers;
using System.Data;

namespace SMS.UI.Mvc3.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public JsonResult Logon(FormCollection formdata)
        {
            string userName = formdata["UserName"];
            string password = formdata["Password"];

            bool sucess = false;
            string message = string.Empty;

            return Json(new
            {
                Succeed = sucess,
                ErrorInfo = message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
