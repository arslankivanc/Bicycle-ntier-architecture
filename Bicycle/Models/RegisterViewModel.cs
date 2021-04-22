using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycle.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bu alan gereklidir")]
        [Remote("IsUsernameInUse", "Account")]
        [Display(Name ="Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        [MinLength(5,ErrorMessage = "Şifre için en az 5 en fazla 50 karakter girebilirsiniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Onay")]
        [StringLength(50,ErrorMessage ="Şifre için en az 5 en fazla 50 karakter girebilirsiniz",MinimumLength =5)]
        [Compare("Password", ErrorMessage = "Şifre eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
