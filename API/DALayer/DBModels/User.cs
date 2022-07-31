using System;
using System.Collections.Generic;

namespace API.DBModels
{
    public partial class User
    {
        public User()
        {
            ArticleComments = new HashSet<ArticleComment>();
            Articles = new HashSet<Article>();
            Roles = new HashSet<Role>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
