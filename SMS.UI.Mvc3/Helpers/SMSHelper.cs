using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;   
using System.IO;

namespace SMS.UI.Mvc3.Helpers
{
    /// <summary>   
    /// LogHelper: write log using log4net   
    /// </summary>   
    public class SMSHelper   
    {
        private SMSHelper() { }
        
        /// <summary>
        ///  判断用户是否已经登录过
        /// </summary>
        public static bool IsLoginUser()
        {
            return !string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name) &&
                System.Web.HttpContext.Current.User.Identity.Name != "admin";
        }
    } 
}