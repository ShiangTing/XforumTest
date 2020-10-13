using System;
using System.Diagnostics;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.NewFolder;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class LikeService : ILikeService<MessageLikeDto> ,ILikeService<PostLikeDto>
    {
        private readonly IRepository<ReposiveMessages> _messages;
        public LikeService(IRepository<ReposiveMessages> messages)
        {
            _messages = messages;
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
                mRepo.LikeNumber = entity.LikeNumber;
                mRepo.DisLikeNumber = entity.DisLikeNumber;
                _messages.Update(mRepo);
                _messages.SaveContext();
            }         
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }         
        }

        /// <summary>
        /// PostLikeandDisLike 傳入發文Id和按讚數
        /// </summary>
        /// <param name="entity"></param>
        public void PostLikeAndDisLike(PostLikeDto entity)
        {
            try
            {
                var mRepo = _messages.GetFirst(x => x.MessageId == entity.PostId);
                mRepo.LikeNumber = entity.LikeNumber;
                mRepo.DisLikeNumber = entity.DisLikeNumber;
                _messages.Update(mRepo);
                _messages.SaveContext();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
