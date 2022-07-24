using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class ArticleComment
    {
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }

        public virtual Article Article { get; set; } = null!;
        public virtual Comment Comment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
