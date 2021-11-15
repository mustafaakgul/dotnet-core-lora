using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using ResponseStates.Models;
using Entities.Models.WebUI.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Middleware.Areas.Web.Controllers.v1
{
    [Area("web")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[area]/users")]
    //[Route("v{version:apiVersion}/[area]/[controller]")]
    //[Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /*
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

        // POST api/values
        [HttpPost("create")]
        public ResponseState Post([FromBody] RegisterModel registerModel)
        {
            return _userService.Create(registerModel);
        }

    }
}
