using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycle.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Bu alan gereklidir")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Bu alan gereklidir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
