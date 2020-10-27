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
     


        //public void Click(MessageLikeDto entity)
        //{
        //    var mRepo = _messages.GetFirst(x => x.MessageId == entity.MessageId);
        //    // var msgUser = _history.GetFirst(x => x.UserId == entity.UserId);
        //    var msg = _history.GetFirst(x => x.MessageId == entity.MessageId && x.UserId == entity.UserId);
        //    //當user已經按讚或按倒讚
        //    if (msg != null && mRepo!=null)
        //    {
        //        if (msg.IsLike == true && entity.IsDisLike == true)
        //        {
        //            msg.IsLike = entity.IsLike;
        //            msg.IsDisLke = entity.IsDisLike;
        //            mRepo.LikeNumber = mRepo.LikeNumber--;
        //            mRepo.DisLikeNumber = mRepo.DisLikeNumber++;
        //        }
        //        else if (msg.IsDisLike == true && entity.IsLike == true)
        //        {
        //            msg.IsLike = entity.IsLike;
        //            msg.IsDisLke = entity.IsDisLike;
        //            mRepo.LikeNumber = mRepo.LikeNumber++;
        //            mRepo.DisLikeNumber = mRepo.DisLikeNumber--;
        //        }
        //        else if ((entity.IsDisLike == false && entity.IsLike == false))
        //        {
        //            if (msg.Isdislike == true)
        //            {
        //                msg.IsLike = entity.IsLike;
        //                msg.IsDisLke = entity.IsDisLike;
        //                mRepo.DisLikeNumber--;
        //            }
        //            else
        //            {
        //                msg.IsLike = entity.IsLike;
        //                msg.IsDisLke = entity.IsDisLike;
        //                mRepo.LikeNumber--;
        //            }
        //        }
        //            // _history.Delete(msg);

        //         _messages.Update(mRepo);
        //        _messages.SaveContext();

        //        _history.Update(msg);
        //        _history.SaveContext();

        //    }
        //    else if (mRepo != null)
        //    {

        //        LikeAndDislikeHistory history = new LikeAndDislikeHistory()
        //        {
        //            Id = Guid.NewGuid(),
        //            MessageId = entity.MessageId,
        //            UserId = entity.UserId
        //            IsDisLke
        //            IsLike
        //        };
        //        _history.Create(history);
        //        _history.SaveContext();
                
        //        if (entity.IsDisLike)
        //        {
        //            mRepo.DisLikeNumber++;
        //        }
        //        else
        //        {
        //            mRepo.LikeNumber++;
        //        }
              

        //        _messages.Update(mRepo);
        //        _messages.SaveContext();
        //    }
        //    else
        //    {
        //        //HttpStatusCode()
        //    }

        //}
        /// <summary>
        /// PostLikeandDisLike 傳入留言Id和按讚數
        /// </summary>
        /// <param name="entity"></param>
        /// 
        public void PostLikeAndDisLike(MessageLikeDto entity)
        {
            
            //try
          //  {             
               
                var mRepo = _messages.GetFirst(x => x.MessageId == entity.MessageId);
               // var msgUser = _history.GetFirst(x => x.UserId == entity.UserId);
                var msg = _history.GetFirst(x => x.MessageId == entity.MessageId && x.UserId == entity.UserId);

                if (msg != null)
                {
                    _history.Delete(msg);
     
                    _history.SaveContext();
       
                }
                if (mRepo != null)
                {
               
                    LikeAndDislikeHistory history = new LikeAndDislikeHistory()
                    {
                        Id = Guid.NewGuid(),
                        MessageId = entity.MessageId,
                        UserId = entity.UserId
                    
                    };
                     _history.Create(history);
                     _history.SaveContext();
                     mRepo.LikeNumber = entity.LikeNumber;
                     mRepo.DisLikeNumber = entity.DisLikeNumber;

                     _messages.Update(mRepo);
                     _messages.SaveContext();
                }
                else
                {
                    //HttpStatusCode()
                }
                
          //  }         
          //  catch (Exception ex)
           // {
              //  Debug.WriteLine(ex.Message);
           // }         
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

                    LikeAndDislikeHistory history = new LikeAndDislikeHistory()
                    {
                        Id = Guid.NewGuid(),
                        PostId = entity.PostId,
                        UserId = entity.UserId

                    };
                    _history.Create(history);
                    _history.SaveContext();
                    
                    
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


        //private void CountLikeandDisLike()
        //{
        //    switch 
        //        case: 
        //}

        //    public enum Quadrant
        //{
        //    Unknown,
        //    Origin,
        //    One,
        //    Two,
        //    Three,
        //    Four,
        //    OnBorder
        //}
        //static Quadrant GetQuadrant(Point point) => point switch
        //{
        //    (0, 0) => Quadrant.Origin,
        //    var (x, y) when x > 0 && y > 0 => Quadrant.One,
        //    var (x, y) when x < 0 && y > 0 => Quadrant.Two,
        //    var (x, y) when x < 0 && y < 0 => Quadrant.Three,
        //    var (x, y) when x > 0 && y < 0 => Quadrant.Four,
        //    var (_, _) => Quadrant.OnBorder,
        //    _ => Quadrant.Unknown
        //};
    }
}
