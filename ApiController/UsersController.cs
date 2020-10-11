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
        /// 註冊會員功能 輸入model
        /// </summary>
        [HttpPost]
        public ApiResult<CreateMemberDto> Register([FromBody] CreateMemberDto dto)
        {
            var result = new ApiResult<CreateMemberDto>();

            if (ModelState.IsValid)
            {
                
                _userService.Create(dto);
                return result;
            }
            else
            {
                return new ApiResult<CreateMemberDto>("Dto");
            }
        }



        /// <summary>
        ///  取得單一會員資料(目前還不拿稱號)
        ///  會拿到.....資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResult<MemberDto> GetSingleMember(Guid id)
        {
            var result = new ApiResult<MemberDto>();

            if (id!=null)
            {

                _userService.GetSingle(id);
                //要修改
                return result;
            }
            else
            {
                return new ApiResult<MemberDto>("id");
            }
        }


        [HttpPost]
        public ApiResult<MemberDto> UpdateMember(MemberDto dto)
        {
            var result = new ApiResult<MemberDto>();

            if (ModelState.IsValid)
            {

                //_userService.GetSingle(id);
                return result;
            }
            else
            {
                return new ApiResult<MemberDto>("id");
            }
        }
    }
}
