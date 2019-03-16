using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bit285_assignment3_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bit285_assignment3_api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private BitDataContext _dbc;

        public UserController(BitDataContext dbc)
        {
            _dbc = dbc;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("FullName")]
        public IActionResult Get(string term)
        {
            var userList = _dbc.Users.Where(u => u.FullName.Contains(term)).Select(s => new { id = s.Id, value = s.FullName });
            return Json(userList);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
