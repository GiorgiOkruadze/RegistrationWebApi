using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Registration.DomainModels.Models
{
    public class UserInformation
    {
        [Key]
        public int Id { get; set;  }
        public string PersonalNumber { get; set; }
        public bool IsMarried { get; set; }
        public bool IsEmployed { get; set; }
        public double RemunerationPerMonthe { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
