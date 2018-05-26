using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Post Create(string title, string content, string categoryName, int userId);
    }
}
