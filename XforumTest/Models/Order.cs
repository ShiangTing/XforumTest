using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public Guid OrderId { get; set; }
        public string EcpayOrderNumber { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PurchaserName { get; set; }
        public string PurchaserEmail { get; set; }
        public string PurchaserPhone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Road { get; set; }
        public string Payment { get; set; }
        public DateTime? PayDate { get; set; }
        public bool Paid { get; set; }
        public bool Build { get; set; }
        public bool Remember { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
