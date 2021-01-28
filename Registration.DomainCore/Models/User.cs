using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Registration.DataAccessLayer.Models
{
    public class User:IdentityUser<int>
    {
        public UserInformation GeneralInformation { get; set; }
    }
}
