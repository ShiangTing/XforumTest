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
    public class LikeService : ILikeService<MessageLikeDto>, ILikeService<PostLikeDto>
    {
        private readonly IRepository<ReposiveMessages> _messages;
        private readonly IRepository<Posts> _posts;
        private readonly IRepository<LikeAndDislikeHistory> _history;
        public LikeService(IRepository<ReposiveMessages> messages, IRepository<Posts> posts, IRepository<LikeAndDislikeHistory> history)
        {
            _posts = posts;
            _messages = messages;
            _history = history;
        }



        private void Click(MessageLikeDto entity)
        {
            var mRepo = _messages.GetFirst(x => x.MessageId == entity.MessageId);
    
            var msg = _history.GetFirst(x => x.MessageId == entity.MessageId && x.UserId == entity.UserId);
            //當user已經按讚或按倒讚
            if (msg != null && mRepo != null)
            {
                //處理總按讚數
                mRepo.LikeNumber = mRepo.LikeNumber + entity.LikeNumber;
                mRepo.DisLikeNumber = mRepo.DisLikeNumber + entity.DisLikeNumber;
                _messages.Update(mRepo);
                _messages.SaveContext();

                msg.IsDisLike = entity.IsDisLike;
                msg.IsLike = entity.IsLike;

                _history.Update(msg);
                _history.SaveContext();

                //if (msg.IsLike == true && entity.IsDisLike == true)
                //{
                //    msg.IsLike = entity.IsLike;
                //    msg.IsDisLike = entity.IsDisLike;
                //    mRepo.LikeNumber = mRepo.LikeNumber--;
                //    mRepo.DisLikeNumber = mRepo.DisLikeNumber++;
                //}
                //else if (msg.IsDisLike == true && entity.IsLike == true)
                //{
                //    msg.IsLike = entity.IsLike;
                //    msg.IsDisLike = entity.IsDisLike;
                //    mRepo.LikeNumber = mRepo.LikeNumber++;
                //    mRepo.DisLikeNumber = mRepo.DisLikeNumber--;
                //}
                //else if ((entity.IsDisLike == false && entity.IsLike == false))
                //{
                //    if (msg.IsDisLike == true)
                //    {
                //        msg.IsLike = entity.IsLike;
                //        msg.IsDisLike = entity.IsDisLike;
                //        mRepo.DisLikeNumber--;
                //    }
                //    else
                //    {
                //        msg.IsLike = entity.IsLike;
                //        msg.IsDisLike = entity.IsDisLike;
                //        mRepo.LikeNumber--;
                //    }
                //}
                //// _history.Delete(msg);

                //_messages.Update(mRepo);
                //_messages.SaveContext();

                //_history.Update(msg);
                //_history.SaveContext();

            }
            else if (mRepo != null)
            {

                LikeAndDislikeHistory history = new LikeAndDislikeHistory()
                {
                    Id = Guid.NewGuid(),
                    MessageId = entity.MessageId,
                    UserId = entity.UserId,
                    IsDisLike = entity.IsDisLike,
                    IsLike = entity.IsLike
                };
                _history.Create(history);
                _history.SaveContext();

                //if (entity.IsDisLike)
                //{
                //    mRepo.DisLikeNumber++;
                //}
                //else
                //{
                //    mRepo.LikeNumber++;
                //}
                mRepo.LikeNumber = mRepo.LikeNumber + entity.LikeNumber;
                mRepo.DisLikeNumber = mRepo.DisLikeNumber + entity.DisLikeNumber;

                _messages.Update(mRepo);
                _messages.SaveContext();
            }
            else
            {
                //HttpStatusCode()
            }

        }
        /// <summary>
        /// PostLikeandDisLike 傳入留言Id和按讚數
        /// </summary>
        /// <param name="entity"></param>
        /// 
        public void PostLikeAndDisLike(MessageLikeDto entity)
        {
            //var dbContext = new MyDBContext();
           // using (var transaction = dbContext.Database.BeginTransaction())
           // {
                try
                {
                    var mRepo = _messages.GetFirst(x => x.MessageId == entity.MessageId);
                   // var msgUser = _history.GetFirst(x => x.UserId == entity.UserId);
                    var msg = _history.GetFirst(x => x.MessageId == entity.MessageId && x.UserId == entity.UserId);

                    if (msg != null && mRepo != null)
                    {
                        //將user按讚狀態變更
                        mRepo.LikeNumber = mRepo.LikeNumber + entity.LikeNumber;
                        mRepo.DisLikeNumber = mRepo.DisLikeNumber + entity.DisLikeNumber;
                        _messages.Update(mRepo);
                        _messages.SaveContext();

                        //處理總按讚數
                        msg.IsDisLike = entity.IsDisLike;
                        msg.IsLike = entity.IsLike;

                        _history.Update(msg);
                        _history.SaveContext();

                         // transaction.Commit();

                    }
                    else if (mRepo != null)
                    {

                        LikeAndDislikeHistory history = new LikeAndDislikeHistory()
                        {
                            Id = Guid.NewGuid(),
                            MessageId = entity.MessageId,
                            UserId = entity.UserId,
                            IsDisLike = entity.IsDisLike,
                            IsLike = entity.IsLike
                        };
                        _history.Create(history);
                        _history.SaveContext();

                        mRepo.LikeNumber = mRepo.LikeNumber + entity.LikeNumber;
                        mRepo.DisLikeNumber = mRepo.DisLikeNumber + entity.DisLikeNumber;

                        _messages.Update(mRepo);
                        _messages.SaveContext();
                       // transaction.Commit();
                    }
                    else
                    {
                        //HttpStatusCode()
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    //transaction.Rollback();
                }
            //}
        }

        /// <summary>
        /// PostLikeandDisLike 傳入Po文Id和按讚數
        /// </summary>
        /// <param name="entity"></param>
        public void PostLikeAndDisLike(PostLikeDto entity)
        {
          //  var dbContext = new MyDBContext();
           // using (var transaction = dbContext.Database.BeginTransaction())
            //{

            
                try
                {
                    var mRepo = _posts.GetFirst(x => x.PostId == entity.PostId);
                    var post = _history.GetFirst(x => x.PostId==entity.PostId && x.UserId == entity.UserId);
                    if (post != null && mRepo != null)
                    {
                        //將user按讚狀態變更
                        mRepo.LikeNumber = mRepo.LikeNumber + entity.LikeNumber;
                        mRepo.DisLikeNumber = mRepo.DisLikeNumber + entity.DisLikeNumber;
                        _posts.Update(mRepo);
                        _posts.SaveContext();

                        //處理總按讚數
                        post.IsDisLike = entity.IsDisLike;
                        post.IsLike = entity.IsLike;

                        _history.Update(post);
                        _history.SaveContext();
                        //transaction.Commit();


                    }
                    else if (mRepo != null)
                    {

                        LikeAndDislikeHistory history = new LikeAndDislikeHistory()
                        {
                            Id = Guid.NewGuid(),
                            PostId = entity.PostId,
                            UserId = entity.UserId,
                            IsDisLike = entity.IsDisLike,
                            IsLike = entity.IsLike
                        };
                        _history.Create(history);
                        _history.SaveContext();

                        mRepo.LikeNumber = mRepo.LikeNumber + entity.LikeNumber;
                        mRepo.DisLikeNumber = mRepo.DisLikeNumber + entity.DisLikeNumber;

                        _posts.Update(mRepo);
                        _posts.SaveContext();
                         //transaction.Commit();
                    }
                    else
                    {
                        //HttpStatusCode()
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    //transaction.Rollback();
                }
           // }
        }


       /// <summary>
       /// return 該 user 對該篇文章的或留言的按讚情況
       /// </summary>
       /// <param name="dto"></param>
        public UserLikeHistoryDto GetUserLikeHistory(BaseLikeEntity dto)
        {
            var userHistory = _history.GetFirst(x => x.UserId == dto.UserId && (x.PostId==dto.Id || x.MessageId== dto.Id));
            if (userHistory != null)
            {
                return new UserLikeHistoryDto()
                {
                    UserId = (Guid)userHistory.UserId,
                    IsDisLike = userHistory.IsDisLike,
                    IsLike = userHistory.IsLike,
                    //message or post id
                   // PostId = userHistory.PostId,
                   // MessageId = userHistory.MessageId
                };
            }

            else
            {
                return new UserLikeHistoryDto()
                {

                };
            }
            //return Dtu{dto.history = userhistory} 
        }
    }
}
