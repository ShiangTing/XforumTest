using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XforumTest.Context;
using XforumTest.DataTable;
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
        MyDBContext _context;

        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appsettings)
        {
            _context = new MyDBContext();
            _members = new GeneralRepository<ForumMembers>(_context);
            _appSettings = appsettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _members.GetAll().Select(x => new User()
            {
                //Id = Convert.ToInt32(x.UserId),
                Username = x.Name,
                Password = x.Password,
            }).SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            if (user == null) { return null; }
            var token = generateToken(user);
            return new AuthenticateResponse(user, token);
        }
        private string generateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public IEnumerable<ForumMembers> GetAll()
        {
            return _members.GetAll();
        }
        public ForumMembers GetById(Guid id)
        {
            return _members.GetFirst(x => x.UserId == id);
        }
    }
}
