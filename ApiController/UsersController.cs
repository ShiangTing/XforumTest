using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Models;
using XforumTest.Services;

namespace XforumTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get userID(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public string GetUserId()
        {
            return _userService.GetUserId(User.Identity.Name);
        }
        /// <summary>
        /// Get username(when authorized)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetUserName()
        {

            return Ok(User.Identity.Name);
        }
        /// <summary>
        /// Verify email and name when register
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<CreateMemberDto> Register([FromBody] CreateMemberDto dto)
        {
            if (ModelState.IsValid)
            {
                ApiResult<CreateMemberDto> result = _userService.VerifyEmailAndNameWhenRegister(dto);
                if (result.Issuccessful) { _userService.Create(dto); }
                return result;
            }
            else
            {
                return new ApiResult<CreateMemberDto>("Dto is invalid");
            }
        }
        /// <summary>
        /// Get single member info
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ApiResult<ReadMemberDTO> GetSingleMember()
        {
            ApiResult<ReadMemberDTO> result = new ApiResult<ReadMemberDTO>
            {
                Data = _userService.GetSingleMember(User.Identity.Name)
            };
            return result;
        }
        /// <summary>
        /// Edit User info
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPatch]
        public ApiResult<EditMemberDTO> UpdateMember([FromBody] EditMemberDTO dto)
        {
            if (ModelState.IsValid)
            {
                ApiResult<EditMemberDTO> result = _userService.VerifyEmailAndNameWhenEdit(dto, User.Identity.Name);
                if (result.Issuccessful) { _userService.Edit(dto, User.Identity.Name); }
                return result;
            }
            else
            {
                return new ApiResult<EditMemberDTO>("id is null");
            }
        }
        [AllowAnonymous]
        [HttpPatch]
        public ApiResult<EditPasswordDto> EditPasswordIfForgot([FromBody] EditPasswordDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.EditPasswordIfForgot(dto);
                return result;
            }
            return new ApiResult<EditPasswordDto>("Error Model!");
        }
    }
}
