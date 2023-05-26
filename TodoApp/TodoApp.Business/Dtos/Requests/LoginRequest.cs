using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Business.Dtos.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre adı boş geçilemez!")]
        public string Password { get; set; }
        public bool IsKeepLoggedIn { get; set; }
    }
}
