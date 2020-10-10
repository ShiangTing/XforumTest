using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class MemberDto
    {

        public Guid? UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid? RoleId { get; set; }
        public string Gender { get; set; }
        public decimal Points { get; set; }
        public int? Age { get; set; }
        public byte? EmailConformed { get; set; }
        public Guid? TitleId { get; set; }
    }
}
