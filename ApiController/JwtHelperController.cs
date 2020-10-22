using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            AuthenticateResponse check = _jwt.ValidateUser(login);
            //if (check == null) return BadRequest(new { message = "Username or password is incorrect!" });
            //HttpContext.Response.Cookies.Append("UserToken", check.Token);
            return Ok(check);
        }/// <summary>
         /// Get expiretime in Token
         /// </summary>
         /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody]string refreshtoken)
        {
            return Ok(_jwt.RefreshToken(refreshtoken));
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
        /// Get role in jwt token
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
        /// Get expiretime in Token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("exp")]
        public IActionResult GetExpireTime()
        {
            return Ok(User.Claims.FirstOrDefault(p => p.Type == "exp").Value);
        }
        /// <summary>
        /// Get expiretime in Token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("nbf")]
        public IActionResult GetReleaseTime()
        {
            return Ok(User.Claims.FirstOrDefault(p => p.Type == "nbf").Value);
        }
        /// <summary>
        /// Get all members, convert to JSON(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "版主")]
        [HttpGet("getmembers")]
        public IActionResult GetMembers()
        {
            return Ok(_jwt.GetMembers());
        }
        /// <summary>
        /// Get all posts, convert to JSON(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "管理者")]
        [HttpGet("getposts")]
        public IActionResult GetPosts()
        {
            return Ok(_jwt.GetPosts());
        }
    }
}
