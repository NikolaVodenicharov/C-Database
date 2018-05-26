using Forum.Data;
using Forum.Models;
using Forum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Services
{
    public class CategoryService : AbstractService, ICategoryService
    {
        public CategoryService(ForumDbContext context) 
            : base(context)
        {
        }

        public Category ById(int id)
        {
            Category category = this.GetContext.Categories.Find(id);

            return category;
        }

        public Category ByName(string name)
        {
            Category category = this.GetContext.Categories.FirstOrDefault(c => c.Name == name);

            return category;
        }

        public Category Create(string name)
        {
            Category category = new Category(name);
            this.GetContext.Categories.Add(category);
            this.GetContext.SaveChanges();

            return category;
        }
    }
}
