using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class CreateMemberDto
    {
        //[Required]
        //public Guid? UserId { get; set; }
        //  public Guid? RoleId { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        [MinLength(1)]
        public string Name { get; set; }

        // [Phone]
        public string Phone { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
        public string ImgLink { get; set; }
    }
}
