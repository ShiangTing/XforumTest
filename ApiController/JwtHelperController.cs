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
    [Route("api/[controller]")]
    [ApiController]
    public class JwtHelperController : ControllerBase
    {
        private IJwtHelperService _jwt;
        public JwtHelperController(IJwtHelperService jwt)
        {
            _jwt = jwt;
        }
        /// <summary>
        /// Login and release jwt token(in JSON)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] AuthenticateRequest login)
        {
            var check = _jwt.ValidateUser(login);
            if (check == null) return BadRequest(new { message = "Username or password is incorrect!" });
            //HttpContext.Response.Cookies.Append("UserToken", check.Token);
            return Ok(check);
        }
        /// <summary>
        /// Get username(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("username")]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }
        /// <summary>
        /// Get userID(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("userid")]
        public string GetUserId()
        {
            return _jwt.GetUserId(User.Identity.Name);
        }
        /// <summary>
        /// Get all claims in Jwt Token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("claim")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }
        /// <summary>
        /// 取得jwt token中的role
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("getrole")]
        public IActionResult GetRole()
        {
            return Ok(User.Claims.FirstOrDefault(p => p.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value);
        }
        /// <summary>
        /// Get jwtId in Token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("jwtid")]
        public IActionResult GetUniqueId()
        {
            return Ok(User.Claims.FirstOrDefault(p => p.Type == "jti").Value);
        }
        /// <summary>
        /// Get all members, convert to JSON(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "肥宅魔法師")]
        [HttpGet("getmembers")]
        public IActionResult GetMembers()
        {
            return Ok(_jwt.GetMembers());
        }
        /// <summary>
        /// Get all posts, convert to JSON(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "我怕練太壯")]
        [HttpGet("getposts")]
        public IActionResult GetPosts()
        {
            return Ok(_jwt.GetPosts());
        }
    }
}
