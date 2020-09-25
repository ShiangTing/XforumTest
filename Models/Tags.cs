using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class Tags
    {
        public Tags()
        {
            ProductTags = new HashSet<ProductTags>();
        }

        public string TagName { get; set; }
        public Guid TagId { get; set; }

        public virtual ICollection<ProductTags> ProductTags { get; set; }
    }
}
