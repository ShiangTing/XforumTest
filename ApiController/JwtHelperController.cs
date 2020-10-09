using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.Entities;
using XforumTest.Helpers;
using XforumTest.Interface;
using XforumTest.Models;

namespace XforumTest.ApiController
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtHelperController : ControllerBase
    {
        private IJwtHelperService _jwt;
        public JwtHelperController(IJwtHelperService jwt)
        {
            _jwt = jwt;
        }
        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult SignIn([FromBody]AuthenticateRequest login)
        {
            var check = _jwt.ValidateUser(login);
            if (check == null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }
            //HttpContext.Response.Cookies.Append("UserToken", check.Token);
            return Ok(check);
        }
        [HttpGet("claim")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }
        [HttpGet("jwtid")]
        public IActionResult GetUniqueId()
        {
            return Ok(User.Claims.FirstOrDefault(p => p.Type == "jti").Value);
        }
        [HttpGet("username")]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }
        [HttpGet("getmembers")]
        public IActionResult GetMembers()
        {
            return Ok(_jwt.GetMembers());
        }
        [HttpGet("getposts")]
        public IActionResult GetPosts()
        {
            return Ok(_jwt.GetPosts());
        }
    }
}
