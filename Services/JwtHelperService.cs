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

        /// <summary>
        /// Generate JwtToken when login
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="expireMinutes"></param>
        /// <returns></returns>
        public string GenerateToken(string userEmail, int expireMinutes = 10)
        {
            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var signKey = _configuration.GetValue<string>("JwtSettings:SignKey");
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

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
        /// <summary>
        /// Use RefreshToken in Database to generate without relogin
        /// </summary>
        /// <param name="refreshtoken"></param>
        /// <returns></returns>
        public AuthenticateResponse RefreshToken(string refreshtoken)
        {
            try
            {
                if (_members.GetAll().Any(x => x.RefreshToken.ToString() == refreshtoken))
                {
                    var getUserData = _members.GetFirst(x => x.RefreshToken.ToString() == refreshtoken);
                    var transfertoUser = new User
                    {
                        Email = getUserData.Email,
                        Password = getUserData.Password,
                        //RefreshToken = getUserData.RefreshToken.ToString()
                    };

                    //Update RefreshToken
                    var newGUID = Guid.NewGuid();
                    //Store new refresh token to Database
                    getUserData.RefreshToken = newGUID;
                    //Show new refresh token in Response
                    transfertoUser.RefreshToken = newGUID.ToString();
                    _members.SaveContext();

                    return new AuthenticateResponse(transfertoUser, GenerateToken(transfertoUser.Email, 10));
                }
                else
                {
                    return new AuthenticateResponse($"查無{refreshtoken}!");
                }
            }
            catch(Exception ex)
            {
                return new AuthenticateResponse(ex.ToString());
            }
        }
        /// <summary>
        /// Verify user login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public AuthenticateResponse ValidateUser(AuthenticateRequest login)
        {
            try
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
                    //先搜尋帳密符合的會員，再轉成User
                    var check = members.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
                    var validuser = new User
                    {
                        Email = check.Email,
                        Password = check.Password,
                        RefreshToken = check.RefreshToken.ToString()
                        //ForumRoles = _forumRole.GetAll().FirstOrDefault(x => x.RoleId == check.RoleId).RoleName
                    };
                    //先把members格式轉成User,再搜尋符合的會員
                    //var user = members.Select(x => new User
                    //{
                    //    RoleId = x.RoleId.GetValueOrDefault().ToString(),
                    //    Email = x.Email,
                    //    Password = x.Password,
                    //    ForumRoles = _forumRole.GetAll().FirstOrDefault(y => y.RoleId == x.RoleId).RoleName,
                    //}).SingleOrDefault(x => x.Email == login.Email && x.Password == login.Password);

                    //if (user == null) return null;
                    return new AuthenticateResponse(validuser, GenerateToken(validuser.Email, 10));
                }
            }
            catch (Exception ex)
            {
                return new AuthenticateResponse(ex.ToString());
            }
        }
        /// <summary>
        /// Get all member data(for testing)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ForumMembers> GetMembers()
        {
            return _members.GetAll();
        }
        /// <summary>
        /// Get all Posts(for testing)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Posts> GetPosts()
        {
            return _posts.GetAll();
        }
    }
}
