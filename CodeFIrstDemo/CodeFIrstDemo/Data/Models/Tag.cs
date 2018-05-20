using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFIrstDemo.Data.Models
{
    public class Tag
    {
        public Tag()
        {

        }

        public Tag(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
