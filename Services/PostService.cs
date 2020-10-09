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

namespace XforumTest.Services
{
    public class PostService : IPostService
    {
        private MyDBContext db;
        //private static MyDBContext db = new MyDBContext();
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
                var po = new Posts
                {
                    PostId = Guid.NewGuid(),
                    ForumId =new Guid(model.ForumId),
                    UserId =new Guid(model.UserId),
                    Title = model.Title,
                    Description = model.Description,
                    CreatedDate = model.CreatedDate,
                    Img = null,
                    State = true
                };
                posts.Create(po);
                posts.SaveContext();

            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        ///取得單一PO文
        /// </summary>
        public IQueryable GetSingle(string id)
        {
            GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
            GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
            var single = from p in posts.GetAll()
                         join u in users.GetAll()
                         on p.UserId equals u.UserId
                         where p.PostId.ToString() == id
                         select new PostListDto
                         {
                            ForumId = p.ForumId,
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
            edit.ForumId = json.ForumId;
            edit.State = json.State;
            posts.Update(edit);
            posts.SaveContext();
        }

        /// <summary>
        /// 取得所有的發文
        /// </summary>
        public List<PostListDto> GetAll()
        {
            GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
            GeneralRepository<ForumMembers> users = new GeneralRepository<ForumMembers>(db);
            var pList = from p in posts.GetAll()
                        join u in users.GetAll()
                        on p.UserId equals u.UserId
                        select new PostListDto
                        {
                            ForumId = p.ForumId,
                            PostId = p.PostId,
                            Title = p.Title,
                            Description = p.Description,
                            CreatedDate = p.CreatedDate,
                            UserId = p.UserId,
                            UserName = u.Name,
                            State = p.State
                        };
            return  pList.ToList();



        }

        IQueryable<PostListDto> IPostService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
