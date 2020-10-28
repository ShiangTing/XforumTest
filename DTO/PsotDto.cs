using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class PostDto
    {
        public string ForumId { get; set; }
        public Guid? PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UserId { get; set; }
        public bool State { get; set; }
    }

    public class PostListDto
    {
        //    public Guid? ForumId { get; set; }
        public string ForumName { get; set; }
        public Guid? PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Rank { get; set; }
        public string RankColor { get; set; }
        public int? LikeNumber { get; set; }
        public int? DisLikeNumber { get; set; }
        public bool? State { get; set; }
    }

    public class PostCreateDto
    {
        public string ForumId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
