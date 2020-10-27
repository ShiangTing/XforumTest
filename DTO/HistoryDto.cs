using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class HistoryDto
    {
        public string HistoryId { get; set; }
        public string UserId { get; set; }
        public string Time { get; set; }
        public int CategoryId { get; set; }
        public decimal PointsChange { get; set; }
    }

    public class RecordDto
    {


    }
}
