﻿using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using XforumTest.Interface;
using XforumTest.Entities;
using XforumTest.Repository;
using XforumTest.DataTable;
using XforumTest.Context;
using XforumTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace XforumTest.Helpers
{
    public class JwtHelperService : IJwtHelperService
    {
        private readonly MyDBContext _db;
        private readonly IConfiguration _configuration;
        GeneralRepository<ForumMembers> _members;
        GeneralRepository<Posts> _posts;
        GeneralRepository<Titles> _titles;
        public JwtHelperService(IConfiguration configuration)
        {
            _configuration = configuration;
            _db = new MyDBContext();
            _members = new GeneralRepository<ForumMembers>(_db);
            _posts = new GeneralRepository<Posts>(_db);
            _titles = new GeneralRepository<Titles>(_db);
        }

        //產生jwtToken
        public string GenerateToken(string userName, int expireMinutes = 30)
        {
            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var signKey = _configuration.GetValue<string>("JwtSettings:SignKey");
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var TitleId = _members.GetAll().SingleOrDefault(x => x.Name == userName).TitleId.GetValueOrDefault().ToString();
            var TitleName = _titles.GetAll().SingleOrDefault(x => x.TitleId.ToString() == TitleId).TitleName;
            claims.Add(new Claim("roles", TitleName));

            var userClaimsIdentity = new ClaimsIdentity(claims);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Subject = userClaimsIdentity,
                Expires = DateTime.Now.AddMinutes(expireMinutes),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializeToken = tokenHandler.WriteToken(securityToken);
            return serializeToken;
        }

        //驗證會員登入
        public AuthenticateResponse ValidateUser(AuthenticateRequest login)
        {
            var user = _members.GetAll().Select(x => new User
            {
                Username = x.Name,
                Password = x.Password,
                TitleId = x.TitleId.GetValueOrDefault().ToString(),
                TitleName = _titles.GetAll().FirstOrDefault(y => y.TitleId == x.TitleId).TitleName
            }).SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null) return null;
            return new AuthenticateResponse(user, GenerateToken(user.Username, 30));
        }

        public IEnumerable<ForumMembers> GetMembers()
        {
            return _members.GetAll();
        }
        public IEnumerable<Posts> GetPosts()
        {
            return _posts.GetAll();
        }
    }
}
