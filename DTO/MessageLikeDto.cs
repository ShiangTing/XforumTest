﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class MessageLikeDto
    {


        public Guid? MessageId { get; set; }


        public int? LikeNumber { get; set; }
        public int? DisLikeNumber { get; set; }

        public bool IsLike { get; set; }
        public bool IsDisLike { get; set; }
        public Guid? UserId { get; set; }

    }
}
