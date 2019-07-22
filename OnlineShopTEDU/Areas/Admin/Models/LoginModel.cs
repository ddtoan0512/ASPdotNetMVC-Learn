using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopTEDU.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn phải nhập username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}