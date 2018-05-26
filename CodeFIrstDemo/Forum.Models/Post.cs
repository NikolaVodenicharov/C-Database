using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Post
    {
        private Post()
        {

        }
        private Post(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public Post(string title, string content, Category category, User author)
            : this(title, content)
        {
            this.Category = category;
            this.Author = author;
        }
        public Post(string title, string content, int categoryId, int authorId)
            : this(title, content)
        {
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();
        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
