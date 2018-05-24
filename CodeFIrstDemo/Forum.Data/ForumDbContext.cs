using Forum.Data.ModelsConfigurations;
using Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext() { }
        public ForumDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);

            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new PostTagConfiguration());
            builder.ApplyConfiguration(new ReplyConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
