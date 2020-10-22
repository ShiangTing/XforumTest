using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Entities;
using XforumTest.Models;
using XforumTest.Services;

namespace XforumTest.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="dto"></param>
        void Create(CreateMemberDto dto);

        /// <summary>
        /// Get single member info
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        MemberDto GetSingleMember(string userEmail);

        /// <summary>
        /// Edit user info
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userEmail"></param>
        void Edit(EditMemberDTO dto, string userEmail);

        /// <summary>
        /// Verify user Email and name
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<CreateMemberDto> VerifyEmailAndNameWhenRegister(CreateMemberDto dto);

        /// <summary>
        /// Verify user name when edit(exclude own data)
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        ApiResult<MemberDto> VerifyEmailAndNameWhenEdit(EditMemberDTO dto, string userEmail);

        /// <summary>
        /// Get UserId
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        string GetUserId(string userEmail);
    }
}
