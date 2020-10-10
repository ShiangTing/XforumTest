using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Entities;
using XforumTest.Models;

namespace XforumTest.Interface
{
    public interface IUserService
    {
        //AuthenticateResponse Authenticate(AuthenticateRequest model);
        //IEnumerable<ForumMembers> GetAll();
        //ForumMembers GetById(Guid id);

        //註冊
        void Create(CreateMemberDto dto);


        //拿到單一會員資料
        MemberDto GetSingleMember(Guid id);


        //編輯會員資料
        void Edit(MemberDto dto);
        
        //選擇稱號
    }
}
