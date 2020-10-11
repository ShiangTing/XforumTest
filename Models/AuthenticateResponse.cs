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
        public string Username { get; set; }
        public string Token { get; set; }
        public string TitleId { get; set; }
        public string TitleName { get; set; }
        public AuthenticateResponse(User user, string token)
        {
            //FirstName = user.FirstName;
            //LastName = user.LastName;
            Id = user.Id;
            Username = user.Username;
            TitleId = user.TitleId;
            TitleName = user.TitleName;
            Token = token;
        }
    }
}
