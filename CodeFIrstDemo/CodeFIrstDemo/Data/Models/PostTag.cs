﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFIrstDemo.Data.Models
{
    public class PostTag
    {
        public PostTag()
        {

        }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
