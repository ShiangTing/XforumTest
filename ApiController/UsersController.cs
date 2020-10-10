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
    }
}
