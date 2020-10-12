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
using Microsoft.EntityFrameworkCore;
using XforumTest.NewFolder;
using System.Diagnostics;

namespace XforumTest.Services
{
    public class ForumService : IForumService
    {
        private readonly IRepository<Forums> _Forums;
        private readonly IRepository<ForumMembers> _members;

        public ForumService(IRepository<Forums> Forums, IRepository<ForumMembers> members)
        {
            _Forums = Forums;
            _members = members;
        }
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
                    ForumName = create.ForumName,
                    State =true
                };
                _Forums.Create(createforum);
                _Forums.SaveContext();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 使用軟刪除 修改State 為 false
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            var delete = _Forums.GetAll().FirstOrDefault(f => f.ForumId.ToString() == id);
            delete.State = false;
            _Forums.Update(delete);
            _Forums.SaveContext();
        }
        /// <summary>
        /// 取的單一看板資料
        /// </summary>
        /// <param name="forumid"></param>
        /// <returns></returns>
        public IQueryable GetSingle(string forumid)
        {
            var forum = from f in _Forums.GetAll()
                        where f.ForumId == Guid.Parse(forumid)
                        select new
                        {
                            title = f.ForumName,
                            date = f.CreatedDate,
                            name = f.ModeratorId,
                            content = f.Description,
                            state = f.State
                        };
            return forum;
        }
        /// <summary>
        /// 編輯看板資料、回復軟刪除狀態
        /// </summary>
        /// <param name="json"></param>
        public void Edit(ForumCreate json)
        {
            //var json = JsonConvert.DeserializeObject<ForumCreate>(data);
            var oldforum = _Forums.GetAll().FirstOrDefault(f => f.ModeratorId == json.ModeratorId);
            oldforum.Img = json.Img;
            oldforum.ModeratorId = json.ModeratorId;
            oldforum.Description = json.Description;
            oldforum.ForumName = json.ForumName;
            oldforum.State = json.State;

            _Forums.Update(oldforum);
            _Forums.SaveContext();
        }    
        /// <summary>
        /// 取的所有看板
        /// </summary>
        /// <returns></returns>
        public IQueryable<ForumGetAllDTO> GetAll()
        {
            var getall = from fm in _Forums.GetAll()
                         where fm.State == true
                         select new ForumGetAllDTO
                         {
                             ForumName = fm.ForumName,
                             ForumId = fm.ForumId,
                             RouteName = fm.RouteName,
                             Description = fm.Description
                         };
            return  getall;
        }

        //IQueryable<ForumGetAllDTO> IForumService.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
