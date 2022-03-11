using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_implement.Models
{
    public class LoginResponse
    {
        public User? User { get; set; }
        public string? Token { get; set; }
    }
}