using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bit285_assignment3_api.Models;
using bit285_assignment3_api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bit285_assignment3_api.Controllers
{
    public class AdminController : Controller
    {
        private BitDataContext _dbc;

        public AdminController(BitDataContext dbc)
        {
            _dbc = dbc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserAdmin userAdmin = new UserAdmin { Users = _dbc.Users };
            return View(userAdmin);
        }

        [HttpPost]
        public IActionResult Index(UserAdmin userAdmin)
        {
            if (userAdmin.FullName == null)
            {
                // returns the full list of users if the search string is empty
                userAdmin.Users = _dbc.Users;
            }
            else
            {
                // returns the list of users with any part of their full names matching the search string
                userAdmin.Users = _dbc.Users.Where(u => u.FullName.Contains(userAdmin.FullName));
            }
            return View(userAdmin);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View("EditUser");
        }

        [HttpGet]
        public IActionResult UpdateUser(long id)
        {
            User user = _dbc.Users.Single(u => u.Id == id);
            return View("EditUser", user);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if (user.Id == 0)
            {
                // Adds as new user if Id property is empty (0 by default from CreateUser action)
                _dbc.Add(user);
            }
            else
            {
                _dbc.Update(user);
            }
            _dbc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RemoveUser(long id)
        {
            User user = new User { Id = id };
            _dbc.Remove(user);
            _dbc.SaveChanges();
            return RedirectToAction("Index");
        }

        // Action to view all activities of a user
        [HttpGet]
        public IActionResult UserActivities(long id)
        {
            UserAdmin ua = new UserAdmin { FullName = _dbc.Users.Single(u => u.Id == id).FullName,
                Activities = _dbc.Activities.Where(i => i.Actor.Id == id).OrderByDescending(a => a.ActivityDate) };
            return View(ua);
        }
    }
}