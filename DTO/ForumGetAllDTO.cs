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
        public string ImgLink { get; set; }
    }

    public class ForumCreateDto
    {
        public string ForumName { get; set; }
        public string RouteName { get; set; }
        public string Description { get; set; }
        public string ModeratorId { get; set; }
        //public string Contnet { get; set; }
        public string ImgLink { get; set; }
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

    public class ForumGetSingleDto
    {
        public string ForumName { get; set; }
        public string Description { get; set; }
        public Guid? ModeratorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? State { get; set; }

    }
    public class GetSingle
    { 
        public string Id { get; set; }
    }
    public class GetUnauditedForum
    { 
        public string ForumName { get; set; }
        public string RouteName { get; set; }
        public string Description { get; set; }
        public string ModeratorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ImgLink { get; set; }

    }

    public class ChangeForumState
    { 
        public string RouteName { get; set; }
        public bool State { get; set; }
    }
}
