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
        public PostService(IRepository<Posts> posts, IRepository<ForumMembers> members, IRepository<Forums> forums)
        {
            _posts = posts;
            _members = members;
            _forums = forums;
        }
        public void Create(PostCreateDto model)
        {

                try
                {
                    // 時區要再調整，先測試用
                    //var localtime = TimeZoneInfo.Local;  自動抓取電腦時區並作調整，但型別不同不能傳入資料庫
                    var po = new Posts
                    {
                        PostId = Guid.NewGuid(),
                        ForumId = new Guid(model.ForumId),
                        UserId = new Guid(model.UserId),
                        Title = model.Title,
                        Description = model.Description,
                        CreatedDate = DateTime.UtcNow,
                        Img = null,
                        State = true
                    };
                    _posts.Create(po);
                    _posts.SaveContext();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

        }

        /// <summary>
        ///取得單一PO文
        /// </summary>
        public PostListDto GetSingle(string postid)
        {
            var single = from p in _posts.GetAll2()
                         join u in _members.GetAll2()
                         on p.UserId equals u.UserId
                         join f in _forums.GetAll2()
                         on p.ForumId equals f.ForumId
                         where p.PostId.ToString() == postid
                         select new PostListDto
                         {
                             ForumName = f.ForumName,
                             PostId = p.PostId,
                             Title = p.Title,
                             Description = p.Description,
                             CreatedDate = p.CreatedDate,
                             UserId = p.UserId,
                             UserName = u.Name,
                             LikeNumber = p.LikeNumber,
                             DisLikeNumber = p.DisLikeNumber,
                             State = p.State
                         };

            return single.FirstOrDefault();
        }

        public void Delete(string id)
        {
            var delete = _posts.GetAll().FirstOrDefault(p => p.UserId.ToString() == id);
            delete.State = false;
            _posts.Update(delete);
            _posts.SaveContext();

        }

        public void Edit(PostListDto json)
        {
            var edit = _posts.GetAll().FirstOrDefault(p => p.PostId == json.PostId);
            edit.Title = json.Title;
            edit.Description = json.Description;
            edit.State = json.State;
            _posts.Update(edit);
            _posts.SaveContext();
        }

        /// <summary>
        /// 取得所有的發文
        /// </summary>
        public IEnumerable<PostListDto> GetAll()
        {
            var pList = from p in _posts.GetAll2()
                        join u in _members.GetAll2()
                        on p.UserId equals u.UserId
                        join f in _forums.GetAll2()
                        on p.ForumId equals f.ForumId
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
                            LikeNumber = p.LikeNumber,
                            DisLikeNumber = p.DisLikeNumber,
                            State = p.State
                        };
            return pList;
        }

        public IEnumerable<PostListDto> GetForum(string routename)
        {
            var singleforum = from p in _posts.GetAll()
                              join u in _members.GetAll()
                              on p.UserId equals u.UserId
                              join f in _forums.GetAll()
                              on p.ForumId equals f.ForumId
                              where f.RouteName == routename
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
                                  LikeNumber = p.LikeNumber,
                                  DisLikeNumber = p.DisLikeNumber,
                                  State = p.State
                              };

            return singleforum.ToList();
        }
    }
}
