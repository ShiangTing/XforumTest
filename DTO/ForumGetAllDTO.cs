using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{


    public class BaseFourmDto
    {
        public string ForumName { get; set; }
        public Guid? ForumId { get; set; }
        public string RouteName { get; set; }
        public string Description { get; set; }
    }
    public class ForumGetAllDTO: BaseFourmDto
    {
 
    }

    public class ForumCreate: BaseFourmDto
    {

        public DateTime? CreatedDate { get; set; }
        public string Img { get; set; }
        public Guid? ModeratorId { get; set; }
        new public string Description { get; set; }
        new public string ForumName { get; set; }
        public bool? State { get; set; }
    }
}
