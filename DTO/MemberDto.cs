using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XforumTest.DTO
{
    public class MemberDto
    {

        public Guid? UserId { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public Guid? RoleId { get; set; }
        public string RoleName { get; set; }
        public string Gender { get; set; }
        public decimal Points { get; set; }
        public int? Age { get; set; }
        public byte? EmailConformed { get; set; }
        public Guid? TitleId { get; set; }
        public string TitleName { get; set; }

        public string ImgLink { get; set; }
    }
}
