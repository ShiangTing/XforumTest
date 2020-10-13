using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Entities;

namespace XforumTest.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public string RoleId { get; set; }
        public string ForumRoles { get; set; }
        public AuthenticateResponse(User user, string token)
        {
            //FirstName = user.FirstName;
            //LastName = user.LastName;
            Id = user.Id;
            UserEmail = user.Email;
            RoleId = user.RoleId;
            ForumRoles = user.ForumRoles;
            Token = token;
        }
    }
}
