using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XforumTest.DataTable;
using XforumTest.Entities;
using XforumTest.Models;

namespace XforumTest.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<ForumMembers> GetAll();
        ForumMembers GetById(Guid id);
    }
}
