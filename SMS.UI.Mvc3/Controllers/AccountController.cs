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
using System.Configuration;

namespace SMS.UI.Mvc3.Controllers
{
    public class AccountController : BaseController
    {
        private string _dbConnString = ConfigurationManager.ConnectionStrings["db_SMSConnectionString"].ConnectionString;

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(SMS.UI.Mvc3.Models.tb_User model)
        {
            //bool sucess = false;
            string message = string.Empty;

            if (ModelState.IsValid)
            {
                int? count = 0;
                using (SMSDataClassesDataContext dc = new SMSDataClassesDataContext(_dbConnString))
                {
                    count = dc.tb_Users.Where(u => u.UserName.Equals(model.UserName)
                        && u.UserPwd.Equals(model.UserPwd))
                        .Count();
                }
                if (count > 0)
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

            //return Json(new
            //{
            //    Succeed = sucess,
            //    ErrorInfo = message
            //}, JsonRequestBehavior.AllowGet);
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
            //if (ModelState.IsValid)
            //{
            //    db.Users.Add(model);
            //    db.SaveChanges();
            //    return RedirectToAction("Default","Books");
            //}

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }
    }
}
