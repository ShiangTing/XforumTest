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
        private  MyDBContext db ;
        //GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
        //GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);

        public PostService()
        {
            db = new MyDBContext();
        }

        public void Create(PostDto model)
        {
      
            try
            {
                GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
                GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
                // 時區要再調整，先測試用
                //var localtime = TimeZoneInfo.Local;  自動抓取電腦時區並作調整，但型別不同不能傳入資料庫
                var po = new Posts
                {
                    PostId = Guid.NewGuid(),
                    ForumId =new Guid(model.ForumId),
                    UserId =new Guid(model.UserId),
                    Title = model.Title,
                    Description = model.Description,
                    CreatedDate = DateTime.UtcNow,
                    Img = null,
                    State = true
                };
                posts.Create(po);
                posts.SaveContext();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        /// <summary>
        ///取得單一PO文
        /// </summary>
        public IQueryable GetSingle(string postid)
        {
            GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
            GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
            GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
            var single = from p in posts.GetAll()
                         join u in users.GetAll()
                         on p.UserId equals u.UserId
                         join f in forums.GetAll()
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
                            State = p.State
                         };

            return single;
        }

        public void Delete(string id)
        {
            GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
            GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
            var delete = posts.GetAll().FirstOrDefault(p => p.UserId.ToString() == id);
            delete.State = false;
            posts.Update(delete);
            posts.SaveContext();
            
        }

        public void Edit(PostListDto json)
        {
            GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
            GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
            var edit = posts.GetAll().FirstOrDefault(p => p.PostId == json.PostId);
            edit.Title = json.Title;
            edit.Description = json.Description;
            edit.State = json.State;
            posts.Update(edit);
            posts.SaveContext();
        }

        /// <summary>
        /// 取得所有的發文
        /// </summary>
        public IQueryable<PostListDto> GetAll()
        {
            GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
            GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
            GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
            var pList = from p in posts.GetAll()
                        join u in users.GetAll()
                        on p.UserId equals u.UserId
                        join f in forums.GetAll()
                        on p.ForumId equals f.ForumId
                        select new PostListDto
                        {
                            ForumName = f.ForumName,
                            PostId = p.PostId,
                            Title = p.Title,
                            Description = p.Description,
                            CreatedDate = p.CreatedDate,
                            UserId = p.UserId,
                            UserName = u.Name,
                            State = p.State
                        };
            return  pList;
        }

        public IQueryable<PostListDto> GetForum(string forumid)
        {
            GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
            GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
            GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
            var singleforum = from p in posts.GetAll()
                         join u in users.GetAll()
                         on p.UserId equals u.UserId
                         join f in forums.GetAll()
                         on p.ForumId equals f.ForumId
                         where p.ForumId.ToString() == forumid
                         select new PostListDto
                         {
                             ForumName = f.ForumName,
                             PostId = p.PostId,
                             Title = p.Title,
                             Description = p.Description,
                             CreatedDate = p.CreatedDate,
                             UserId = p.UserId,
                             UserName = u.Name,
                             State = p.State
                         };

            return singleforum;
        }
    }
}
