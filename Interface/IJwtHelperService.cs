using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.Entities;
using XforumTest.Models;

namespace XforumTest.Interface
{
    public interface IJwtHelperService
    {
        string GenerateToken(string userName, int expireMinutes = 30);
        AuthenticateResponse ValidateUser(AuthenticateRequest login);
        IEnumerable<ForumMembers> GetMembers();
        IEnumerable<Posts> GetPosts();
    }
}
