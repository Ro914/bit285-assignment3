using System;
using System.Collections.Generic;
using bit285_assignment3_api.Models;

namespace bit285_assignment3_api.ViewModels
{
    public class UserAdmin
    {
        //TODO : Add properties to support the /Views/Admin/Index.cshtml View
        public long uId { get; set; }

        public string FullName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
