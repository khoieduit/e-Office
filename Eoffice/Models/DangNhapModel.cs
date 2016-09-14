using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eoffice.Models
{
    public class DangNhapModel
    {
        [Required(ErrorMessage="Vui lòng nhập tài khoản !")]
        public string TaiKhoan { set; get; }

        [Required(ErrorMessage="Vui lòng nhập mật khẩu")]
        public string MatKhau { set; get; }
    }
}