using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopTEDU.Models
{
    public class LoginModel
    {
        [Key]
        public string ID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn phải nhập tài khoản")]
        public string UserName { get; set; }

        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage ="Bạn phải nhập mật khẩu")]
        public string Password { get; set; }
    }
}