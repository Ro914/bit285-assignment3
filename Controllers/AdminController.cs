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

        public IActionResult Index()
        {
            return View();
        }
    }
}