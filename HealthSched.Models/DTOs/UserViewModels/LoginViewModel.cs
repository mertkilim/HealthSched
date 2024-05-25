using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.UserViewModels
{
    public class LoginViewModel
    {
        public string IdentificationNumber { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

    }
}
