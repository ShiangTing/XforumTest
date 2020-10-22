using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Services;

namespace XforumTest.Interface
{
    public interface IUserService
    {
        //註冊
        void Create(CreateMemberDto dto);
        //拿到單一會員資料
        MemberDto GetSingleMember(string userEmail);

        //編輯會員資料
        void Edit(MemberDto dto, string userEmail);

        //註冊驗證Email, 暱稱
        ApiResult<CreateMemberDto> VerifyEmailAndNameWhenRegister(string email, string name);
        //編輯會員資料驗證Email, 暱稱(排除自己的資料)
        ApiResult<MemberDto> VerifyEmailAndNameWhenEdit(string email, string name, string userEmail);
        //獲得登入者UserId
        string GetUserId(string userEmail);
    }
}
