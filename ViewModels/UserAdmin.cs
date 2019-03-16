using System;
using System.Collections.Generic;
using bit285_assignment3_api.Models;

namespace bit285_assignment3_api.ViewModels
{
    public class UserAdmin
    {
        //TODO : Add properties to support the /Views/Admin/Index.cshtml View

        public string FullName { get; set; }

        public IEnumerable<User> Users { get; set; }

        // Activities list for bonus
        public IEnumerable<Activity> Activities { get; set; }
    }
}
