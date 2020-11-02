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
        private readonly IRepository<Posts> _posts;
        private readonly IRepository<ReposiveMessages> _repoMsgs;

        public ForumService(IRepository<Forums> Forums, IRepository<ForumMembers> members, IRepository<Posts> posts, IRepository<ReposiveMessages> repoMsgs)
        {
            _Forums = Forums;
            _members = members;
            _posts = posts;
            _repoMsgs = repoMsgs;
        }
        /// <summary>
        /// 創版
        /// </summary>
        /// <param name="create"></param>
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
        /// 取得單一看板資料
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
        public void Edit(ForumEditDto json)
        {
            //var json = JsonConvert.DeserializeObject<ForumCreate>(data);
            //oldforum.Img = json.ImgLink;
            //oldforum.ModeratorId = json.ModeratorId;
            Forums oldforum = _Forums.GetAll().FirstOrDefault(f => f.RouteName == json.RouteName);
            oldforum.ForumName = json.ForumName;
            oldforum.Description = json.Description;
            oldforum.State = json.State;
            oldforum.RejectMsg = json.RejectMeg;

            _Forums.Update(oldforum);
            _Forums.SaveContext();
        }
        /// <summary>
        /// 刪除看板(版內的文章,留言內容一併刪除)
        /// </summary>
        /// <param name="deletedForum"></param>
        public void Delete(ForumDeleteDto deletedForum)
        {
            //Guid b = _repoMsgs.GetAll2().FirstOrDefault(x => x.PostId == _posts.GetAll2().FirstOrDefault(x => x.ForumId == deletedForum.ForumId).PostId).MessageId;

            IEnumerable<ReposiveMessages> repoMsgs = _repoMsgs.GetAll2().Where(x => x.PostId == _posts.GetAll2().FirstOrDefault(y => y.ForumId == deletedForum.ForumId).PostId);
            foreach (ReposiveMessages msgs in repoMsgs)
            {
                _repoMsgs.Delete(msgs);
            }
            _repoMsgs.SaveContext();

            IEnumerable<Posts> oldPosts = _posts.GetAll2().Where(x => x.ForumId == deletedForum.ForumId);
            foreach (Posts post in oldPosts)
            {
                _posts.Delete(post);
            }
            _posts.SaveContext();

            Forums oldForum = _Forums.GetFirst(x => x.ForumId == deletedForum.ForumId);
            _Forums.Delete(oldForum);
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
        /// 查詢管理者的待審、需重審、審核通過版面
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetUnauditedForum> GetManagerForumPage(AuditForumPageOfManagerAndMod pageOfManager)
        {
            IEnumerable<GetUnauditedForum> Unaudited = (from f in _Forums.GetAll2()
                                                        where f.State == pageOfManager.State && string.IsNullOrEmpty(f.RejectMsg) == string.IsNullOrEmpty(pageOfManager.RejectMsg)
                                                        orderby f.CreatedDate descending
                                                        select new GetUnauditedForum()
                                                        {
                                                            ForumId = f.ForumId,
                                                            ForumName = f.ForumName,
                                                            RouteName = f.RouteName,
                                                            Description = f.Description,
                                                            ModeratorName = _members.GetAll2().FirstOrDefault(x => x.UserId == f.ModeratorId).Name,
                                                            ImgLink = f.Img,
                                                            CreatedDate = f.CreatedDate.ToString(),
                                                            RejectMsg = f.RejectMsg,
                                                            State = (bool)f.State
                                                        });
            return Unaudited;
        }
        /// <summary>
        /// 根據版主Email,查詢版主創版之待審、需重審、審核通過的版面
        /// </summary>
        /// <param name="UserEmail"></param>
        /// <param name="pageOfMod"></param>
        /// <returns></returns>
        public IEnumerable<GetUnauditedForum> GetModForumPage(string UserEmail, AuditForumPageOfManagerAndMod pageOfMod)
        {
            Guid userId = _members.GetAll2().FirstOrDefault(x => x.Email == UserEmail).UserId;
            return _Forums.GetAll2().Where(x => x.ModeratorId == userId && x.State == pageOfMod.State && string.IsNullOrEmpty(x.RejectMsg) == string.IsNullOrEmpty(pageOfMod.RejectMsg)).OrderByDescending(x => x.CreatedDate).Select(x => new GetUnauditedForum
            {
                ForumId = x.ForumId,
                ForumName = x.ForumName,
                RouteName = x.RouteName,
                Description = x.Description,
                ModeratorName = _members.GetAll2().FirstOrDefault(y => y.UserId == x.ModeratorId).Name,
                ImgLink = x.Img,
                CreatedDate = x.CreatedDate.ToString(),
                RejectMsg = x.RejectMsg,
                State = (bool)x.State
            });
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
