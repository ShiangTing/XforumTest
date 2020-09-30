using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class ProductTags
    {
        public Guid ProductId { get; set; }
        public Guid Id { get; set; }
        public Guid? TagId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
