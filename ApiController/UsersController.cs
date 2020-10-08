using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.Interface;
using XforumTest.Models;

namespace XforumTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenicate([FromBody]AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            if(response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }
            HttpContext.Response.Cookies.Append("UserLoginToken", response.Token);
            return Ok(response);
        }
        [Authorize]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}
