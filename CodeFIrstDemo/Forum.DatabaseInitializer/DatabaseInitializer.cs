using Forum.Data;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Forum.DatabaseInitializer
{
    public class DatabaseInitializer
    {
        public static void ResetDatabase(ForumDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            Seed(context);
        }

        public static void Seed(ForumDbContext context)
        {
            User[] users = CreateUsers();
            context.Users.AddRange(users);

            Category[] categories = CreateCategories();
            context.Categories.AddRange(categories);

            Post[] posts = CreatePosts(users, categories);
            context.Posts.AddRange(posts);

            context.SaveChanges();
        }
        private static Category[] CreateCategories()
        {
            return new Category[]
            {
                new Category("C#"),
                new Category("Java"),
                new Category("PHP"),
                new Category("JavaScript"),
            };
        }
        private static User[] CreateUsers()
        {
            return new User[]
            {
                new User("Robert", "12334"),
                new User("George", "12334"),
                new User("Richard", "12334"),
                new User("John", "12334"),
            };
        }
        private static Post[] CreatePosts(User[] users, Category[] categories)
        {
            return new Post[]
            {
                new Post("C# rulz", "Yeah!", categories[0], users[0]),
                new Post("Java rulz", "Bravo!", categories[1], users[1]),
                new Post("PHP rulz", "Super!", categories[2], users[2]),
                new Post("JavaScript rulz", "Cool!", categories[3], users[3]),
            };
        }

    }
}
