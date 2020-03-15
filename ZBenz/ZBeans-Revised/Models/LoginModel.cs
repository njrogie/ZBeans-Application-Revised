using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZBeansApplication.Models
{
    public class LoginModel
    {

        public string Email;
        public string Password;
        public User UserData { get; set; }

    }
}
