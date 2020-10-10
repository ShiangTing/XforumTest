using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class CreateMemberDto
    {

        public Guid? UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }
    }
}
