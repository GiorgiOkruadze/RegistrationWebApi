using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.DomainModels.Models
{
    public class LogInUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
        public string ReturnUrl { get; set; }
    }
}
