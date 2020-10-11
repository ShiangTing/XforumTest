using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XforumTest.Entities
{
    public class User
    {
        public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public string TitleId { get; set; }
        public string TitleName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
