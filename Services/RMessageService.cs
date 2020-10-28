using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;


namespace XforumTest.Services
{
    public class RMessageService : IMessageService
    {
        private readonly IRepository<ReposiveMessages> _messages;
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<Posts> _post;

        public RMessageService(IRepository<ReposiveMessages> messages, IRepository<Posts> posts, IRepository<ForumMembers> members)
        {
            _messages = messages;
            _members = members;
            _post = posts;
        }

        public void Create(RMessageDTO dto)
        {
            //if post!=null
            try
            {
                //var post = _post.GetFirst(x => x.PostId == dto.PostId);
                //if (post != null) { }
                ReposiveMessages messages = new ReposiveMessages()
                {
                    MessageId = Guid.NewGuid(),
                    UserId = dto.UserId,
                    Context = dto.Context,
                    LikeNumber = 0,
                    DisLikeNumber = 0,
                    CreatedDate = DateTime.Now,
                    PostId = dto.PostId
                };
                _messages.Create(messages);
                _messages.SaveContext();
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void Delete(Base dto)
        {
            try
            {
                var deletMessage = _messages.GetFirst(x => x.MessageId == dto.Id);
                if (deletMessage != null)
                {
                    _messages.Delete(deletMessage);
                    _messages.SaveContext();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task<List<RMessageDTO>> GetAllbyPostId(Guid postId)
        {
            var mRepo = (from m in _messages.GetAll()
                         where m.PostId == postId
                         join p in _members.GetAll()
                         on m.UserId equals p.UserId
                         select new RMessageDTO
                         {
                             MessageId = m.MessageId,
                             LikeNumber = m.LikeNumber,
                             DisLikeNumber = m.DisLikeNumber,
                             PostId = m.PostId,
                             CreatedDate = m.CreatedDate,
                             Context = m.Context,
                             UserId = (Guid)m.UserId,
                             UserName = p.Name,
                             UserImg = p.ImgLink
                         }).OrderBy(item => item.CreatedDate);
            return await mRepo.ToListAsync();
        }
        public void GetSingle()
        {
            throw new NotImplementedException();
        }
    }
}
