using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Services;

//using static XforumTest.Services.ApiResult;

namespace XforumTest.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RMessageController : ControllerBase
    {
        //private ApiResult<RMessageDTO> results;
        
        private readonly IMessageService _messageService;
        private readonly ILikeService<MessageLikeDto> _likeService;

        public RMessageController(IMessageService messageService,ILikeService<MessageLikeDto> likeService)
        {
            _messageService = messageService;
            _likeService = likeService;
        }
        
        
        /// <summary>
        /// 留言
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult<RMessageDTO> CreateMessage(RMessageDTO dto)
        {
            var result = new ApiResult<RMessageDTO>();
            if (ModelState.IsValid)
            {
               // var service = new RMessageService();
                _messageService.Create(dto);

                return  result;
            }
            else
            {
      
                return new ApiResult<RMessageDTO>("dto");
            }
        }


        /// <summary>
        /// 依據傳入PostId去拿到所有的留言 api/RMessage/XXXX-XXXX
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>

        [HttpGet("{postId}")]
        public async Task<ApiResult<List<RMessageDTO>>> GetAllMessages(Guid postId)
        {
            var result = new ApiResult<List<RMessageDTO>>();

            if (postId != null)
            {
              //  var service = new RMessageService();
                result.Data = await _messageService.GetAllbyPostId(postId);
                return result;

            }
            else
            {
   
                return new ApiResult<List<RMessageDTO>>("postId"); 
            }
        }


        /// <summary>
        /// 永久刪除留言
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        [HttpDelete]
        public ApiResult<RMessageDTO> DeleteMessages(Guid mId)
        {
            var result = new ApiResult<RMessageDTO>();
            if (mId != null)
            {
                // var service = new RMessageService();
                _messageService.Delete(mId);
                return result;
            }
            else
            {
             
                return new ApiResult<RMessageDTO>("Id");
            }

        }


        /// <summary>
        /// 按讚跟按倒讚功能
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        [HttpPut]
        public ApiResult<MessageLikeDto> PostLikeAndDisLike(MessageLikeDto Dto)
        {
            var result = new ApiResult<MessageLikeDto>();

            if (ModelState.IsValid)
            {
                //var service = new LikeService();
                _likeService.PostLikeAndDisLike(Dto);
                return result;
            }
            else
            {
                return new ApiResult<MessageLikeDto>("Dto");
            }

        }

    }
}
