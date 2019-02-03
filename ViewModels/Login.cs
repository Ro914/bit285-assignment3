using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using bit285_assignment2_login.Models;

namespace bit285_assignment2_login.ViewModels
{
    public class Login
    {
        [Display(Name = "Username (Email)")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [Display(AutoGenerateField =true)]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        public bool IsUser(BitDataContext dbc)
        {
            return dbc.Users.Any(u => (u.EmailAddress == UserName && u.Password == Password));
        }
    }
}
