﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class PostListDto
    {
        public Guid? ForumId { get; set; }
        public Guid? PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public bool? State { get; set; }
    }
}
