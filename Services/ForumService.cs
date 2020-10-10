﻿using System;
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

namespace XforumTest.Services
{
    public class ForumService : IForumService
    {
        //static MyDBContext db = new MyDBContext();

        private MyDBContext db;

        public ForumService()
        {
            db = new MyDBContext();
        }
        public void Create(ForumCreate create)
        {
    
            try
            {
                GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
                GeneralRepository<ForumMembers> forummembers = new GeneralRepository<ForumMembers>(db);
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
                forums.Create(createforum);
                forums.SaveContext();
            }
            catch (Exception ex)
            {
                
            }
        }
        /// <summary>
        /// 使用軟刪除 修改State 為 false
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
            GeneralRepository<ForumMembers> forummembers = new GeneralRepository<ForumMembers>(db);
            var delete = forums.GetAll().FirstOrDefault(f => f.ForumId.ToString() == id);
            delete.State = false;
            forums.Update(delete);
            forums.SaveContext();
        }
        /// <summary>
        /// 取的單一看板資料
        /// </summary>
        /// <param name="forumid"></param>
        /// <returns></returns>
        public IQueryable GetSingle(string forumid)
        {
            GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
            GeneralRepository<ForumMembers> forummembers = new GeneralRepository<ForumMembers>(db);
            var forum = from f in forums.GetAll()
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
            GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
            GeneralRepository<ForumMembers> forummembers = new GeneralRepository<ForumMembers>(db);
            //var json = JsonConvert.DeserializeObject<ForumCreate>(data);
            var oldforum = forums.GetAll().FirstOrDefault(f => f.ModeratorId == json.ModeratorId);
            oldforum.Img = json.Img;
            oldforum.ModeratorId = json.ModeratorId;
            oldforum.Description = json.Description;
            oldforum.ForumName = json.ForumName;
            oldforum.State = json.State;
                           
            forums.Update(oldforum);
            forums.SaveContext();
        }    
        /// <summary>
        /// 取的所有看板
        /// </summary>
        /// <returns></returns>
        public IQueryable<ForumGetAllDTO> GetAll()
        {
            GeneralRepository<Forums> forums = new GeneralRepository<Forums>(db);
            GeneralRepository<ForumMembers> forummembers = new GeneralRepository<ForumMembers>(db);
            var getall = from fm in forums.GetAll()
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
