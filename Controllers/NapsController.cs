using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bit285_assignment2_login.Models;


namespace bit285_assignment2_login.Controllers
{
    public class NapsController : Controller
    {
        private BitDataContext _dbc;
        /*
         * Constructor
         */
         public NapsController(BitDataContext dbc)
        {
            _dbc = dbc;
        }

        /* 
         * 1) Account Info 
        */
        public IActionResult AccountInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AccountInfo(User user)
        {
            _dbc.Add<User>(user);
            _dbc.SaveChanges();

            return RedirectToAction("PasswordInfo", new { id=user.Id});
        }
        /* 
         * 2) Password Info 
        */
        [HttpGet]
        public IActionResult PasswordInfo(long id)
        {
            //The route includes the id as the parameter
            User dbUser = _dbc.Users.Find(id);

             return View( new { LastName = dbUser.LastName });
        }
        [HttpPost]
        public IActionResult PasswordInfo(User account, string dummy)
        {

            return RedirectToAction("SelectPassword", "Naps", account);
        }
        /* 
         * 3) Select Password  
        */
        [HttpGet]
        public IActionResult SelectPassword(User account)
        {
            return View(account);
        }
        [HttpPost]
        public IActionResult SelectPassword(User account, string dummy)
        {
            return RedirectToAction("ConfirmAccount", "Naps", account);
        }
        /* 
         * 4) Confirm Account 
        */
        [HttpGet]
        public IActionResult ConfirmAccount(User account)
        {
            return View(account);
        }
        [HttpPost]
        public IActionResult ConfirmAccount()
        {
            return RedirectToAction("Login");
        }
        /* 
         * 5) Login 
        */
        public IActionResult Login()
        {
            return View();
        }
    }
}
