﻿using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Posts
    {
        public Posts()
        {
            LikeAndDislikeHistory = new HashSet<LikeAndDislikeHistory>();
            ReposiveMessages = new HashSet<ReposiveMessages>();
        }

        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public Guid? ForumId { get; set; }
        public int? LikeNumber { get; set; }
        public int? DisLikeNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UserId { get; set; }
        public bool? State { get; set; }

        public virtual Forums Forum { get; set; }
        public virtual ForumMembers User { get; set; }
        public virtual ICollection<LikeAndDislikeHistory> LikeAndDislikeHistory { get; set; }
        public virtual ICollection<ReposiveMessages> ReposiveMessages { get; set; }
    }
}
