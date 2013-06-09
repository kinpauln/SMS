using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;   
using System.IO;
using System.Configuration;
using SMS.UI.Mvc3.Models;

namespace SMS.UI.Mvc3.Models
{
    /// <summary>   
    /// LogHelper: write log using log4net   
    /// </summary>   
    public class SMSModel
    {
        private static string _dbConnString = ConfigurationManager.ConnectionStrings["db_SMSConnectionString"].ConnectionString;

        private SMSModel() { }
        
        /// <summary>
        ///   根据用户名获取一个用户实体对象
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>用户实体</returns>
        public static tb_User GetOneUserEntity(string username)
        {
            using (SMSDataClassesDataContext dc = new SMSDataClassesDataContext(_dbConnString)) {
                var user = dc.tb_Users.Where(u => u.UserName.Trim().ToLower().Equals(username.Trim().ToLower())).FirstOrDefault();
                return user;
            }
        }
    } 
}