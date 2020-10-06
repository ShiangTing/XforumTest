using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class ProductImgs
    {
        public long ProductImgId { get; set; }
        public Guid ProductId { get; set; }
        public string ImgLink { get; set; }
    }
}
