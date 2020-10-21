using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Entities;
using XforumTest.Helpers;
using XforumTest.Interface;


namespace XforumTest.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<ForumRoles> _roles;
        private readonly IRepository<Titles> _titles;
        private readonly IRepository<MemberTitle> _memberTitle;
        public UserService(IRepository<ForumMembers> members, IRepository<ForumRoles> roles, IRepository<Titles> titles, IRepository<MemberTitle> memberTitle)
        {
            _members = members;
            _roles = roles;
            _titles = titles;
            _memberTitle = memberTitle;
        }

        public IEnumerable<MemberDto> GetAll()
        {
            return _members.GetAll()
                .Select(x => new MemberDto()
                {
                    //UserId = x.UserId,
                    Password = x.Password,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                    RoleName = _roles.GetFirst(y => y.RoleId == x.RoleId).RoleName,
                    Gender = x.Gender,
                    Points = (decimal)x.Points,
                    Age = (int)x.Age,
                    EmailConformed = x.EmailConformed,
                    TitleId = x.TitleId
                });
        }
        /// <summary>
        /// 獲得UserId
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public string GetUserId(string userEmail)
        {
            return _members.GetAll().SingleOrDefault(x => x.Email == userEmail).UserId.ToString();
        }
        /// <summary>
        /// 新增會員資料
        /// </summary>
        /// <param name="dto"></param>
        public void Create(CreateMemberDto dto)
        {
            try
            {
                var user = new ForumMembers()
                {
                    UserId = Guid.NewGuid(),
                    Password = dto.Password,
                    Email = dto.Email,
                    Name = dto.Name,
                    Gender = dto.Gender,
                    Age = dto.Age,
                    Phone = dto.Phone,
                    //預設為一般使用者
                    RoleId = _roles.GetFirst(x => x.RoleName == "一般使用者").RoleId,
                    //預測點數為1000
                    Points = 1000,
                    //預設為單身一年
                    TitleId = _titles.GetFirst(x => x.TitleName == "初心者").TitleId,
                    //RefreshToken,當JwtToken失效後
                    RefreshToken = Guid.NewGuid()
                };
                _members.Create(user);
                _members.SaveContext();

                //加入初心者稱號至擁有的稱號
                var usertitle = new MemberTitle()
                {
                    UserId = user.UserId,
                    HasTitleId = user.TitleId
                };
                _memberTitle.Create(usertitle);
                _memberTitle.SaveContext();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 編輯會員資料
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userEmail"></param>
        public void Edit(MemberDto dto, string userEmail)
        {
            try
            {
                var editedContext = _members.GetFirst(x => x.Email == userEmail);
                editedContext.Name = dto.Name;
                editedContext.Email = dto.Email;
                editedContext.Password = dto.Password;
                editedContext.Age = dto.Age;
                editedContext.Phone = dto.Phone;
                editedContext.Gender = dto.Gender;
                //依據輸入的Role名稱去Role表搜RoleId並更換
                editedContext.RoleId = _roles.GetFirst(x => x.RoleName == dto.RoleName).RoleId;
                //依據輸入的Title名稱去Title表搜尋TitleId並更換
                editedContext.TitleId = _titles.GetFirst(x => x.TitleName == dto.TitleName).TitleId;

                _members.Update(editedContext);
                _members.SaveContext();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 取得單一會員資料
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public MemberDto GetSingleMember(string userEmail)
        {
            var source = _members.GetAll().First(x => x.Email == userEmail);
            var result = new MemberDto
            {
                UserId = source.UserId,
                Name = source.Name,
                Email = source.Email,
                Password = source.Password,
                Age = (int)source.Age,
                Phone = source.Phone,
                Gender = source.Gender,
                Points = (decimal)source.Points,
                RoleId = source.RoleId,
                RoleName = _roles.GetFirst(x => x.RoleId == source.RoleId).RoleName,
                TitleId = source.TitleId,
                TitleName = _titles.GetFirst(x => x.TitleId == source.TitleId).TitleName
            };
            return result;
        }
        /// <summary>
        /// 註冊驗證Email,暱稱
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ApiResult<CreateMemberDto> VerifyEmailAndNameWhenRegister(string email, string name)
        {
            var sourcre = _members.GetAll().Where(x => x.Email == email || x.Name == name);

            if (sourcre.Any(x => x.Email == email))
            {
                if (sourcre.Any(x => x.Name == name))
                {
                    return new ApiResult<CreateMemberDto>($"Email:{email} 及暱稱:{name} 皆已被使用,請更換!"); //兩者皆已存在
                }
                return new ApiResult<CreateMemberDto>($"Email:{email} 已存在，請更換!"); //此Email已存在，請更換Email
            }
            if (sourcre.Any(x => x.Name == name))
            {
                return new ApiResult<CreateMemberDto>($"暱稱: {name}已存在，請更換!"); //此暱稱已存在，請更換暱稱
            }
            else
            {
                return new ApiResult<CreateMemberDto>();
            }
        }
        /// <summary>
        ///編輯會員資料驗證Email,暱稱(排除自己的資料)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public ApiResult<MemberDto> VerifyEmailAndNameWhenEdit(string email, string name, string userEmail)
        {

            //排除自己資料
            var source = _members.GetAll().Where(x => x.Email != userEmail && (x.Email == email || x.Name == name));

            if (source.Any(x => x.Email == email))
            {
                if (source.Any(x => x.Name == name))
                {
                    return new ApiResult<MemberDto>($"Email:{email} 及暱稱:{name} 皆已被使用,請更換!"); //兩者皆已存在
                }
                return new ApiResult<MemberDto>($"Email:{email} 已存在，請更換!"); //此Email已存在，請更換Email
            }
            if (source.Any(x => x.Name == name))
            {
                return new ApiResult<MemberDto>($"暱稱: {name}已存在，請更換!"); //此暱稱已存在，請更換暱稱
            }
            else
            {
                return new ApiResult<MemberDto>();
            }
        }
    }
}
