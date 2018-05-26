using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Reply
    {
        public Reply()
        {

        }
        private Reply(string content)
        {
            this.Content = content;
        }
        public Reply(User author, Post post, string content)
            : this(content)
        {
            this.Author = author;
            this.Post = post;
        }

        public int Id { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string Content { get; set; }
    }
}
