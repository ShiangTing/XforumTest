using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Interface;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class RMessageService : IMessageService
    {

        private MyDBContext context ;


        public RMessageService()
        {
            context = new MyDBContext();
        }

        public void Create(RMessageDTO dto)
        {
            try
            {
                var repository = new GeneralRepository<ReposiveMessages>(context);
                var postRepo = new GeneralRepository<Posts>(context);
                //  if (postRepo.GetAll().FirstOrDefault(x => x.PostId == dto.PostId) != null)
                //  {
            

                ReposiveMessages messages = new ReposiveMessages()
                    {
                        MessageId = Guid.NewGuid(),
                        Context = dto.Context,
                        LikeNumber = dto.LikeNumber,
                        DisLikeNumber = dto.DisLikeNumber,
                        CreatedDate = DateTime.Now,
                        PostId = dto.PostId
                    };

                    repository.Create(messages);
                    repository.SaveContext();
               // }
             

            }

            catch(Exception ex)
            {

            }
             

        }

        public void Delete(Guid id)
        {
            try
            {

                var repository = new GeneralRepository<ReposiveMessages>(context);
                var deletMessage = repository.GetFirst(x => x.MessageId==id);
                if (deletMessage != null)
                {
                    repository.Delete(deletMessage);
                    repository.SaveContext();
                }
                else
                {

                }

            }

            catch
            {

            }
        }



        public async Task<List<RMessageDTO>> GetAllbyPostId(Guid postId)
        {
            var repository = new GeneralRepository<ReposiveMessages>(context);
            //var memberRepository = new GeneralRepository<ForumMembers>(context);
            //var mDto = new RMessageDTO();
            //if (repository.getall().getfirst(x=>x.messageId==postid)!=null)
            var mRepo = from m in repository.GetAll()
                        where m.MessageId == postId
                        select new RMessageDTO
                        {
                            MessageId = m.MessageId,
                            LikeNumber = m.LikeNumber,
                            DisLikeNumber = m.DisLikeNumber,
                            PostId = m.PostId,
                            CreatedDate = m.CreatedDate,
                            Context = m.Context,
                            UserId = (Guid)m.UserId
                        };


            return await mRepo.ToListAsync();
        }


        //public  async  Task<List<RMessageDTO>> GetAllPostbyId(Guid postId)
        //{
        //    var repository = new GeneralRepository<ReposiveMessages>(context);
        //    var memberRepository = new GeneralRepository<ForumMembers>(context);
        //    var mDto = new RMessageDTO();

        //    var mRepo = from m in repository.GetAll()
        //                //join u in memberRepository.GetAll()
        //                //on m.
        //                where m.MessageId == postId
        //                select new RMessageDTO
        //                {
        //                    MessageId = m.MessageId,
        //                    LikeNumber = m.LikeNumber,
        //                    DisLikeNumber = m.DisLikeNumber,
        //                    PostId = m.PostId,
        //                    CreatedDate = m.CreatedDate,
        //                    Context = m.Context,
        //                };


        //    return await mRepo.ToListAsync();
        //}

        public void GetSingle()
        {
            throw new NotImplementedException();
        }

    }
}
