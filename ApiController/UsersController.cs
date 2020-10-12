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
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 註冊會員功能 輸入model 若email與暱稱有重複erroMsg會顯示"此Email/暱稱已存在，請換一組Email"
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<CreateMemberDto> Register([FromBody] CreateMemberDto dto)
        {
            var result = new ApiResult<CreateMemberDto>();

            if (ModelState.IsValid)
            {
                if (_userService.VerifyEmailAndName(dto.Email)=="1")
                {
                   // ModelState.AddModelError("Email", "此Email已存在");
                    return new ApiResult<CreateMemberDto>("此Email已存在，請換一組Email");
                }
                if(_userService.VerifyEmailAndName(dto.Name) == "2")
                {
                    return new ApiResult<CreateMemberDto>("此暱稱已存在，請換一組暱稱");
                }
                _userService.Create(dto);
                return result;
            }
            else
            {
                return new ApiResult<CreateMemberDto>("Dto is invalid");
            }
        }

        /// <summary>
        ///  取得單一會員資料(目前還不拿稱號)
        ///  測試中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ApiResult<MemberDto> GetSingleMember(Guid id)
        {
            var result = new ApiResult<MemberDto>();

            if (id!=null)
            {

               result.Data= _userService.GetSingle(id);
                //要修改
                return result;
            }
            else
            {
                return new ApiResult<MemberDto>("id is null");
            }
        }

        [Authorize]
        [HttpPost]
        public ApiResult<MemberDto> UpdateMember(MemberDto dto)
        {
            var result = new ApiResult<MemberDto>();

            if (ModelState.IsValid)
            {

                _userService.Edit(dto);
                return result;
            }
            else
            {
                return new ApiResult<MemberDto>("id is null");
            }
        }
    }
}
