using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFIrstDemo.Data.Models
{
    public class Reply
    {
        public Reply()
        {

        }

        public int Id { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string Content { get; set; }
    }
}
