﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XforumTest.DTO
{
    public class JwtUser
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string RoleId { get; set; }
        //public string ForumRoles { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
