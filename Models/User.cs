using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bit285_assignment2_login.Models
{
    public class User
    {
        //Represents Primary Key
        public long Id { get; set;  }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Program { get; set; }

    }
}
