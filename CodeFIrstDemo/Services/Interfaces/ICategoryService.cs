using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services.Interfaces
{
    public interface ICategoryService
    {
        Category ById(int id);
        Category ByName(string name);
        Category Create(string name);
    }
}
