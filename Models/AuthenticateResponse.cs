using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DTO;


namespace XforumTest.Models
{
    public class AuthenticateResponse
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string RoleId { get; set; }
        //public string ForumRoles { get; set; }
        public bool Issuccessful { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public string ErrorMsg { get; set; }
        public string RefreshToken { get; set; }
        public string ReleaseTime { get; set; }
        public string ExpireTime { get; set; }
        public AuthenticateResponse(JwtUser user, string token)
        {
            //FirstName = user.FirstName;
            //LastName = user.LastName;
            //RoleId = user.RoleId;
            //Id = user.Id;
            //ForumRoles = user.ForumRoles;
            //RefreshToken = Guid.NewGuid().ToString();
            Issuccessful = true;
            UserEmail = user.Email;
            ErrorMsg = "no error!";
            Token = token;
            RefreshToken = user.RefreshToken;
            ReleaseTime = Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            ExpireTime = Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 600).ToString();
        }
        public AuthenticateResponse(string error)
        {
            Issuccessful = false;
            ErrorMsg = $"{error}";
        }
    }
}
