using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItems>();
        }

        public Guid CartId { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<CartItems> CartItems { get; set; }
    }
}
