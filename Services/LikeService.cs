using System;
using System.Diagnostics;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class LikeService : ILikeService<MessageLikeDto> ,ILikeService<PostLikeDto>
    {
        private readonly MyDBContext context;

        private IRepository<MessageLikeDto> repository;
        public LikeService(MyDBContext _context,IRepository<MessageLikeDto> _repository)
        {
            context = _context;
            repository = _repository;
        }
     

        /// <summary>
        /// PostLikeandDisLike 傳入留言Id和按讚數
        /// </summary>
        /// <param name="entity"></param>
        public void PostLikeAndDisLike(MessageLikeDto entity)
        {
            try
            {
                var repository = new GeneralRepository<ReposiveMessages>(context);

              
                var mRepo = repository.GetFirst(x => x.MessageId == entity.MessageId);
                mRepo.LikeNumber = entity.LikeNumber;
                mRepo.DisLikeNumber = entity.DisLikeNumber;
                repository.Update(mRepo);
                repository.SaveContext();

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
                var repository = new GeneralRepository<ReposiveMessages>(context);


                var mRepo = repository.GetFirst(x => x.MessageId == entity.PostId);
                mRepo.LikeNumber = entity.LikeNumber;
                mRepo.DisLikeNumber = entity.DisLikeNumber;
                repository.Update(mRepo);
                repository.SaveContext();

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
