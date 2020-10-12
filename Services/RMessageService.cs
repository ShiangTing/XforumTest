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
using XforumTest.NewFolder;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class RMessageService : IMessageService
    {
        private readonly MyDBContext _context;
        private readonly IRepository<ReposiveMessages> _messages;
        private readonly IRepository<ForumMembers> _members;

        public RMessageService(MyDBContext context, IRepository<ReposiveMessages> messages, IRepository<Posts> posts, IRepository<ForumMembers> members)
        {
            _context = context;
            _messages = messages;
            _members = members;
        }

        public void Create(RMessageDTO dto)
        {
            try
            {
                ReposiveMessages messages = new ReposiveMessages()
                {
                    MessageId = Guid.NewGuid(),
                    Context = dto.Context,
                    LikeNumber = dto.LikeNumber,
                    DisLikeNumber = dto.DisLikeNumber,
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
        public void Delete(Guid id)
        {
            try
            {
                var deletMessage = _messages.GetFirst(x => x.MessageId == id);
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
            var mRepo = from m in _messages.GetAll()
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
                            UserName = p.Name
                        };
            return await mRepo.ToListAsync();
        }
        public void GetSingle()
        {
            throw new NotImplementedException();
        }
    }
}
