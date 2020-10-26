using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Diagnostics;
using System.Net;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;


namespace XforumTest.Services
{
    public class LikeService : ILikeService<MessageLikeDto> ,ILikeService<PostLikeDto>
    {
        private readonly IRepository<ReposiveMessages> _messages;
        private readonly IRepository<LikeAndDislikeHistory> _history;
    
        public LikeService(IRepository<ReposiveMessages> messages, IRepository<LikeAndDislikeHistory> history)
        {
            _messages = messages;
            _history = history;
        }
     
        /// <summary>
        /// PostLikeandDisLike 傳入留言Id和按讚數
        /// </summary>
        /// <param name="entity"></param>
        /// 
        public void PostLikeAndDisLike(MessageLikeDto entity)
        {
            
            try
            {             
               
                var mRepo = _messages.GetFirst(x => x.MessageId == entity.MessageId);
               // var msgUser = _history.GetFirst(x => x.UserId == entity.UserId);
                var msg = _history.GetFirst(x => x.MessageId == entity.MessageId && x.UserId == entity.UserId);
                if(msg != null)
                {
                    _history.Delete(msg);
                    _history.SaveContext();
       
                }
                if (mRepo != null)
                {
                    mRepo.LikeNumber = entity.LikeNumber;
                    mRepo.DisLikeNumber = entity.DisLikeNumber;
                    _messages.Update(mRepo);
                    _messages.SaveContext();
                }
                else
                {
                    //HttpStatusCode()
                }
                
            }         
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }         
        }

        /// <summary>
        /// PostLikeandDisLike 傳入Po文Id和按讚數
        /// </summary>
        /// <param name="entity"></param>
        public void PostLikeAndDisLike(PostLikeDto entity)
        {
            try
            {
                var mRepo = _messages.GetFirst(x => x.MessageId == entity.PostId);
                var post = _history.GetFirst(x => x.PostId== entity.PostId && x.UserId == entity.UserId);
                if (post != null)
                {
                    _history.Delete(post);
                    _history.SaveContext();

                }
                if (mRepo != null)
                {
                    mRepo.LikeNumber = entity.LikeNumber;
                    mRepo.DisLikeNumber = entity.DisLikeNumber;
                    _messages.Update(mRepo);
                    _messages.SaveContext();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        
    }
}
