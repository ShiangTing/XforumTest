using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Services;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LikeAndDisLikeController : ControllerBase
    {
        private readonly ILikeService<MessageLikeDto> _mlikeService;
        private readonly ILikeService<PostLikeDto> _plikeService;

        public LikeAndDisLikeController(ILikeService<MessageLikeDto> mlikeService, ILikeService<PostLikeDto> plikeService)
        {
            _mlikeService = mlikeService;
            _plikeService = plikeService;
        }

        /// <summary>
        /// 對留言按讚跟按倒讚功能
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        [HttpPost]

        public ApiResult<MessageLikeDto> MsgLikeAndDisLike([FromBody]MessageLikeDto Dto)
        {
            var result = new ApiResult<MessageLikeDto>();
            System.Diagnostics.Debug.WriteLine("test");
            if (ModelState.IsValid)
            {
              //  var service = new LikeService();
                _mlikeService.PostLikeAndDisLike(Dto);
                return result;
            }
            else
            {
                return new ApiResult<MessageLikeDto>("Dto");
            }

        }

        /// <summary>
        /// 對發文按讚跟按倒讚功能
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        [HttpPut]
        public ApiResult<PostLikeDto> PostLikeAndDisLike(PostLikeDto Dto)
        {
            var result = new ApiResult<PostLikeDto>();

            if (ModelState.IsValid)
            {
                //  var service = new LikeService();
                _plikeService.PostLikeAndDisLike(Dto);
                return result;
            }
            else
            {
                return new ApiResult<PostLikeDto>("Dto");
            }

        }
    }
}
