using System;
using System.Collections.Generic;
using System.Linq;
using XforumTest.DataTable;
using XforumTest.Interface;
using XforumTest.Repository;
using XforumTest.DTO;
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
        public void Create(ForumCreateDto create)
        {

            try
            {
                Forums createforum = new Forums
                {
                    ForumId = Guid.NewGuid(),
                    ForumName = create.ForumName,
                    RouteName = create.RouteName,
                    CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local),
                    ModeratorId = Guid.Parse(create.ModeratorId),
                    Description = create.Description,
                    Img = create.ImgLink,
                    State = false
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
        /// 取的單一看板資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ForumGetSingleDto GetSingle(string id)
        {
            ForumGetSingleDto forum = (from f in _Forums.GetAll().AsEnumerable()
                                       where f.ForumId == Guid.Parse(id)
                                       select new ForumGetSingleDto
                                       {
                                           ForumName = f.ForumName,
                                           Description = f.Description,
                                           ModeratorId = f.ModeratorId,
                                           CreatedDate = f.CreatedDate,
                                           State = f.State
                                       }).FirstOrDefault();
            return forum;
        }
        /// <summary>
        /// 編輯看板資料、回復軟刪除狀態
        /// </summary>
        /// <param name="json"></param>
        public void Edit(ForumCreateDto json)
        {
            //var json = JsonConvert.DeserializeObject<ForumCreate>(data);
            Forums oldforum = _Forums.GetAll().FirstOrDefault(f => f.RouteName == json.RouteName);
            oldforum.Img = json.ImgLink;
            oldforum.ForumName = json.ForumName;
            //oldforum.ModeratorId = json.ModeratorId;
            oldforum.Description = json.Description;
            oldforum.ForumName = json.ForumName;

            _Forums.Update(oldforum);
            _Forums.SaveContext();
        }
        /// <summary>
        /// 取得所有看板
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ForumGetAllDTO> GetAll()
        {
            IEnumerable<ForumGetAllDTO> getall = from fm in _Forums.GetAll2()
                                                 where fm.State == true
                                                 select new ForumGetAllDTO
                                                 {
                                                     ForumName = fm.ForumName,
                                                     ForumId = fm.ForumId,
                                                     RouteName = fm.RouteName,
                                                     Description = fm.Description,
                                                     ImgLink = fm.Img
                                                 };
            return getall;
        }
        /// <summary>
        /// 取得state = false的待創版審核之版面
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetUnauditedForum> GetUnauditedForum()
        {
            IEnumerable<GetUnauditedForum> Unaudited = (from f in _Forums.GetAll2()
                                                        where f.State == false
                                                        select new GetUnauditedForum()
                                                        {
                                                            ForumName = f.ForumName,
                                                            RouteName = f.RouteName,
                                                            Description = f.Description,
                                                            ModeratorName = _members.GetAll2().FirstOrDefault(x => x.UserId == f.ModeratorId).Name,
                                                            ImgLink = f.Img,
                                                            CreatedDate = f.CreatedDate,
                                                            RejectMsg = f.RejectMsg,
                                                            State = (bool)f.State
                                                        }).ToList();
            return Unaudited;
        }
        /// <summary>
        /// 使用軟刪除 修改State 為 false
        /// </summary>
        /// <param name="model"></param>
        public void ChangeForumState(ChangeForumState model)
        {
            Forums forum = _Forums.GetAll().FirstOrDefault(f => f.RouteName == model.RouteName);
            forum.State = model.State;
            forum.RejectMsg = model.RejectMsg;
            _Forums.Update(forum);
            _Forums.SaveContext();
        }

        public string GetImgLink(string id)
        {
            return _Forums.GetAll2().FirstOrDefault(x => x.RouteName == id).Img;
        }
    }
}
