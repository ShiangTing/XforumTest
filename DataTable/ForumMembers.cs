using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class ForumMembers
    {
        public ForumMembers()
        {
            Chats = new HashSet<Chats>();
            Forums = new HashSet<Forums>();
            History = new HashSet<History>();
            LikeAndDislikeHistory = new HashSet<LikeAndDislikeHistory>();
            MemberTitle = new HashSet<MemberTitle>();
            Posts = new HashSet<Posts>();
        }

        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid? RoleId { get; set; }
        public string Gender { get; set; }
        public decimal? Points { get; set; }
        public int? Age { get; set; }
        public byte? EmailConformed { get; set; }
        public Guid? TitleId { get; set; }
        public string ImgLink { get; set; }
        public Guid RefreshToken { get; set; }

        public virtual ForumRoles Role { get; set; }
        public virtual Titles Title { get; set; }
        public virtual ICollection<Chats> Chats { get; set; }
        public virtual ICollection<Forums> Forums { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<LikeAndDislikeHistory> LikeAndDislikeHistory { get; set; }
        public virtual ICollection<MemberTitle> MemberTitle { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
