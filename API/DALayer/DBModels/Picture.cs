using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class Picture
    {
        public Picture()
        {
            Articles = new HashSet<Article>();
        }

        public Guid PictureId { get; set; }
        public string PictureUrl { get; set; } = null!;
        public string PictureDescription { get; set; } = null!;

        public virtual ICollection<Article> Articles { get; set; }
    }
}
