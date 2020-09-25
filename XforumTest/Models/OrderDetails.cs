﻿using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int? ImageId { get; set; }
        public int Quantity { get; set; }
        public Guid? Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}