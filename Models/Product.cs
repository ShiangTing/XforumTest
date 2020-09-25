using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItems>();
            OrderDetails = new HashSet<OrderDetails>();
            ProductTags = new HashSet<ProductTags>();
            WishList = new HashSet<WishList>();
        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int UnitInStock { get; set; }
        public decimal Price { get; set; }
        public string Isbn { get; set; }
        public string ProductImgId { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Intro { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Language { get; set; }

        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductTags> ProductTags { get; set; }
        public virtual ICollection<WishList> WishList { get; set; }
    }
}
