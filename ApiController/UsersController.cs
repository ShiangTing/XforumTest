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
        /// 註冊會員功能 輸入model 若email與暱稱有重複erroMsg會顯示"此Email/暱稱已存在，請換一組Email"
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<CreateMemberDto> Register([FromBody] CreateMemberDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.VerifyEmailAndNameWhenRegister(dto.Email, dto.Name);
                if (result.Issuccessful) { _userService.Create(dto); }
                return result;
            }
            else
            {
                return new ApiResult<CreateMemberDto>("Dto is invalid");
            }
        }
        /// <summary>
        ///  取得單一會員資料
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ApiResult<MemberDto> GetSingleMember()
        {
            var result = new ApiResult<MemberDto>
            {
                Data = _userService.GetSingleMember(User.Identity.Name)
            };
            return result;
        }
        /// <summary>
        /// 更新會員資料
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public ApiResult<MemberDto> UpdateMember([FromBody] MemberDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.VerifyEmailAndNameWhenEdit(dto.Email, dto.Name, User.Identity.Name);
                if (result.Issuccessful) { _userService.Edit(dto, User.Identity.Name); }
                return result;
            }
            else
            {
                return new ApiResult<MemberDto>("id is null");
            }
        }
    }
}
