using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class Tag
    {
        public Tag()
        {
            Articles = new HashSet<Article>();
        }

        public Guid TagId { get; set; }
        public string TagName { get; set; } = null!;

        public virtual ICollection<Article> Articles { get; set; }
    }
}
