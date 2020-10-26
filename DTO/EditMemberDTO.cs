using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class EditMemberDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        public int Age { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string TitleName { get; set; }
        public string ImgLink { get; set; }
    }
}
