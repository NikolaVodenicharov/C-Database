using Forum.Data;
using Forum.Models;
using Forum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services
{
    public class PostService : AbstractService, IPostService
    {
        private ICategoryService categoryService;

        public PostService(ForumDbContext context, ICategoryService categoryService) 
            : base(context)
        {
            this.categoryService = categoryService;
        }

        public Post Create(string title, string content, string categoryName, int userId)
        {
            Category category = this.categoryService.EnsureCreate(categoryName);
            Post post = new Post(title, content, category.Id, userId);
            this.GetContext.Posts.Add(post);
            this.GetContext.SaveChanges();

            return post;
        }
    }
}
