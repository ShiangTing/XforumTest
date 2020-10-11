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
using XforumTest.Models;
using XforumTest.Repository;

namespace XforumTest.Services
{
    public class UserService : IUserService
    {
        GeneralRepository<ForumMembers> _members;
        private MyDBContext context;

        public UserService()
        {
           
            context = new MyDBContext();
            _members = new GeneralRepository<ForumMembers>(context);
        }

        public IEnumerable<MemberDto> GetAll()
        {

            return _members.GetAll()
                .Select(x=>new MemberDto() 
                {
                    UserId = x.UserId,
                    Password = x.Password,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                    RoleId = x.RoleId,
                    Gender = x.Gender,
                    Points = (decimal)x.Points,
                    Age = (int)x.Age,
                    EmailConformed = x.EmailConformed,
                    TitleId = x.TitleId


                });
        }
        public MemberDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Create(CreateMemberDto dto)
        {
            try {
            var user = new ForumMembers()
            {
                UserId = Guid.NewGuid(),
                Password = dto.Password,
                Email = dto.Email,
                Name = dto.Name,
                Gender = dto.Gender,
            };
            _members.Create(user);
            _members.SaveContext();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// 取得單一會員資料(目前還不拿稱號)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public MemberDto GetSingle(Guid id)
        {
           var titleRepo = new GeneralRepository<Titles>(context);
            var member = from m in _members.GetAll()
                         join t in titleRepo.GetAll()
                         on m.TitleId equals t.TitleId
                         select new MemberDto()
                         {
                             UserId = m.UserId,
                             Password = m.Password,
                             Email = m.Email,
                             Name = m.Name,
                             Phone = m.Phone,
                             RoleId = m.RoleId,
                             Gender = m.Gender,
                             Points = (decimal)m.Points,
                             Age = (int)m.Age,
                             EmailConformed = m.EmailConformed,
                             TitleId = null,

                         };

            return member.FirstOrDefault(x=>x.UserId==id);
        }

        public void Edit(MemberDto dto)
        {

            try
            {
                var user = new ForumMembers()
                {
                    UserId = (Guid)dto.UserId,
                    Password = dto.Password,
                    Email = dto.Email,
                    Name = dto.Name,
                    Phone = dto.Phone,
                    RoleId = dto.RoleId,
                    Gender = dto.Gender,
                    Points = (decimal)dto.Points,
                    Age = (int)dto.Age,
                    EmailConformed = dto.EmailConformed,
                    TitleId = dto.TitleId,
                };
                _members.Update(user);
                _members.SaveContext();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


        }
    }
}
