using System;

namespace Forum.Data
{
    public class Connection
    {
        public static string ConnectionString => @"Server=.\SQLEXPRESS;Database=Forum;Integrated Security=true";
    }
}
