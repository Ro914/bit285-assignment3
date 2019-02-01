using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bit285_assignment2_login.Models;
using bit285_assignment2_login.ViewModels;

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
            PasswordInfo passwordInfo = new PasswordInfo()
            {
                Id = dbUser.Id,
                LastName = dbUser.LastName
            };

             return View(passwordInfo);
        }
        [HttpPost]
        public IActionResult PasswordInfo(PasswordInfo info)
        {
            return RedirectToAction("SelectPassword", info);
        }
        /* 
         * 3) Select Password  
        */
        [HttpGet]
        public IActionResult SelectPassword(PasswordInfo info)
        {
            return View(info);
        }
        [HttpPost]
        public IActionResult SelectPassword(PasswordInfo info, string dummy)
        {
            //PasswordInfo ViewModel includes the UserId, get the User
            User dbUser = _dbc.Users.Find(info.Id);
            //Update the user password from the form
            dbUser.Password = info.Password;
            _dbc.SaveChanges();
            return RedirectToAction("ConfirmAccount", new { id = dbUser.Id });
        }
        /* 
         * 4) Confirm Account 
        */
        [HttpGet]
        public IActionResult ConfirmAccount(long Id)
        {
            return View(_dbc.Users.Find(Id));
        }
        [HttpPost]
        public IActionResult ConfirmAccount(User user)
        {
            return RedirectToAction("Index","Login",user);
        }

    }
}
