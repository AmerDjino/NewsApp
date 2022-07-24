using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class Priviledge
    {
        public Priviledge()
        {
            Roles = new HashSet<Role>();
        }

        public Guid PriviledgeId { get; set; }
        public string PriviledgeName { get; set; } = null!;
        public string? PriviledgeDescription { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
