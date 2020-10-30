using System;
using System.Collections.Generic;

namespace XforumTest.DataTable
{
    public partial class ChatDetails
    {
        public Guid Id { get; set; }
        public string RoomId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
