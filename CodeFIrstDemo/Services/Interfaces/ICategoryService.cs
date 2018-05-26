using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services.Interfaces
{
    public interface ICategoryService
    {
        Category ByName(string name);
        Category Create(string name);
        Category EnsureCreate(string name);
    }
}
