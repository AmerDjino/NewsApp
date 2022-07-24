using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDescription { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
