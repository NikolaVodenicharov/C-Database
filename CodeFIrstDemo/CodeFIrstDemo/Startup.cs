using CodeFIrstDemo.Data;
using CodeFIrstDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFIrstDemo
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var context = new ForumDbContext())
            {
                ResetDatabase(context);

                var users = context.Users.Select(u => u.Username).ToArray();

                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }

            Console.WriteLine();
        }

        private static void ResetDatabase(ForumDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            Seed(context);
            
        }
        private static void Seed(ForumDbContext context)
        {
            var users = new User[]
            {
                new User("Robert", "12334"),
                new User("George", "12334"),
                new User("Richard", "12334"),
                new User("John", "12334"),
            };
            context.Users.AddRange(users);

            var categories = new Category[]
            {
                new Category("C#"),
                new Category("Java"),
                new Category("PHP"),
                new Category("JavaScript"),
            };
            context.Categories.AddRange(categories);

            var posts = new Post[]
            {
                new Post("C# rulz", "Yeah!", categories[0], users[0]),
                new Post("Java rulz", "Bravo!", categories[1], users[1]),
                new Post("PHP rulz", "Super!", categories[2], users[2]),
                new Post("JavaScript rulz", "Cool!", categories[3], users[3]),
            };
            context.Posts.AddRange(posts);


            context.SaveChanges();
        }
    }
}
