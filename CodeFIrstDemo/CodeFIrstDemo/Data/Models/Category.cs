﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFIrstDemo.Data.Models
{
    public class Category
    {
        public Category()
        {

        }

        public Category(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
