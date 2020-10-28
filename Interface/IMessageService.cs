using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;

namespace XforumTest.Interface
{
    public interface IMessageService
    {
        void Create(RMessageDTO dto);

        Task<List<RMessageDTO>> GetAllbyPostId(Guid postId);

        void Delete(Base dto);

        void GetSingle();


        
    }
}
