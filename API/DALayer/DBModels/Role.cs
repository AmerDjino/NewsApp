using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class Role
    {
        public Role()
        {
            Priviledges = new HashSet<Priviledge>();
            Users = new HashSet<User>();
        }

        public Guid RoleId { get; set; }
        public int RoleName { get; set; }
        public string? RoleDesription { get; set; }

        public virtual ICollection<Priviledge> Priviledges { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
