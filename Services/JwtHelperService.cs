using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration _configuration;
        private readonly IRepository<ForumMembers> _members;
        private readonly IRepository<Posts> _posts;
        private readonly IRepository<ForumRoles> _forumRole;
        public JwtHelperService(IConfiguration configuration, IRepository<ForumMembers> members, IRepository<Posts> posts, IRepository<ForumRoles> ForumRoles)
        {
            _configuration = configuration;
            _members = members;
            _posts = posts;
            _forumRole = ForumRoles;
        }

        //產生jwtToken
        public string GenerateToken(string userEmail, int expireMinutes = 60)
        {
            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var signKey = _configuration.GetValue<string>("JwtSettings:SignKey");
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userEmail));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var RoleId = _members.GetAll().SingleOrDefault(x => x.Email == userEmail).RoleId.GetValueOrDefault().ToString();
            var RoleName = _forumRole.GetAll().SingleOrDefault(x => x.RoleId.ToString() == RoleId).RoleName;
            claims.Add(new Claim("roles", RoleName));

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

        //Verify user login
        public AuthenticateResponse ValidateUser(AuthenticateRequest login)
        {
            var members = _members.GetAll();
            if (!members.Any(x => x.Email == login.Email))
            {
                return new AuthenticateResponse($"查無此 {login.Email} Email!");
            }
            if (members.Any(x => x.Email == login.Email) && members.FirstOrDefault(x => x.Email == login.Email).Password != login.Password)
            {
                return new AuthenticateResponse($"密碼輸入錯誤!");
            }
            else
            {
                var user = members.Select(x => new User
                {
                    //RoleId = x.RoleId.GetValueOrDefault().ToString(),
                    Email = x.Email,
                    Password = x.Password,
                    ForumRoles = _forumRole.GetAll().FirstOrDefault(y => y.RoleId == x.RoleId).RoleName,
                }).SingleOrDefault(x => x.Email == login.Email && x.Password == login.Password);

                //if (user == null) return null;
                return new AuthenticateResponse(user, GenerateToken(user.Email, 60));
            }
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
