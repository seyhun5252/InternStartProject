using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternStartProject.Models
{
    public class UserEditViewModel
    {
        public string userName { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string phonenumber { get; set; }
        public string mail { get; set; }
    }
}
