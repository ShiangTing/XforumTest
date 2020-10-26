using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.Interface;
using XforumTest.DTO;
using XforumTest.DataTable;
using XforumTest.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace XforumTest.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Posts> _posts;
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<Forums> _forums;
        private readonly IRepository<Titles> _titles;
        public PostService(IRepository<Posts> posts, IRepository<ForumMembers> members, IRepository<Forums> forums, IRepository<Titles> titles)
        {
            _posts = posts;
            _members = members;
            _forums = forums;
            _titles = titles;
        }
        public string Create(PostCreateDto model)
        {
                try
                {                    
                    Posts po = new Posts
                    {
                        PostId = Guid.NewGuid(),
                        ForumId = new Guid(model.ForumId),
                        UserId = new Guid(model.UserId),
                        Title = model.Title,
                        Description = model.Description,
                        CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,TimeZoneInfo.Local),
                        Img = null,
                        State = true
                    };
                    // 每PO一篇文 +50 points
                    ForumMembers user = _members.GetAll2().FirstOrDefault(x => x.UserId.ToString() == model.UserId);
                    user.Points = user.Points + 50;

                    _posts.Create(po);
                    _posts.SaveContext();
                    
                    _members.Update(user);
                    _members.SaveContext();
                    return "Po文成功，積分增加50點";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

        }

        /// <summary>
        ///取得單一PO文
        /// </summary>
        public PostListDto GetSingle(string id)
        {
            PostListDto single = (from p in _posts.GetAll2()
                         join u in _members.GetAll2()
                         on p.UserId equals u.UserId
                         join f in _forums.GetAll2()
                         on p.ForumId equals f.ForumId
                         where p.PostId.ToString() == id
                         select new PostListDto
                         {
                             ForumName = f.ForumName,
                             PostId = p.PostId,
                             Title = p.Title,
                             Description = p.Description,
                             CreatedDate = p.CreatedDate,
                             UserId = p.UserId,
                             UserName = u.Name,
                             Rank = _titles.GetAll2().FirstOrDefault(x => x.TitleId == u.TitleId).TitleName,
                             LikeNumber = p.LikeNumber,
                             DisLikeNumber = p.DisLikeNumber,
                             State = p.State
                         }).FirstOrDefault();

            return single;
        }

        public void Delete(string id)
        {
            Posts delete = _posts.GetAll().FirstOrDefault(p => p.PostId.ToString() == id);
            delete.State = false;
            _posts.Update(delete);
            _posts.SaveContext();

        }

        public void Edit(PostListDto json)
        {
            Posts edit = _posts.GetAll().FirstOrDefault(p => p.PostId == json.PostId);
            edit.Title = json.Title;
            edit.Description = json.Description;
            edit.State = json.State;
            _posts.Update(edit);
            _posts.SaveContext();
        }

        /// <summary>
        /// 取得所有的發文
        /// </summary>
        public List<PostListDto> GetAll()
        {
            List<PostListDto> pList = (from p in _posts.GetAll2()
                                            join u in _members.GetAll2()
                                            on p.UserId equals u.UserId
                                            join f in _forums.GetAll2()
                                            on p.ForumId equals f.ForumId
                                            where p.State == true
                                            orderby p.CreatedDate
                                            select new PostListDto
                                            {
                                                ForumName = f.ForumName,
                                                PostId = p.PostId,
                                                Title = p.Title,
                                                Description = p.Description,
                                                CreatedDate = p.CreatedDate,
                                                UserId = p.UserId,
                                                UserName = u.Name,
                                                Rank = _titles.GetAll2().FirstOrDefault(x => x.TitleId == u.TitleId).TitleName,
                                                LikeNumber = p.LikeNumber,
                                                DisLikeNumber = p.DisLikeNumber,
                                                State = p.State
                                            }).ToList();
            return pList;
        }

        public List<PostListDto> GetForum(string id)
        {
             List<PostListDto> singleforum = (from p in _posts.GetAll2()
                                                  join u in _members.GetAll2()
                                                  on p.UserId equals u.UserId
                                                  join f in _forums.GetAll2()
                                                  on p.ForumId equals f.ForumId
                                                  where f.RouteName == id
                                                  orderby p.CreatedDate
                                                  select new PostListDto
                                                  {
                                                      ForumName = f.ForumName,
                                                      PostId = p.PostId,
                                                      Title = p.Title,
                                                      Description = p.Description,
                                                      CreatedDate = p.CreatedDate,
                                                      UserId = p.UserId,
                                                      UserName = u.Name,
                                                      Rank = _titles.GetAll2().FirstOrDefault(x => x.TitleId == u.TitleId).TitleName,
                                                      LikeNumber = p.LikeNumber,
                                                      DisLikeNumber = p.DisLikeNumber,
                                                      State = p.State
                                                  }).ToList();

            return singleforum;
        }
    }
}
