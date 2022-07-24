using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class Comment
    {
        public Comment()
        {
            ArticleComments = new HashSet<ArticleComment>();
        }

        public Guid CommentId { get; set; }
        public string CommentContent { get; set; } = null!;
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public bool CommentIsDeleted { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid? ParentCommentId { get; set; }

        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    }
}
