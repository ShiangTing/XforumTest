using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Repository;


namespace XforumTest.Services
{
    //public class LikeService : ILikeService<ReposiveMessages>,ILikeService<ForumGetAllDTO>
    //{

    //    private MyDBContext context;


    //    public LikeService()
    //    {
    //        context = new MyDBContext();
    //    }
    //    //public void GetAllDisLike()
    //    //{
 
    //    //}

    //    //public void GetAllLike(Guid postId)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public void GetAllMsgDisLike(Guid msgId)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public void GetAllMsgLike(Guid msgId)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
  
    //    public async void  PostDisLike(Guid postId)
    //    {
    //        try
    //        {

    //            var repository = new GeneralRepository<ReposiveMessages>(context);

    //            var mDto = new RMessageDTO();

    //            var mRepo = repository.GetFirst(x => x.PostId == postId);
    //            mDto.DisLikeNumber = mDto.DisLikeNumber + 1;
    //            repository.Update(mRepo);
    //            //repository.
    //            await context.SaveChangesAsync();
    //        }
    //        catch(Exception ex)
    //        {

    //        }
           
    //    }

    //    public async void PostLike(Guid postId)
    //    {
    //        try
    //        {
    //            var repository = new GeneralRepository<ReposiveMessages>(context);
    //            var mDto = new RMessageDTO();

    //            var mRepo = repository.GetFirst(x => x.PostId == postId);
    //            mDto.DisLikeNumber = mDto.DisLikeNumber + 1;
    //            repository.Update(mRepo);
    //            //repository.
    //            await context.SaveChangesAsync();
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //    }

    //    public void PostLike<T>(Guid id) where T : ReposiveMessages
    //    {
           
    //    }
    //}
}
