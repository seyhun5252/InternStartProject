using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternStartProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adını<ı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresini giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
    }
}
