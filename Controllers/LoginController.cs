using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bit285_assignment2_login.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bit285_assignment2_login.Controllers
{
    public class LoginController : Controller
    {
        private BitDataContext _dbc;
        /*
         * Constructor
         */
        public LoginController(BitDataContext dbc)
        {
            _dbc = dbc;
        }


        [HttpGet]
        public IActionResult Index(User user)
        {
            if(user != null)
            {
                ViewModels.Login login = new ViewModels.Login()
                {
                    UserName = user.EmailAddress
                };
                return View(login);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(ViewModels.Login login)
        {
            if (!ModelState.IsValid || !login.isUser(_dbc))
            {
                return View(login);
            }

            return RedirectToAction("Welcome");
        }
    }
}
