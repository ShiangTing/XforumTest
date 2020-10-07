using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.Interface;
using XforumTest.DTO;
using XforumTest.DataTable;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class PostService : IPostService
    {
        private static MyDBContext db = new MyDBContext();
        GeneralRepository<Posts> posts = new GeneralRepository<Posts>(db);
        public void Create(PostDto model)
        {
            //try
            //{
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

            //}
            //catch(Exception ex)
            //{

            //}

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetSingle()
        {
            throw new NotImplementedException();
        }
    }
}
