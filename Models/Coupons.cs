using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Coupons
    {
        public Guid Id { get; set; }
        public string CouponName { get; set; }
        public decimal? Discount { get; set; }
        public string CouponCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
