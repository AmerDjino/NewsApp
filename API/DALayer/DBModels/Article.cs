using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class Article
    {
        public Article()
        {
            ArticleComments = new HashSet<ArticleComment>();
            Pictures = new HashSet<Picture>();
            Tags = new HashSet<Tag>();
        }

        public Guid ArticleId { get; set; }
        public string ArticleTitle { get; set; } = null!;
        public string ArticleContent { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int ArticleRateing { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
        public bool IsEditing { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
