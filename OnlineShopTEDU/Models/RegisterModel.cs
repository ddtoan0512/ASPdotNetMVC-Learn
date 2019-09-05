using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopTEDU.Models
{
    public class RegisterModel
    {
        [Key] // Khong dung den nhung van can
        public long ID { get; set; }

        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Tên đăng nhập là bắt buộc")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(30, ErrorMessage ="Độ dài mật khẩu tối thiểu là 6 kí tự")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email")]
        public string Email  { get; set; }

        [Display(Name = "Điện thoại")]
        public string Phone  { get; set; }

        [Display(Name = "Tỉnh/thành")]
        public string ProvinceID { get; set; }

        [Display(Name = "Quận/huyện")]
        public string DistrictID { get; set; }

    }
}