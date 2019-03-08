using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bit285_assignment3_api.Models
{
    public class User
    {
        //Represents Primary Key
        public long Id { get; set;  }
        [Required(ErrorMessage = "* required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "* required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "* required")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "* required")]
        public string Program { get; set; }
        public string Password { get; set; }

        //Navigation Property
        public ICollection<Activity> Activities { get; set; }
    }
}
