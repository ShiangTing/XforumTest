using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class Category
    {
        public Category()
        {
            History = new HashSet<History>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal? Points { get; set; }

        public virtual ICollection<History> History { get; set; }
    }
}
