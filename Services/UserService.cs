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
        private readonly IEncryptService _encrypt;
        public UserService(IRepository<ForumMembers> members, IRepository<ForumRoles> roles, IRepository<Titles> titles, IRepository<MemberTitle> memberTitle, IEncryptService encrypt)
        {
            _members = members;
            _roles = roles;
            _titles = titles;
            _memberTitle = memberTitle;
            _encrypt = encrypt;
        }

        /// <summary>
        /// Get UserId
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public string GetUserId(string userEmail)
        {
            return _members.GetAll().SingleOrDefault(x => x.Email == userEmail).UserId.ToString();
        }
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="dto"></param>
        public void Create(CreateMemberDto dto)
        {
            try
            {
                ForumMembers user = new ForumMembers()
                {
                    UserId = Guid.NewGuid(),
                    Password = _encrypt.ToMD5(dto.Password),
                    Email = dto.Email,
                    Name = dto.Name,
                    Gender = dto.Gender,
                    Age = dto.Age,
                    Phone = dto.Phone,
                    //Default Picture
                    ImgLink = "https://i.imgur.com/gZQyxZj.png",
                    //Set default role to "normal"
                    RoleId = _roles.GetFirst(x => x.RoleName == "一般使用者").RoleId,
                    //Set default points to 1K
                    Points = 1000,
                    //Set default title to "Novice"
                    TitleId = _titles.GetFirst(x => x.TitleName == "初心者").TitleId,
                    //RefreshToken(Use it when jwt token expired)
                    RefreshToken = Guid.NewGuid()
                };
                _members.Create(user);
                _members.SaveContext();

                //Add title "Novice" to MemberTitle when register
                MemberTitle usertitle = new MemberTitle()
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
        /// Edit user info
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userEmail"></param>
        public void Edit(EditMemberDTO dto, string userEmail)
        {
            try
            {
                ForumMembers editedContext = _members.GetFirst(x => x.Email == userEmail);
                editedContext.Name = dto.Name;
                editedContext.Password = _encrypt.ToMD5(dto.Password);
                editedContext.Age = dto.Age;
                editedContext.Phone = dto.Phone;
                editedContext.Gender = dto.Gender;
                editedContext.ImgLink = dto.ImgLink;
                //Edit TitleId base on input TitleName
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
        /// Edit password if forget
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ApiResult<EditPasswordDto> EditPasswordIfForgot(EditPasswordDto dto)
        {
            if (!_members.GetAll().Any(x => x.Email == dto.Email))
            {
                return new ApiResult<EditPasswordDto>($"{dto.Email} not exists!");
            }
            else
            {
                try
                {
                    ForumMembers member = _members.GetFirst(x => x.Email == dto.Email);
                    member.Password = _encrypt.ToMD5(dto.Password);
                    _members.Update(member);
                    _members.SaveContext();
                    return new ApiResult<EditPasswordDto>();
                }
                catch (Exception ex)
                {
                    return new ApiResult<EditPasswordDto>($"{ex}");
                }
            }
        }
        /// <summary>
        /// Get single member info
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public ReadMemberDTO GetSingleMember(string userEmail)
        {
            ForumMembers source = _members.GetAll().First(x => x.Email == userEmail);
            ReadMemberDTO result = new ReadMemberDTO
            {
                UserId = source.UserId.ToString(),
                Name = source.Name,
                Email = source.Email,
                Age = (int)source.Age,
                Phone = source.Phone,
                Gender = source.Gender,
                Points = (decimal)source.Points,
                ImgLink = source.ImgLink,
                Password = source.Password,
                TitleName = _titles.GetFirst(x => x.TitleId == source.TitleId).TitleName,
                RoleName = _roles.GetFirst(x => x.RoleId == source.RoleId).RoleName
            };
            return result;
        }
        /// <summary>
        /// Verify email and name when register
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ApiResult<CreateMemberDto> VerifyEmailAndNameWhenRegister(CreateMemberDto dto)
        {
            IQueryable<ForumMembers> sourcre = _members.GetAll().Where(x => x.Email == dto.Email || x.Name == dto.Name);

            if (sourcre.Any(x => x.Email == dto.Email))
            {
                if (sourcre.Any(x => x.Name == dto.Name))
                {
                    return new ApiResult<CreateMemberDto>($"{dto.Email} and {dto.Name} already exist，choose another one!");
                }
                return new ApiResult<CreateMemberDto>($"{dto.Email} already exists，choose another one!");
            }
            if (sourcre.Any(x => x.Name == dto.Name))
            {
                return new ApiResult<CreateMemberDto>($"{dto.Name} already exists，choose another one!");
            }
            else
            {
                return new ApiResult<CreateMemberDto>();
            }
        }
        /// <summary>
        /// Verify user name when edit(exclude own data)
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public ApiResult<EditMemberDTO> VerifyEmailAndNameWhenEdit(EditMemberDTO dto, string userEmail)
        {
            //Exclude own data
            IQueryable<ForumMembers> source = _members.GetAll().Where(x => x.Email != userEmail && x.Name == dto.Name);

            if (source.Any(x => x.Name == dto.Name))
            {
                return new ApiResult<EditMemberDTO>($"{dto.Name} already exists，choose another one!");
            }
            else
            {
                return new ApiResult<EditMemberDTO>();
            }
        }
    }
}
