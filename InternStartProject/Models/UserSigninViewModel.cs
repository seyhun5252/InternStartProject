using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternStartProject.Models
{
    public class UserSigninViewModel
    {
        [Required(ErrorMessage = "lütfen kullanıcı adınızı girin")]
        public string username { get; set; }

        [Required(ErrorMessage = "lütfen kullanıcı şifrenizi girin girin")]
        public string password { get; set; }
    }
}
