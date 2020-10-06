using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Product
    {
        public Product()
        {
            ProductTags = new HashSet<ProductTags>();
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

        public virtual ICollection<ProductTags> ProductTags { get; set; }
    }
}
