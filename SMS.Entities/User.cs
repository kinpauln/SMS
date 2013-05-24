using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.Entities
{
    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }

        [DisplayName("用户名")]
        [Required(ErrorMessage = "必须输入书名")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "必须输入密码")]
        public string Password { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
