using System;
using System.Collections.Generic;

namespace XforumTest.Models
{
    public partial class ForumMember
    {
        public ForumMember()
        {
            Forum = new HashSet<Forum>();
            Posts = new HashSet<Posts>();
            Thread = new HashSet<Thread>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? RoleId { get; set; }
        public string Gender { get; set; }
        public string Passward { get; set; }
        public string Points { get; set; }
        public string Age { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Forum> Forum { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Thread> Thread { get; set; }
    }
}
