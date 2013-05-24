using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SMS.UI.Mvc3.Models;
using SMS.Domain;
using SMS.Entities;

namespace SMS.UI.Mvc3.Controllers
{
    public class AccountController : Controller
    {
        private UserDBContext db = new UserDBContext();

        public ActionResult Default()
        {
            return View();
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                int count = db.Users.Select(u=>u.UserName.Equals(model.UserName) && u.Password.Equals(model.Password)).Count();

                if (count>0)
                {
                    return RedirectToAction("Default", "Books");
                }
                else
                {
                    // 如果我们进行到这一步时某个地方出错，则重新显示表单
                    return View(model);
                }
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult Register(SMS.Entities.User model)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(model);
                db.SaveChanges();
                return RedirectToAction("Default","Books");
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }
    }
}
