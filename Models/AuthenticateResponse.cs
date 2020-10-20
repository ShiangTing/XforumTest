using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.Entities;

namespace XforumTest.Models
{
    public class AuthenticateResponse
    {
        public bool Issuccessful { get; set; }
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
        //public string RoleId { get; set; }
        public string ForumRoles { get; set; }
        public string ErrorMsg { get; set; }
        public string RefreshToken { get; set; }
        public AuthenticateResponse(User user, string token)
        {
            //FirstName = user.FirstName;
            //LastName = user.LastName;
            //RoleId = user.RoleId;
            //Id = user.Id;
            Issuccessful = true;
            UserEmail = user.Email;
            ForumRoles = user.ForumRoles;
            ErrorMsg = "no error!";
            Token = token;
            RefreshToken = Guid.NewGuid().ToString().Replace("-", "");
        }
        public AuthenticateResponse(string error)
        {
            Issuccessful = false;
            ErrorMsg = $"{error}";
        }
    }
}
