﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class TitleDto
    {
        public Guid? TitleId { get; set; }
        public string TitleName { get; set; }
        public decimal Price { get; set; }
    }
    public class TitleCreateDto
    { 
        public string TitleName { get; set; }
        public decimal Price { get; set; }
    }
    //public class 
}
