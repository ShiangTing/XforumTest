using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class WishList
    {
        public long ListId { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Datetime { get; set; }

        public virtual Product Product { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
