using Microsoft.Extensions.Configuration;
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
using Microsoft.EntityFrameworkCore;

namespace XforumTest.Helpers
{
    public class JwtHelperService : IJwtHelperService
    {
        private readonly MyDBContext _db;
        private readonly IConfiguration _configuration;
        private DbSet<ForumMembers> _members;
        private DbSet<Posts> _posts;
        private DbSet<ForumRoles> _ForumRole;
        public JwtHelperService(IConfiguration configuration, MyDBContext db)
        {
            _configuration = configuration;
            _db = db;
            _members = _db.ForumMembers;
            _posts = _db.Posts;
            _ForumRole = _db.ForumRoles;
        }

        //產生jwtToken
        public string GenerateToken(string userEmail, int expireMinutes = 60)
        {
            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var signKey = _configuration.GetValue<string>("JwtSettings:SignKey");
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userEmail));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var RoleId = _members.SingleOrDefault(x => x.Email == userEmail).RoleId.GetValueOrDefault().ToString();
            var RoleName = _ForumRole.SingleOrDefault(x => x.RoleId.ToString() == RoleId).RoleName;
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
            var user = _members.Select(x => new User
            {
                Email = x.Email,
                Password = x.Password,
                RoleId = x.RoleId.GetValueOrDefault().ToString(),
                ForumRoles = _ForumRole.FirstOrDefault(y => y.RoleId == x.RoleId).RoleName
            }).SingleOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if (user == null) return null;
            return new AuthenticateResponse(user, GenerateToken(user.Email, 60));
        }

        public IEnumerable<ForumMembers> GetMembers()
        {
            return _members;
        }
        public IEnumerable<Posts> GetPosts()
        {
            return _posts;
        }
        public string GetUserId(string userEmail)
        {
            return _members.SingleOrDefault(x => x.Email == userEmail).UserId.ToString();
        }
    }
}
