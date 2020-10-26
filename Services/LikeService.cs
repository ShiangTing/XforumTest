using System;
using System.Diagnostics;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;


namespace XforumTest.Services
{
    public class LikeService : ILikeService<MessageLikeDto> ,ILikeService<PostLikeDto>
    {
        private readonly IRepository<ReposiveMessages> _messages;
        private readonly IRepository<Posts> _posts;
        public LikeService(IRepository<ReposiveMessages> messages,IRepository<Posts> posts)
        {
            _posts = posts;
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
                var mRepo = _posts.GetFirst(x => x.PostId == entity.PostId);
                mRepo.LikeNumber = entity.LikeNumber;
                mRepo.DisLikeNumber = entity.DisLikeNumber;
                _posts.Update(mRepo);
                _posts.SaveContext();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
