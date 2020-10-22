using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.Models;

namespace XforumTest.Interface
{
    public interface IJwtHelperService
    {
        /// <summary>
        /// Generate jwt token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="expireMinutes"></param>
        /// <returns></returns>
        string GenerateToken(string userName, int expireMinutes = 10);
        /// <summary>
        /// Use RefreshToken in Database to generate without relogin
        /// </summary>
        /// <param name="refreshtoken"></param>
        /// <returns></returns>
        AuthenticateResponse RefreshToken(string refreshtoken);
        /// <summary>
        /// Verify login email and password
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        AuthenticateResponse ValidateUser(AuthenticateRequest login);
        /// <summary>
        /// Get all member data
        /// </summary>
        /// <returns></returns>
        IEnumerable<ForumMembers> GetMembers();
        /// <summary>
        /// Get all Posts
        /// </summary>
        /// <returns></returns>
        IEnumerable<Posts> GetPosts();
    }
}
