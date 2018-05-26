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
        public CategoryService(ForumDbContext context) : base(context) {}

        public Category ByName(string name)
        {
            Category category = this.ByNameWithoutChecking(name);

            if (category == null)
            {
                throw new InvalidOperationException("Category does not exist.");
            }

            return category;
        }
        private Category ByNameWithoutChecking(string name)
        {
            Category category = this.GetContext.Categories.FirstOrDefault(c => c.Name == name);

            return category;
        }

        public Category Create(string name)
        {
            if (this.IsCategoryExist(name))
            {
                throw new InvalidOperationException("Category already exist.");
            }

            return this.CreateWithoutCheking(name);
        }
        public Category EnsureCreate(string name)
        {
            if (this.IsCategoryExist(name))
            {
                return this.ByNameWithoutChecking(name);
            }

            return this.CreateWithoutCheking(name);
        }
        private Category CreateWithoutCheking(string name)
        {
            Category category = new Category(name);
            this.GetContext.Categories.Add(category);
            this.GetContext.SaveChanges();

            return category;
        }
        private bool IsCategoryExist(string name)
        {
            if (this.ByNameWithoutChecking(name) == null)
            {
                return false;
            }

            return true;
        }
    }
}
