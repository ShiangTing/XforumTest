using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;

using XforumTest.Services;

namespace XforumTest.Interface
{
    public interface IForumService
    {
        void Create(ForumCreateDto model);
        IEnumerable<ForumGetAllDTO> GetAll();
        ForumGetSingleDto GetSingle(string id);
        void ChangeForumState(ChangeForumState model);
        void Edit(ForumEditDto model);
        IEnumerable<GetUnauditedForum> GetManagerForumPage(AuditForumPageOfManagerAndMod pageOfManager);
        IEnumerable<GetUnauditedForum> GetModForumPage(string UserEmail, AuditForumPageOfManagerAndMod pageOfMod);
        string GetImgLink(string id);
    }
}
