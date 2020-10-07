using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.Interface;
using XforumTest.Repository;
using XforumTest.DTO;
using Newtonsoft.Json;
using System.Text.Json;

namespace XforumTest.Services
{
    public class ForumService : IForumService
    {
        static MyDBContext db = new MyDBContext();
        GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
        GeneralRepository<ForumMembers> forummembers = new GeneralRepository<ForumMembers>(db);

        public void Create(ForumCreate create)
        {
            try
            {
                var createforum = new Forums
                {
                    ForumId = Guid.NewGuid(),
                    CreatedDate = create.CreatedDate,
                    Img = create.Img,
                    ModeratorId = create.ModeratorId,
                    Description = create.Description,
                    ForumName = create.ForumName
                };
                forums.Create(createforum);
                forums.SaveContext();
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Delete()
        {
            //使用軟刪除 修改狀態
            throw new NotImplementedException();
        }

        public IQueryable GetSingle(string forumid)
        {

            var forum = from f in forums.GetAll()
                        where f.ForumId.ToString() == forumid
                        select new
                        {
                            title = f.ForumName,
                            date = f.CreatedDate,
                            name = f.ModeratorId,
                            content = f.Description
                        };
            return forum;
        }

        public void Edit(ForumCreate json)
        {
            //var json = JsonConvert.DeserializeObject<ForumCreate>(data);
            var oldforum = forums.GetAll().FirstOrDefault(f => f.ModeratorId == json.ModeratorId);
            oldforum.Img = json.Img;
            oldforum.ModeratorId = json.ModeratorId;
            oldforum.Description = json.Description;
            oldforum.ForumName = json.ForumName;
                           
            forums.Update(oldforum);
            forums.SaveContext();
        }
        
        public void Find()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ForumGetAllDTO> GetAll()
        {
            //var getall = from f in forums.GetAll()
            //             join fm in forummembers.GetAll()
            //             on f.ModeratorId equals fm.UserId
            //             select new ForumGetAllDTO
            //             {
            //                 UserName = fm.Name,
            //                 Age = fm.Age
            //             };
            var getall = from fm in forums.GetAll()
                         select new ForumGetAllDTO
                         {
                             ForumName = fm.ForumName,
                             ForumId = fm.ForumId
                         };

            //forums.GetAll();
            return getall;
        }
    }
}
