﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class RMessageDTO
    {

        public Guid MessageId { get; set; }
        public Guid? PostId { get; set; }
        public string Context { get; set; }
        public int? LikeNumber { get; set; }
        public int? DisLikeNumber { get; set; }

        public string UserName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Guid UserId { get; set; }

        public string UserImg { get; set; }
    }
}
